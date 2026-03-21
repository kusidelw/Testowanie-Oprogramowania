using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Biblioteka
{
    public partial class UCForgetUsers : UserControl
    {
        private string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private string searchQuery = "";

        public UCForgetUsers()
        {
            InitializeComponent();
            KonfigurujDGV();
            this.VisibleChanged += UCForgetUsers_VisibleChanged;
        }

        private void UCForgetUsers_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                dgv_users.DataSource = null;
                txt_search_user.Clear();
                searchQuery = "";
            }
        }

        private void KonfigurujDGV()
        {
            dgv_users.ReadOnly = true;
            dgv_users.AllowUserToAddRows = false;
            dgv_users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_users.MultiSelect = false;
            dgv_users.RowHeadersVisible = false;
        }

        private void WczytajUzytkownikow()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    string sqlCount = @"
                        SELECT COUNT(*) FROM Uzytkownicy
                        WHERE CzyZapomniany = 0
                        AND (@Query = '' OR Login LIKE @QueryLike
                             OR Email = @Query
                             OR PESEL = @Query)";

                    int totalRecords;
                    using (SqlCommand cmd = new SqlCommand(sqlCount, conn))
                    {
                        cmd.Parameters.AddWithValue("@Query", searchQuery);
                        cmd.Parameters.AddWithValue("@QueryLike", "%" + searchQuery + "%");
                        totalRecords = (int)cmd.ExecuteScalar();
                    }

                    if (totalRecords == 0 && !string.IsNullOrEmpty(searchQuery))
                    {
                        MessageBox.Show("Nie znaleziono użytkownika o podanych kryteriach.", "Brak wyników",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (dgv_users.DataSource is DataTable dt)
                            dt.Clear();

                        return;
                    }

                    string sqlData = @"
                        SELECT
                            ID AS [ID],
                            Login AS [Login],
                            (Imie + ' ' + Nazwisko) AS [Imię i nazwisko],
                            PESEL AS [PESEL],
                            Email AS [Adres e-mail]
                        FROM Uzytkownicy
                        WHERE CzyZapomniany = 0
                        AND (@Query = '' OR Login LIKE @QueryLike
                             OR Email = @Query
                             OR PESEL = @Query)
                        ORDER BY Nazwisko, Imie";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        cmd.Parameters.AddWithValue("@Query", searchQuery);
                        cmd.Parameters.AddWithValue("@QueryLike", "%" + searchQuery + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_users.DataSource = dt;
                    }

                    if (dgv_users.Columns["ID"] != null)
                        dgv_users.Columns["ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_user_Click(object sender, EventArgs e)
        {
            searchQuery = txt_search_user.Text.Trim();
            WczytajUzytkownikow();
        }

        private void txt_search_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search_user_Click(sender, e);
        }

        private void btn_forget_user_Click(object sender, EventArgs e)
        {
            if (dgv_users.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz użytkownika z listy.", "Informacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = (int)dgv_users.SelectedRows[0].Cells["ID"].Value;
            string userName = dgv_users.SelectedRows[0].Cells["Imię i nazwisko"].Value.ToString();

            // Scenariusz E1 – sprawdzenie czy użytkownik już zapomniany
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT CzyZapomniany FROM Uzytkownicy WHERE ID = @UserId", conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        bool czyZapomniany = (bool)cmd.ExecuteScalar();
                        if (czyZapomniany)
                        {
                            MessageBox.Show("Dane tego użytkownika są już zanonimizowane.", "Informacja",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Scenariusz główny pkt. 3 – ostrzeżenie o nieodwracalności
            var potwierdzenie = MessageBox.Show(
                $"Czy na pewno chcesz zapomnieć użytkownika:\n{userName}?\n\nOperacji nie można cofnąć.",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // Scenariusz A1 – anulowanie
            if (potwierdzenie != DialogResult.Yes)
                return;

            try
            {
                // Generujemy spójne dane: DataUrodzenia, Plec i PESEL razem
                Random rnd = new Random();
                DateTime losowaData = new DateTime(rnd.Next(1950, 2000), rnd.Next(1, 13), rnd.Next(1, 29));
                string losowaPlec = rnd.Next(2) == 0 ? "M" : "K";
                string losowePesel = GenerujLosowePesel(losowaData, losowaPlec);

                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    string sql = @"
                        UPDATE Uzytkownicy SET
                            CzyZapomniany   = 1,
                            DataZapomnienia = @DataZapomnienia,
                            Imie            = @LosoweImie,
                            Nazwisko        = @LosoweNazwisko,
                            PESEL           = @LosowePesel,
                            Email           = @LosoweEmail,
                            Telefon         = @LosoweTelefon,
                            Miejscowosc     = @LosoweMiejscowosc,
                            KodPocztowy     = @LosoweKodPocztowy,
                            Ulica           = @LosoweUlica,
                            NumerPosesji    = @LosoweNumerPosesji,
                            NumerLokalu     = @LosoweNumerLokalu,
                            DataUrodzenia   = @LosowaDataUrodzenia,
                            Plec            = @LosowaPlec
                        WHERE ID = @UserId";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@DataZapomnienia", DateTime.Now);
                        cmd.Parameters.AddWithValue("@LosoweImie", GenerujLosowyString(8));
                        cmd.Parameters.AddWithValue("@LosoweNazwisko", GenerujLosowyString(10));
                        cmd.Parameters.AddWithValue("@LosowePesel", losowePesel);
                        cmd.Parameters.AddWithValue("@LosoweEmail", GenerujLosowyString(6) + "@anon.invalid");
                        cmd.Parameters.AddWithValue("@LosoweTelefon", GenerujLosowyTelefon());
                        cmd.Parameters.AddWithValue("@LosoweMiejscowosc", GenerujLosowyString(8));
                        cmd.Parameters.AddWithValue("@LosoweKodPocztowy", rnd.Next(10, 99) + "-" + rnd.Next(100, 999));
                        cmd.Parameters.AddWithValue("@LosoweUlica", GenerujLosowyString(10));
                        cmd.Parameters.AddWithValue("@LosoweNumerPosesji", rnd.Next(1, 999).ToString());
                        cmd.Parameters.AddWithValue("@LosoweNumerLokalu", rnd.Next(1, 99).ToString());
                        cmd.Parameters.AddWithValue("@LosowaDataUrodzenia", losowaData);
                        cmd.Parameters.AddWithValue("@LosowaPlec", losowaPlec);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Scenariusz główny pkt. 6
                MessageBox.Show("Zapomniano Użytkownika.", "Sukces",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgv_users.DataSource = null;
                txt_search_user.Clear();
                searchQuery = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapominania użytkownika: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Metody pomocnicze ────────────────────────────────────────

        private string GenerujLosowyString(int dlugosc)
        {
            const string znaki = "abcdefghijklmnopqrstuvwxyz";
            Random rnd = new Random();
            char[] wynik = new char[dlugosc];
            for (int i = 0; i < dlugosc; i++)
                wynik[i] = znaki[rnd.Next(znaki.Length)];
            return new string(wynik);
        }

        private string GenerujLosowyTelefon()
        {
            Random rnd = new Random();
            return "5" + rnd.Next(10000000, 99999999).ToString();
        }

        private string GenerujLosowePesel(DateTime dataUrodzenia, string plec)
        {
            Random rnd = new Random();
            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int[] cyfry = new int[11];

            // Cyfry 0-1: ostatnie 2 cyfry roku
            int rok = dataUrodzenia.Year % 100;
            cyfry[0] = rok / 10;
            cyfry[1] = rok % 10;

            // Cyfry 2-3: miesiąc (dla lat 2000+ dodajemy 20)
            int miesiac = dataUrodzenia.Year >= 2000
                ? dataUrodzenia.Month + 20
                : dataUrodzenia.Month;
            cyfry[2] = miesiac / 10;
            cyfry[3] = miesiac % 10;

            // Cyfry 4-5: dzień
            cyfry[4] = dataUrodzenia.Day / 10;
            cyfry[5] = dataUrodzenia.Day % 10;

            // Cyfry 6-8: losowe
            for (int i = 6; i <= 8; i++)
                cyfry[i] = rnd.Next(0, 10);

            // Cyfra 9: płeć – M = nieparzysta, K = parzysta
            cyfry[9] = plec == "M"
                ? rnd.Next(0, 5) * 2 + 1   // 1,3,5,7,9
                : rnd.Next(0, 5) * 2;       // 0,2,4,6,8

            // Cyfra 10: suma kontrolna
            int suma = 0;
            for (int i = 0; i < 10; i++)
                suma += cyfry[i] * wagi[i];
            cyfry[10] = (10 - (suma % 10)) % 10;

            StringBuilder sb = new StringBuilder();
            foreach (int c in cyfry)
                sb.Append(c);

            return sb.ToString();
        }

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
                mainForm.PowrotDoMenuGlownego();
        }

        private void lbl_search_criteria_Click(object sender, EventArgs e) { }
    }
}