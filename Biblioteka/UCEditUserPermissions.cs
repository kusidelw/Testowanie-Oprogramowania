using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Biblioteka.Models;

namespace Biblioteka
{
    public partial class UCEditUserPermissions : UserControl
    {
        private string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private int _userId;

        public UCEditUserPermissions()
        {
            InitializeComponent();
        }

        public void ZaladujDaneUzytkownika(int userId, string userName)
        {
            _userId = userId;
            lbl_user_name.Text = $"Użytkownik: {userName}";
            ZaladujUprawnienia();
        }

        private void ZaladujUprawnienia()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    // 1. Pobierz wszystkie uprawnienia
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

                    // 2. Pobierz aktualne uprawnienia użytkownika
                    string sqlUserPermissions = @"
                        SELECT UprawnienieID 
                        FROM Uzytkownicy_Uprawnienia 
                        WHERE UzytkownikID = @uid";

                    List<int> currentPermissionIds = new List<int>();
                    using (SqlCommand cmd = new SqlCommand(sqlUserPermissions, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                currentPermissionIds.Add((int)reader["UprawnienieID"]);
                            }
                        }
                    }

                    // 3. Wypełnij CheckedListBox
                    // SCENARIUSZ GŁÓWNY pkt. 2
                    clb_permissions.Items.Clear();
                    foreach (var perm in allPermissions)
                    {
                        int index = clb_permissions.Items.Add(perm);
                        clb_permissions.SetItemChecked(index, currentPermissionIds.Contains(perm.ID));
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
            // SCENARIUSZ GŁÓWNY pkt. 4-5
            try
            {
                // 1. Zbierz zaznaczone uprawnienia
                List<int> selectedPermissionIds = new List<int>();
                foreach (Uprawnienie item in clb_permissions.CheckedItems)
                {
                    selectedPermissionIds.Add(item.ID);
                }

                // 2. WALIDACJA BIZNESOWA - SCENARIUSZ WYJĄTKOWY E1
                if (selectedPermissionIds.Count == 0)
                {
                    bool czyZapomniany = CzyUzytkownikJestZapomniany(_userId);

                    if (!czyZapomniany)
                    {
                        MessageBox.Show(
                            "Użytkownik (poza zapomnianym) musi posiadać co najmniej jedno uprawnienie.",
                            "Błąd walidacji",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 3. Zapisz zmiany (TRANSAKCJA!)
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 3a. Usuń stare uprawnienia
                            string deleteQuery = "DELETE FROM Uzytkownicy_Uprawnienia WHERE UzytkownikID = @uid";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@uid", _userId);
                                deleteCmd.ExecuteNonQuery();
                            }

                            // 3b. Dodaj nowe uprawnienia
                            foreach (int permId in selectedPermissionIds)
                            {
                                string insertQuery = @"
                                    INSERT INTO Uzytkownicy_Uprawnienia (UzytkownikID, UprawnienieID) 
                                    VALUES (@uid, @permId)";
                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@uid", _userId);
                                    insertCmd.Parameters.AddWithValue("@permId", permId);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            // 4. Komunikat sukcesu (SCENARIUSZ GŁÓWNY pkt. 5)
                            MessageBox.Show("Zaktualizowano uprawnienia", "Sukces",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 5. Powrót
                            WrocDoPoprzedniegoEkranu();
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
                MessageBox.Show("Błąd zapisu: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // SCENARIUSZ ALTERNATYWNY A1 pkt. 4-5
            WrocDoPoprzedniegoEkranu();
        }

        private bool CzyUzytkownikJestZapomniany(int userId)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                string query = "SELECT CzyZapomniany FROM Uzytkownicy WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null && Convert.ToBoolean(result);
            }
        }

        private void WrocDoPoprzedniegoEkranu()
        {
            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
            {
                mainForm.PowrotDoMenuGlownego();
            }
        }

    }
}