using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
            
        }

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            // Szukamy formularza nadrzędnego (Form1)
            Form parentForm = this.FindForm();

            if (parentForm is Form1 mainForm)
            {
                // Wywołujemy stworzoną wcześniej metodę powrotu
                mainForm.PowrotDoMenuGlownego();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            error_add_user_form.Clear();

            if (!ValidateForm())
                return;

            try
            {
                char plec = cb_gender.SelectedItem.ToString() == "Mężczyzna" ? 'M' : 'K';

                // Hasło domyślne = hash PESELu (czytelnik zmienia przy pierwszym logowaniu)
                string hasloHash = HashSHA256(txt_PESEL.Text.Trim());

                using (var conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    // 1. Sprawdź unikalność
                    if (ValueExists(conn, "Login", txt_login.Text.Trim()))
                    { SetError(txt_login, "Ten login jest już zajęty."); return; }

                    if (ValueExists(conn, "PESEL", txt_PESEL.Text.Trim()))
                    { SetError(txt_PESEL, "Ten PESEL jest już zarejestrowany."); return; }

                    if (ValueExists(conn, "Email", txt_mail.Text.Trim()))
                    { SetError(txt_mail, "Ten e-mail jest już zarejestrowany."); return; }

                    // 2. INSERT użytkownika
                    const string sqlInsert = @"
                        INSERT INTO Uzytkownicy
                            (Login, HasloHash, Imie, Nazwisko,
                             Miejscowosc, KodPocztowy, Ulica, NumerPosesji, NumerLokalu,
                             PESEL, DataUrodzenia, Plec, Email, Telefon)
                        VALUES
                            (@Login, @Haslo, @Imie, @Nazwisko,
                             @Miejscowosc, @KodPocztowy, @Ulica, @NumerPosesji, @NumerLokalu,
                             @PESEL, @DataUrodzenia, @Plec, @Email, @Telefon);";

                    using (var cmd = new SqlCommand(sqlInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Login", txt_login.Text.Trim());
                        cmd.Parameters.AddWithValue("@Haslo", hasloHash);
                        cmd.Parameters.AddWithValue("@Imie", txt_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nazwisko", txt_surname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Miejscowosc", txt_town.Text.Trim());
                        cmd.Parameters.AddWithValue("@KodPocztowy", txt_zip_code.Text.Trim());
                        cmd.Parameters.AddWithValue("@Ulica", NullIfEmpty(txt_street.Text));
                        cmd.Parameters.AddWithValue("@NumerPosesji", txt_property_number.Text.Trim());
                        cmd.Parameters.AddWithValue("@NumerLokalu", NullIfEmpty(txtlbl_apartment_number.Text));
                        cmd.Parameters.AddWithValue("@PESEL", txt_PESEL.Text.Trim());
                        cmd.Parameters.AddWithValue("@DataUrodzenia", DateTime.Parse(txt_birth_date.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Plec", plec.ToString());
                        cmd.Parameters.AddWithValue("@Email", txt_mail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telefon", txt_phone_number.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Przypisz rolę Czytelnik
                    const string sqlRola = @"
                        INSERT INTO Uzytkownicy_Uprawnienia (UzytkownikID, UprawnienieID)
                        SELECT u.ID, p.ID
                        FROM Uzytkownicy u, Uprawnienia p
                        WHERE u.Login = @Login AND p.Nazwa = 'Czytelnik';";

                    using (var cmd = new SqlCommand(sqlRola, conn))
                    {
                        cmd.Parameters.AddWithValue("@Login", txt_login.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                // Sukces — komunikat i wyczyszczenie formularza
                MessageBox.Show(
                    $"Użytkownik '{txt_login.Text.Trim()}' został pomyślnie dodany do bazy.",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                btn_anuluj_Click(sender, e);
            }
            catch (Exception ex)
            {
                // Błąd — formularz zostaje, użytkownik może poprawić dane
                MessageBox.Show(
                    $"Błąd podczas dodawania użytkownika:\n{ex.Message}",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txt_login.Text))
            { SetError(txt_login, "Login jest wymagany."); ok = false; }

            if (string.IsNullOrWhiteSpace(txt_name.Text))
            { SetError(txt_name, "Imię jest wymagane."); ok = false; }

            if (string.IsNullOrWhiteSpace(txt_surname.Text))
            { SetError(txt_surname, "Nazwisko jest wymagane."); ok = false; }

            if (!Regex.IsMatch(txt_PESEL.Text.Trim(), @"^\d{11}$"))
            { SetError(txt_PESEL, "PESEL musi mieć dokładnie 11 cyfr."); ok = false; }

            if (!DateTime.TryParse(txt_birth_date.Text.Trim(), out _))
            { SetError(txt_birth_date, "Podaj datę w formacie RRRR-MM-DD."); ok = false; }

            if (!Regex.IsMatch(txt_mail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { SetError(txt_mail, "Podaj poprawny adres e-mail."); ok = false; }

            if (!Regex.IsMatch(txt_phone_number.Text.Trim(), @"^\d{9}$"))
            { SetError(txt_phone_number, "Telefon musi składać się z 9 cyfr."); ok = false; }

            if (string.IsNullOrWhiteSpace(txt_town.Text))
            { SetError(txt_town, "Miejscowość jest wymagana."); ok = false; }

            if (!Regex.IsMatch(txt_zip_code.Text.Trim(), @"^\d{2}-\d{3}$"))
            { SetError(txt_zip_code, "Kod pocztowy w formacie XX-XXX."); ok = false; }

            if (string.IsNullOrWhiteSpace(txt_property_number.Text))
            { SetError(txt_property_number, "Numer posesji jest wymagany."); ok = false; }

            if (cb_gender.SelectedItem == null)
            {
                SetError(cb_gender, "Wybierz płeć.");
                ok = false;
            }

            return ok;
        }
        private bool ValueExists(SqlConnection conn, string column, string value)
        {
            using (var cmd = new SqlCommand(
                $"SELECT COUNT(1) FROM Uzytkownicy WHERE [{column}] = @Val", conn))
            {
                cmd.Parameters.AddWithValue("@Val", value);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void SetError(Control ctrl, string message)
            => error_add_user_form.SetError(ctrl, message);

        private static object NullIfEmpty(string value)
            => string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value.Trim();

        private static string HashSHA256(string input)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        
    }

}


