using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCShowBooks : UserControl
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        public int? CurrentUserId { get; set; }

        private bool _isBibliotekarz = false;
        public bool IsBibliotekarz
        {
            get => _isBibliotekarz;
            set
            {
                _isBibliotekarz = value;
                btn_dodaj_nowy_egzemplarz.Visible = value;
            }
        }

        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 1;
        private string searchTytul = "";
        private string searchAutor = "";
        private string searchGatunek = "";
        private string searchWydawnictwo = "";
        private string searchStatus = "";

        public UCShowBooks()
        {
            InitializeComponent();
            KonfigurujDGV();
            InicjalizujStatusy();
            WczytajKsiążki();
        }

        private void KonfigurujDGV()
        {
            dgv_books_list.ReadOnly = true;
            dgv_books_list.AllowUserToAddRows = false;
            dgv_books_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_books_list.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_books_list.MultiSelect = false;
            dgv_books_list.RowHeadersVisible = false;
        }

        private void InicjalizujStatusy()
        {
            cbm_status.Items.Clear();
            cbm_status.Items.Add("(wszystkie)");

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    const string sql = "SELECT DISTINCT Status FROM Egzemplarze ORDER BY Status;";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read())
                            cbm_status.Items.Add(reader["Status"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania statusów: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cbm_status.SelectedIndex = 0;
        }

        private void WczytajKsiążki()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    string sqlCount = @"
                        SELECT COUNT(DISTINCT K.ID)
                        FROM KatalogKsiazek K
                        LEFT JOIN Gatunki     G ON G.ID = K.GatunekID
                        LEFT JOIN Wydawnictwa W ON W.ID = K.WydawnictwoID
                        WHERE (@Tytul        = '' OR K.Tytul  LIKE @TytulLike)
                          AND (@Gatunek      = '' OR G.Nazwa  LIKE @GatunekLike)
                          AND (@Wydawnictwo  = '' OR W.Nazwa  LIKE @WydawnictwoLike)
                          AND (@Autor        = '' OR EXISTS (
                                SELECT 1
                                FROM KsiazkaKatalog_Autorzy KA2
                                JOIN Autorzy A2 ON KA2.AutorID = A2.ID
                                WHERE KA2.KsiazkaID = K.ID
                                  AND (A2.Imie + ' ' + A2.Nazwisko) LIKE @AutorLike
                              ))
                          AND (@Status = '' OR EXISTS (
                                SELECT 1 FROM Egzemplarze E2
                                WHERE E2.KsiazkaID = K.ID AND E2.Status = @Status
                              ))";

                    int totalRecords;
                    using (SqlCommand cmd = new SqlCommand(sqlCount, conn))
                    {
                        DodajParametryFiltrów(cmd);
                        totalRecords = (int)cmd.ExecuteScalar();
                    }

                    if (totalRecords == 0 && (!string.IsNullOrEmpty(searchTytul) || !string.IsNullOrEmpty(searchAutor)
                        || !string.IsNullOrEmpty(searchGatunek) || !string.IsNullOrEmpty(searchWydawnictwo)
                        || !string.IsNullOrEmpty(searchStatus)))
                    {
                        MessageBox.Show(
                            "Nie znaleziono książek spełniających podane kryteria.",
                            "Brak wyników",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        if (dgv_books_list.DataSource is DataTable dt)
                            dt.Clear();

                        lbl_page_info.Text = "Strona: 1 / 1";
                        AktualizujPrzyciskiStron();
                        return;
                    }

                    totalPages = Math.Max(1, (int)Math.Ceiling((double)totalRecords / pageSize));
                    if (currentPage > totalPages) currentPage = totalPages;
                    lbl_page_info.Text = $"Strona: {currentPage} / {totalPages}";

                    string sqlData = @"
                        SELECT
                            K.ID,
                            K.Tytul                                                                    AS [Tytuł],
                            ISNULL(G.Nazwa, '')                                                        AS [Gatunek],
                            ISNULL(W.Nazwa, '')                                                        AS [Wydawnictwo],
                            ISNULL((SELECT STUFF((
                                SELECT ', ' + A2.Imie + ' ' + A2.Nazwisko
                                FROM KsiazkaKatalog_Autorzy KA2
                                JOIN Autorzy A2 ON KA2.AutorID = A2.ID
                                WHERE KA2.KsiazkaID = K.ID
                                ORDER BY A2.Nazwisko, A2.Imie
                                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')), '')  AS [Autorzy],
                            K.RokWydania                                                               AS [Rok wydania],
                            (SELECT COUNT(*)
                             FROM Egzemplarze E WHERE E.KsiazkaID = K.ID)                             AS [Egzemplarze],
                            (SELECT COUNT(*)
                             FROM Egzemplarze E WHERE E.KsiazkaID = K.ID AND E.Status = 'Dostepna')   AS [Dostępne]
                        FROM KatalogKsiazek K
                        LEFT JOIN Gatunki     G ON G.ID = K.GatunekID
                        LEFT JOIN Wydawnictwa W ON W.ID = K.WydawnictwoID
                        WHERE (@Tytul        = '' OR K.Tytul  LIKE @TytulLike)
                          AND (@Gatunek      = '' OR G.Nazwa  LIKE @GatunekLike)
                          AND (@Wydawnictwo  = '' OR W.Nazwa  LIKE @WydawnictwoLike)
                          AND (@Autor        = '' OR EXISTS (
                                SELECT 1
                                FROM KsiazkaKatalog_Autorzy KA2
                                JOIN Autorzy A2 ON KA2.AutorID = A2.ID
                                WHERE KA2.KsiazkaID = K.ID
                                  AND (A2.Imie + ' ' + A2.Nazwisko) LIKE @AutorLike
                              ))
                          AND (@Status = '' OR EXISTS (
                                SELECT 1 FROM Egzemplarze E2
                                WHERE E2.KsiazkaID = K.ID AND E2.Status = @Status
                              ))
                        ORDER BY K.ID
                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        DodajParametryFiltrów(cmd);
                        cmd.Parameters.Add("@Offset",   SqlDbType.Int).Value = (currentPage - 1) * pageSize;
                        cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        dgv_books_list.DataSource = dt;
                    }

                    if (dgv_books_list.Columns["ID"] != null)
                        dgv_books_list.Columns["ID"].Visible = false;

                    AktualizujPrzyciskiStron();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd bazy danych: " + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DodajParametryFiltrów(SqlCommand cmd)
        {
            cmd.Parameters.Add("@Tytul",           SqlDbType.NVarChar, 255).Value = searchTytul;
            cmd.Parameters.Add("@TytulLike",        SqlDbType.NVarChar, 257).Value = "%" + searchTytul + "%";
            cmd.Parameters.Add("@Autor",            SqlDbType.NVarChar, 101).Value = searchAutor;
            cmd.Parameters.Add("@AutorLike",        SqlDbType.NVarChar, 103).Value = "%" + searchAutor + "%";
            cmd.Parameters.Add("@Gatunek",          SqlDbType.NVarChar, 100).Value = searchGatunek;
            cmd.Parameters.Add("@GatunekLike",      SqlDbType.NVarChar, 102).Value = "%" + searchGatunek + "%";
            cmd.Parameters.Add("@Wydawnictwo",      SqlDbType.NVarChar, 100).Value = searchWydawnictwo;
            cmd.Parameters.Add("@WydawnictwoLike",  SqlDbType.NVarChar, 102).Value = "%" + searchWydawnictwo + "%";
            cmd.Parameters.Add("@Status",           SqlDbType.NVarChar,  50).Value = searchStatus;
        }

        private void AktualizujPrzyciskiStron()
        {
            btn_prev_page.Enabled = currentPage > 1;
            btn_next_page.Enabled = currentPage < totalPages;
            bool zaznaczona = dgv_books_list.SelectedRows.Count > 0;
            btn_details.Enabled              = zaznaczona;
            btn_dodaj_nowy_egzemplarz.Enabled = zaznaczona;
        }

        // ── WYSZUKIWANIE ──────────────────────────────────────────────────────────

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchTytul        = txt_search_tytul.Text.Trim();
            searchAutor        = txt_search_autor.Text.Trim();
            searchGatunek      = txt_search_gatunek.Text.Trim();
            searchWydawnictwo  = txt_search_wydawnictwo.Text.Trim();
            searchStatus       = cbm_status.SelectedIndex <= 0 ? "" : cbm_status.SelectedItem.ToString();
            currentPage = 1;
            WczytajKsiążki();
        }

        private void btn_clear_filters_Click(object sender, EventArgs e)
        {
            txt_search_tytul.Clear();
            txt_search_autor.Clear();
            txt_search_gatunek.Clear();
            txt_search_wydawnictwo.Clear();
            cbm_status.SelectedIndex = 0;
            searchTytul       = "";
            searchAutor       = "";
            searchGatunek     = "";
            searchWydawnictwo = "";
            searchStatus      = "";
            currentPage = 1;
            WczytajKsiążki();
        }


        private void btn_prev_page_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                WczytajKsiążki();
            }
        }

        private void btn_next_page_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                WczytajKsiążki();
            }
        }

        // ── SZCZEGÓŁY KSIĄŻKI ─────────────────────────────────────────────────────

        private void btn_details_Click(object sender, EventArgs e)
        {
            if (dgv_books_list.SelectedRows.Count == 0) return;

            int wybraneId = Convert.ToInt32(dgv_books_list.SelectedRows[0].Cells["ID"].Value);
            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
                mainForm.PokazWidokZeStanem(new UCBookDetails(wybraneId));
        }

        private void dgv_books_list_SelectionChanged(object sender, EventArgs e)
        {
            bool zaznaczona = dgv_books_list.SelectedRows.Count > 0;
            btn_details.Enabled              = zaznaczona;
            btn_dodaj_nowy_egzemplarz.Enabled = zaznaczona;
        }

        private void dgv_books_list_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btn_details_Click(sender, e);
        }

        private void btn_dodaj_nowy_egzemplarz_Click(object sender, EventArgs e)
        {
            if (dgv_books_list.SelectedRows.Count == 0) return;

            int wybranaKsiazkaId = Convert.ToInt32(dgv_books_list.SelectedRows[0].Cells["ID"].Value);

            Form parentForm = this.FindForm();
            if (!(parentForm is Form1 mainForm)) return;

            var formularz = new UCAddBook();
            formularz.CurrentUserId       = CurrentUserId;
            formularz.IstniejacaKsiazkaId = wybranaKsiazkaId;
            formularz.ZaladujDaneIstniejacejKsiazki(wybranaKsiazkaId);

            mainForm.PokazWidokZeStanem(formularz);
        }
    }
}
