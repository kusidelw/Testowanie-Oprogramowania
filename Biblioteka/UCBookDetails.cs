using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                                lbl_tytul_ksiazki.Text       = reader["Tytul"].ToString();
                                lbl_wydawnictwo_ksiazki.Text = reader["Wydawnictwo"].ToString();
                                lbl_gatunek_ksiazki.Text     = reader["Gatunek"].ToString();
                                lbl_liczba_stron_ksiazki.Text = reader["LiczbaStron"].ToString();
                                lbl_rok_wydania_ksiazki.Text = reader["RokWydania"].ToString();
                                lbl_cena_ksiazki.Text        = $"{reader["Cena"]:0.00} zł";
                                lbl_liczba_sztuk_ksiazki.Text = reader["LiczbaSztuk"].ToString();
                                txt_opis.Text = reader["Opis"].ToString();
                         

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

        private void btn_wroc_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
                mainForm.WrocDoListyKsiazek();
        }
    }
}
