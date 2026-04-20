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

                    // 1. Sprawdzanie unikalności danych kluczowych
                    // Metoda ValueExists musi obsługiwać parametry, aby zapobiec SQL Injection
                    if (ValueExists(conn, "Login", txt_login.Text.Trim()) ||
                        ValueExists(conn, "PESEL", txt_PESEL.Text.Trim()) ||
                        ValueExists(conn, "Email", txt_mail.Text.Trim()))
                    {
                        MessageBox.Show("Użytkownik z podanym loginem, numerem PESEL lub adresem e-mail już istnieje w systemie.",
                                        "Błąd unikalności", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Przygotowanie danych do zapisu
                    string hasloTymczasowe = Walidator.GenerujHasloSystemowe();
                    string hasloHash = hasloTymczasowe;
                    string plec = cb_gender.SelectedItem.ToString() == "Mężczyzna" ? "M" : "K";

                    // Generowanie numeru karty (zmienna lokalna do komunikatu)
                    string nrKarty = "LIB-" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();

                    // 3. Obsługa znormalizowanej tabeli adresowej
                    // Pobieramy ID z tabeli słownikowej lub dodajemy nowy wpis, jeśli nie istnieje
                    int miejscowoscKodId = PobierzLubDodajKodIMiejscowosc(conn, txt_zip_code.Text.Trim(), txt_town.Text.Trim());

                    // 4. Zapytanie SQL dostosowane do aktualnej struktury tabeli Uzytkownicy
                    const string sql = @"
                INSERT INTO Uzytkownicy 
                (Login, HasloHash, Imie, Nazwisko, MiejscowoscKodID, Ulica, NumerPosesji, NumerLokalu, 
                 PESEL, DataUrodzenia, Plec, Email, Telefon, CzyZapomniany, CzyZablokowany, LiczbaBlednychLogowan)
                OUTPUT INSERTED.ID
                VALUES 
                (@Login, @Haslo, @Imie, @Nazwisko, @MiejscowoscKodID, @Ulica, @NumerPosesji, @NumerLokalu, 
                 @PESEL, @DataUrodzenia, @Plec, @Email, @Telefon, 0, 0, 0);";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Parametry tekstowe i liczbowe
                        cmd.Parameters.Add("@Login", SqlDbType.NVarChar).Value = txt_login.Text.Trim();
                        cmd.Parameters.Add("@Haslo", SqlDbType.NVarChar).Value = hasloHash;
                        cmd.Parameters.Add("@Imie", SqlDbType.NVarChar).Value = txt_name.Text.Trim();
                        cmd.Parameters.Add("@Nazwisko", SqlDbType.NVarChar).Value = txt_surname.Text.Trim();
                        cmd.Parameters.Add("@MiejscowoscKodID", SqlDbType.Int).Value = miejscowoscKodId;

                        // Obsługa pól opcjonalnych (NULL w bazie)
                        cmd.Parameters.Add("@Ulica", SqlDbType.NVarChar).Value =
                            string.IsNullOrWhiteSpace(txt_street.Text) ? DBNull.Value : (object)txt_street.Text.Trim();

                        cmd.Parameters.Add("@NumerPosesji", SqlDbType.NVarChar).Value = txt_property_number.Text.Trim();

                        cmd.Parameters.Add("@NumerLokalu", SqlDbType.NVarChar).Value =
                            string.IsNullOrWhiteSpace(txtlbl_apartment_number.Text) ? DBNull.Value : (object)txtlbl_apartment_number.Text.Trim();

                        // Dane wrażliwe i formatowane
                        cmd.Parameters.Add("@PESEL", SqlDbType.Char, 11).Value = txt_PESEL.Text.Trim();
                        cmd.Parameters.Add("@DataUrodzenia", SqlDbType.Date).Value = DateTime.Parse(txt_birth_date.Text.Trim());
                        cmd.Parameters.Add("@Plec", SqlDbType.Char, 1).Value = plec;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txt_mail.Text.Trim();
                        cmd.Parameters.Add("@Telefon", SqlDbType.VarChar, 9).Value = txt_phone_number.Text.Trim();

                        int nowyUzytkownikId = (int)cmd.ExecuteScalar(); // Pobieramy ID nowo dodanego użytkownika

                        // Automatyczne przypisanie roli "Czytelnik"
                        PrzypisRoleCzytelnik(conn, nowyUzytkownikId);
                    }

                    MessageBox.Show($"Użytkownik został pomyślnie dodany!\nNr karty bibliotecznej: {nrKarty}",
                "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Wysyłka hasła tymczasowego na email nowego użytkownika
                    WyslijHasloNaEmail(txt_mail.Text.Trim(), txt_login.Text.Trim(), hasloTymczasowe);

                    WyczyscFormularz();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędny format daty urodzenia.", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                // Obsługa błędów naruszenia kluczy/constraintów z bazy danych
                MessageBox.Show($"Błąd bazy danych ({ex.Number}): {ex.Message}", "Błąd SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //WALIDACJA 

        private bool WalidujFormularz()
        {
            bool isValid = true;
            error_add_user_form.Clear();
            ResetFieldColors();

            // 1. Sprawdzanie pustych pól podstawowych (bez daty, peselu i numerów - to robi walidator)
            TextBox[] required = { txt_login, txt_name, txt_surname, txt_town };
            foreach (var tb in required)
            {
                if (string.IsNullOrWhiteSpace(tb.Text)) { OznaczBlad(tb, "Pole wymagane"); isValid = false; }
            }

            if (cb_gender.SelectedIndex == -1)
            {
                error_add_user_form.SetError(cb_gender, "Wybierz płeć");
                isValid = false;
            }

            // 2. Data Urodzenia i PESEL (Najpierw data, potem PESEL w oparciu o datę)
            DateTime dataUr;
            if (!Walidator.SprawdzDateUrodzenia(txt_birth_date.Text, out dataUr))
            {
                OznaczBlad(txt_birth_date, "Niepoprawna data (zły format lub data z przyszłości)");
                isValid = false;
            }
            else if (cb_gender.SelectedIndex != -1) // Jeśli data i płeć są OK, sprawdzamy PESEL
            {
                if (!Walidator.WalidujScislyPESEL(txt_PESEL.Text.Trim(), cb_gender.SelectedItem.ToString(), dataUr))
                {
                    OznaczBlad(txt_PESEL, "PESEL niezgodny z datą, płcią lub błędna cyfra kontrolna");
                    isValid = false;
                }
            }

            // 3. Dane kontaktowe i adresowe
            if (!Walidator.SprawdzEmail(txt_mail.Text))
            { OznaczBlad(txt_mail, "Błędny format e-mail"); isValid = false; }

            if (!Walidator.SprawdzTelefon(txt_phone_number.Text))
            { OznaczBlad(txt_phone_number, "Telefon musi mieć dokładnie 9 cyfr"); isValid = false; }

            if (!Walidator.SprawdzKodPocztowy(txt_zip_code.Text))
            { OznaczBlad(txt_zip_code, "Format XX-XXX"); isValid = false; }

            // 4. Numery domów (Posesja = wymagana (false), Lokal = opcjonalny (true))
            if (!Walidator.SprawdzNumer(txt_property_number.Text, false))
            { OznaczBlad(txt_property_number, "Błędny numer posesji (max 10 znaków)"); isValid = false; }

            if (!Walidator.SprawdzNumer(txtlbl_apartment_number.Text, true))
            { OznaczBlad(txtlbl_apartment_number, "Błędny format numeru lokalu"); isValid = false; }

            return isValid;
        }

        // POMOCNICZE
        private void WyczyscFormularz()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox tb)
                {
                    tb.Clear();
                }
                else if (ctrl is MaskedTextBox mtb)
                {
                    mtb.Clear();
                }
            }
            cb_gender.SelectedIndex = -1;
            ResetFieldColors();
            error_add_user_form.Clear();
        }

        private void OznaczBlad(Control ctrl, string msg)
        {
            ctrl.BackColor = Color.MistyRose; // system podświetla pole na czerwono
            error_add_user_form.SetError(ctrl, msg);
        }

        private void ResetFieldColors()
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox) ctrl.BackColor = SystemColors.Window;
        }

        private bool ValueExists(SqlConnection conn, string column, string value)
        {
            // Zabezpieczenie przed nieprawidłowymi nazwami kolumn
            string[] allowedColumns = { "Login", "PESEL", "Email" };
            if (!allowedColumns.Contains(column)) return false;

            using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(1) FROM Uzytkownicy WHERE {column} = @Val", conn))
            {
                cmd.Parameters.AddWithValue("@Val", value);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private int PobierzLubDodajKodIMiejscowosc(SqlConnection conn, string kodPocztowy, string miasto)
        {
            // Sprawdź czy para Kod + Miasto już istnieje
            string selectSql = "SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy = @Kod AND Miejscowosc = @Miasto";
            using (SqlCommand cmd = new SqlCommand(selectSql, conn))
            {
                cmd.Parameters.AddWithValue("@Kod", kodPocztowy);
                cmd.Parameters.AddWithValue("@Miasto", miasto);
                object res = cmd.ExecuteScalar();
                if (res != null) return (int)res;
            }

            // Jeśli nie istnieje, dodaj nowy i zwróć wygenerowane ID
            string insertSql = "INSERT INTO KodyPocztowe_Miejscowosci (KodPocztowy, Miejscowosc) OUTPUT INSERTED.ID VALUES (@Kod, @Miasto)";
            using (SqlCommand cmd = new SqlCommand(insertSql, conn))
            {
                cmd.Parameters.AddWithValue("@Kod", kodPocztowy);
                cmd.Parameters.AddWithValue("@Miasto", miasto);
                return (int)cmd.ExecuteScalar();
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

        private void WyslijHasloNaEmail(string email, string login, string hasloTymczasowe)
        {
            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
                int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
                string smtpUser = ConfigurationManager.AppSettings["SmtpUser"];
                string smtpPass = ConfigurationManager.AppSettings["SmtpPass"];

                using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(smtpHost, smtpPort))
                {
                    smtp.EnableSsl = false; // Mailtrap sandbox nie wymaga SSL na porcie 2525
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false; // WAŻNE: musi być przed Credentials
                    smtp.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);
                    smtp.Timeout = 10000;

                    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage
                    {
                        From = new System.Net.Mail.MailAddress("noreply@biblioteka.pl", "System Biblioteki"),
                        Subject = "Witaj w systemie biblioteki – Twoje dane logowania",
                        Body = $"Witaj {login},\n\n" +
                                     $"Twoje konto zostało utworzone.\n\n" +
                                     $"Login: {login}\n" +
                                     $"Hasło tymczasowe: {hasloTymczasowe}\n\n" +
                                     $"Przy pierwszym logowaniu zostaniesz poproszony o zmianę hasła.\n\n" +
                                     $"Pozdrawiamy,\nSystem Biblioteki",
                        IsBodyHtml = false
                    };
                    msg.To.Add(email);
                    smtp.Send(msg);
                }
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                MessageBox.Show(
                    "Użytkownik został dodany, ale nie udało się wysłać e-maila z hasłem.\n" +
                    "Skontaktuj się z administratorem systemu.\n\n" +
                    $"Szczegóły: {ex.StatusCode} – {ex.Message}",
                    "Błąd wysyłki e-mail",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Automatycznie przypisuje nowemu użytkownikowi rolę "Czytelnik"
        /// </summary>
        private void PrzypisRoleCzytelnik(SqlConnection conn, int uzytkownikId)
        {
            // 1. Pobierz ID roli "Czytelnik" z tabeli Uprawnienia
            string selectRolaId = "SELECT ID FROM Uprawnienia WHERE Nazwa = @NazwaRoli";
            int? rolaId = null;

            using (SqlCommand cmdRola = new SqlCommand(selectRolaId, conn))
            {
                cmdRola.Parameters.Add("@NazwaRoli", SqlDbType.NVarChar).Value = "Czytelnik";
                object result = cmdRola.ExecuteScalar();

                if (result != null)
                    rolaId = (int)result;
            }

            // 2. Jeśli rola "Czytelnik" istnieje, przypisz ją użytkownikowi
            if (rolaId.HasValue)
            {
                string insertUprawnienie = @"
                    INSERT INTO Uzytkownicy_Uprawnienia (UzytkownikID, UprawnienieID)
                    VALUES (@UzytkownikID, @UprawnienieID)";

                using (SqlCommand cmdUprawnienie = new SqlCommand(insertUprawnienie, conn))
                {
                    cmdUprawnienie.Parameters.Add("@UzytkownikID", SqlDbType.Int).Value = uzytkownikId;
                    cmdUprawnienie.Parameters.Add("@UprawnienieID", SqlDbType.Int).Value = rolaId.Value;
                    cmdUprawnienie.ExecuteNonQuery();
                }
            }
            else
            {
                // Jeśli rola "Czytelnik" nie istnieje w bazie, wyświetl ostrzeżenie
                MessageBox.Show(
                    "Uwaga: Rola 'Czytelnik' nie została znaleziona w bazie danych. Użytkownik został dodany bez roli.",
                    "Ostrzeżenie",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }
    }
}