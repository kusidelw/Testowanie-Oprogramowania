using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Biblioteka.Models;

namespace Biblioteka
{
    public partial class UCUsersWithPermission : UserControl
    {
        private string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private int _permissionId;

        public UCUsersWithPermission()
        {
            InitializeComponent();
            KonfigurujCheckListBox();
        }

        private void KonfigurujCheckListBox()
        {

            chLB_User_With_Role.CheckOnClick = true;
            chbl_UserWIthout_role.CheckOnClick = true;
        }

        public void ZaladujDane(int permissionId, string permissionName)
        {
            _permissionId = permissionId;
            lbl_title.Text = $"UŻYTKOWNICY O PODANEJ ROLI: {permissionName}";

            WczytajUzytkownikowZUprawnieniem();
            WczytajUzytkownikowBezUprawnienia();
        }

        private void WczytajUzytkownikowZUprawnieniem()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    string sqlData = @"
                        SELECT 
                            u.ID,
                            u.Login,
                            (u.Imie + ' ' + u.Nazwisko) AS ImieNazwisko,
                            u.Email
                        FROM Uzytkownicy u
                        INNER JOIN Uzytkownicy_Uprawnienia uu ON u.ID = uu.UzytkownikID
                        WHERE uu.UprawnienieID = @permId
                        ORDER BY u.Nazwisko, u.Imie";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        cmd.Parameters.AddWithValue("@permId", _permissionId);

                        chLB_User_With_Role.Items.Clear();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                var user = new UzytkownikListItem
                                {
                                    ID = (int)reader["ID"],
                                    Login = reader["Login"].ToString(),
                                    ImieNazwisko = reader["ImieNazwisko"].ToString(),
                                    Email = reader["Email"].ToString()
                                };

                                chLB_User_With_Role.Items.Add(user);
                                count++;
                            }

                            lbl_count.Text = $"Liczba: {count} użytkowników z rolą";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania użytkowników: " + ex.Message,
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WczytajUzytkownikowBezUprawnienia()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    string sqlData = @"
                        SELECT 
                            u.ID,
                            u.Login,
                            (u.Imie + ' ' + u.Nazwisko) AS ImieNazwisko,
                            u.Email
                        FROM Uzytkownicy u
                        WHERE u.ID NOT IN (
                            SELECT UzytkownikID 
                            FROM Uzytkownicy_Uprawnienia 
                            WHERE UprawnienieID = @permId
                        )
                        ORDER BY u.Nazwisko, u.Imie";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        cmd.Parameters.AddWithValue("@permId", _permissionId);

                        chbl_UserWIthout_role.Items.Clear();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = new UzytkownikListItem
                                {
                                    ID = (int)reader["ID"],
                                    Login = reader["Login"].ToString(),
                                    ImieNazwisko = reader["ImieNazwisko"].ToString(),
                                    Email = reader["Email"].ToString()
                                };

                                chbl_UserWIthout_role.Items.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania użytkowników: " + ex.Message,
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Add_Role_Click(object sender, EventArgs e)
        {
            try
            {
                var zaznaczeni = chbl_UserWIthout_role.CheckedItems.Cast<UzytkownikListItem>().ToList();

                if (!PermissionValidator.CzyZaznaczonoUzytkownikow(zaznaczeni.Count))
                {
                    MessageBox.Show("Nie zaznaczono żadnego użytkownika.",
                        "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result = MessageBox.Show(
                    $"Czy na pewno chcesz przypisać role {zaznaczeni.Count} użytkownikom?",
                    "Potwierdzenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                int dodanych = 0;
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (var user in zaznaczeni)
                            {
                                string insertQuery = @"
                                    INSERT INTO Uzytkownicy_Uprawnienia (UzytkownikID, UprawnienieID)
                                    VALUES (@userId, @permId)";

                                using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@userId", user.ID);
                                    cmd.Parameters.AddWithValue("@permId", _permissionId);
                                    cmd.ExecuteNonQuery();
                                    dodanych++;
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show(
                                $"Pomyślnie przypisano rolę {dodanych} użytkownikom!",
                                "Sukces",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            WczytajUzytkownikowZUprawnieniem();
                            WczytajUzytkownikowBezUprawnienia();
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
                    "Błąd podczas przypisywania ról: " + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_Remove_Role_Click(object sender, EventArgs e)
        {
            try
            {
                var zaznaczeni = chLB_User_With_Role.CheckedItems.Cast<UzytkownikListItem>().ToList();

                if (!PermissionValidator.CzyZaznaczonoUzytkownikow(zaznaczeni.Count))
                {
                    MessageBox.Show("Nie zaznaczono żadnego użytkownika.",
                        "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result = MessageBox.Show(
                    $"Czy na pewno chcesz odebrać rolę {zaznaczeni.Count} użytkownikom?",
                    "Potwierdzenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                int usunietych = 0;
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (var user in zaznaczeni)
                            {
                                string deleteQuery = @"
                                    DELETE FROM Uzytkownicy_Uprawnienia 
                                    WHERE UzytkownikID = @userId AND UprawnienieID = @permId";

                                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@userId", user.ID);
                                    cmd.Parameters.AddWithValue("@permId", _permissionId);
                                    cmd.ExecuteNonQuery();
                                    usunietych++;
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show(
                                $"Pomyślnie odebrano rolę {usunietych} użytkownikom!",
                                "Sukces",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            WczytajUzytkownikowZUprawnieniem();
                            WczytajUzytkownikowBezUprawnienia();
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
                    "Błąd podczas odbierania roli: " + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void chLB_User_With_Role_DoubleClick(object sender, EventArgs e)
        {
            if (chLB_User_With_Role.SelectedItem != null)
            {
                var selectedUser = chLB_User_With_Role.SelectedItem as UzytkownikListItem;
                if (selectedUser != null)
                {
                    PrzejdzDoKartyUzytkownika(selectedUser.ID);
                }
            }
        }

        private void chbl_UserWIthout_role_DoubleClick(object sender, EventArgs e)
        {
            if (chbl_UserWIthout_role.SelectedItem != null)
            {
                var selectedUser = chbl_UserWIthout_role.SelectedItem as UzytkownikListItem;
                if (selectedUser != null)
                {
                    PrzejdzDoKartyUzytkownika(selectedUser.ID);
                }
            }
        }

        private void PrzejdzDoKartyUzytkownika(int userId)
        {
            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
            {
                mainForm.PokazKarteUzytkownika(userId);
            }
        }
    }
}