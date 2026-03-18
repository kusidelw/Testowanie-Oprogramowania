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
    public partial class UCEditData : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private int currentUserId;

        public UCEditData()
        {
            InitializeComponent();
        }

        public void ZaladujDaneDoEdycji(int userId)
        {
            currentUserId = userId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Uzytkownicy WHERE ID = @Id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_login.Text = reader["Login"].ToString();
                                txt_name.Text = reader["Imie"].ToString();
                                txt_surname.Text = reader["Nazwisko"].ToString();
                                txt_PESEL.Text = reader["PESEL"].ToString();
                                txt_birth_date.Text = Convert.ToDateTime(reader["DataUrodzenia"]).ToString("yyyy-MM-dd");
                                txt_mail.Text = reader["Email"].ToString();
                                txt_phone_number.Text = reader["Telefon"].ToString();
                                txt_town.Text = reader["Miejscowosc"].ToString();
                                txt_zip_code.Text = reader["KodPocztowy"].ToString();
                                txt_street.Text = reader["Ulica"].ToString();
                                txt_property_number.Text = reader["NumerPosesji"].ToString();
                                txtlbl_apartment_number.Text = reader["NumerLokalu"] == DBNull.Value ? "" : reader["NumerLokalu"].ToString();

                                string plec = reader["Plec"].ToString();
                                txt_gender.Text = plec == "M" ? "Mężczyzna" : "Kobieta";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_changes_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE Uzytkownicy SET 
                                    Login = @Login, Imie = @Imie, Nazwisko = @Nazwisko, 
                                    PESEL = @PESEL, DataUrodzenia = @DataUrodzenia, 
                                    Email = @Email, Telefon = @Telefon, Miejscowosc = @Miejscowosc, 
                                    KodPocztowy = @KodPocztowy, Ulica = @Ulica, 
                                    NumerPosesji = @NumerPosesji, NumerLokalu = @NumerLokalu, Plec = @Plec
                                   WHERE ID = @Id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Login", txt_login.Text);
                        cmd.Parameters.AddWithValue("@Imie", txt_name.Text);
                        cmd.Parameters.AddWithValue("@Nazwisko", txt_surname.Text);
                        cmd.Parameters.AddWithValue("@PESEL", txt_PESEL.Text);
                        cmd.Parameters.AddWithValue("@DataUrodzenia", DateTime.Parse(txt_birth_date.Text));
                        cmd.Parameters.AddWithValue("@Email", txt_mail.Text);
                        cmd.Parameters.AddWithValue("@Telefon", txt_phone_number.Text);
                        cmd.Parameters.AddWithValue("@Miejscowosc", txt_town.Text);
                        cmd.Parameters.AddWithValue("@KodPocztowy", txt_zip_code.Text);
                        cmd.Parameters.AddWithValue("@Ulica", txt_street.Text);
                        cmd.Parameters.AddWithValue("@NumerPosesji", txt_property_number.Text);
                        cmd.Parameters.AddWithValue("@NumerLokalu", string.IsNullOrEmpty(txtlbl_apartment_number.Text) ? (object)DBNull.Value : txtlbl_apartment_number.Text);
                        cmd.Parameters.AddWithValue("@Plec", txt_gender.Text.ToLower().StartsWith("m") ? "M" : "K");
                        cmd.Parameters.AddWithValue("@Id", currentUserId);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Dane zostały zaktualizowane pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 1. Czyścimy formularz
                        WyczyscFormularz();

                        // 2. Wracamy do widoku ShowUsers
                        WrocDoWidokuShowUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_changing_Click(object sender, EventArgs e)
        {
            WyczyscFormularz();
            WrocDoWidokuShowUsers();
        }

        private void WrocDoWidokuShowUsers()
        {
            var form1 = this.ParentForm as Form1;
            if (form1 != null)
            {
                // Wywołujemy metodę, która w Form1 odpowiada za pokazanie listy (ucShowUsers)
                // Zakładając, że w Form1 masz taką metodę lub dostęp do przycisku
                form1.PokazWidokZeStanem(new UCShowUsers());
                // LUB jeśli masz instancję w Form1:
                // form1.btn_show_users_Click(null, null);
            }
        }

        private void WyczyscFormularz()
        {
            currentUserId = 0;

            // Rekurencyjne czyszczenie wszystkich TextBoxów
            Action<Control.ControlCollection> clearControls = null;
            clearControls = (controls) =>
            {
                foreach (Control c in controls)
                {
                    if (c is TextBox textBox)
                        textBox.Clear();

                    if (c.HasChildren)
                        clearControls(c.Controls);
                }
            };

            clearControls(this.Controls);

            // Dodatkowe pola, jeśli nie zostały złapane przez pętlę
            txtlbl_apartment_number.Text = "";
            txt_gender.Text = "";
        }
    }
}