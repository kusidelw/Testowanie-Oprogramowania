using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCChangePassword : UserControl
    {
        public UCChangePassword()
        {
            InitializeComponent();

            Error_msg.Text = "";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string login = txt_login.Text;
            string newPass = txt_new_password.Text;
            string repeatPass = txt_repeat_password.Text;

            // 1. Walidacja pustych pól
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(newPass))
            {
                ShowError("Proszę uzupełnić wszystkie pola.");
                return;
            }

            // 2. Scenariusz wyjątku E1 (USTAW_HAS_UZY_1): Niezgodność haseł
            if (newPass != repeatPass)
            {
                ShowError("Hasła nie są identyczne.");
                return;
            }

            // 3. Scenariusz wyjątku E1 (ZMIANA_HAS_ADMIN_1): Kryteria walidacji (8-15 znaków itp.)
            if (!ValidatePasswordPolicy(newPass))
            {
                ShowError("Hasło nie spełnia wymogów bezpieczeństwa.");
                return;
            }

            // 4. Scenariusz wyjątku E2: Hasło historyczne (3 ostatnie)
            if (IsPasswordInHistory(login, newPass))
            {
                ShowError("Hasło nie może być jednym z 3 ostatnio używanych.");
                return;
            }

            // SUKCES - Zapisanie hasła
            MessageBox.Show("Hasło zostało zmienione pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Po sukcesie wracamy do ekranu logowania (Scenariusz główny)
            ReturnToLogin();
        }

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            // Scenariusz A1: Powrót do logowania bez zapisu
            ReturnToLogin();
        }

        // --- METODY POMOCNICZE ---

        private bool ValidatePasswordPolicy(string pass)
        {
            // Kryteria: 8-15 znaków
            if (pass.Length < 8 || pass.Length > 15) return false;

            // Wielka litera, mała litera, cyfra
            bool hasUpper = pass.Any(char.IsUpper);
            bool hasLower = pass.Any(char.IsLower);
            bool hasDigit = pass.Any(char.IsDigit);

            // Znaki specjalne zgodnie z GEN_HAS_SYS_1: -, _, !, *, #, $, &
            bool hasSpecial = Regex.IsMatch(pass, @"[-_!*#$&]");

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        private bool IsPasswordInHistory(string user, string pass)
        {
            // Symulacja sprawdzenia w bazie (zawsze zwraca false dla testów UI)
            return false;
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