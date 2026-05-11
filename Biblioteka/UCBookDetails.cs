using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCBookDetails : UserControl
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private readonly int _ksiazkaId;

        public UCBookDetails(int ksiazkaId)
        {
            InitializeComponent();
            _ksiazkaId = ksiazkaId;
            KonfigurujDGV();
            WczytajSzczegoly();
        }

        public bool IsBibliotekarz
        {
            set
            {
                bool editable = value;
                txt_tytul.ReadOnly        = !editable;
                txt_wydawnictwo.ReadOnly  = !editable;
                txt_liczba_stron.ReadOnly = !editable;
                txt_rok_wydania.ReadOnly  = !editable;
                txt_cena.ReadOnly         = !editable;
                txt_gatunek.ReadOnly      = !editable;
                txt_opis.ReadOnly         = !editable;

                Color bg = editable ? SystemColors.Window : SystemColors.Control;
                txt_tytul.BackColor        = bg;
                txt_wydawnictwo.BackColor  = bg;
                txt_liczba_stron.BackColor = bg;
                txt_rok_wydania.BackColor  = bg;
                txt_cena.BackColor         = bg;
                txt_gatunek.BackColor      = bg;
                txt_opis.BackColor         = bg;

                btn_zapisz.Visible = editable;
            }
        }

        private void KonfigurujDGV()
        {
            dgv_autorzy.ReadOnly = true;
            dgv_autorzy.AllowUserToAddRows = false;
            dgv_autorzy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_autorzy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_autorzy.MultiSelect = false;
            dgv_autorzy.RowHeadersVisible = false;
        }

        private void WczytajSzczegoly()
        {
            const string sqlKsiazka = @"
                SELECT
                    k.Tytul,
                    w.Nazwa        AS Wydawnictwo,
                    g.Nazwa        AS Gatunek,
                    k.LiczbaStron,
                    k.RokWydania,
                    k.Cena,
                    k.Opis,
                    COUNT(e.ID)    AS LiczbaSztuk
                FROM KatalogKsiazek k
                INNER JOIN Wydawnictwa w ON w.ID = k.WydawnictwoID
                INNER JOIN Gatunki    g ON g.ID = k.GatunekID
                LEFT  JOIN Egzemplarze e ON e.KsiazkaID = k.ID
                WHERE k.ID = @KsiazkaID
                GROUP BY k.Tytul, w.Nazwa, g.Nazwa, k.LiczbaStron, k.RokWydania, k.Cena, k.Opis;";

            const string sqlAutorzy = @"
                SELECT a.Imie, a.Nazwisko
                FROM Autorzy a
                INNER JOIN KsiazkaKatalog_Autorzy ka ON ka.AutorID = a.ID
                WHERE ka.KsiazkaID = @KsiazkaID
                ORDER BY a.Nazwisko, a.Imie;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlKsiazka, conn))
                    {
                        cmd.Parameters.AddWithValue("@KsiazkaID", _ksiazkaId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_tytul.Text             = reader["Tytul"].ToString();
                                txt_wydawnictwo.Text       = reader["Wydawnictwo"].ToString();
                                txt_gatunek.Text           = reader["Gatunek"].ToString();
                                txt_liczba_stron.Text      = reader["LiczbaStron"].ToString();
                                txt_rok_wydania.Text       = reader["RokWydania"].ToString();
                                txt_cena.Text              = $"{reader["Cena"]:0.00}";
                                lbl_liczba_sztuk_ksiazki.Text = reader["LiczbaSztuk"].ToString();
                                lbl_id_ksiazki.Text        = _ksiazkaId.ToString();
                                txt_opis.Text              = reader["Opis"].ToString();

                                lbl_szczegoly_ksiazki.Text = $"SZCZEGÓŁY KSIĄŻKI: {reader["Tytul"]}";
                            }
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(sqlAutorzy, conn))
                    {
                        cmd.Parameters.AddWithValue("@KsiazkaID", _ksiazkaId);
                        var tabela = new DataTable();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            tabela.Load(reader);

                        tabela.Columns["Imie"].ColumnName     = "Imię";
                        tabela.Columns["Nazwisko"].ColumnName = "Nazwisko";

                        dgv_autorzy.DataSource = tabela;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd wczytywania danych książki:\n{ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            string tytul        = txt_tytul.Text.Trim();
            string wydawnictwo  = txt_wydawnictwo.Text.Trim();
            string gatunek      = txt_gatunek.Text.Trim();
            string liczbaStronStr = txt_liczba_stron.Text.Trim();
            string rokWydaniaStr  = txt_rok_wydania.Text.Trim();
            string cenaStr        = txt_cena.Text.Trim().Replace(',', '.');
            string opis           = txt_opis.Text.Trim();

            if (string.IsNullOrEmpty(tytul))
            { MessageBox.Show("Tytuł jest wymagany.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(gatunek))
            { MessageBox.Show("Gatunek jest wymagany", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(wydawnictwo))
            { MessageBox.Show("Wydawnictwo jest wymagane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(liczbaStronStr, out int liczbaStron) || liczbaStron <= 0)
            { MessageBox.Show("Liczba stron musi być liczbą większą od zera.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(rokWydaniaStr, out int rokWydania) || rokWydania < 1 || rokWydania > DateTime.Now.Year)
            { MessageBox.Show("Podaj poprawny rok wydania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!decimal.TryParse(cenaStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal cena) || cena <= 0)
            { MessageBox.Show("Cena musi być liczbą większą od zera.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(opis))
            { MessageBox.Show("Opis jest wymagany.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Pobierz ID gatunku
                            int gatunekId;
                            using (SqlCommand cmd = new SqlCommand(
                                "SELECT ID FROM Gatunki WHERE Nazwa = @Nazwa", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Nazwa", gatunek);
                                object result = cmd.ExecuteScalar();
                                if (result == null)
                                {
                                    MessageBox.Show("Podany gatunek nie istnieje w słowniku.", "Błąd",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    transaction.Rollback();
                                    return;
                                }
                                gatunekId = (int)result;
                            }

                            int wydawnictwoId = PobierzLubDodajWydawnictwo(conn, transaction, wydawnictwo);

                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE KatalogKsiazek
                                SET Tytul          = @Tytul,
                                    WydawnictwoID  = @WydawnictwoID,
                                    GatunekID      = @GatunekID,
                                    LiczbaStron    = @LiczbaStron,
                                    RokWydania     = @RokWydania,
                                    Cena           = @Cena,
                                    Opis           = @Opis
                                WHERE ID = @KsiazkaID", conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Tytul",         tytul);
                                cmd.Parameters.AddWithValue("@WydawnictwoID", wydawnictwoId);
                                cmd.Parameters.AddWithValue("@GatunekID",     gatunekId);
                                cmd.Parameters.AddWithValue("@LiczbaStron",   liczbaStron);
                                cmd.Parameters.AddWithValue("@RokWydania",    rokWydania);
                                cmd.Parameters.AddWithValue("@Cena",          cena);
                                cmd.Parameters.AddWithValue("@Opis",          opis);
                                cmd.Parameters.AddWithValue("@KsiazkaID",     _ksiazkaId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Zmiany zostały zapisane", "Sukces",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            WczytajSzczegoly();
                        }
                        catch (Exception ex)
                        {
                            if (transaction?.Connection?.State == ConnectionState.Open)
                                transaction.Rollback();
                            MessageBox.Show($"Błąd zapisu:\n{ex.Message}", "Błąd",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd połączenia:\n{ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int PobierzLubDodajWydawnictwo(SqlConnection conn, SqlTransaction transaction, string nazwa)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT ID FROM Wydawnictwa WHERE Nazwa = @Nazwa", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Nazwa", nazwa);
                object result = cmd.ExecuteScalar();
                if (result != null) return (int)result;
            }

            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Wydawnictwa (Nazwa) OUTPUT INSERTED.ID VALUES (@Nazwa)", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Nazwa", nazwa);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void btn_wroc_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm is Biblioteka mainForm)
                mainForm.WrocDoListyKsiazek();
        }
    }
}
