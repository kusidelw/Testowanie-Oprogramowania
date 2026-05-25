using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class PrzedluzWypozyczenie : Form
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private int _wypozyczenieId;
        private DateTime _pierwotnaDataZwrotu;
        private bool isCalculating = false;

        public PrzedluzWypozyczenie(int wypozyczenieId)
        {
            InitializeComponent();
            _wypozyczenieId = wypozyczenieId;

            txb_reader.ReadOnly = true;
            txb_libralian.ReadOnly = true;
            txb_books.ReadOnly = true;
            txb_books.Height = 60;

            dtp_borrow_date.Enabled = false;
            dtp_return_date.Enabled = false;

            nup_borrow_period.Minimum = 1;
            nup_borrow_period.Maximum = 365;
            nup_borrow_period.Value = 14; // Domyślnie 14 dni 

            nup_borrow_period.ValueChanged += nup_borrow_period_ValueChanged;
            btn_save.Click += btn_save_Click;
            btn_cancel.Click += btn_cancel_Click;

            WczytajDaneWypozyczenia();
        }

        private void WczytajDaneWypozyczenia()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            c.Imie + ' ' + c.Nazwisko AS Czytelnik,
                            b.Imie + ' ' + b.Nazwisko AS Bibliotekarz,
                            w.DataWypozyczenia,
                            w.OczekiwanaDataZwrotu,
                            (
                                SELECT STRING_AGG(ISNULL(aut.AutorN, '') + kk.Tytul, CHAR(13) + CHAR(10)) 
                                FROM PozycjeWypozyczenia pw
                                JOIN Egzemplarze e ON pw.EgzemplarzID = e.ID
                                JOIN KatalogKsiazek kk ON e.KsiazkaID = kk.ID
                                OUTER APPLY (
                                    SELECT TOP 1 a.Imie + ' ' + a.Nazwisko + ' - ' AS AutorN
                                    FROM KsiazkaKatalog_Autorzy kka
                                    JOIN Autorzy a ON kka.AutorID = a.ID
                                    WHERE kka.KsiazkaID = kk.ID
                                ) aut
                                WHERE pw.WypozyczenieID = w.ID
                            ) AS Ksiazki
                        FROM Wypozyczenia w
                        JOIN Uzytkownicy c ON w.CzytelnikID = c.ID
                        JOIN Uzytkownicy b ON w.BibliotekarzID = b.ID
                        WHERE w.ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", _wypozyczenieId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txb_reader.Text = reader["Czytelnik"].ToString();
                                txb_libralian.Text = reader["Bibliotekarz"].ToString();
                                txb_books.Text = reader["Ksiazki"].ToString();

                                dtp_borrow_date.Value = Convert.ToDateTime(reader["DataWypozyczenia"]);
                                _pierwotnaDataZwrotu = Convert.ToDateTime(reader["OczekiwanaDataZwrotu"]);

                                PrzeliczDateZwrotu();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Daty przeliczamy na bieżąco podczas zmiany liczby dni
        private void nup_borrow_period_ValueChanged(object sender, EventArgs e)
        {
            PrzeliczDateZwrotu();
        }

        private void PrzeliczDateZwrotu()
        {
            if (isCalculating) return;
            isCalculating = true;

            int dodaneDni = (int)nup_borrow_period.Value;
            DateTime bazaDoObliczen;

            // Pkt 6a i 6b z analizy:
            if (_pierwotnaDataZwrotu.Date >= DateTime.Today)
            {
                // 6a Książka przed terminem zwrotu to wydłużamy od pierwotnej daty zwrotu
                bazaDoObliczen = _pierwotnaDataZwrotu;
            }
            else
            {
                // 6b Książka jest po terminie to wydłużamy od dzisiaj
                bazaDoObliczen = DateTime.Today;
            }

            DateTime nowaData = bazaDoObliczen.AddDays(dodaneDni);

            dtp_return_date.Value = nowaData;

            isCalculating = false;
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                // SCENARIUSZ E1: Weryfikacja dni wolnych w momencie zapisu
                DateTime ostatecznaData = SprawdzDniWolne(dtp_return_date.Value);

                int nowyOkresDni = (int)(ostatecznaData.Date - dtp_borrow_date.Value.Date).TotalDays;

                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    // Aktualizujemy datę status oraz wyliczony łączny okres
                    string sql = @"
                        UPDATE Wypozyczenia 
                        SET OczekiwanaDataZwrotu = @NowaData, 
                            Status = 'Przedluzone',
                            OkresWypozyczeniaDni = @NowyOkres
                        WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@NowaData", ostatecznaData);
                        cmd.Parameters.AddWithValue("@NowyOkres", nowyOkresDni);
                        cmd.Parameters.AddWithValue("@ID", _wypozyczenieId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // SCENARIUSZ GŁÓWNY (Pkt 8)
                MessageBox.Show("Termin zwrotu został pomyślnie zaktualizowany", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //  LOGIKA DNI WOLNYCH I ŚWIĄT
        private DateTime SprawdzDniWolne(DateTime data)
        {
            bool przesunieto = false;

            while (CzyDzienWolny(data))
            {
                data = data.AddDays(1);
                przesunieto = true;
            }

            if (przesunieto)
            {
                // SCENARIUSZ E1
                MessageBox.Show($"Korekta terminu: Nowa data zwrotu przypada w święto. Ustawiono termin na: {data:dd.MM.yyyy}",
                                "Korekta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return data;
        }

        private bool CzyDzienWolny(DateTime data)
        {
            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday) return true;

            int d = data.Day, m = data.Month, r = data.Year;
            if ((d == 1 && m == 1) || (d == 6 && m == 1) || (d == 1 && m == 5) || (d == 3 && m == 5) ||
                (d == 15 && m == 8) || (d == 1 && m == 11) || (d == 11 && m == 11) || (d == 25 && m == 12) || (d == 26 && m == 12))
                return true;

            DateTime wielkanoc = PobierzWielkanoc(r);
            if (data.Date == wielkanoc.Date || data.Date == wielkanoc.AddDays(1).Date ||
                data.Date == wielkanoc.AddDays(60).Date || data.Date == wielkanoc.AddDays(49).Date)
                return true;

            return false;
        }

        private DateTime PobierzWielkanoc(int rok)
        {
            int a = rok % 19, b = rok / 100, c = rok % 100, d = b / 4, e = b % 4, f = (b + 8) / 25;
            int g = (b - f + 1) / 3, h = (19 * a + b - d - g + 15) % 30, i = c / 4, k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7, m = (a + 11 * h + 22 * l) / 451;
            return new DateTime(rok, (h + l - 7 * m + 114) / 31, ((h + l - 7 * m + 114) % 31) + 1);
        }
    }
}