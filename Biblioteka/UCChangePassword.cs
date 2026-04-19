using System;
using System.Collections.Generic;
using System.Configuration; // Musisz dodać referencję do System.Configuration
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCChangePassword : UserControl
    {
        // Pobieranie stringa z App.config (tak samo jak w login1)
        private readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        public UCChangePassword()
        {
            InitializeComponent();
            Error_msg.Text = "";

            // Maskowanie haseł w kodzie (na wypadek, gdyby w Designerze było wyłączone)
            txt_new_password.UseSystemPasswordChar = true;
            txt_repeat_password.UseSystemPasswordChar = true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string login = txt_login.Text.Trim();
            string newPass = txt_new_password.Text;
            string repeatPass = txt_repeat_password.Text;

            // 1. Walidacja pustych pól
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(newPass))
            {
                ShowError("Proszę uzupełnić wszystkie pola.");
                return;
            }

            // 2. Sprawdzenie zgodności
            if (newPass != repeatPass)
            {
                ShowError("Hasła nie są identyczne.");
                return;
            }

            // 3. Walidacja polityki (8-15 znaków, duża litera, znak specjalny)
            if (!ValidatePasswordPolicy(newPass))
            {
                ShowError("Hasło nie spełnia wymogów bezpieczeństwa.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // 4. Sprawdzenie historii (Scenariusz E2)
                    if (IsPasswordInHistory(conn, login, newPass))
                    {
                        ShowError("Hasło nie może być jednym z 3 ostatnio używanych.");
                        return;
                    }

                    // 5. Aktualizacja hasła w bazie
                    UpdatePasswordInDb(conn, login, newPass);

                    MessageBox.Show("Hasło zostało zmienione pomyślnie!", "Sukces",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ReturnToLogin();
                }
            }
            catch (Exception ex)
            {
                ShowError("Błąd bazy danych podczas zmiany hasła.");
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            ReturnToLogin();
        }

        // --- METODY LOGICZNE ---

        private bool ValidatePasswordPolicy(string pass)
        {
            if (pass.Length < 8 || pass.Length > 15) return false;
            bool hasUpper = pass.Any(char.IsUpper);
            bool hasLower = pass.Any(char.IsLower);
            bool hasDigit = pass.Any(char.IsDigit);
            bool hasSpecial = Regex.IsMatch(pass, @"[-_!*#$&]");

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        private bool IsPasswordInHistory(SqlConnection conn, string login, string newPass)
        {
            // Przykładowe zapytanie sprawdzające tabelę HistoriaHasel
            string query = @"
                SELECT COUNT(1) FROM HistoriaHasel 
                WHERE UzytkownikID = (SELECT ID FROM Uzytkownicy WHERE Login = @Login)
                AND HasloHash = @NewPass";
            // UWAGA: Tu w przyszłości użyj haszowania BCrypt!

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@NewPass", newPass);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void UpdatePasswordInDb(SqlConnection conn, string login, string newPass)
        {
            // 1. Zmiana hasła głównego
            string updateQuery = "UPDATE Uzytkownicy SET HasloHash = @NewPass WHERE Login = @Login";

            // 2. Dodanie do historii (uproszczone)
            string historyQuery = @"
                INSERT INTO HistoriaHasel (UzytkownikID, HasloHash, DataZmiany)
                VALUES ((SELECT ID FROM Uzytkownicy WHERE Login = @Login), @NewPass, GETDATE())";

            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@NewPass", newPass);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.ExecuteNonQuery();
            }

            using (SqlCommand cmdHistory = new SqlCommand(historyQuery, conn))
            {
                cmdHistory.Parameters.AddWithValue("@NewPass", newPass);
                cmdHistory.Parameters.AddWithValue("@Login", login);
                cmdHistory.ExecuteNonQuery();
            }
        }

        private void ShowError(string msg)
        {
            Error_msg.ForeColor = Color.Red;
            Error_msg.Text = msg;
        }

        private void ReturnToLogin()
        {
            if (this.ParentForm is login1 frm)
            {
                frm.ShowLoginLayout();
            }
        }
    }
}