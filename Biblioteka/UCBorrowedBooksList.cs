using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCBorrowedBooksList : UserControl
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        public int? CurrentUserId { get; set; }
        private int currentPage = 1;
        private int totalPages = 1; // <--- Dodane dla paginacji
        private const int pageSize = 20;

        public UCBorrowedBooksList()
        {
            InitializeComponent();

            // Konfiguracja kontrolek zgodnie z analizą
            // Włączamy checkboxy w kalendarzach - domyślnie ignorujemy datę
            dtp_date_from.ShowCheckBox = true;
            dtp_date_from.Checked = false;

            dtp_date_to.ShowCheckBox = true;
            dtp_date_to.Checked = false;

            cb_status.Items.Clear();
            cb_status.Items.AddRange(new string[] { "Wszystkie", "Nowe", "Przedłużone", "Zakończone" });
            cb_status.SelectedIndex = 0;
        }

        public void UstawUprawnienia(List<string> role)
        {
            if (role == null) return;
            bool jestBibliotekarz = role.Contains("Bibliotekarz");
            bool jestManager = role.Contains("Manager");

            // Tylko Bibliotekarz może klikać akcje
            btn_add_new_rental.Enabled = jestBibliotekarz;
            btn_extend_time.Enabled = jestBibliotekarz;
        }

        public void WczytajDane(int page = 1)
        {
            currentPage = page;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    // Filtry budowane dynamicznie
                    string whereClause = " WHERE 1=1";
                    bool czyUzytoFiltrow = false; // czy użyto filtrów dla komunikatu E1

                    if(!string.IsNullOrWhiteSpace(txb_reader.Text))
                    {
                        czyUzytoFiltrow = true;
                        whereClause += " AND (c.Imie = @reader OR c.Nazwisko = @reader OR c.Imie + ' ' + c.Nazwisko = @reader)";
                        cmd.Parameters.AddWithValue("@reader", txb_reader.Text.Trim());
                    }

                    // Filtrowanie po BIBLIOTEKARZU - DOKŁADNE dopasowanie
                    if (!string.IsNullOrWhiteSpace(txb_librarian.Text))
                    {
                        czyUzytoFiltrow = true;
                        whereClause += " AND (b.Imie = @lib OR b.Nazwisko = @lib OR b.Imie + ' ' + b.Nazwisko = @lib)";
                        cmd.Parameters.AddWithValue("@lib", txb_librarian.Text.Trim());
                    }
                    if (cb_status.SelectedIndex > 0)
                    {
                        czyUzytoFiltrow = true;
                        whereClause += " AND w.Status = @status";
                        cmd.Parameters.AddWithValue("@status", cb_status.SelectedItem.ToString());
                    }

                    // Filtrowanie dat działa tylko wtedy gdy checkbox w kalendarzu jest zaznaczony
                    if (dtp_date_from.Checked)
                    {
                        czyUzytoFiltrow = true;
                        whereClause += " AND w.DataWypozyczenia >= @dateFrom";
                        cmd.Parameters.AddWithValue("@dateFrom", dtp_date_from.Value.Date);
                    }
                    if (dtp_date_to.Checked)
                    {
                        czyUzytoFiltrow = true;
                        whereClause += " AND w.DataWypozyczenia <= @dateTo";
                        cmd.Parameters.AddWithValue("@dateTo", dtp_date_to.Value.Date.AddDays(1).AddSeconds(-1));
                    }

                    // Obliczenie całkowitej liczby rekordów dla paginacji
                    string countSql = @"
                        SELECT COUNT(*) 
                        FROM Wypozyczenia w
                        JOIN Uzytkownicy c ON w.CzytelnikID = c.ID
                        JOIN Uzytkownicy b ON w.BibliotekarzID = b.ID" + whereClause;

                    cmd.CommandText = countSql;
                    int totalRecords = (int)cmd.ExecuteScalar();

                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages == 0) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;

                    // Główne zapytanie z paginacją
                    string sql = @"
                        SELECT 
                            w.ID,
                            c.Imie + ' ' + c.Nazwisko AS Czytelnik,
                            c.Ulica + ' ' + c.NumerPosesji + ISNULL('/' + c.NumerLokalu, '') AS Adres,
                            c.Telefon AS [Nr Telefonu],
                    
                            (
                                SELECT STRING_AGG(ISNULL(aut.AutorN, '') + kk.Tytul, ', ')
                                FROM PozycjeWypozyczenia pw2
                                JOIN Egzemplarze eg2 ON pw2.EgzemplarzID = eg2.ID
                                JOIN KatalogKsiazek kk ON eg2.KsiazkaID = kk.ID
                                OUTER APPLY (
                                    SELECT TOP 1 a.Imie + ' ' + a.Nazwisko + ' - ' AS AutorN
                                    FROM KsiazkaKatalog_Autorzy kka
                                    JOIN Autorzy a ON kka.AutorID = a.ID
                                    WHERE kka.KsiazkaID = kk.ID
                                ) aut
                                WHERE pw2.WypozyczenieID = w.ID
                            ) AS [Książka],

                            b.Imie + ' ' + b.Nazwisko AS Bibliotekarz,
                            w.DataWypozyczenia AS [Data Wypożyczenia],
                            w.OczekiwanaDataZwrotu AS [Termin Zwrotu],
                            CAST(w.OkresWypozyczeniaDni AS VARCHAR) + ' dni' AS [Okres],
                            w.Status
                        FROM Wypozyczenia w
                        JOIN Uzytkownicy c ON w.CzytelnikID = c.ID
                        JOIN Uzytkownicy b ON w.BibliotekarzID = b.ID "
                        + whereClause +
                        @" ORDER BY w.DataWypozyczenia DESC
                           OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    cmd.Parameters.AddWithValue("@Offset", (currentPage - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);

                    cmd.CommandText = sql;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_rentals.DataSource = dt;

                    // Poprawa wyglądu DataGridView i paginacja
                    if (dgv_rentals.Columns.Contains("ID")) dgv_rentals.Columns["ID"].Visible = false;
                    dgv_rentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgv_rentals.Columns.Contains("Data Wypożyczenia"))
                        dgv_rentals.Columns["Data Wypożyczenia"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    if (dgv_rentals.Columns.Contains("Termin Zwrotu"))
                        dgv_rentals.Columns["Termin Zwrotu"].DefaultCellStyle.Format = "dd.MM.yyyy";

                    if (dgv_rentals.Columns.Contains("Okres"))
                        dgv_rentals.Columns["Okres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    if (dgv_rentals.Columns.Contains("Status"))
                        dgv_rentals.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (this.Controls.Find("lbl_page_info", true).Length > 0)
                        this.Controls.Find("lbl_page_info", true)[0].Text = $"Strona: {currentPage} / {totalPages}";

                    if (this.Controls.Find("btn_prev_page", true).Length > 0)
                        this.Controls.Find("btn_prev_page", true)[0].Enabled = currentPage > 1;

                    if (this.Controls.Find("btn_next_page", true).Length > 0)
                        this.Controls.Find("btn_next_page", true)[0].Enabled = currentPage < totalPages;

                    // Obsługa scenariusza E1
                    if (dt.Rows.Count == 0 && czyUzytoFiltrow)
                    {
                        MessageBox.Show("Nie znaleziono wypożyczeń spełniających podane kryteria", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (dtp_date_from.Checked && dtp_date_to.Checked)
            {
                // Jeśli "Data od" jest późniejsza niż "Data do"
                if (dtp_date_from.Value.Date > dtp_date_to.Value.Date)
                {
                    MessageBox.Show("Data 'do' nie może być wcześniejsza niż data 'od'!", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
            }

            WczytajDane(1);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txb_reader.Clear();
            txb_librarian.Clear();
            cb_status.SelectedIndex = 0;

            dtp_date_from.Checked = false;
            dtp_date_to.Checked = false;

            WczytajDane(1);
        }

        private void btn_add_new_rental_Click(object sender, EventArgs e)
        {
            if (this.FindForm() is Biblioteka mainForm)
                mainForm.OtworzNoweWypozyczenie();
        }

        private void btn_extend_time_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funkcjonalność przedłużania (PRZ_PRZEDL_1) w trakcie przygotowania.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Paginator 
        private void btn_prev_page_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) WczytajDane(currentPage - 1);
        }

        private void btn_next_page_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages) WczytajDane(currentPage + 1);
        }
    }
}