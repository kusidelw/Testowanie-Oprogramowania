using System;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class login1 : Form
    {
        // Logika blokady (Scenariusze E2 i A1 z Twojej dokumentacji)
        private int loginAttempts = 0;
        private DateTime? lockoutUntil = null;

        public login1()
        {
            InitializeComponent();

            // Wymaganie niefunkcjonalne: Maskowanie hasła
            txt_password.PasswordChar = '*';

            // Ustawienia początkowe etykiet
            Error_msg.Text = "";
            lbl_personal_data.Text = "Wprowadź dane użytkownika";
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // 1. Sprawdzenie blokady (Scenariusz A1)
            if (lockoutUntil.HasValue && DateTime.Now < lockoutUntil.Value)
            {
                Error_msg.ForeColor = System.Drawing.Color.Red;
                Error_msg.Text = $"Blokada do: {lockoutUntil.Value:HH:mm:ss}";
                return;
            }

            // 2. Walidacja danych (Scenariusz LOG_UZY_1)
            // Używamy Twoich nazw: txt_login oraz txt_password
            if (txt_login.Text == "admin" && txt_password.Text == "admin")
            {
                // SUKCES: Przeniesienie do Form1.cs przez Program.cs
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                HandleFailedLogin();
            }
        }

        private void HandleFailedLogin()
        {
            loginAttempts++;

            // Scenariusz E2: Trzykrotne błędne hasło
            if (loginAttempts >= 3)
            {
                lockoutUntil = DateTime.Now.AddMinutes(15);
                Error_msg.Text = "Konto zablokowane na 15 min.";
            }
            else
            {
                // Scenariusz E1: Komunikat "Błędne Dane"
                Error_msg.Text = "Błędne Dane";
                txt_password.Clear();
                txt_login.Focus();
            }
        }

        private void btn_Recover_pass_Click(object sender, EventArgs e)
        {
            // Scenariusz ODZYSK_HAS_UZY_1: Przeniesienie do UCChangePassword.cs
            UCChangePassword ucChange = new UCChangePassword();

            // Czyścimy formularz login1, aby zrobić miejsce dla kontrolki
            this.Controls.Clear();

            // Dodajemy UCChangePassword na pełne okno
            ucChange.Dock = DockStyle.Fill;
            this.Controls.Add(ucChange);

            this.Text = "Odzyskiwanie i zmiana hasła";
        }
    }
}