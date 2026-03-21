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
    public partial class UCFindForgottenUsers : UserControl
    {
        private string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        public UCFindForgottenUsers()
        {
            InitializeComponent();
            KonfigurujDGV();
            this.VisibleChanged += UCFindForgottenUsers_VisibleChanged;
        }

        private void UCFindForgottenUsers_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                WczytajZapomnianych();
        }

        private void KonfigurujDGV()
        {
            dgv_forgotten_users.ReadOnly = true;
            dgv_forgotten_users.AllowUserToAddRows = false;
            dgv_forgotten_users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_forgotten_users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_forgotten_users.MultiSelect = false;
            dgv_forgotten_users.RowHeadersVisible = false;
        }

        private void WczytajZapomnianych()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    string sql = @"
                        SELECT
                            ID                           AS [ID],
                            Login                        AS [Login],
                            (Imie + ' ' + Nazwisko)      AS [Imię i nazwisko],
                            DataZapomnienia              AS [Data zapomnienia],
                            ZapomnianyPrzezUzytkownikaID AS [ID administratora]
                        FROM Uzytkownicy
                        WHERE CzyZapomniany = 1
                        ORDER BY DataZapomnienia DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_forgotten_users.DataSource = dt;

                        // Scenariusz E1 – brak zapomnianych użytkowników
                        if (dt.Rows.Count == 0)
                            lbl_info_message.Text = "Brak użytkowników spełniających kryteria.";
                        else
                            lbl_info_message.Text = $"Wyświetlono {dt.Rows.Count} wyników! Kliknij dwukrotnie wiersz, aby zobaczyć szczegóły.";
                    }

                    if (dgv_forgotten_users.Columns["ID"] != null)
                        dgv_forgotten_users.Columns["ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_forgotten_users_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int userId = (int)dgv_forgotten_users.Rows[e.RowIndex].Cells["ID"].Value;

            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
            {
                mainForm.PokazKarteUzytkownika(userId);
            }
        }

        private void btn_search_users_Click(object sender, EventArgs e)
        {
            WczytajZapomnianych();
        }
    }
}