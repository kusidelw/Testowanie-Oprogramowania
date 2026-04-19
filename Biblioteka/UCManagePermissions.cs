using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCManagePermissions : UserControl
    {
        private string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private string searchQuery = "";

        public UCManagePermissions()
        {
            InitializeComponent();
            KonfigurujDGV();
            WczytajUprawnienia();
            this.VisibleChanged += UCManagePermissions_VisibleChanged;
        }

        private void UCManagePermissions_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                WczytajUprawnienia();
            }
        }

        private void KonfigurujDGV()
        {
            dgv_permissions.ReadOnly = true;
            dgv_permissions.AllowUserToAddRows = false;
            dgv_permissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_permissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_permissions.MultiSelect = false;
            dgv_permissions.RowHeadersVisible = false;
        }

        private void WczytajUprawnienia()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    // SCENARIUSZ GŁÓWNY pkt. 2 + ALTERNATYWNY A1 pkt. 4
                    string sqlData = @"
                        SELECT 
                            u.ID AS [ID],
                            u.Nazwa AS [Nazwa uprawnienia],
                            COUNT(uu.UzytkownikID) AS [Liczba użytkowników]
                        FROM Uprawnienia u
                        LEFT JOIN Uzytkownicy_Uprawnienia uu ON u.ID = uu.UprawnienieID
                        WHERE (@Query = '' OR u.Nazwa LIKE @QueryLike)
                        GROUP BY u.ID, u.Nazwa
                        ORDER BY u.Nazwa";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        cmd.Parameters.AddWithValue("@Query", searchQuery);
                        cmd.Parameters.AddWithValue("@QueryLike", "%" + searchQuery + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgv_permissions.DataSource = dt;

                        if (dgv_permissions.Columns["ID"] != null)
                            dgv_permissions.Columns["ID"].Visible = false;

                        lbl_count.Text = $"Znaleziono: {dt.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchQuery = txt_search_permission.Text.Trim();
            WczytajUprawnienia();
        }

        private void txt_search_permission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search_Click(sender, e);
        }

        private void dgv_permissions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Przejście do US #3 - lista użytkowników z tym uprawnieniem
            if (e.RowIndex >= 0)
            {
                int permissionId = (int)dgv_permissions.Rows[e.RowIndex].Cells["ID"].Value;
                string permissionName = dgv_permissions.Rows[e.RowIndex].Cells["Nazwa uprawnienia"].Value.ToString();

                Form parentForm = this.FindForm();
                if (parentForm is Form1 mainForm)
                {
                    mainForm.PokazUzytkownikowZUprawnieniem(permissionId, permissionName);
                }
            }
        }

    }
}