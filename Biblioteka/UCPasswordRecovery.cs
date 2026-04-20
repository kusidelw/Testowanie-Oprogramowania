using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCPasswordRecovery : UserControl
    {
        private readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        public UCPasswordRecovery()
        {
            InitializeComponent();
            Error_msg.Text = "";
        }

        // ── ANULUJ ───────────────────────────────────────────────────────────────

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            // Scenariusz A1: powrót do ekranu logowania
            ReturnToLogin();
        }

        // ── WYŚLIJ ───────────────────────────────────────────────────────────────

        private void btn_send_Click(object sender, EventArgs e)
        {
            string login = txt_login.Text.Trim();
            string email = txt_email.Text.Trim();

            // Walidacja pustych pól
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(email))
            {
                ShowError("Proszę uzupełnić wszystkie pola.");
                return;
            }

            // Walidacja formatu email przez Walidator
            if (!Walidator.SprawdzEmail(email))
            {
                ShowError("Podaj poprawny adres e-mail.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Krok 1: Weryfikacja loginu i emaila (Scenariusz główny pkt. 3)
                    // Scenariusz E1: komunikat nie zdradza, które pole jest błędne
                    int? userId = GetUserIdIfValid(conn, login, email);

                    if (userId == null)
                    {
                        ShowError("Podane dane nie są zgodne z naszą bazą.");
                        return;
                    }

                    // Scenariusz E1 z GEN_HAS_SYS_1: blokada dla kont zapomnianych
                    if (IsCzyZapomniany(conn, userId.Value))
                    {
                        // Nie zdradzamy, że konto istnieje — ten sam komunikat co wyżej
                        ShowError("Podane dane nie są zgodne z naszą bazą.");
                        return;
                    }

                    // Krok 2: Generowanie hasła systemowego (GEN_HAS_SYS_1)
                    string noweHaslo = Walidator.GenerujHasloSystemowe();

                    // Krok 3: Zapis nowego hasła do bazy (w transakcji)
                    SaveNewPassword(conn, userId.Value, noweHaslo);

                    // Krok 4: Wysłanie hasła mailem (Scenariusz główny pkt. 4)
                    SendPasswordByEmail(email, noweHaslo);

                    MessageBox.Show(
                        "Nowe hasło zostało wysłane na podany adres e-mail.",
                        "Sukces",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ReturnToLogin();
                }
            }
            catch (SmtpException)
            {
                // Scenariusz A1 z GEN_HAS_SYS_1: błąd serwera pocztowego
                ShowError("Błąd wysyłki e-mail. Skontaktuj się z administratorem.");
            }
            catch (Exception ex)
            {
                ShowError("Błąd systemowy. Spróbuj ponownie później.");
                Console.WriteLine(ex.Message);
            }
        }

        // ── METODY LOGICZNE ───────────────────────────────────────────────────────

        /// <summary>
        /// Zwraca ID użytkownika jeśli login i email pasują do siebie.
        /// Zwraca null jeśli nie znaleziono — nie zdradza, które pole jest błędne.
        /// </summary>
        private int? GetUserIdIfValid(SqlConnection conn, string login, string email)
        {
            string query = @"
                SELECT ID 
                FROM Uzytkownicy
                WHERE Login = @Login 
                  AND Email = @Email
                  AND CzyZapomniany = 0";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Email", email);

                object result = cmd.ExecuteScalar();
                return result != null ? (int?)Convert.ToInt32(result) : null;
            }
        }

        private bool IsCzyZapomniany(SqlConnection conn, int userId)
        {
            string query = "SELECT CzyZapomniany FROM Uzytkownicy WHERE ID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", userId);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        private void SaveNewPassword(SqlConnection conn, int userId, string noweHaslo)
        {
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    // 1. Aktualizacja hasła głównego
                    using (SqlCommand cmdUpdate = new SqlCommand(
                        "UPDATE Uzytkownicy SET HasloHash = @Haslo WHERE ID = @ID",
                        conn, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Haslo", noweHaslo);
                        cmdUpdate.Parameters.AddWithValue("@ID", userId);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // 2. Zapis do historii haseł
                    using (SqlCommand cmdHistory = new SqlCommand(
                        "INSERT INTO HistoriaHasel (UzytkownikID, HasloHash, DataZmiany) " +
                        "VALUES (@ID, @Haslo, GETDATE())",
                        conn, transaction))
                    {
                        cmdHistory.Parameters.AddWithValue("@ID", userId);
                        cmdHistory.Parameters.AddWithValue("@Haslo", noweHaslo);
                        cmdHistory.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private void SendPasswordByEmail(string email, string haslo)
        {
            string smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
            int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            string smtpUser = ConfigurationManager.AppSettings["SmtpUser"];
            string smtpPass = ConfigurationManager.AppSettings["SmtpPass"];

            using (SmtpClient smtp = new SmtpClient(smtpHost, smtpPort))
            {
                smtp.EnableSsl = false; // Mailtrap sandbox — TLS opcjonalny, nie wymagany
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false; // WAŻNE: musi być przed Credentials
                smtp.Credentials = new NetworkCredential(smtpUser, smtpPass);
                smtp.Timeout = 10000;

                MailMessage msg = new MailMessage
                {
                    From = new MailAddress("noreply@biblioteka.pl", "System Biblioteki"),
                    Subject = "Odzyskiwanie hasła",
                    Body = $"Twoje nowe hasło tymczasowe: {haslo}\n\n" +
                                 "Po zalogowaniu zostaniesz poproszony o jego zmianę.",
                    IsBodyHtml = false
                };
                msg.To.Add(email);
                smtp.Send(msg);
            }
        }

        // ── NAWIGACJA ─────────────────────────────────────────────────────────────

        private void ReturnToLogin()
        {
            if (this.ParentForm is login1 frm)
                frm.ShowLoginLayout();
        }

        private void ShowError(string msg)
        {
            Error_msg.ForeColor = Color.Red;
            Error_msg.Text = msg;
        }
    }
}