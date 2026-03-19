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
using System.Text.RegularExpressions;

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
            //blokowanie pól, które nie powinny być edytowane według analizy wymagań
            txt_login.Enabled = false;
            txt_PESEL.Enabled = false;
            txt_birth_date.Enabled = false;
            txt_gender.Enabled = false;

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
            if (!WalidujFormularzEdycji())
            {
                MessageBox.Show("Formularz zawiera błędy. Popraw podświetlone pola.", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (CzyEmailZajety(conn, txt_mail.Text.Trim(), currentUserId))
                    {
                        MessageBox.Show("Podany adres e-mail jest już przypisany do innego użytkownika.", "Błąd unikalności", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string sql = @"UPDATE Uzytkownicy SET 
                                    Imie = @Imie, Nazwisko = @Nazwisko, 
                                    Email = @Email, Telefon = @Telefon, Miejscowosc = @Miejscowosc, 
                                    KodPocztowy = @KodPocztowy, Ulica = @Ulica, 
                                    NumerPosesji = @NumerPosesji, NumerLokalu = @NumerLokalu
                                   WHERE ID = @Id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Imie", txt_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nazwisko", txt_surname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txt_mail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telefon", txt_phone_number.Text.Trim());
                        cmd.Parameters.AddWithValue("@Miejscowosc", txt_town.Text.Trim());
                        cmd.Parameters.AddWithValue("@KodPocztowy", txt_zip_code.Text.Trim());
                        cmd.Parameters.AddWithValue("@Ulica", string.IsNullOrWhiteSpace(txt_street.Text) ? (object)DBNull.Value : txt_street.Text.Trim());
                        cmd.Parameters.AddWithValue("@NumerPosesji", txt_property_number.Text.Trim());
                        cmd.Parameters.AddWithValue("@NumerLokalu", string.IsNullOrWhiteSpace(txtlbl_apartment_number.Text) ? (object)DBNull.Value : txtlbl_apartment_number.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id", currentUserId);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Dane zostały zaktualizowane pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        WrocDoWidokuShowUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // WALIDACJA 
        private bool WalidujFormularzEdycji()
        {
            bool isValid = true;
            ResetFieldColors();

            // 1. Sprawdzanie pustych pól podstawowych (Imię, Nazwisko, Miejscowość)
            TextBox[] required = { txt_name, txt_surname, txt_town };
            foreach (var tb in required)
            {
                if (string.IsNullOrWhiteSpace(tb.Text)) { OznaczBlad(tb); isValid = false; }
            }

            // 2. Dane kontaktowe
            if (!Walidator.SprawdzEmail(txt_mail.Text)) { OznaczBlad(txt_mail); isValid = false; }
            if (!Walidator.SprawdzTelefon(txt_phone_number.Text)) { OznaczBlad(txt_phone_number); isValid = false; }
            if (!Walidator.SprawdzKodPocztowy(txt_zip_code.Text)) { OznaczBlad(txt_zip_code); isValid = false; }

            // 3. Posesja (wymagana - false) i Lokal (opcjonalny - true)
            if (!Walidator.SprawdzNumer(txt_property_number.Text, false)) { OznaczBlad(txt_property_number); isValid = false; }
            if (!Walidator.SprawdzNumer(txtlbl_apartment_number.Text, true)) { OznaczBlad(txtlbl_apartment_number); isValid = false; }

            return isValid;
        }

        //POMOCNICZE 

        private void OznaczBlad(Control ctrl)
        {
            // polegamy na podświetleniu kolorem
            ctrl.BackColor = Color.MistyRose;
        }

        private void ResetFieldColors()
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox && ctrl.Enabled) ctrl.BackColor = SystemColors.Window;
        }

        private bool CzyEmailZajety(SqlConnection conn, string email, int currentUserId)
        {
            string query = "SELECT COUNT(1) FROM Uzytkownicy WHERE Email = @Email AND ID != @UserId";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@UserId", currentUserId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void btn_cancel_changing_Click(object sender, EventArgs e)
        {
            WrocDoWidokuShowUsers();
        }

        private void WrocDoWidokuShowUsers()
        {
            var form1 = this.ParentForm as Form1;
            if (form1 != null)
            {
                //wracamy do użytkownika, którego właśnie edytowaliśmy
                form1.PokazKarteUzytkownika(currentUserId);
            }
        }

        /* chyba nie potrzebna żeby nie znikały dane jak user znów kliknie "Edytuj" z poziomu karty użytkownika, ale zostawiam na wszelki wypadek
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
        */
    }
}