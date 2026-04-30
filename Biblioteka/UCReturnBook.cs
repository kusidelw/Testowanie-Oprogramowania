using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCReturnBook : UserControl
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        public UCReturnBook()
        {
            InitializeComponent();
            KonfigurujDGV();
            this.VisibleChanged += (s, e) => { if (this.Visible) WczytajWypozyczenia(); };
        }

        private void KonfigurujDGV()
        {
            dgv_wypozyczenia.ReadOnly = true;
            dgv_wypozyczenia.AllowUserToAddRows = false;
            dgv_wypozyczenia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_wypozyczenia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_wypozyczenia.MultiSelect = false;
            dgv_wypozyczenia.RowHeadersVisible = false;
        }

        private void WczytajWypozyczenia()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    const string sql = @"
                        SELECT
                            W.ID,
                            UC.Imie + ' ' + UC.Nazwisko + ' (' + UC.Login + ')'   AS [Czytelnik],
                            UB.Imie + ' ' + UB.Nazwisko                            AS [Bibliotekarz],
                            CONVERT(NVARCHAR, W.DataWypozyczenia,    103)           AS [Data wypożyczenia],
                            CONVERT(NVARCHAR, W.OczekiwanaDataZwrotu, 103)          AS [Oczekiwana data zwrotu],
                            W.Status,
                            ISNULL((SELECT STUFF((
                                SELECT ', Egz.#' + CAST(E2.ID AS NVARCHAR) + ' ' + K2.Tytul
                                FROM PozycjeWypozyczenia PW2
                                JOIN Egzemplarze E2    ON PW2.EgzemplarzID = E2.ID
                                JOIN KatalogKsiazek K2 ON E2.KsiazkaID     = K2.ID
                                WHERE PW2.WypozyczenieID = W.ID
                                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')), '') AS [Egzemplarze]
                        FROM Wypozyczenia W
                        JOIN Uzytkownicy UC ON W.CzytelnikID    = UC.ID
                        JOIN Uzytkownicy UB ON W.BibliotekarzID = UB.ID
                        WHERE W.Status IN ('Nowe', 'Przedluzone')
                        ORDER BY W.DataWypozyczenia DESC";

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        new SqlDataAdapter(cmd).Fill(dt);

                    dgv_wypozyczenia.DataSource = dt;

                    if (dgv_wypozyczenia.Columns["ID"] != null)
                        dgv_wypozyczenia.Columns["ID"].Visible = false;

                    AktualizujPrzyciski();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania wypożyczeń: " + ex.Message,
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AktualizujPrzyciski()
        {
            btn_zwroc.Enabled = dgv_wypozyczenia.SelectedRows.Count > 0;
        }

        private void btn_zwroc_Click(object sender, EventArgs e)
        {
            if (dgv_wypozyczenia.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz wypożyczenie do zwrotu.",
                    "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int wypozyczenieId = Convert.ToInt32(dgv_wypozyczenia.SelectedRows[0].Cells["ID"].Value);

            DialogResult potwierdzenie = MessageBox.Show(
                "Czy na pewno chcesz zarejestrować zwrot tego wypożyczenia?",
                "Potwierdzenie zwrotu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (potwierdzenie != DialogResult.Yes) return;

            SqlTransaction transakcja = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transakcja = conn.BeginTransaction();

                    // 1. Zamknięcie wypożyczenia — warunek AND Status IN ('Nowe','Przedluzone')
                    //    zabezpiecza przed podwójnym zwrotem przy odświeżeniu nieaktualnej siatki.
                    const string sqlZamknij = @"
                        UPDATE Wypozyczenia
                        SET DataZwrotu = GETDATE(), Status = 'Zakonczone'
                        WHERE ID = @WypozyczenieID AND Status IN ('Nowe', 'Przedluzone');";

                    int zaktualizowane;
                    using (SqlCommand cmd = new SqlCommand(sqlZamknij, conn, transakcja))
                    {
                        cmd.Parameters.Add("@WypozyczenieID", SqlDbType.Int).Value = wypozyczenieId;
                        zaktualizowane = cmd.ExecuteNonQuery();
                    }

                    if (zaktualizowane == 0)
                    {
                        transakcja.Rollback();
                        MessageBox.Show(
                            "To wypożyczenie zostało już zwrócone lub nie istnieje. Odśwież listę.",
                            "Już zwrócone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        WczytajWypozyczenia();
                        return;
                    }

                    // 2. Przywrócenie statusu 'Dostepna' — tylko egzemplarze faktycznie wypożyczone
                    //    (nie nadpisujemy statusu Zniszczona/Zagubiona nadanego poza tym wypożyczeniem).
                    const string sqlZwrocEgzemplarze = @"
                        UPDATE Egzemplarze
                        SET Status = 'Dostepna'
                        WHERE ID IN (
                            SELECT EgzemplarzID
                            FROM PozycjeWypozyczenia
                            WHERE WypozyczenieID = @WypozyczenieID
                        ) AND Status = 'Wypozyczona';";

                    using (SqlCommand cmd = new SqlCommand(sqlZwrocEgzemplarze, conn, transakcja))
                    {
                        cmd.Parameters.Add("@WypozyczenieID", SqlDbType.Int).Value = wypozyczenieId;
                        cmd.ExecuteNonQuery();
                    }

                    transakcja.Commit();
                }

                MessageBox.Show("Zwrot został zarejestrowany.",
                    "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                WczytajWypozyczenia();
            }
            catch (Exception ex)
            {
                if (transakcja?.Connection != null &&
                    transakcja.Connection.State == ConnectionState.Open)
                {
                    try { transakcja.Rollback(); }
                    catch { /* ignoruj błąd rollback */ }
                }

                MessageBox.Show("Błąd podczas rejestrowania zwrotu: " + ex.Message,
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_odswiez_Click(object sender, EventArgs e)
        {
            WczytajWypozyczenia();
        }

        private void dgv_wypozyczenia_SelectionChanged(object sender, EventArgs e)
        {
            AktualizujPrzyciski();
        }
    }
}
