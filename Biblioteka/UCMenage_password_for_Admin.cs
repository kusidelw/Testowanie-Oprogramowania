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

        private int _wybranyUzytkownikId = -1;
        private string _wybranyLogin = null;

        public UCMenage_password_for_Admin()
        {
            InitializeComponent();
            txt_new_password.UseSystemPasswordChar = true;
            txt_repeat_password.UseSystemPasswordChar = true;
            lbl_error.Text = "";

            dgv_users.ReadOnly = true;
            dgv_users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_users.MultiSelect = false;
            dgv_users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_users.SelectionChanged += dgv_users_SelectionChanged;

            SetPasswordFieldsEnabled(false);

            // Load zamiast VisibleChanged — odpala się gdy kontrolka jest w pełni gotowa
            this.Load += UCMenage_password_for_Admin_Load;
            this.VisibleChanged += UCMenage_password_for_Admin_VisibleChanged;
        }

        private void UCMenage_password_for_Admin_Load(object sender, EventArgs e)
        {
            // Pierwsze załadowanie — kontrolka gotowa
            WczytajUzytkownikow("");
        }


        private void UCMenage_password_for_Admin_VisibleChanged(object sender, EventArgs e)
        {
            // Odświeżenie przy każdym powrocie do zakładki
            // IsHandleCreated zapewnia że kontrolka jest już wyrenderowana
            if (this.Visible && this.IsHandleCreated)
                ResetujStan();
        }

        public void OdswiezDane()
        {
            ResetujStan();
        }

        private void ResetujStan()
        {
            txt_search_user.Clear();

            _wybranyUzytkownikId = -1;
            _wybranyLogin = null;

            ClearPasswordFields();
            SetPasswordFieldsEnabled(false);
            ClearError();

            // Załaduj wszystkich użytkowników przy otwarciu
            WczytajUzytkownikow("");
        }

        // ── ŁADOWANIE DANYCH ──────────────────────────────────────────────────────

        private void WczytajUzytkownikow(string fraza)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            u.ID,
                            u.Login,
                            (u.Imie + ' ' + u.Nazwisko) AS [Imię i nazwisko],
                            u.Email,
                            up.Nazwa                    AS Rola
                        FROM Uzytkownicy u
                        LEFT JOIN Uzytkownicy_Uprawnienia uu ON u.ID  = uu.UzytkownikID
                        LEFT JOIN Uprawnienia up ON uu.UprawnienieID  = up.ID
                        WHERE u.CzyZapomniany = 0
                          AND (
                              @Fraza = '' OR
                              u.Login LIKE @FrazaLike OR
                              u.PESEL LIKE @FrazaLike OR
                              u.Email LIKE @FrazaLike
                          )
                        ORDER BY u.Nazwisko, u.Imie";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Fraza", fraza);
                        cmd.Parameters.AddWithValue("@FrazaLike", $"%{fraza}%");

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            da.Fill(dt);

                        // Odepnij event przed ustawieniem DataSource
                        dgv_users.SelectionChanged -= dgv_users_SelectionChanged;
                        dgv_users.DataSource = dt;

                        if (dgv_users.Columns.Contains("ID"))
                            dgv_users.Columns["ID"].Visible = false;

                        // Przywróć event
                        dgv_users.SelectionChanged += dgv_users_SelectionChanged;

                        if (dt.Rows.Count == 0 && !string.IsNullOrEmpty(fraza))
                            ShowError("Nie znaleziono użytkowników spełniających kryteria.");
                        else
                            ClearError();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Błąd podczas ładowania użytkowników.");
                Console.WriteLine(ex.Message);
            }
        }

        // ── SZUKAJ ───────────────────────────────────────────────────────────────

        private void btn_search_user_Click(object sender, EventArgs e)
        {
            string fraza = txt_search_user.Text.Trim();

            _wybranyUzytkownikId = -1;
            _wybranyLogin = null;
            SetPasswordFieldsEnabled(false);
            ClearPasswordFields();

            WczytajUzytkownikow(fraza);
        }

        // Wyszukiwanie klawiszem Enter
        private void txt_search_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search_user_Click(sender, e);
        }

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

        // ── ZAPISZ — ZMIANA_HAS_ADMIN_1 ──────────────────────────────────────────

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (_wybranyUzytkownikId == -1)
            {
                ShowError("Wybierz użytkownika z listy.");
                return;
            }

            string newPass = txt_new_password.Text;
            string repeatPass = txt_repeat_password.Text;

            if (string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(repeatPass))
            {
                ShowError("Proszę uzupełnić oba pola hasła.");
                return;
            }

            if (newPass != repeatPass)
            {
                ShowError("Hasła nie są identyczne.");
                return;
            }

            // Scenariusz E1: walidacja polityki haseł
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

                    // Scenariusz E2: historia 3 ostatnich haseł
                    if (IsPasswordInRecentHistory(conn, newPass))
                    {
                        ShowError("Nowe hasło musi być inne niż 3 ostatnio używane.");
                        return;
                    }

                    SavePasswordWithHistory(conn, newPass);

                    MessageBox.Show(
                        $"Hasło użytkownika '{_wybranyLogin}' zostało zmienione pomyślnie.",
                        "Sukces",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Reset po zapisie — odświeży też DataGridView
                    ResetujStan();
                }
            }
            catch (Exception ex)
            {
                ShowError("Wystąpił błąd podczas zapisywania hasła.");
                Console.WriteLine(ex.Message);
            }
        }

        // ── WRÓĆ DO LISTY — Scenariusz A1 ────────────────────────────────────────

        private void btn_back_to_list_Click(object sender, EventArgs e)
        {
            // A1: zamknięcie bez zapisywania
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
                    // 1. Aktualizacja hasła + CzyPierwszeLogowanie = 1
                    using (SqlCommand cmdUpdate = new SqlCommand(@"
                        UPDATE Uzytkownicy 
                        SET HasloHash            = @NewPass,
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