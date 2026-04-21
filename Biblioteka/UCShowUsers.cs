using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCShowUsers : UserControl
    {
        private string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 1;
        private string searchQuery = "";

        public UCShowUsers()
        {
            InitializeComponent();
            KonfigurujDGV();
            WczytajUzytkownikow();
            this.VisibleChanged += UCShowUsers_VisibleChanged;
        }

        private void UCShowUsers_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                WczytajUzytkownikow();
        }

        private void KonfigurujDGV()
        {
            dgv_users_list.ReadOnly = true;
            dgv_users_list.AllowUserToAddRows = false;
            dgv_users_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_users_list.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_users_list.MultiSelect = false;
            dgv_users_list.RowHeadersVisible = false;
        }

        private void WczytajUzytkownikow()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    // 1. Liczenie rekordów
                    // PESEL wymaga pełnego ciągu, Login/Imię/Nazwisko pozwalają na częściowe frazy
                    string sqlCount = @"
                        SELECT COUNT(*) FROM Uzytkownicy
                        WHERE CzyZapomniany = 0
                          AND (@Query = '' 
                               OR Login LIKE @QueryLike 
                               OR (Imie + ' ' + Nazwisko) LIKE @QueryLike 
                               OR PESEL = @Query)";

                    int totalRecords;
                    using (SqlCommand cmd = new SqlCommand(sqlCount, conn))
                    {
                        cmd.Parameters.AddWithValue("@Query", searchQuery);
                        cmd.Parameters.AddWithValue("@QueryLike", "%" + searchQuery + "%");
                        totalRecords = (int)cmd.ExecuteScalar();
                    }

                    // Scenariusz E1: brak wyników dla aktywnego wyszukiwania
                    if (totalRecords == 0 && !string.IsNullOrEmpty(searchQuery))
                    {
                        MessageBox.Show(
                            "Nie znaleziono użytkownika o podanych kryteriach.",
                            "Brak wyników",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        if (dgv_users_list.DataSource is DataTable dt)
                            dt.Clear();

                        lbl_page_info.Text = "Strona: 1 / 1";

                        // Odblokowanie/zablokowanie przycisków stronicowania
                        AktualizujPrzyciskiStron();
                        return;
                    }

                    // 2. Obliczanie stron
                    totalPages = Math.Max(1, (int)Math.Ceiling((double)totalRecords / pageSize));
                    if (currentPage > totalPages) currentPage = totalPages;
                    lbl_page_info.Text = $"Strona: {currentPage} / {totalPages}";

                    // 3. Pobieranie danych ze stronicowaniem
                    string sqlData = @"
                        SELECT 
                            ID                          AS [ID],
                            Login                       AS [Login],
                            (Imie + ' ' + Nazwisko)     AS [Imię i nazwisko],
                            Email                       AS [Adres e-mail]
                        FROM Uzytkownicy
                        WHERE CzyZapomniany = 0
                          AND (@Query = '' 
                               OR Login LIKE @QueryLike 
                               OR (Imie + ' ' + Nazwisko) LIKE @QueryLike 
                               OR PESEL = @Query)
                        ORDER BY Nazwisko, Imie
                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        cmd.Parameters.AddWithValue("@Query", searchQuery);
                        cmd.Parameters.AddWithValue("@QueryLike", "%" + searchQuery + "%");
                        cmd.Parameters.AddWithValue("@Offset", (currentPage - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@PageSize", pageSize);

                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        dgv_users_list.DataSource = dt;
                    }

                    // Ukryj kolumnę ID 
                    if (dgv_users_list.Columns["ID"] != null)
                        dgv_users_list.Columns["ID"].Visible = false;

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

        // Blokuje przyciski gdy nie ma sensu ich używać
        private void AktualizujPrzyciskiStron()
        {
            btn_prev_page.Enabled = currentPage > 1;
            btn_next_page.Enabled = currentPage < totalPages;
        }

        // ── WYSZUKIWANIE ──────────────────────────────────────────────────────────

        private void btn_search_user_Click_1(object sender, EventArgs e)
        {
            searchQuery = txt_search_user.Text.Trim();
            currentPage = 1;
            WczytajUzytkownikow();
        }

        // Wyszukiwanie klawiszem Enter
        private void txt_search_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search_user_Click_1(sender, e);
        }

        // ── STRONICOWANIE ─────────────────────────────────────────────────────────

        private void btn_next_page_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                WczytajUzytkownikow();
            }
        }

        private void btn_prev_page_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                WczytajUzytkownikow();
            }
        }

        // ── PODGLĄD KARTY UŻYTKOWNIKA (dwuklik) ──────────────────────────────────

        private void dgv_users_list_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int userId = Convert.ToInt32(dgv_users_list.Rows[e.RowIndex].Cells["ID"].Value);

            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
                mainForm.PokazKarteUzytkownika(userId);
        }
    }
}