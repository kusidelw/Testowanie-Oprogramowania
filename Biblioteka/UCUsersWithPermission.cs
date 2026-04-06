using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCUsersWithPermission : UserControl
    {
        private string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private int _permissionId;

        public UCUsersWithPermission()
        {
            InitializeComponent();
            KonfigurujDGV();
        }

        private void KonfigurujDGV()
        {
            dgv_users.ReadOnly = true;
            dgv_users.AllowUserToAddRows = false;
            dgv_users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_users.MultiSelect = false;
            dgv_users.RowHeadersVisible = false;
        }

        public void ZaladujDane(int permissionId, string permissionName)
        {
            _permissionId = permissionId;
            lbl_title.Text = $"UŻYTKOWNICY Z UPRAWNIENIEM: {permissionName}";
            WczytajUzytkownikow();
        }

        private void WczytajUzytkownikow()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    // SCENARIUSZ GŁÓWNY pkt. 3
                    string sqlData = @"
                        SELECT 
                            u.ID AS [ID],
                            u.Login AS [Login],
                            (u.Imie + ' ' + u.Nazwisko) AS [Imię i nazwisko],
                            u.Email AS [Email]
                        FROM Uzytkownicy u
                        INNER JOIN Uzytkownicy_Uprawnienia uu ON u.ID = uu.UzytkownikID
                        WHERE uu.UprawnienieID = @permId
                        ORDER BY u.Nazwisko, u.Imie";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        cmd.Parameters.AddWithValue("@permId", _permissionId);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // SCENARIUSZ WYJĄTKOWY E1
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Brak użytkowników z przypisanym tym uprawnieniem.",
                                "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgv_users.DataSource = null;
                            lbl_count.Text = "Liczba: 0";
                            return;
                        }

                        dgv_users.DataSource = dt;

                        if (dgv_users.Columns["ID"] != null)
                            dgv_users.Columns["ID"].Visible = false;

                        lbl_count.Text = $"Liczba: {dt.Rows.Count} użytkowników";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_users_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // OPCJA B: Przejście do edycji UPRAWNIEŃ (nie danych osobowych)
            if (e.RowIndex >= 0)
            {
                int userId = (int)dgv_users.Rows[e.RowIndex].Cells["ID"].Value;
                string login = dgv_users.Rows[e.RowIndex].Cells["Login"].Value.ToString();
                string fullName = dgv_users.Rows[e.RowIndex].Cells["Imię i nazwisko"].Value.ToString();

                Form parentForm = this.FindForm();
                if (parentForm is Form1 mainForm)
                {
                    mainForm.PokazEdycjeUprawnien(userId, $"{fullName} ({login})");
                }
            }
        }

    }
}