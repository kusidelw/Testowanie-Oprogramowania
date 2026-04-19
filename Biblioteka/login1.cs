using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Biblioteka
{
    public partial class login1 : Form
    {
        private readonly string ConnectionString =
    ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        public login1()
        {
            InitializeComponent();
            Error_msg.Text = "";
            lbl_personal_data.Text = "Wprowadź dane użytkownika";
        }

        public void ShowLoginLayout()
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string login = txt_login.Text.Trim();
            string haslo = txt_password.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo))
            {
                Error_msg.ForeColor = System.Drawing.Color.Red;
                Error_msg.Text = "Wprowadź login i hasło.";
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Krok 1: Pobierz dane użytkownika razem z flagami blokady
                    string queryUser = @"
                        SELECT 
                            u.ID,
                            u.HasloHash,
                            u.CzyZablokowany,
                            u.LiczbaBlednychLogowan,
                            u.CzasOdblokowania
                        FROM Uzytkownicy u
                        WHERE u.Login = @Login AND u.CzyZapomniany = 0";

                    int userId = -1;
                    string hasloHash = null;
                    bool czyZablokowany = false;
                    int liczbaBlednych = 0;
                    DateTime? czasOdblokowania = null;

                    using (SqlCommand cmd = new SqlCommand(queryUser, conn))
                    {
                        cmd.Parameters.AddWithValue("@Login", login);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = reader.GetInt32(0);
                                hasloHash = reader.GetString(1);
                                czyZablokowany = reader.GetBoolean(2);
                                liczbaBlednych = reader.GetInt32(3);
                                czasOdblokowania = reader.IsDBNull(4)
                                                    ? (DateTime?)null
                                                    : reader.GetDateTime(4);
                            }
                        }
                    }

                    // Użytkownik nie istnieje
                    if (userId == -1)
                    {
                        HandleFailedLogin(conn, -1);
                        return;
                    }

                    // Krok 2: Sprawdź blokadę czasową 
                    if (czyZablokowany)
                    {
                        if (czasOdblokowania.HasValue && DateTime.Now < czasOdblokowania.Value)
                        {
                            Error_msg.ForeColor = System.Drawing.Color.Red;
                            Error_msg.Text = $"Konto zablokowane do: {czasOdblokowania.Value:HH:mm:ss}";
                            return;
                        }
                        else
                        {
                            // Blokada minęła – odblokuj konto w bazie
                            ResetBlokady(conn, userId);
                            czyZablokowany = false;
                        }
                    }

                    // Krok 3: Sprawdź hasło
                    // UWAGA! na razie nie implementujemy hashowania!!!
                    bool hasloPoprawne = (hasloHash == haslo);

                    if (!hasloPoprawne)
                    {
                        HandleFailedLogin(conn, userId, liczbaBlednych);
                        return;
                    }

                    // Krok 4: Sprawdź, czy użytkownik ma rolę Administratora
                    string queryAdmin = @"
                        SELECT COUNT(1)
                        FROM Uzytkownicy_Uprawnienia uu
                        JOIN Uprawnienia up ON uu.UprawnienieID = up.ID
                        WHERE uu.UzytkownikID = @UserID AND up.Nazwa = 'Administrator'";

                    bool jestAdminem = false;
                    using (SqlCommand cmdAdmin = new SqlCommand(queryAdmin, conn))
                    {
                        cmdAdmin.Parameters.AddWithValue("@UserID", userId);
                        jestAdminem = (int)cmdAdmin.ExecuteScalar() > 0;
                    }

                    if (!jestAdminem)
                    {
                        Error_msg.ForeColor = System.Drawing.Color.Red;
                        Error_msg.Text = "Brak uprawnień administratora.";
                        txt_password.Clear();
                        return;
                    }

                    // Krok 5: SUKCES – zresetuj licznik błędnych logowań
                    ResetBlokady(conn, userId);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                Error_msg.ForeColor = System.Drawing.Color.Red;
                Error_msg.Text = "Błąd połączenia z bazą danych.";
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Inkrementuje licznik błędnych prób i blokuje konto po 3 nieudanych logowaniach.
        /// userId = -1 oznacza nieznanego użytkownika (nie aktualizujemy bazy).
        /// </summary>
        private void HandleFailedLogin(SqlConnection conn, int userId, int dotychczasoweBledne = 0)
        {
            Error_msg.ForeColor = System.Drawing.Color.Red;

            if (userId != -1)
            {
                int nowaLiczba = dotychczasoweBledne + 1;

                if (nowaLiczba >= 3)
                {
                    // Zablokuj konto na 15 minut (Scenariusz E2)
                    string blokuj = @"
                        UPDATE Uzytkownicy
                        SET CzyZablokowany = 1,
                            LiczbaBlednychLogowan = @Liczba,
                            CzasOdblokowania = DATEADD(MINUTE, 15, GETDATE())
                        WHERE ID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(blokuj, conn))
                    {
                        cmd.Parameters.AddWithValue("@Liczba", nowaLiczba);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.ExecuteNonQuery();
                    }

                    Error_msg.Text = "Konto zablokowane na 15 min.";
                }
                else
                {
                    // Zwiększ tylko licznik (Scenariusz E1)
                    string update = @"
                        UPDATE Uzytkownicy
                        SET LiczbaBlednychLogowan = @Liczba
                        WHERE ID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@Liczba", nowaLiczba);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.ExecuteNonQuery();
                    }

                    Error_msg.Text = "Błędne dane.";
                }
            }
            else
            {
                // Nieznany login – nie zdradzamy, co jest złe (Scenariusz E1)
                Error_msg.Text = "Błędne dane.";
            }

            txt_password.Clear();
            txt_login.Focus();
        }

        /// <summary>Zeruje blokadę i licznik błędnych logowań po sukcesie lub po wygaśnięciu blokady.</summary>
        private void ResetBlokady(SqlConnection conn, int userId)
        {
            string reset = @"
                UPDATE Uzytkownicy
                SET CzyZablokowany = 0,
                    LiczbaBlednychLogowan = 0,
                    CzasOdblokowania = NULL
                WHERE ID = @UserID";

            using (SqlCommand cmd = new SqlCommand(reset, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.ExecuteNonQuery();
            }
        }

        private void btn_Recover_pass_Click(object sender, EventArgs e)
        {
            UCChangePassword ucChange = new UCChangePassword();
            this.Controls.Clear();
            ucChange.Dock = DockStyle.Fill;
            this.Controls.Add(ucChange);
            this.Text = "Odzyskiwanie i zmiana hasła";
        }
    }
}