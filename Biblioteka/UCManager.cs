using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCManager : UserControl
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private int currentPage = 1;
        private int pageSize    = 20;
        private int totalPages  = 1;

        public int? CurrentUserId { get; set; }

        public UCManager()
        {
            InitializeComponent();
            dtp_data_od.MaxDate = DateTime.Today;
            KonfigurujDGV();
            WczytajAudit();
        }

        private void KonfigurujDGV()
        {
            dgv_audit.ReadOnly = true;
            dgv_audit.AllowUserToAddRows = false;
            dgv_audit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_audit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_audit.MultiSelect = false;
            dgv_audit.RowHeadersVisible = false;
        }

        private void WczytajAudit()
        {
            string tytul       = txt_filter_tytul.Text.Trim();
            string autor       = txt_filter_autor.Text.Trim();
            string gatunek     = txt_filter_gatunek.Text.Trim();
            string wydawnictwo = txt_filter_wyd.Text.Trim();
            string osoba       = txt_filter_osoba.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    // Grupujemy egzemplarze w "partie" wg (KsiazkaID, rejestrator, sekunda DataRejestracji).
                    // Wszystkie egzemplarze wstawione w tej samej operacji mają ten sam znacznik sekundy.
                    const string ctePartie = @"
                        WITH Partie AS (
                            SELECT
                                E.KsiazkaID,
                                E.ZarejestrowanePrzezID,
                                CONVERT(VARCHAR(19), E.DataRejestracji, 120)  AS CzasPartii,
                                MIN(E.DataRejestracji)                        AS DataRejestracji,
                                MIN(E.ID)                                     AS IDRejestracji,
                                COUNT(*)                                      AS LiczbaSztuk
                            FROM Egzemplarze E
                            GROUP BY E.KsiazkaID, E.ZarejestrowanePrzezID,
                                     CONVERT(VARCHAR(19), E.DataRejestracji, 120)
                        )";

                    const string filtr = @"
                        FROM Partie P
                        JOIN KatalogKsiazek K ON K.ID = P.KsiazkaID
                        JOIN Uzytkownicy   U ON U.ID = P.ZarejestrowanePrzezID
                        LEFT JOIN Gatunki     G ON G.ID = K.GatunekID
                        LEFT JOIN Wydawnictwa W ON W.ID = K.WydawnictwoID
                        WHERE (@Tytul       = '' OR K.Tytul  LIKE @TytulLike)
                          AND (@Gatunek     = '' OR G.Nazwa  LIKE @GatunekLike)
                          AND (@Wydawnictwo = '' OR W.Nazwa  LIKE @WydawnictwoLike)
                          AND (@Osoba       = '' OR (U.Imie + ' ' + U.Nazwisko) LIKE @OsobaLike
                                                 OR U.Login LIKE @OsobaLike)
                          AND (@Autor       = '' OR EXISTS (
                                SELECT 1 FROM KsiazkaKatalog_Autorzy KA
                                JOIN Autorzy A ON KA.AutorID = A.ID
                                WHERE KA.KsiazkaID = K.ID
                                  AND (A.Imie + ' ' + A.Nazwisko) LIKE @AutorLike))
                          AND (@DataOd IS NULL OR P.DataRejestracji >= @DataOd)
                          AND (@DataDo IS NULL OR P.DataRejestracji <= @DataDo)";

                    int totalRecords;
                    using (SqlCommand cmd = new SqlCommand(ctePartie + "\nSELECT COUNT(*) " + filtr, conn))
                    {
                        DodajParametry(cmd, tytul, autor, gatunek, wydawnictwo, osoba);
                        totalRecords = (int)cmd.ExecuteScalar();
                    }

                    totalPages = Math.Max(1, (int)Math.Ceiling((double)totalRecords / pageSize));
                    if (currentPage > totalPages) currentPage = totalPages;
                    lbl_page_info.Text = $"Strona: {currentPage} / {totalPages}";

                    if (totalRecords == 0)
                    {
                        MessageBox.Show(
                            "Brak rejestracji spełniających podane kryteria",
                            "Brak wyników",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        if (dgv_audit.DataSource is DataTable dtEmpty)
                            dtEmpty.Clear();
                        AktualizujStronowanie();
                        return;
                    }

                    string sqlData = ctePartie + @"
                        SELECT
                            P.IDRejestracji                                                              AS [ID Rejestracji],
                            CONVERT(NVARCHAR(19), P.DataRejestracji, 120)                               AS [Data rejestracji],
                            U.Imie + ' ' + U.Nazwisko                                                   AS [Osoba rejestrująca],
                            K.Tytul                                                                      AS [Tytuł],
                            ISNULL((SELECT STUFF((
                                SELECT ', ' + A2.Imie + ' ' + A2.Nazwisko
                                FROM KsiazkaKatalog_Autorzy KA2
                                JOIN Autorzy A2 ON KA2.AutorID = A2.ID
                                WHERE KA2.KsiazkaID = K.ID
                                ORDER BY A2.Nazwisko
                                FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,2,'')), '')          AS [Autorzy],
                            ISNULL(G.Nazwa, '')                                                          AS [Gatunek],
                            ISNULL(W.Nazwa, '')                                                          AS [Wydawnictwo],
                            P.LiczbaSztuk                                                                AS [Liczba dodanych sztuk],
                            CASE
                                WHEN P.CzasPartii = (
                                    SELECT TOP 1 CONVERT(VARCHAR(19), E2.DataRejestracji, 120)
                                    FROM Egzemplarze E2
                                    WHERE E2.KsiazkaID = K.ID
                                    ORDER BY E2.DataRejestracji ASC
                                )
                                THEN N'Nowa pozycja'
                                ELSE N'Dopisanie egzemplarzy'
                            END                                                                          AS [Typ akcji]
                        " + filtr + @"
                        ORDER BY P.DataRejestracji DESC
                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        DodajParametry(cmd, tytul, autor, gatunek, wydawnictwo, osoba);
                        cmd.Parameters.Add("@Offset",   SqlDbType.Int).Value = (currentPage - 1) * pageSize;
                        cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        dgv_audit.DataSource = dt;
                    }

                    AktualizujStronowanie();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DodajParametry(SqlCommand cmd, string tytul, string autor, string gatunek, string wydawnictwo, string osoba)
        {
            cmd.Parameters.Add("@Tytul",           SqlDbType.NVarChar, 255).Value = tytul;
            cmd.Parameters.Add("@TytulLike",        SqlDbType.NVarChar, 257).Value = "%" + tytul + "%";
            cmd.Parameters.Add("@Autor",            SqlDbType.NVarChar, 101).Value = autor;
            cmd.Parameters.Add("@AutorLike",        SqlDbType.NVarChar, 103).Value = "%" + autor + "%";
            cmd.Parameters.Add("@Gatunek",          SqlDbType.NVarChar, 100).Value = gatunek;
            cmd.Parameters.Add("@GatunekLike",      SqlDbType.NVarChar, 102).Value = "%" + gatunek + "%";
            cmd.Parameters.Add("@Wydawnictwo",      SqlDbType.NVarChar, 100).Value = wydawnictwo;
            cmd.Parameters.Add("@WydawnictwoLike",  SqlDbType.NVarChar, 102).Value = "%" + wydawnictwo + "%";
            cmd.Parameters.Add("@Osoba",            SqlDbType.NVarChar, 101).Value = osoba;
            cmd.Parameters.Add("@OsobaLike",        SqlDbType.NVarChar, 103).Value = "%" + osoba + "%";

            cmd.Parameters.Add("@DataOd", SqlDbType.DateTime).Value =
                chk_data_od.Checked ? (object)dtp_data_od.Value.Date : DBNull.Value;
            cmd.Parameters.Add("@DataDo", SqlDbType.DateTime).Value =
                chk_data_do.Checked ? (object)dtp_data_do.Value.Date.AddDays(1).AddSeconds(-1) : DBNull.Value;
        }

        private void AktualizujStronowanie()
        {
            btn_prev_page.Enabled = currentPage > 1;
            btn_next_page.Enabled = currentPage < totalPages;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            WczytajAudit();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_filter_tytul.Clear();
            txt_filter_autor.Clear();
            txt_filter_gatunek.Clear();
            txt_filter_wyd.Clear();
            txt_filter_osoba.Clear();
            chk_data_od.Checked = false;
            chk_data_do.Checked = false;
            currentPage = 1;
            WczytajAudit();
        }

        private void txt_filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search_Click(sender, e);
        }

        private void txt_filter_TextChanged(object sender, EventArgs e)
        {
            var tb = (System.Windows.Forms.TextBox)sender;
            if (tb.Text.Length == 0 || tb.Text.Length >= 3)
            {
                currentPage = 1;
                WczytajAudit();
            }
        }

        private void chk_data_od_CheckedChanged(object sender, EventArgs e)
        {
            dtp_data_od.Enabled = chk_data_od.Checked;
            if (!WalidujDaty()) return;
            currentPage = 1;
            WczytajAudit();
        }

        private void chk_data_do_CheckedChanged(object sender, EventArgs e)
        {
            dtp_data_do.Enabled = chk_data_do.Checked;
            if (!WalidujDaty()) return;
            currentPage = 1;
            WczytajAudit();
        }

        private void dtp_data_ValueChanged(object sender, EventArgs e)
        {
            if (!WalidujDaty()) return;
            currentPage = 1;
            WczytajAudit();
        }

        private bool WalidujDaty()
        {
            if (chk_data_od.Checked && dtp_data_od.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Data od nie może być późniejsza niż dziś.",
                    "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_data_od.Value = DateTime.Today;
                return false;
            }

            if (chk_data_od.Checked && chk_data_do.Checked
                && dtp_data_od.Value.Date > dtp_data_do.Value.Date)
            {
                MessageBox.Show("Data od musi być wcześniejsza lub równa dacie do.",
                    "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btn_prev_page_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) { currentPage--; WczytajAudit(); }
        }

        private void btn_next_page_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages) { currentPage++; WczytajAudit(); }
        }
    }
}
