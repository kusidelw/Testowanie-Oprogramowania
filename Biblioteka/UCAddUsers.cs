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

            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
            {
                mainForm.PowrotDoMenuGlownego(); // Powrót do menu
            }
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
                    if (ValueExists(conn, "Login", txt_login.Text.Trim()) ||
                        ValueExists(conn, "PESEL", txt_PESEL.Text.Trim()) ||
                        ValueExists(conn, "Email", txt_mail.Text.Trim()))
                    {
                        MessageBox.Show("Użytkownik już istnieje", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }
                    string hasloHash = HashSHA256(txt_PESEL.Text.Trim());
                    string plec = cb_gender.SelectedItem.ToString() == "Mężczyzna" ? "M" : "K";

                    string nrKarty = "LIB-" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();

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

                    MessageBox.Show($"Użytkownik został pomyślnie dodany!\nNr karty bibliotecznej: {nrKarty}", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            // Pola tekstowe wymagane 
            TextBox[] required = { txt_login, txt_name, txt_surname, txt_town, txt_zip_code, txt_property_number, txt_birth_date, txt_PESEL, txt_mail, txt_phone_number };
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
            DateTime dataUr;
            if (!DateTime.TryParse(txt_birth_date.Text.Trim(), out dataUr))
            {
                OznaczBlad(txt_birth_date, "Niepoprawny format daty");
                isValid = false;
            }
            else
            {
                // Walidacja ścisła 1 i E2: PESEL (Suma kontrolna, płeć, data)
                if (!WalidujScislyPESEL(txt_PESEL.Text.Trim(), cb_gender.SelectedItem.ToString(), dataUr))
                {
                    OznaczBlad(txt_PESEL, "E2: PESEL niezgodny z datą urodzenia, płcią lub błędna cyfra kontrolna");
                    isValid = false;
                }
            }

            // Email
            if (txt_mail.Text.Length > 255 || !Regex.IsMatch(txt_mail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                OznaczBlad(txt_mail, "E2: Błędny format e-mail");
                isValid = false;
            }

            // Telefon (9 cyfr)
            if (!Regex.IsMatch(txt_phone_number.Text.Trim(), @"^\d{9}$"))
            {
                OznaczBlad(txt_phone_number, "E2: Telefon musi mieć dokładnie 9 cyfr");
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

        // SPECJALNA WALIDACJA PESEL
        private bool WalidujScislyPESEL(string pesel, string plecFormularz, DateTime dataUr)
        {
            if (pesel.Length != 11 || !Regex.IsMatch(pesel, @"^\d{11}$")) return false;

            // 1. Suma kontrolna PESEL (oficjalny algorytm MSWiA)
            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int suma = 0;
            for (int i = 0; i < 10; i++) suma += int.Parse(pesel[i].ToString()) * wagi[i];
            int cyfraKontrolna = (10 - (suma % 10)) % 10;
            if (cyfraKontrolna != int.Parse(pesel[10].ToString())) return false;

            // 2. Płeć (Przedostatnia cyfra: nieparzyste=M, parzyste=K)
            int cyfraPlci = int.Parse(pesel[9].ToString());
            bool toKobieta = (cyfraPlci % 2 == 0);
            if ((plecFormularz == "Kobieta" && !toKobieta) || (plecFormularz == "Mężczyzna" && toKobieta)) return false;

            // 3. Zgodność z datą urodzenia
            int rok = dataUr.Year;
            int miesiac = dataUr.Month;
            int dzien = dataUr.Day;

            // Kodowanie stulecia w miesiącu PESEL
            if (rok >= 2000 && rok < 2100) miesiac += 20;
            else if (rok >= 1800 && rok < 1900) miesiac += 80;
            else if (rok >= 2100 && rok < 2200) miesiac += 40;
            else if (rok >= 2200 && rok < 2300) miesiac += 60;

            string peselData = $"{rok % 100:D2}{miesiac:D2}{dzien:D2}";
            if (pesel.Substring(0, 6) != peselData) return false;

            return true;
        }

        // POMOCNICZE
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
            ctrl.BackColor = Color.MistyRose; // E2: system podświetla pole na czerwono
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