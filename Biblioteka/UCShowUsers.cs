using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Biblioteka
{
    public partial class UCShowUsers : UserControl
    {
        private string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 1;
        private string searchQuery = "";

        public UCShowUsers()
        {
            InitializeComponent();
            KonfigurujDGV();
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
                    string sqlCount = @"
                SELECT COUNT(*) FROM Uzytkownicy
                WHERE CzyZapomniany = 0
                AND (@Query = '' OR Login LIKE @QueryLike 
                     OR (Imie + ' ' + Nazwisko) LIKE @QueryLike 
                     OR PESEL LIKE @QueryLike)";

                    int totalRecords;
                    using (SqlCommand cmd = new SqlCommand(sqlCount, conn))
                    {
                        cmd.Parameters.AddWithValue("@Query", searchQuery);
                        cmd.Parameters.AddWithValue("@QueryLike", "%" + searchQuery + "%");
                        totalRecords = (int)cmd.ExecuteScalar();
                    }

                    // --- REAKCJA NA BRAK WYNIKÓW (Scenariusz E1) ---
                    if (totalRecords == 0 && !string.IsNullOrEmpty(searchQuery))
                    {
                        MessageBox.Show("Nie znaleziono użytkownika o podanych kryteriach", "Brak wyników", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Opcjonalnie: czyścimy stary widok w DGV
                        dgv_users_list.DataSource = null;
                        lbl_page_info.Text = "Strona: 0 / 0";
                        return; // Przerywamy dalsze ładowanie
                    }

                    // 2. Obliczanie stron
                    totalPages = Math.Max(1, (int)Math.Ceiling((double)totalRecords / pageSize));
                    if (currentPage > totalPages) currentPage = totalPages;
                    lbl_page_info.Text = $"Strona: {currentPage} / {totalPages}";

                    // 3. Pobieranie danych
                    string sqlData = @"
                SELECT 
                    ID AS [ID],
                    Login AS [Login],
                    Imie AS [Imię],
                    Nazwisko AS [Nazwisko],
                    PESEL AS [PESEL],
                    Email AS [Email],
                    Telefon AS [Telefon],
                    Miejscowosc AS [Miejscowość]
                FROM Uzytkownicy
                WHERE CzyZapomniany = 0
                AND (@Query = '' OR Login LIKE @QueryLike 
                     OR (Imie + ' ' + Nazwisko) LIKE @QueryLike 
                     OR PESEL LIKE @QueryLike)
                ORDER BY Nazwisko, Imie
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        cmd.Parameters.AddWithValue("@Query", searchQuery);
                        cmd.Parameters.AddWithValue("@QueryLike", "%" + searchQuery + "%");
                        cmd.Parameters.AddWithValue("@Offset", (currentPage - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@PageSize", pageSize);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_users_list.DataSource = dt;
                    }

                    if (dgv_users_list.Columns["ID"] != null)
                        dgv_users_list.Columns["ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_user_Click_1(object sender, EventArgs e)
        {
            searchQuery = txt_search_user.Text.Trim();
            currentPage = 1;
            WczytajUzytkownikow();
        }

        private void txt_search_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search_user_Click_1(sender, e);
        }

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

        private void btn_edit_data_Click(object sender, EventArgs e)
        {
            if (dgv_users_list.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika z listy.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = (int)dgv_users_list.SelectedRows[0].Cells["ID"].Value;

            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
            {
                mainForm.PrzejdzDoEdycji(userId);
            }
        }

        private void btn_show_data_Click(object sender, EventArgs e)
        {
            
        }
    }
}