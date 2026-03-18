using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCAddUsers : UserControl
    {
        private string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        public UCAddUsers()
        {
            InitializeComponent();
            if (cb_gender.Items.Count == 0)
            {
                cb_gender.Items.Add("Mężczyzna");
                cb_gender.Items.Add("Kobieta");
            }
        }


        private void btn_anuluj_Click_1(object sender, EventArgs e)
        {
            WyczyscFormularz();
        }

        private void btnAU_create_user_Click(object sender, EventArgs e)
        {
            if (WalidujFormularz())
            {
                ZapiszUzytkownikaDoBazy();
            }
        }

        // --- LOGIKA BAZY DANYCH ---

        private void ZapiszUzytkownikaDoBazy()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    // Sprawdzanie unikalności
                    if (ValueExists(conn, "Login", txt_login.Text.Trim())) { OznaczBlad(txt_login, "Login zajęty"); return; }
                    if (ValueExists(conn, "PESEL", txt_PESEL.Text.Trim())) { OznaczBlad(txt_PESEL, "PESEL już istnieje"); return; }
                    if (ValueExists(conn, "Email", txt_mail.Text.Trim())) { OznaczBlad(txt_mail, "Email już istnieje"); return; }

                    string hasloHash = HashSHA256(txt_PESEL.Text.Trim());
                    string plec = cb_gender.SelectedItem.ToString() == "Mężczyzna" ? "M" : "K";

                    const string sql = @"
                        INSERT INTO Uzytkownicy 
                        (Login, HasloHash, Imie, Nazwisko, Miejscowosc, KodPocztowy, Ulica, NumerPosesji, NumerLokalu, PESEL, DataUrodzenia, Plec, Email, Telefon, CzyZapomniany)
                        VALUES 
                        (@Login, @Haslo, @Imie, @Nazwisko, @Miejscowosc, @KodPocztowy, @Ulica, @NumerPosesji, @NumerLokalu, @PESEL, @DataUrodzenia, @Plec, @Email, @Telefon, 0);";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Login", txt_login.Text.Trim());
                        cmd.Parameters.AddWithValue("@Haslo", hasloHash);
                        cmd.Parameters.AddWithValue("@Imie", txt_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nazwisko", txt_surname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Miejscowosc", txt_town.Text.Trim());
                        cmd.Parameters.AddWithValue("@KodPocztowy", txt_zip_code.Text.Trim());
                        cmd.Parameters.AddWithValue("@Ulica", string.IsNullOrWhiteSpace(txt_street.Text) ? (object)DBNull.Value : txt_street.Text.Trim());
                        cmd.Parameters.AddWithValue("@NumerPosesji", txt_property_number.Text.Trim());
                        cmd.Parameters.AddWithValue("@NumerLokalu", string.IsNullOrWhiteSpace(txtlbl_apartment_number.Text) ? (object)DBNull.Value : txtlbl_apartment_number.Text.Trim());
                        cmd.Parameters.AddWithValue("@PESEL", txt_PESEL.Text.Trim());
                        cmd.Parameters.AddWithValue("@DataUrodzenia", DateTime.Parse(txt_birth_date.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Plec", plec);
                        cmd.Parameters.AddWithValue("@Email", txt_mail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telefon", txt_phone_number.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Użytkownik został pomyślnie dodany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    WyczyscFormularz();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- WALIDACJA ---

        private bool WalidujFormularz()
        {
            bool isValid = true;
            error_add_user_form.Clear();
            ResetFieldColors();

            // Pola tekstowe wymagane (używamy Twoich NOWYCH nazw z Designera)
            TextBox[] required = { txt_login, txt_name, txt_surname, txt_town, txt_zip_code, txt_property_number, txt_birth_date };
            foreach (var tb in required)
            {
                if (string.IsNullOrWhiteSpace(tb.Text)) { OznaczBlad(tb, "Pole wymagane"); isValid = false; }
            }

            if (!isValid) return false;

            // PESEL (11 cyfr)
            if (!Regex.IsMatch(txt_PESEL.Text.Trim(), @"^\d{11}$"))
            {
                OznaczBlad(txt_PESEL, "PESEL musi mieć 11 cyfr");
                isValid = false;
            }

            // Data urodzenia (Czy to jest prawdziwa data wg kalendarza?)
            if (!DateTime.TryParse(txt_birth_date.Text.Trim(), out _))
            {
                OznaczBlad(txt_birth_date, "Podaj poprawną datę (np. 1990-05-20)");
                isValid = false;
            }

            // Email
            if (!Regex.IsMatch(txt_mail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                OznaczBlad(txt_mail, "Błędny format email");
                isValid = false;
            }

            // Telefon (9 cyfr)
            if (!Regex.IsMatch(txt_phone_number.Text.Trim(), @"^\d{9}$"))
            {
                OznaczBlad(txt_phone_number, "Wymagane 9 cyfr");
                isValid = false;
            }

            //Kod pocztowy (format XX-XXX)
            if (!Regex.IsMatch(txt_zip_code.Text.Trim(), @"^\d{2}-\d{3}$"))
            {
                OznaczBlad(txt_zip_code, "Kod pocztowy musi być w formacie XX-XXX (np. 00-123)");
                isValid = false;
            }

            // Płeć
            if (cb_gender.SelectedIndex == -1)
            {
                error_add_user_form.SetError(cb_gender, "Wybierz płeć");
                isValid = false;
            }

            return isValid;


        }

        // --- POMOCNICZE ---

        private void WyczyscFormularz()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox tb) tb.Clear();
            }
            cb_gender.SelectedIndex = -1;
            ResetFieldColors();
            error_add_user_form.Clear();
        }

        private void OznaczBlad(Control ctrl, string msg)
        {
            ctrl.BackColor = Color.MistyRose;
            error_add_user_form.SetError(ctrl, msg);
        }

        private void ResetFieldColors()
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox) ctrl.BackColor = SystemColors.Window;
        }

        private bool ValueExists(SqlConnection conn, string column, string value)
        {
            using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(1) FROM Uzytkownicy WHERE {column} = @Val", conn))
            {
                cmd.Parameters.AddWithValue("@Val", value);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private string HashSHA256(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}