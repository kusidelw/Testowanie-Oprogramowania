using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class login1 : Form
    {
        private readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

      
        public string ZalogowanaRola { get; private set; }

        public login1()
        {
            InitializeComponent();
            Error_msg.Text = "";
            lbl_personal_data.Text = "Wprowadź dane użytkownika";
        }

        // Przywraca widok logowania po powrocie z UCPasswordRecovery lub po anulowaniu zmiany hasła
        public void ShowLoginLayout()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            Error_msg.Text = "";
        }

        // Wywoływane przez UCChangePassword po pomyślnej zmianie hasła 
        public void ProceedAfterPasswordChange()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ── LOGOWANIE ────────────────────────────────────────────────────────────

        private void btn_login_Click(object sender, EventArgs e)
        {
            string login = txt_login.Text.Trim();
            string haslo = txt_password.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo))
            {
                ShowError("Wprowadź login i hasło.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Pobierz dane użytkownika
                    UserAuthInfo user = GetUserData(conn, login);

                    if (user == null)
                    {
                        HandleFailedLogin(conn, -1);
                        return;
                    }

                    // Sprawdź blokadę czasową 
                    if (user.CzyZablokowany)
                    {
                        if (user.CzasOdblokowania.HasValue && DateTime.Now < user.CzasOdblokowania.Value)
                        {
                            ShowError($"Konto zablokowane do: {user.CzasOdblokowania.Value:HH:mm:ss}");
                            return;
                        }
                        else
                        {
                            // Blokada minęła – odblokuj
                            ResetBlokady(conn, user.Id);
                        }
                    }

                    // Sprawdź hasło 
                    // UWAGA: bez hashowania zgodnie z obecnym założeniem projektu---------------------------------------------------
                    if (user.HasloHash != haslo)
                    {
                        HandleFailedLogin(conn, user.Id, user.LiczbaBlednych);
                        return;
                    }

                    //  Pobierz rolę
                    string rola = GetUserRole(conn, user.Id);

                    if (string.IsNullOrEmpty(rola))
                    {
                        ShowError("Użytkownik nie posiada przypisanej roli.");
                        return;
                    }

                    //  Reset blokady po udanym logowaniu
                    ResetBlokady(conn, user.Id);

                    //  wymuszenie zmiany hasła przy pierwszym logowaniu
                    if (user.CzyPierwszeLogowanie)
                    {
                        // Zapamiętaj rolę — po zmianie hasła ProceedAfterPasswordChange() ją użyje
                        ZalogowanaRola = rola;

                        // Wyświetl UCChangePassword na tym samym oknie
                        UCChangePassword ucChange = new UCChangePassword();
                        ucChange.TargetLogin = login;
                        ucChange.IsFirstLogin = true;
                        ucChange.Dock = DockStyle.Fill;

                        this.Controls.Clear();
                        this.Controls.Add(ucChange);
                        this.Text = "Wymagana zmiana hasła";
                        return; // NIE zamykamy login1 — czekamy na zmianę hasła
                    }

                    // Normalne logowanie — przekaż rolę i zamknij
                    ZalogowanaRola = rola;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowError("Błąd systemowy. Spróbuj ponownie później.");
                Console.WriteLine(ex.Message);
            }
        }

        // ── ODZYSKIWANIE HASŁA ────────────────────────────────────────────────────

        private void btn_Recover_pass_Click(object sender, EventArgs e)
        {
           
            UCPasswordRecovery ucRecovery = new UCPasswordRecovery();
            this.Controls.Clear();
            ucRecovery.Dock = DockStyle.Fill;
            this.Controls.Add(ucRecovery);
            this.Text = "Odzyskiwanie hasła";
        }

        // ── METODY POMOCNICZE ─────────────────────────────────────────────────────

        private UserAuthInfo GetUserData(SqlConnection conn, string login)
        {
            string query = @"
                SELECT ID, HasloHash, CzyZablokowany, LiczbaBlednychLogowan, 
                       CzasOdblokowania, CzyPierwszeLogowanie
                FROM Uzytkownicy
                WHERE Login = @Login AND CzyZapomniany = 0";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Login", login);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserAuthInfo
                        {
                            Id = reader.GetInt32(0),
                            HasloHash = reader.GetString(1),
                            CzyZablokowany = reader.GetBoolean(2),
                            LiczbaBlednych = reader.GetInt32(3),
                            CzasOdblokowania = reader.IsDBNull(4)
                                                   ? (DateTime?)null
                                                   : reader.GetDateTime(4),
                            CzyPierwszeLogowanie = reader.GetBoolean(5)
                        };
                    }
                }
            }
            return null;
        }

        private string GetUserRole(SqlConnection conn, int userId)
        {
            string query = @"
                SELECT TOP 1 up.Nazwa
                FROM Uprawnienia up
                JOIN Uzytkownicy_Uprawnienia uu ON up.ID = uu.UprawnienieID
                WHERE uu.UzytkownikID = @UserID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        private void HandleFailedLogin(SqlConnection conn, int userId, int currentFailed = 0)
        {
            if (userId != -1)
            {
                int newCount = currentFailed + 1;

                if (newCount >= 3)
                {
                    // blokada na 15 minut
                    ExecuteUpdate(conn,
                        "UPDATE Uzytkownicy SET CzyZablokowany = 1, LiczbaBlednychLogowan = @Count, " +
                        "CzasOdblokowania = DATEADD(MINUTE, 15, GETDATE()) WHERE ID = @ID",
                        newCount, userId);
                    ShowError("Konto zablokowane na 15 min.");
                }
                else
                {
                    // błędne dane
                    ExecuteUpdate(conn,
                        "UPDATE Uzytkownicy SET LiczbaBlednychLogowan = @Count WHERE ID = @ID",
                        newCount, userId);
                    ShowError("Błędne dane.");
                }
            }
            else
            {
                // Nieznany login – nie zdradzamy szczegółów
                ShowError("Błędne dane.");
            }

            txt_password.Clear();
            txt_login.Focus();
        }

        private void ResetBlokady(SqlConnection conn, int userId)
        {
            ExecuteUpdate(conn,
                "UPDATE Uzytkownicy SET CzyZablokowany = 0, LiczbaBlednychLogowan = 0, " +
                "CzasOdblokowania = NULL WHERE ID = @ID",
                0, userId);
        }

        private void ExecuteUpdate(SqlConnection conn, string query, int count, int userId)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Count", count);
                cmd.Parameters.AddWithValue("@ID", userId);
                cmd.ExecuteNonQuery();
            }
        }

        private void ShowError(string msg)
        {
            Error_msg.ForeColor = Color.Red;
            Error_msg.Text = msg;
        }

        // ── KLASA POMOCNICZA ──────────────────────────────────────────────────────

        private class UserAuthInfo
        {
            public int Id { get; set; }
            public string HasloHash { get; set; }
            public bool CzyZablokowany { get; set; }
            public int LiczbaBlednych { get; set; }
            public DateTime? CzasOdblokowania { get; set; }
            public bool CzyPierwszeLogowanie { get; set; }
        }
    }
}