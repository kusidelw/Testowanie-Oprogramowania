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
    public partial class UCFindUsers : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        public UCFindUsers()
        {
            InitializeComponent();
            lbl_results_message.Visible = false;
        }

        private void btn_search_user_Click(object sender, EventArgs e)
        {
            string searchQuery = txt_search_query.Text.Trim();

            // Zapytanie SQL - szukamy tylko tych, którzy NIE są zapomniani (RODO)
            string query = @"
                SELECT 
                    ID, 
                    Login, 
                    Imie AS [Imię], 
                    Nazwisko, 
                    PESEL, 
                    Email, 
                    Telefon
                FROM Uzytkownicy
                WHERE CzyZapomniany = 0 
                AND (
                    Login LIKE @search 
                    OR Imie LIKE @search 
                    OR Nazwisko LIKE @search 
                    OR PESEL LIKE @search
                    OR (Imie + ' ' + Nazwisko) LIKE @search
                )";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchQuery + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        conn.Open();
                        adapter.Fill(dt);

                        // Wrzucamy dane do tabelki na ekranie
                        dgv_user_results.DataSource = dt;

                        lbl_results_message.Text = $"Wyświetlono {dt.Rows.Count} wyników. Kliknij dwukrotnie wiersz, aby zobaczyć szczegóły.";

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Nie znaleziono użytkowników o podanych kryteriach.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_user_results_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sprawdzamy, czy kliknięto wiersz, a nie nagłówek
            if (e.RowIndex >= 0)
            {
                try
                {
                    int selectedId = Convert.ToInt32(dgv_user_results.Rows[e.RowIndex].Cells["ID"].Value);

                    Form1 mainForm = (Form1)this.FindForm();

                    UCShowUsersData ucDetails = new UCShowUsersData();

                    ucDetails.ZaladujDaneUzytkownika(selectedId);

                    mainForm.PokazWidokZeStanem(ucDetails);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy otwieraniu karty: " + ex.Message);
                }
            }
        }
    }
}
