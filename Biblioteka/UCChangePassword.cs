using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCChangePassword : UserControl
    {
        private readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        // Ustawiany przez login1.SwitchToChangePassword() lub UCPasswordRecovery
        public string TargetLogin { get; set; }

        public UCChangePassword()
        {
            InitializeComponent();
            Error_msg.Text = "";
            txt_new_password.UseSystemPasswordChar = true;
            txt_repeat_password.UseSystemPasswordChar = true;
        }

        // ── ZAPISZ ───────────────────────────────────────────────────────────────

        private void btn_save_Click(object sender, EventArgs e)
        {
            string newPass = txt_new_password.Text;
            string repeatPass = txt_repeat_password.Text;

            // Scenariusz E1: pola puste
            if (string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(repeatPass))
            {
                ShowError("Proszę uzupełnić wszystkie pola.");
                return;
            }

            // Scenariusz E1: hasła nie są identyczne
            if (newPass != repeatPass)
            {
                ShowError("Hasła nie są identyczne.");
                return;
            }

            // Scenariusz E2: walidacja polityki (8-15 znaków, W/M/C/S)
            if (!ValidatePasswordPolicy(newPass))
            {
                ShowError("Hasło musi mieć 8-15 znaków, zawierać dużą literę, małą literę, cyfrę i znak specjalny.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Scenariusz E2: historia 3 ostatnich haseł
                    if (IsPasswordInRecentHistory(conn, newPass))
                    {
                        ShowError("Nowe hasło musi być inne niż 3 ostatnio używane.");
                        return;
                    }

                    // Zapis w transakcji
                    UpdatePasswordWithHistory(conn, newPass);

                    MessageBox.Show("Hasło zostało zmienione pomyślnie!", "Sukces",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ReturnToLogin();
                }
            }
            catch (Exception ex)
            {
                ShowError("Wystąpił błąd podczas zapisywania hasła.");
                Console.WriteLine(ex.Message);
            }
        }

        // ── ANULUJ ───────────────────────────────────────────────────────────────

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            // Scenariusz A1: rezygnacja z zmiany → powrót do logowania
            ReturnToLogin();
        }

        // ── METODY LOGICZNE ───────────────────────────────────────────────────────

        private bool IsPasswordInRecentHistory(SqlConnection conn, string newPass)
        {
            // Sprawdzamy TOP 3 ostatnie hasła dla użytkownika
            string query = @"
                SELECT COUNT(1) 
                FROM (
                    SELECT TOP 3 HasloHash
                    FROM HistoriaHasel
                    WHERE UzytkownikID = (SELECT ID FROM Uzytkownicy WHERE Login = @Login)
                    ORDER BY DataZmiany DESC
                ) AS Ostatnie
                WHERE HasloHash = @NewPass";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Login", TargetLogin);
                cmd.Parameters.AddWithValue("@NewPass", newPass);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void UpdatePasswordWithHistory(SqlConnection conn, string newPass)
        {
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    // Pobierz ID użytkownika
                    int userId;
                    using (SqlCommand cmdId = new SqlCommand(
                        "SELECT ID FROM Uzytkownicy WHERE Login = @Login", conn, transaction))
                    {
                        cmdId.Parameters.AddWithValue("@Login", TargetLogin);
                        userId = (int)cmdId.ExecuteScalar();
                    }

                    // 1. Aktualizacja hasła głównego
                    using (SqlCommand cmdUpdate = new SqlCommand(
                        "UPDATE Uzytkownicy SET HasloHash = @NewPass WHERE ID = @ID",
                        conn, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@NewPass", newPass);
                        cmdUpdate.Parameters.AddWithValue("@ID", userId);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // 2. Zapis do historii haseł
                    using (SqlCommand cmdHistory = new SqlCommand(
                        "INSERT INTO HistoriaHasel (UzytkownikID, HasloHash, DataZmiany) " +
                        "VALUES (@ID, @NewPass, GETDATE())",
                        conn, transaction))
                    {
                        cmdHistory.Parameters.AddWithValue("@ID", userId);
                        cmdHistory.Parameters.AddWithValue("@NewPass", newPass);
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

        // Walidacja polityki haseł: 8-15 znaków, wielka litera, mała litera, cyfra, znak specjalny
        private bool ValidatePasswordPolicy(string password)
        {
            if (password.Length < 8 || password.Length > 15)
                return false;

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            string specialChars = "-_!*#$&";

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                if (char.IsDigit(c)) hasDigit = true;
                if (specialChars.Contains(c)) hasSpecial = true;
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
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