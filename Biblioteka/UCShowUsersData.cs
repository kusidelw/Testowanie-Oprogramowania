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
using Biblioteka.Models;

namespace Biblioteka
{
    public partial class UCShowUsersData : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        private int currentUserId;
        private bool czyUzytkownikZapomniany = false;
        private List<int> originalPermissionIds = new List<int>(); // Oryginalne uprawnienia do porównania

        public UCShowUsersData()
        {
            InitializeComponent();
            lbl_anonymization_message.Visible = false;
        }

        public void ZaladujDaneUzytkownika(int userId)
        {
            currentUserId = userId;
            string query = @"
                SELECT u.*, k.KodPocztowy, k.Miejscowosc 
                FROM Uzytkownicy u
                LEFT JOIN KodyPocztowe_Miejscowosci k ON u.MiejscowoscKodID = k.ID
                WHERE u.ID = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", userId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            czyUzytkownikZapomniany = Convert.ToBoolean(reader["CzyZapomniany"]);

                            if (czyUzytkownikZapomniany)
                            {
                                //WIDOK RODO DLA ZAPOMNIANEGO UŻYTKOWNIKA
                                lbl_anonymization_message.Visible = true;
                                btn_edit_data.Enabled = false;
                                btn_edit_data.BackColor = Color.Gray;

                                string rodoMsg = "*** ZANONIMIZOWANE ***";

                                txt_login.Text = reader["Login"].ToString(); 
                                txt_name.Text = rodoMsg;
                                txt_surname.Text = rodoMsg;
                                txt_PESEL.Text = rodoMsg;
                                txt_birth_date.Text = rodoMsg;
                                txt_gender.Text = rodoMsg;
                                txt_mail.Text = rodoMsg;
                                txt_phone_number.Text = rodoMsg;
                                txt_street.Text = rodoMsg;
                                txt_zip_code.Text = rodoMsg;
                                txt_town.Text = rodoMsg;
                                txt_property_number.Text = rodoMsg;
                                txtlbl_apartment_number.Text = rodoMsg;
                            }
                            else
                            {
                                //NORMALNY WIDOK
                                lbl_anonymization_message.Visible = false;
                                btn_edit_data.Enabled = true;
                                btn_edit_data.BackColor = Color.DarkSeaGreen;

                                txt_login.Text = reader["Login"].ToString();
                                txt_name.Text = reader["Imie"].ToString();
                                txt_surname.Text = reader["Nazwisko"].ToString();
                                txt_PESEL.Text = reader["PESEL"].ToString();
                                txt_birth_date.Text = Convert.ToDateTime(reader["DataUrodzenia"]).ToShortDateString();
                                txt_gender.Text = reader["Plec"].ToString() == "K" ? "Kobieta" : "Mężczyzna";
                                txt_mail.Text = reader["Email"].ToString();
                                txt_phone_number.Text = reader["Telefon"].ToString();
                                txt_street.Text = reader["Ulica"].ToString();
                                txt_zip_code.Text = reader["KodPocztowy"].ToString();
                                txt_town.Text = reader["Miejscowosc"].ToString();
                                txt_property_number.Text = reader["NumerPosesji"].ToString();
                                txtlbl_apartment_number.Text = reader["NumerLokalu"].ToString();
                            }
                        }
                    }
                }

                // Załaduj uprawnienia użytkownika
                ZaladujUprawnienia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Przycisk "Wróć do listy"
        private void btn_back_to_list_Click(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.FindForm();
            if (mainForm != null)
            {
                mainForm.WrocDoWyszukiwarki(); 
            }
        }

        // Przycisk "Edytuj dane"
        private void btn_edit_data_Click(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.FindForm();
            if (mainForm != null)
            {
                mainForm.PrzejdzDoEdycji(currentUserId); 
            }
        }

        private void ZaladujUprawnienia()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlAllPermissions = "SELECT ID, Nazwa FROM Uprawnienia ORDER BY Nazwa";
                    List<Uprawnienie> allPermissions = new List<Uprawnienie>();

                    using (SqlCommand cmd = new SqlCommand(sqlAllPermissions, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                allPermissions.Add(new Uprawnienie
                                {
                                    ID = (int)reader["ID"],
                                    Nazwa = reader["Nazwa"].ToString()
                                });
                            }
                        }
                    }

                    string sqlUserPermissions = @"
                        SELECT UprawnienieID 
                        FROM Uzytkownicy_Uprawnienia 
                        WHERE UzytkownikID = @uid";

                    List<int> currentPermissionIds = new List<int>();
                    using (SqlCommand cmd = new SqlCommand(sqlUserPermissions, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", currentUserId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                currentPermissionIds.Add((int)reader["UprawnienieID"]);
                            }
                        }
                    }

                    originalPermissionIds = new List<int>(currentPermissionIds);

                    clb_permissions.Items.Clear();
                    foreach (var perm in allPermissions)
                    {
                        int index = clb_permissions.Items.Add(perm);
                        clb_permissions.SetItemChecked(index, currentPermissionIds.Contains(perm.ID));
                    }

                    if (czyUzytkownikZapomniany)
                    {
                        clb_permissions.Enabled = false;
                    }
                    else
                    {
                        clb_permissions.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania uprawnień: " + ex.Message,
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> selectedPermissionIds = new List<int>();
                foreach (Uprawnienie item in clb_permissions.CheckedItems)
                {
                    selectedPermissionIds.Add(item.ID);
                }

                if (selectedPermissionIds.Count == 0)
                {
                    MessageBox.Show(
                        "Użytkownik musi posiadać co najmniej jedno uprawnienie.",
                        "Błąd walidacji",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                bool czyBylyZmiany = CzyBylyZmianyWUprawnieniach(selectedPermissionIds);

                if (!czyBylyZmiany)
                {
                    ZaladujUprawnienia();
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string deleteQuery = "DELETE FROM Uzytkownicy_Uprawnienia WHERE UzytkownikID = @uid";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@uid", currentUserId);
                                deleteCmd.ExecuteNonQuery();
                            }

                            foreach (int permId in selectedPermissionIds)
                            {
                                string insertQuery = @"
                                    INSERT INTO Uzytkownicy_Uprawnienia (UzytkownikID, UprawnienieID) 
                                    VALUES (@uid, @permId)";
                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@uid", currentUserId);
                                    insertCmd.Parameters.AddWithValue("@permId", permId);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show(
                                "Uprawnienia zostały zaktualizowane pomyślnie!",
                                "Sukces",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ZaladujUprawnienia();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd zapisu uprawnień: " + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ZaladujUprawnienia();
        }


        private bool CzyBylyZmianyWUprawnieniach(List<int> nowePrawnienia)
        {
            if (nowePrawnienia.Count != originalPermissionIds.Count)
                return true;

            List<int> sortedNew = nowePrawnienia.OrderBy(x => x).ToList();
            List<int> sortedOriginal = originalPermissionIds.OrderBy(x => x).ToList();

            for (int i = 0; i < sortedNew.Count; i++)
            {
                if (sortedNew[i] != sortedOriginal[i])
                    return true;
            }

            return false;
        }
    }
}