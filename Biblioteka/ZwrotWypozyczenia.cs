using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class ZwrotWypozyczenia : Form
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private int _wypozyczenieId;

        public ZwrotWypozyczenia(int wypozyczenieId)
        {
            InitializeComponent();
            _wypozyczenieId = wypozyczenieId;

            txb_reader.ReadOnly = true;
            txb_libralian.ReadOnly = true;
            txb_books.ReadOnly = true;
            txb_days.ReadOnly = true;
            txb_delay.ReadOnly = true;

            dtp_borrow_date.Enabled = false;
            dtp_return_date.Enabled = false;

            btn_save.Click += btn_save_Click;
            btn_cancel.Click += btn_cancel_Click;

            WczytajDaneDoPodsumowania();
        }

        private void WczytajDaneDoPodsumowania()
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
                                // Wypełnienie danych tekstowych
                                txb_reader.Text = reader["Czytelnik"].ToString();
                                txb_libralian.Text = reader["Bibliotekarz"].ToString();
                                txb_books.Text = reader["Ksiazki"].ToString();

                                // Pobranie dat
                                DateTime dataWypozyczenia = Convert.ToDateTime(reader["DataWypozyczenia"]);
                                DateTime oczekiwanaData = Convert.ToDateTime(reader["OczekiwanaDataZwrotu"]);
                                DateTime dataRzeczywistegoZwrotu = DateTime.Today;

                                dtp_borrow_date.Value = dataWypozyczenia;
                                dtp_return_date.Value = dataRzeczywistegoZwrotu;

                                int faktyczneDni = (int)(dataRzeczywistegoZwrotu.Date - dataWypozyczenia.Date).TotalDays;
                                int opoznienie = (int)(dataRzeczywistegoZwrotu.Date - oczekiwanaData.Date).TotalDays;

                                txb_days.Text = faktyczneDni.ToString() + " dni";

                                // Logika opóźnienia
                                if (opoznienie <= 0)
                                {
                                    txb_delay.Text = "0 dni";
                                    txb_delay.ForeColor = Color.Green;
                                }
                                else
                                {
                                    txb_delay.Text = opoznienie.ToString() + " dni";
                                    txb_delay.ForeColor = Color.Red;
                                }
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            SqlTransaction transakcja = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transakcja = conn.BeginTransaction();

                    // Zmieniamy status wypożyczenia na "Zakonczone" i ustawiamy DataZwrotu
                    string sqlWypozyczenie = @"
                        UPDATE Wypozyczenia 
                        SET Status = 'Zakonczone', 
                            DataZwrotu = GETDATE()
                        WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(sqlWypozyczenie, conn, transakcja))
                    {
                        cmd.Parameters.AddWithValue("@ID", _wypozyczenieId);
                        cmd.ExecuteNonQuery();
                    }

                    // Przywracamy książki (status "Dostepna")
                    string sqlEgzemplarze = @"
                        UPDATE Egzemplarze 
                        SET Status = 'Dostepna'
                        WHERE ID IN (
                            SELECT EgzemplarzID 
                            FROM PozycjeWypozyczenia 
                            WHERE WypozyczenieID = @ID
                        )";

                    using (SqlCommand cmd = new SqlCommand(sqlEgzemplarze, conn, transakcja))
                    {
                        cmd.Parameters.AddWithValue("@ID", _wypozyczenieId);
                        cmd.ExecuteNonQuery();
                    }

                    transakcja.Commit();
                }

                MessageBox.Show("Zarejestrowano zwrot książek. Pozycje są ponownie dostępne.",
                                "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (transakcja != null) try { transakcja.Rollback(); } catch { }
                MessageBox.Show("Błąd podczas rejestrowania zwrotu: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}