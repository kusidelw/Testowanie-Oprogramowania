using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCBorrowBook : UserControl
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        public int? CurrentUserId { get; set; }
        private bool isCalculatingDate = false;

        public bool PominPotwierdzenie { get; set; } = false;

        // Model pomocniczy dla listy egzemplarzy
        private class EgzemplarzItem
        {
            public int ID { get; set; }
            public string Opis { get; set; }
            public override string ToString() => Opis;
        }

        public UCBorrowBook()
        {
            InitializeComponent();
            KonfigurujDGV();

            // Pkt 6: Blokada edycji daty wypożyczenia 
            dtp_borrow_date.Enabled = false;

            nup_borrow_period.Minimum = 1;
            nup_borrow_period.Maximum = 365;

            // Zdarzenia do przeliczania dat w obie strony
            nup_borrow_period.ValueChanged += Nup_borrow_period_ValueChanged;
            dtp_return_date.ValueChanged += Dtp_return_date_ValueChanged;
        }

        // Resetuje formularz do stanu początkowego
        public void WyczyscFormularz()
        {
            isCalculatingDate = true;
            dtp_borrow_date.Value = DateTime.Today;

            DateTime wyliczonaData = SprawdzDniWolne(DateTime.Today.AddDays(14));
            dtp_return_date.Value = wyliczonaData;
            nup_borrow_period.Value = (int)(wyliczonaData - DateTime.Today).TotalDays;

            isCalculatingDate = false;

            txtSzukajCzytelnika.Text = "";
            txtSzukajEgzemplarza.Text = "";
            WczytajDane();

            if (dgvCzytelnicy.Rows.Count > 0) dgvCzytelnicy.ClearSelection();
            for (int i = 0; i < chlbEgzemplarze.Items.Count; i++) chlbEgzemplarze.SetItemChecked(i, false);
        }

        private void KonfigurujDGV()
        {
            dgvCzytelnicy.ReadOnly = true;
            dgvCzytelnicy.AllowUserToAddRows = false;
            dgvCzytelnicy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCzytelnicy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCzytelnicy.MultiSelect = false;
            dgvCzytelnicy.RowHeadersVisible = false;
        }

        private void WczytajDane()
        {
            WczytajCzytelnikow(txtSzukajCzytelnika.Text.Trim());
            WczytajEgzemplarze(txtSzukajEgzemplarza.Text.Trim());
        }

        // ─── WYLICZANIE DAT I WEEKENDÓW (SCENARIUSZE A1, E2, E3) ──────────────
        private void Nup_borrow_period_ValueChanged(object sender, EventArgs e)
        {
            if (isCalculatingDate) return;
            isCalculatingDate = true;

            DateTime nowaData = dtp_borrow_date.Value.AddDays((double)nup_borrow_period.Value);

            DateTime bezpiecznaData = SprawdzDniWolne(nowaData);

            dtp_return_date.Value = bezpiecznaData;

            int faktyczneDni = (int)(bezpiecznaData.Date - dtp_borrow_date.Value.Date).TotalDays;

            if (nup_borrow_period.Value != faktyczneDni)
            {
                nup_borrow_period.Value = faktyczneDni;
            }

            isCalculatingDate = false;
        }

        private void Dtp_return_date_ValueChanged(object sender, EventArgs e)
        {
            if (isCalculatingDate) return;

            // SCENARIUSZ E2: Data zwrotu z przeszłości lub dzisiaj
            if (dtp_return_date.Value.Date <= DateTime.Today)
            {
                MessageBox.Show("Data oczekiwanego zwrotu nie może być wcześniejsza niż jutro!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isCalculatingDate = true;

                dtp_return_date.Value = SprawdzDniWolne(DateTime.Today.AddDays(1)); // Cofnij na bezpieczną datę 
                nup_borrow_period.Value = 1;

                isCalculatingDate = false;
                return;
            }

            isCalculatingDate = true;
            DateTime bezpiecznaData = SprawdzDniWolne(dtp_return_date.Value);

            if (bezpiecznaData != dtp_return_date.Value)
            {
                dtp_return_date.Value = bezpiecznaData;
            }

            // Przeliczenie różnicy dni
            int dniRoznicy = (int)(dtp_return_date.Value.Date - dtp_borrow_date.Value.Date).TotalDays;

            if (dniRoznicy > nup_borrow_period.Maximum) dniRoznicy = (int)nup_borrow_period.Maximum;
            if (dniRoznicy < nup_borrow_period.Minimum) dniRoznicy = (int)nup_borrow_period.Minimum;

            nup_borrow_period.Value = dniRoznicy;
            isCalculatingDate = false;
        }

        // ENARIUSZ E3: Sprawdzanie weekendów i świąt stałych w Polsce
        private DateTime SprawdzDniWolne(DateTime data)
        {
            bool przesunieto = false;

            // Dopóki data wypada w dzień wolny, przesuwamy o 1 dzień do przodu
            while (CzyDzienWolny(data))
            {
                data = data.AddDays(1);
                przesunieto = true;
            }

            if (przesunieto)
            {
                MessageBox.Show($"Uwaga: Termin zwrotu przypada w dzień wolny. Data została przesunięta na {data:dd.MM.yyyy}",
                                "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return data;
        }

        private bool CzyDzienWolny(DateTime data)
        {
            // Weekendy (Sobota, Niedziela)
            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
                return true;

            int d = data.Day;
            int m = data.Month;
            int r = data.Year;

            // Święta stałe w Polsce
            if ((d == 1 && m == 1) ||   // Nowy Rok
                (d == 6 && m == 1) ||   // Trzech Króli
                (d == 1 && m == 5) ||   // Święto Pracy
                (d == 3 && m == 5) ||   // Święto Konstytucji 3 Maja
                (d == 15 && m == 8) ||  // Wniebowzięcie NMP
                (d == 1 && m == 11) ||  // Wszystkich Świętych
                (d == 11 && m == 11) || // Święto Niepodległości
                (d == 25 && m == 12) || // Boże Narodzenie (1. dzień)
                (d == 26 && m == 12))   // Boże Narodzenie (2. dzień)
            {
                return true;
            }

            // Święta ruchome
            DateTime wielkanoc = PobierzWielkanoc(r);
            DateTime poniedzialekWielkanocny = wielkanoc.AddDays(1);
            DateTime bozeCialo = wielkanoc.AddDays(60); // Boże Ciało to zawsze 60 dni po Wielkanocy
            DateTime zieloneSwiatki = wielkanoc.AddDays(49);

            if (data.Date == wielkanoc.Date ||
                data.Date == poniedzialekWielkanocny.Date ||
                data.Date == bozeCialo.Date ||
                data.Date == zieloneSwiatki.Date)
            {
                return true;
            }

            return false;
        }

        // Algorytm matematyczny wyliczający datę Wielkanocy dla danego roku
        private DateTime PobierzWielkanoc(int rok)
        {
            int a = rok % 19;
            int b = rok / 100;
            int c = rok % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int miesiac = (h + l - 7 * m + 114) / 31;
            int dzien = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(rok, miesiac, dzien);
        }

        // ─── WYSZUKIWANIE CZYTELNIKÓW I KSIĄŻEK ──────────────

        private void WczytajCzytelnikow(string filtr)
        {
            try
            {
                string wzorzec = "%" + filtr + "%";
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    const string sql = @"
                        SELECT 
                            u.ID, 
                            u.Imie, 
                            u.Nazwisko, 
                            km.Miejscowosc + 
                            CASE 
                                WHEN u.Ulica IS NOT NULL AND u.Ulica <> '' THEN ', ' + u.Ulica + ' ' 
                                ELSE ' ' 
                            END + 
                            u.NumerPosesji + 
                            ISNULL('/' + u.NumerLokalu, '') AS Adres,
                            u.Telefon AS [Nr Telefonu]
                        FROM Uzytkownicy u
                        JOIN KodyPocztowe_Miejscowosci km ON u.MiejscowoscKodID = km.ID
                        WHERE u.CzyZablokowany = 0 AND u.CzyZapomniany = 0
                          AND (u.Nazwisko LIKE @Filtr OR u.Imie LIKE @Filtr)
                        ORDER BY u.Nazwisko, u.Imie";

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Filtr", SqlDbType.NVarChar).Value = wzorzec;
                        new SqlDataAdapter(cmd).Fill(dt);
                    }
                    dgvCzytelnicy.DataSource = dt;
                }

                if (dgvCzytelnicy.Columns.Contains("ID")) dgvCzytelnicy.Columns["ID"].Visible = false;

                if (dgvCzytelnicy.Rows.Count > 0)
                    dgvCzytelnicy.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Błąd wczytywania: " + ex.Message); }
        }

        private void WczytajEgzemplarze(string filtr)
        {
            try
            {
                string wzorzec = "%" + filtr + "%";
                var lista = new List<EgzemplarzItem>();

                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    const string sql = @"
                        SELECT e.ID, ISNULL(aut.AutorN, '') + k.Tytul AS TytulWyswietlany
                        FROM Egzemplarze e
                        JOIN KatalogKsiazek k ON e.KsiazkaID = k.ID
                        OUTER APPLY (
                            SELECT TOP 1 a.Imie + ' ' + a.Nazwisko + ' - ' AS AutorN
                            FROM KsiazkaKatalog_Autorzy kka
                            JOIN Autorzy a ON kka.AutorID = a.ID
                            WHERE kka.KsiazkaID = k.ID
                        ) aut
                        WHERE e.Status = 'Dostepna' AND (k.Tytul LIKE @Filtr)
                        ORDER BY k.Tytul, e.ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Filtr", SqlDbType.NVarChar).Value = wzorzec;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new EgzemplarzItem { ID = reader.GetInt32(0), Opis = $"{reader.GetString(1)} (Egz. #{reader.GetInt32(0)})" });
                            }
                        }
                    }
                }
                chlbEgzemplarze.Items.Clear();
                foreach (var item in lista) chlbEgzemplarze.Items.Add(item);
            }
            catch (Exception ex) { MessageBox.Show("Błąd wczytywania: " + ex.Message); }
        }

        private void txtSzukajCzytelnika_TextChanged(object sender, EventArgs e) => WczytajCzytelnikow(txtSzukajCzytelnika.Text.Trim());
        private void txtSzukajEgzemplarza_TextChanged(object sender, EventArgs e) => WczytajEgzemplarze(txtSzukajEgzemplarza.Text.Trim());
        private void btnSzukajCzytelnika_Click(object sender, EventArgs e) => WczytajCzytelnikow(txtSzukajCzytelnika.Text.Trim());
        private void btnSzukajEgzemplarza_Click(object sender, EventArgs e) => WczytajEgzemplarze(txtSzukajEgzemplarza.Text.Trim());


        // ─── ZAPIS WYPOŻYCZENIA ──────────────
        private void btnWypozycz_Click(object sender, EventArgs e)
        {
            if (!CurrentUserId.HasValue) return;

            // SCENARIUSZ E5: Brak wybranego czytelnika lub książki
            if (dgvCzytelnicy.SelectedRows.Count != 1 || chlbEgzemplarze.CheckedItems.Count == 0)
            {
                MessageBox.Show("Błąd: Nie można zarejestrować wypożyczenia. Należy wybrać czytelnika oraz co najmniej jedną książkę",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int czytelnikId = Convert.ToInt32(dgvCzytelnicy.SelectedRows[0].Cells["ID"].Value);
            int bibliotekarzId = CurrentUserId.Value;
            int okresDni = (int)nup_borrow_period.Value;
            DateTime oczekiwanaData = dtp_return_date.Value.Date;

            SqlTransaction transakcja = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transakcja = conn.BeginTransaction();

                    // Zapis nagłówka wypożyczenia
                    const string sqlWypozyczenie = @"
                        INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, Status)
                        VALUES (@C, @B, GETDATE(), @Okres, @DataZ, 'Nowe');
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int noweWypozyczenieId;
                    using (SqlCommand cmd = new SqlCommand(sqlWypozyczenie, conn, transakcja))
                    {
                        cmd.Parameters.AddWithValue("@C", czytelnikId);
                        cmd.Parameters.AddWithValue("@B", bibliotekarzId);
                        cmd.Parameters.AddWithValue("@Okres", okresDni);
                        cmd.Parameters.AddWithValue("@DataZ", oczekiwanaData);
                        noweWypozyczenieId = (int)cmd.ExecuteScalar();
                    }

                    // Zapis pozycji i zmiana statusu
                    foreach (EgzemplarzItem item in chlbEgzemplarze.CheckedItems)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WID, @EID);", conn, transakcja))
                        {
                            cmd.Parameters.AddWithValue("@WID", noweWypozyczenieId);
                            cmd.Parameters.AddWithValue("@EID", item.ID);
                            cmd.ExecuteNonQuery();
                        }

                        int zaktualizowane;
                        using (SqlCommand cmd = new SqlCommand("UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EID AND Status = 'Dostepna';", conn, transakcja))
                        {
                            cmd.Parameters.AddWithValue("@EID", item.ID);
                            zaktualizowane = cmd.ExecuteNonQuery();
                        }

                        // SCENARIUSZ E1: Ktoś inny właśnie wypożyczył
                        if (zaktualizowane == 0)
                        {
                            transakcja.Rollback();
                            MessageBox.Show("Błąd: Wybrana książka jest już wypożyczona innej osobie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            WczytajDane();
                            return;
                        }
                    }

                    transakcja.Commit();
                }

                // SCENARIUSZ GŁÓWNY
                MessageBox.Show("Pomyślnie zarejestrowano wypożyczenie", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Zapis pomyślny 
                PominPotwierdzenie = true;
                WrocDoListyWypozyczen();
            }
            catch (Exception ex)
            {
                if (transakcja != null) try { transakcja.Rollback(); } catch { }
                MessageBox.Show("Wystąpił błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── ANULOWANIE I POWRÓT ──────────────
        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            DialogResult wynik = MessageBox.Show("Czy na pewno chcesz anulować rejestrację wypożyczenia? Zmiany nie zostaną zapisane.",
                                                 "Anuluj wypożyczenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (wynik == DialogResult.Yes)
            {
                PominPotwierdzenie = true; // Zgoda na powrót 
                WrocDoListyWypozyczen();
            }
        }

        private void WrocDoListyWypozyczen()
        {
            Form parentForm = this.FindForm();
            if (parentForm is Biblioteka mainForm)
            {
                mainForm.OtworzListeWypozyczen();
            }
        }
    }
}