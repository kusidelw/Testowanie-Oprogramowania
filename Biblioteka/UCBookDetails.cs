using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCBookDetails : UserControl
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private readonly int _ksiazkaId;
        private readonly KsiazkaRepository _repo;
        private System.Windows.Forms.TextBoxBase[] _polaEdytowalne;

        public UCBookDetails(int ksiazkaId)
        {
            InitializeComponent();
            _ksiazkaId = ksiazkaId;
            _repo = new KsiazkaRepository(ConnStr);
            _polaEdytowalne = new System.Windows.Forms.TextBoxBase[] { txt_tytul, txt_wydawnictwo,
                                       txt_liczba_stron, txt_rok_wydania, txt_cena, txt_opis };
            KonfigurujDGV();
            ZaladujGatunki();
            WczytajSzczegoly();
        }

        public bool IsBibliotekarz
        {
            set
            {
                Color bg = value ? SystemColors.Window : SystemColors.Control;
                foreach (var txt in _polaEdytowalne)
                {
                    txt.ReadOnly  = !value;
                    txt.BackColor = bg;
                }
                cb_gatunek.Enabled   = value;
                cb_gatunek.BackColor = bg;
                btn_zapisz.Visible = value;
            }
        }

        private void ZaladujGatunki()
        {
            try
            {
                var gatunki = _repo.PobierzGatunki("");
                cb_gatunek.DataSource    = gatunki;
                cb_gatunek.DisplayMember = "Nazwa";
                cb_gatunek.ValueMember   = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania gatunków:\n{ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                cb_gatunek.Text            = reader["Gatunek"].ToString();
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

        private bool WalidujFormularz()
        {
            bool isValid = true;
            error_add_book_form.Clear();
            ResetFieldColors();

            if (string.IsNullOrWhiteSpace(txt_tytul.Text))
                { OznaczBlad(txt_tytul, "Tytuł jest wymagany"); isValid = false; }

            if (string.IsNullOrWhiteSpace(txt_wydawnictwo.Text))
                { OznaczBlad(txt_wydawnictwo, "Wydawnictwo jest wymagane"); isValid = false; }

            if (cb_gatunek.SelectedItem == null)
                { error_add_book_form.SetError(cb_gatunek, "Należy wybrać dokładnie jeden gatunek"); isValid = false; }

            if (!int.TryParse(txt_liczba_stron.Text.Trim(), out int _liczbaStron) || _liczbaStron <= 0)
                { OznaczBlad(txt_liczba_stron, "Liczba stron musi być liczbą większą od zera"); isValid = false; }

            if (!int.TryParse(txt_rok_wydania.Text.Trim(), out int _rokWydania)
                || _rokWydania < 1 || _rokWydania > DateTime.Now.Year)
                { OznaczBlad(txt_rok_wydania, "Podaj poprawny rok wydania"); isValid = false; }

            if (!decimal.TryParse(txt_cena.Text.Trim(), out decimal _cena) || _cena <= 0)
                { OznaczBlad(txt_cena, "Cena musi być liczbą większą od zera"); isValid = false; }

            if (string.IsNullOrWhiteSpace(txt_opis.Text))
                { OznaczBlad(txt_opis, "Opis jest wymagany"); isValid = false; }

            return isValid;
        }

        private void OznaczBlad(Control ctrl, string msg)
        {
            ctrl.BackColor = Color.MistyRose;
            error_add_book_form.SetError(ctrl, msg);
        }

        private void ResetFieldColors()
        {
            var stack = new Stack<Control>();
            foreach (Control c in this.Controls) stack.Push(c);
            while (stack.Count > 0)
            {
                var ctrl = stack.Pop();
                if (ctrl is System.Windows.Forms.TextBoxBase tb)
                    tb.BackColor = tb.ReadOnly ? SystemColors.Control : SystemColors.Window;
                foreach (Control child in ctrl.Controls) stack.Push(child);
            }
        }

        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            if (!WalidujFormularz()) return;

            string  tytul       = txt_tytul.Text.Trim();
            string  wydawnictwo = txt_wydawnictwo.Text.Trim();
            string  opis        = txt_opis.Text.Trim();
            int     liczbaStron = int.Parse(txt_liczba_stron.Text.Trim());
            int     rokWydania  = int.Parse(txt_rok_wydania.Text.Trim());
            decimal cena        = decimal.Parse(txt_cena.Text.Trim().Replace(',', '.'),
                                      System.Globalization.NumberStyles.Any,
                                      System.Globalization.CultureInfo.InvariantCulture);
            int gatunekId = ((Models.Gatunek)cb_gatunek.SelectedItem).ID;

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        int wydawnictwoId = _repo.PobierzLubDodajWydawnictwo(conn, tran, wydawnictwo);

                        ZaktualizujKsiazke(conn, tran, tytul, wydawnictwoId, gatunekId,
                            liczbaStron, rokWydania, cena, opis);

                        tran.Commit();
                    }
                }
                MessageBox.Show("Zmiany zostały zapisane.", "Sukces",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                WczytajSzczegoly();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas aktualizacji książki: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZaktualizujKsiazke(SqlConnection conn, SqlTransaction tran,
            string tytul, int wydawnictwoId, int gatunekId,
            int liczbaStron, int rokWydania, decimal cena, string opis)
        {
            const string sql = @"
                UPDATE KatalogKsiazek
                SET Tytul         = @Tytul,
                    WydawnictwoID = @WydawnictwoID,
                    GatunekID     = @GatunekID,
                    LiczbaStron   = @LiczbaStron,
                    RokWydania    = @RokWydania,
                    Cena          = @Cena,
                    Opis          = @Opis
                WHERE ID = @KsiazkaID";

            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.Add("@Tytul",         SqlDbType.NVarChar, 255).Value = tytul;
                cmd.Parameters.Add("@WydawnictwoID", SqlDbType.Int).Value     = wydawnictwoId;
                cmd.Parameters.Add("@GatunekID",     SqlDbType.Int).Value     = gatunekId;
                cmd.Parameters.Add("@LiczbaStron",   SqlDbType.Int).Value     = liczbaStron;
                cmd.Parameters.Add("@RokWydania",    SqlDbType.Int).Value     = rokWydania;
                cmd.Parameters.Add("@Cena",          SqlDbType.Decimal).Value = cena;
                cmd.Parameters.Add("@Opis",          SqlDbType.NVarChar, -1).Value = opis;
                cmd.Parameters.Add("@KsiazkaID",     SqlDbType.Int).Value     = _ksiazkaId;
                cmd.ExecuteNonQuery();
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
