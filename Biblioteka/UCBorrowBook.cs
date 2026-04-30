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

        // Model pomocniczy dla CheckedListBox — ToString() jest używane jako tekst wyświetlany
        private class EgzemplarzItem
        {
            public int    ID   { get; set; }
            public string Opis { get; set; }
            public override string ToString() => Opis;
        }

        public UCBorrowBook()
        {
            InitializeComponent();
            KonfigurujDGV();
            this.VisibleChanged += (s, e) => { if (this.Visible) WczytajDane(); };
        }

        private void KonfigurujDGV()
        {
            dgvCzytelnicy.ReadOnly                = true;
            dgvCzytelnicy.AllowUserToAddRows      = false;
            dgvCzytelnicy.AutoSizeColumnsMode     = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCzytelnicy.SelectionMode           = DataGridViewSelectionMode.FullRowSelect;
            dgvCzytelnicy.MultiSelect             = false;
            dgvCzytelnicy.RowHeadersVisible       = false;
        }

        private void WczytajDane()
        {
            WczytajCzytelnikow(txtSzukajCzytelnika.Text.Trim());
            WczytajEgzemplarze(txtSzukajEgzemplarza.Text.Trim());
        }

        private void WczytajCzytelnikow(string filtr)
        {
            try
            {
                string wzorzec = "%" + filtr + "%";
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    const string sql = @"
                        SELECT ID, Imie, Nazwisko, PESEL
                        FROM   Uzytkownicy
                        WHERE  CzyZablokowany = 0
                          AND  CzyZapomniany  = 0
                          AND  (Nazwisko LIKE @Filtr OR PESEL LIKE @Filtr)
                        ORDER BY Nazwisko, Imie";

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Filtr", SqlDbType.NVarChar).Value = wzorzec;
                        new SqlDataAdapter(cmd).Fill(dt);
                    }

                    dgvCzytelnicy.DataSource = dt;
                }

                if (dgvCzytelnicy.Columns.Contains("ID"))
                    dgvCzytelnicy.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania czytelników: " + ex.Message,
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        SELECT e.ID, k.Tytul
                        FROM   Egzemplarze e
                        JOIN   KatalogKsiazek k ON e.KsiazkaID = k.ID
                        WHERE  e.Status = 'Dostepna'
                          AND  k.Tytul LIKE @Filtr
                        ORDER BY k.Tytul, e.ID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Filtr", SqlDbType.NVarChar).Value = wzorzec;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new EgzemplarzItem
                                {
                                    ID   = reader.GetInt32(0),
                                    Opis = string.Format("{0} (Egz. #{1})", reader.GetString(1), reader.GetInt32(0))
                                });
                            }
                        }
                    }
                }

                chlbEgzemplarze.Items.Clear();
                foreach (var item in lista)
                    chlbEgzemplarze.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania egzemplarzy: " + ex.Message,
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Obsługa wyszukiwania ─────────────────────────────────────────────────

        private void txtSzukajCzytelnika_TextChanged(object sender, EventArgs e)
            => WczytajCzytelnikow(txtSzukajCzytelnika.Text.Trim());

        private void txtSzukajEgzemplarza_TextChanged(object sender, EventArgs e)
            => WczytajEgzemplarze(txtSzukajEgzemplarza.Text.Trim());

        private void btnSzukajCzytelnika_Click(object sender, EventArgs e)
            => WczytajCzytelnikow(txtSzukajCzytelnika.Text.Trim());

        private void btnSzukajEgzemplarza_Click(object sender, EventArgs e)
            => WczytajEgzemplarze(txtSzukajEgzemplarza.Text.Trim());

        // ── Wypożyczenie ─────────────────────────────────────────────────────────

        private void btnWypozycz_Click(object sender, EventArgs e)
        {
            if (!CurrentUserId.HasValue)
            {
                MessageBox.Show("Brak informacji o zalogowanym bibliotekarzu.",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvCzytelnicy.SelectedRows.Count != 1)
            {
                MessageBox.Show("Wybierz dokładnie jednego czytelnika z listy.",
                    "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chlbEgzemplarze.CheckedItems.Count == 0)
            {
                MessageBox.Show("Zaznacz co najmniej jeden egzemplarz do wypożyczenia.",
                    "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int czytelnikId    = Convert.ToInt32(dgvCzytelnicy.SelectedRows[0].Cells["ID"].Value);
            int bibliotekarzId = CurrentUserId.Value;

            SqlTransaction transakcja = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transakcja = conn.BeginTransaction();

                    // 1. INSERT nagłówka wypożyczenia
                    const string sqlWypozyczenie = @"
                        INSERT INTO Wypozyczenia
                            (CzytelnikID, BibliotekarzID, DataWypozyczenia, OczekiwanaDataZwrotu, Status)
                        VALUES
                            (@CzytelnikID, @BibliotekarzID, GETDATE(), DATEADD(day, 14, GETDATE()), 'Nowe');
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int noweWypozyczenieId;
                    using (SqlCommand cmd = new SqlCommand(sqlWypozyczenie, conn, transakcja))
                    {
                        cmd.Parameters.Add("@CzytelnikID",    SqlDbType.Int).Value = czytelnikId;
                        cmd.Parameters.Add("@BibliotekarzID", SqlDbType.Int).Value = bibliotekarzId;
                        noweWypozyczenieId = (int)cmd.ExecuteScalar();
                    }

                    // 2. Dla każdego zaznaczonego egzemplarza: INSERT pozycji + UPDATE statusu
                    foreach (EgzemplarzItem item in chlbEgzemplarze.CheckedItems)
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WID, @EID);",
                            conn, transakcja))
                        {
                            cmd.Parameters.Add("@WID", SqlDbType.Int).Value = noweWypozyczenieId;
                            cmd.Parameters.Add("@EID", SqlDbType.Int).Value = item.ID;
                            cmd.ExecuteNonQuery();
                        }

                        int zaktualizowane;
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EID AND Status = 'Dostepna';",
                            conn, transakcja))
                        {
                            cmd.Parameters.Add("@EID", SqlDbType.Int).Value = item.ID;
                            zaktualizowane = cmd.ExecuteNonQuery();
                        }

                        if (zaktualizowane == 0)
                        {
                            transakcja.Rollback();
                            MessageBox.Show(
                                string.Format("Egzemplarz #{0} nie jest już dostępny. Odśwież listę i spróbuj ponownie.", item.ID),
                                "Egzemplarz niedostępny", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            WczytajDane();
                            return;
                        }
                    }

                    transakcja.Commit();
                }

                MessageBox.Show(
                    string.Format("Wypożyczenie zarejestrowane pomyślnie ({0} egz.).", chlbEgzemplarze.CheckedItems.Count),
                    "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                WczytajDane();
            }
            catch (Exception ex)
            {
                if (transakcja != null)
                {
                    try { transakcja.Rollback(); } catch { }
                }
                MessageBox.Show("Błąd podczas rejestrowania wypożyczenia: " + ex.Message,
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
                mainForm.PowrotDoMenuGlownego();
        }
    }
}
