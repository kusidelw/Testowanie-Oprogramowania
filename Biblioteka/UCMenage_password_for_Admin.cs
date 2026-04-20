using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCMenage_password_for_Admin : UserControl
    {
        private readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        // ID użytkownika wybranego w DataGridView
        private int _wybranyUzytkownikId = -1;
        private string _wybranyLogin = null;

        public UCMenage_password_for_Admin()
        {
            InitializeComponent();
            txt_new_password.UseSystemPasswordChar = true;
            txt_repeat_password.UseSystemPasswordChar = true;
            lbl_error.Text = "";

            // Konfiguracja DataGridView
            dgv_users.ReadOnly = true;
            dgv_users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_users.MultiSelect = false;
            dgv_users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_users.SelectionChanged += dgv_users_SelectionChanged;

            // Pola hasła zablokowane dopóki nie wybrano użytkownika
            SetPasswordFieldsEnabled(false);
        }

        // ── SZUKAJ ───────────────────────────────────────────────────────────────

        private void btn_search_user_Click(object sender, EventArgs e)
        {
            string fraza = txt_search_user.Text.Trim();

            // Wyczyść poprzedni wybór
            _wybranyUzytkownikId = -1;
            _wybranyLogin = null;
            SetPasswordFieldsEnabled(false);
            ClearPasswordFields();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Wyszukiwanie po Login, PESEL lub Email
                    // Pomijamy konta zapomniane (RODO)
                    string query = @"
                        SELECT 
                            u.ID,
                            u.Login,
                            u.Imie,
                            u.Nazwisko,
                            u.Email,
                            up.Nazwa AS Rola
                        FROM Uzytkownicy u
                        LEFT JOIN Uzytkownicy_Uprawnienia uu ON u.ID = uu.UzytkownikID
                        LEFT JOIN Uprawnienia up ON uu.UprawnienieID = up.ID
                        WHERE u.CzyZapomniany = 0
                          AND (
                              u.Login LIKE @Fraza OR
                              u.PESEL LIKE @Fraza OR
                              u.Email LIKE @Fraza
                          )
                        ORDER BY u.Nazwisko, u.Imie";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Fraza", $"%{fraza}%");

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            da.Fill(dt);

                        // Ukryj kolumnę ID w widoku, ale zachowaj w danych
                        dgv_users.DataSource = dt;

                        if (dgv_users.Columns.Contains("ID"))
                            dgv_users.Columns["ID"].Visible = false;

                        if (dt.Rows.Count == 0)
                            ShowError("Nie znaleziono użytkowników spełniających kryteria.");
                        else
                            ClearError();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Błąd podczas wyszukiwania.");
                Console.WriteLine(ex.Message);
            }
        }

        // Obsługa wyboru wiersza w DataGridView
        private void dgv_users_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_users.SelectedRows.Count == 0)
            {
                _wybranyUzytkownikId = -1;
                _wybranyLogin = null;
                SetPasswordFieldsEnabled(false);
                return;
            }

            DataGridViewRow row = dgv_users.SelectedRows[0];
            _wybranyUzytkownikId = Convert.ToInt32(row.Cells["ID"].Value);
            _wybranyLogin = row.Cells["Login"].Value?.ToString();

            SetPasswordFieldsEnabled(true);
            ClearPasswordFields();
            ClearError();
        }

        // ── ZAPISZ — ZMIANA_HAS_ADMIN_1 ────────────────────────────

        private void btn_save_Click(object sender, EventArgs e)
        {
            //  musi być wybrany użytkownik
            if (_wybranyUzytkownikId == -1)
            {
                ShowError("Wybierz użytkownika z listy.");
                return;
            }

            string newPass = txt_new_password.Text;
            string repeatPass = txt_repeat_password.Text;

            // Walidacja pustych pól
            if (string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(repeatPass))
            {
                ShowError("Proszę uzupełnić oba pola hasła.");
                return;
            }

            // Walidacja zgodności pól
            if (newPass != repeatPass)
            {
                ShowError("Hasła nie są identyczne.");
                return;
            }

            //  walidacja polityki (8-15 znaków, W/M/C/S)
            if (!Walidator.ValidatePasswordPolicy(newPass))
            {
                ShowError("Hasło musi mieć 8-15 znaków, zawierać dużą literę, małą literę, cyfrę i znak specjalny (- _ ! * # $ &).");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // historia 3 ostatnich haseł
                    if (IsPasswordInRecentHistory(conn, newPass))
                    {
                        ShowError("Nowe hasło musi być inne niż 3 ostatnio używane.");
                        return;
                    }

                    // zapis w transakcji
                    SavePasswordWithHistory(conn, newPass);

                    MessageBox.Show(
                        $"Hasło użytkownika '{_wybranyLogin}' zostało zmienione pomyślnie.",
                        "Sukces",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Po zmianie wyczyść pola i resetuj wybór
                    ClearPasswordFields();
                    dgv_users.ClearSelection();
                    _wybranyUzytkownikId = -1;
                    _wybranyLogin = null;
                    SetPasswordFieldsEnabled(false);
                    ClearError();
                }
            }
            catch (Exception ex)
            {
                ShowError("Wystąpił błąd podczas zapisywania hasła.");
                Console.WriteLine(ex.Message);
            }
        }

        // ── WRÓĆ DO LISTY —  

        private void btn_back_to_list_Click(object sender, EventArgs e)
        {
            // A1: zamknięcie formularza bez zapisywania zmian
            ClearPasswordFields();
            dgv_users.ClearSelection();
            _wybranyUzytkownikId = -1;
            _wybranyLogin = null;
            SetPasswordFieldsEnabled(false);
            ClearError();

            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
                mainForm.PowrotDoMenuGlownego();
        }

        // ── METODY LOGICZNE ───────────────────────────────────────────────────────

        private bool IsPasswordInRecentHistory(SqlConnection conn, string newPass)
        {
            string query = @"
                SELECT COUNT(1)
                FROM (
                    SELECT TOP 3 HasloHash
                    FROM HistoriaHasel
                    WHERE UzytkownikID = @UserID
                    ORDER BY DataZmiany DESC
                ) AS Ostatnie
                WHERE HasloHash = @NewPass";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", _wybranyUzytkownikId);
                cmd.Parameters.AddWithValue("@NewPass", newPass);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void SavePasswordWithHistory(SqlConnection conn, string newPass)
        {
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    // 1. Aktualizacja hasła + ustawienie CzyPierwszeLogowanie = 1
                    //    (użytkownik będzie zmuszony do zmiany przy następnym logowaniu)
                    using (SqlCommand cmdUpdate = new SqlCommand(@"
                        UPDATE Uzytkownicy 
                        SET HasloHash = @NewPass,
                            CzyPierwszeLogowanie = 1
                        WHERE ID = @UserID",
                        conn, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@NewPass", newPass);
                        cmdUpdate.Parameters.AddWithValue("@UserID", _wybranyUzytkownikId);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // 2. Zapis do historii haseł
                    using (SqlCommand cmdHistory = new SqlCommand(@"
                        INSERT INTO HistoriaHasel (UzytkownikID, HasloHash, DataZmiany)
                        VALUES (@UserID, @NewPass, GETDATE())",
                        conn, transaction))
                    {
                        cmdHistory.Parameters.AddWithValue("@UserID", _wybranyUzytkownikId);
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

        // ── HELPERS ───────────────────────────────────────────────────────────────

        private void SetPasswordFieldsEnabled(bool enabled)
        {
            txt_new_password.Enabled = enabled;
            txt_repeat_password.Enabled = enabled;
            btn_save.Enabled = enabled;
        }

        private void ClearPasswordFields()
        {
            txt_new_password.Clear();
            txt_repeat_password.Clear();
        }

        private void ShowError(string msg)
        {
            lbl_error.ForeColor = Color.Red;
            lbl_error.Text = msg;
        }

        private void ClearError()
        {
            lbl_error.Text = "";
        }
    }
}