using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCAddBook : UserControl
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        public int? CurrentUserId { get; set; }

        public UCAddBook()
        {
            InitializeComponent();
            this.VisibleChanged += (sender, e) =>
            {
                if (Visible)
                {
                    WyczyscFormularz();
                }
            };
        }

        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            if (WalidujFormularz())
            {
                ZapiszKsiazkeDoBazy();
            }
        }

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            WyczyscFormularz();

            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
            {
                mainForm.PowrotDoMenuGlownego();
            }
        }

        private bool WalidujFormularz()
        {
            bool isValid = true;
            int liczbaStron;
            int rokWydania;
            int liczbaSztuk;
            decimal cena;

            error_add_book_form.Clear();
            ResetFieldColors();

            if (string.IsNullOrWhiteSpace(txt_tytul.Text))
            {
                OznaczBlad(txt_tytul, "Tytuł jest wymagany.");
                isValid = false;
            }
            else if (txt_tytul.Text.Trim().Length > 255)
            {
                OznaczBlad(txt_tytul, "Tytuł może mieć maksymalnie 255 znaków.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txt_gatunek.Text))
            {
                OznaczBlad(txt_gatunek, "Gatunek jest wymagany.");
                isValid = false;
            }
            else if (txt_gatunek.Text.Trim().Length > 100)
            {
                OznaczBlad(txt_gatunek, "Gatunek może mieć maksymalnie 100 znaków.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txt_wydawnictwo.Text))
            {
                OznaczBlad(txt_wydawnictwo, "Wydawnictwo jest wymagane.");
                isValid = false;
            }
            else if (txt_wydawnictwo.Text.Trim().Length > 100)
            {
                OznaczBlad(txt_wydawnictwo, "Wydawnictwo może mieć maksymalnie 100 znaków.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txt_autor_imie.Text))
            {
                OznaczBlad(txt_autor_imie, "Imię autora jest wymagane.");
                isValid = false;
            }
            else if (txt_autor_imie.Text.Trim().Length > 50)
            {
                OznaczBlad(txt_autor_imie, "Imię autora może mieć maksymalnie 50 znaków.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txt_autor_nazwisko.Text))
            {
                OznaczBlad(txt_autor_nazwisko, "Nazwisko autora jest wymagane.");
                isValid = false;
            }
            else if (txt_autor_nazwisko.Text.Trim().Length > 50)
            {
                OznaczBlad(txt_autor_nazwisko, "Nazwisko autora może mieć maksymalnie 50 znaków.");
                isValid = false;
            }

            if (!int.TryParse(txt_liczba_stron.Text.Trim(), out liczbaStron) || liczbaStron <= 0)
            {
                OznaczBlad(txt_liczba_stron, "Liczba stron musi być liczbą większą od zera.");
                isValid = false;
            }

            if (!int.TryParse(txt_rok_wydania.Text.Trim(), out rokWydania) ||
                rokWydania < 1450 ||
                rokWydania > DateTime.Now.Year + 1)
            {
                OznaczBlad(txt_rok_wydania, "Podaj poprawny rok wydania.");
                isValid = false;
            }

            if (!TryParseCena(txt_cena.Text.Trim(), out cena) || cena <= 0)
            {
                OznaczBlad(txt_cena, "Cena musi być liczbą większą od zera.");
                isValid = false;
            }

            if (!int.TryParse(txt_liczba_sztuk.Text.Trim(), out liczbaSztuk) || liczbaSztuk <= 0)
            {
                OznaczBlad(txt_liczba_sztuk, "Liczba sztuk musi być liczbą większą od zera.");
                isValid = false;
            }

            return isValid;
        }

        private void ZapiszKsiazkeDoBazy()
        {
            SqlTransaction transaction = null;

            try
            {
                if (!CurrentUserId.HasValue)
                {
                    MessageBox.Show("Brak informacji o zalogowanym bibliotekarzu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tytul = txt_tytul.Text.Trim();
                string gatunek = txt_gatunek.Text.Trim();
                string wydawnictwo = txt_wydawnictwo.Text.Trim();
                string imieAutora = txt_autor_imie.Text.Trim();
                string nazwiskoAutora = txt_autor_nazwisko.Text.Trim();
                int liczbaStron = int.Parse(txt_liczba_stron.Text.Trim());
                int rokWydania = int.Parse(txt_rok_wydania.Text.Trim());
                decimal cena = ParseCena(txt_cena.Text.Trim());
                string opis = txt_opis.Text.Trim();
                int liczbaSztuk = int.Parse(txt_liczba_sztuk.Text.Trim());

                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    int gatunekId = PobierzLubDodajIdSlownika(conn, transaction, "Gatunki", gatunek);
                    int wydawnictwoId = PobierzLubDodajIdSlownika(conn, transaction, "Wydawnictwa", wydawnictwo);
                    int ksiazkaId = DodajKsiazkeDoKatalogu(conn, transaction, tytul, gatunekId, wydawnictwoId, liczbaStron, rokWydania, cena, opis);
                    int autorId = PobierzLubDodajAutora(conn, transaction, imieAutora, nazwiskoAutora);

                    PowiazAutoraZKsiazka(conn, transaction, ksiazkaId, autorId);
                    DodajEgzemplarze(conn, transaction, ksiazkaId, liczbaSztuk, CurrentUserId.Value);

                    transaction.Commit();
                }

                WyczyscFormularz();
                MessageBox.Show("Dodano książkę", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string rollbackKomunikat = string.Empty;

                if (transaction != null && transaction.Connection != null)
                {
                    if (transaction.Connection.State == ConnectionState.Open)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            rollbackKomunikat = "\nDodatkowo nie udało się wycofać transakcji: " + rollbackEx.Message;
                        }
                    }
                }

                MessageBox.Show("Wystąpił błąd podczas dodawania książki: " + ex.Message + rollbackKomunikat, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int PobierzLubDodajIdSlownika(SqlConnection conn, SqlTransaction transaction, string nazwaTabeli, string nazwa)
        {
            string selectSql;
            string insertSql;

            switch (nazwaTabeli)
            {
                case "Gatunki":
                    selectSql = "SELECT ID FROM Gatunki WHERE Nazwa = @Nazwa";
                    insertSql = "INSERT INTO Gatunki (Nazwa) VALUES (@Nazwa); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    break;
                case "Wydawnictwa":
                    selectSql = "SELECT ID FROM Wydawnictwa WHERE Nazwa = @Nazwa";
                    insertSql = "INSERT INTO Wydawnictwa (Nazwa) VALUES (@Nazwa); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    break;
                default:
                    throw new ArgumentException("Nieobsługiwana tabela słownikowa.");
            }

            using (SqlCommand cmd = new SqlCommand(selectSql, conn, transaction))
            {
                cmd.Parameters.Add("@Nazwa", SqlDbType.NVarChar, 100).Value = nazwa;
                object existingId = cmd.ExecuteScalar();

                if (existingId != null)
                {
                    return Convert.ToInt32(existingId);
                }
            }

            using (SqlCommand cmd = new SqlCommand(insertSql, conn, transaction))
            {
                cmd.Parameters.Add("@Nazwa", SqlDbType.NVarChar, 100).Value = nazwa;
                return (int)cmd.ExecuteScalar();
            }
        }

        private int DodajKsiazkeDoKatalogu(
            SqlConnection conn,
            SqlTransaction transaction,
            string tytul,
            int gatunekId,
            int wydawnictwoId,
            int liczbaStron,
            int rokWydania,
            decimal cena,
            string opis)
        {
            const string sql = @"
INSERT INTO KatalogKsiazek
    (Tytul, GatunekID, WydawnictwoID, LiczbaStron, RokWydania, Cena, Opis)
VALUES
    (@Tytul, @GatunekID, @WydawnictwoID, @LiczbaStron, @RokWydania, @Cena, @Opis);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
            {
                cmd.Parameters.Add("@Tytul", SqlDbType.NVarChar, 255).Value = tytul;
                cmd.Parameters.Add("@GatunekID", SqlDbType.Int).Value = gatunekId;
                cmd.Parameters.Add("@WydawnictwoID", SqlDbType.Int).Value = wydawnictwoId;
                cmd.Parameters.Add("@LiczbaStron", SqlDbType.Int).Value = liczbaStron;
                cmd.Parameters.Add("@RokWydania", SqlDbType.Int).Value = rokWydania;
                cmd.Parameters.Add("@Cena", SqlDbType.Decimal).Value = cena;
                cmd.Parameters["@Cena"].Precision = 10;
                cmd.Parameters["@Cena"].Scale = 2;
                cmd.Parameters.Add("@Opis", SqlDbType.NVarChar, -1).Value =
                    string.IsNullOrWhiteSpace(opis) ? (object)DBNull.Value : opis;

                return (int)cmd.ExecuteScalar();
            }
        }

        private int PobierzLubDodajAutora(SqlConnection conn, SqlTransaction transaction, string imie, string nazwisko)
        {
            const string selectSql = "SELECT ID FROM Autorzy WHERE Imie = @Imie AND Nazwisko = @Nazwisko;";
            const string insertSql = @"
INSERT INTO Autorzy (Imie, Nazwisko)
VALUES (@Imie, @Nazwisko);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlCommand cmd = new SqlCommand(selectSql, conn, transaction))
            {
                cmd.Parameters.Add("@Imie", SqlDbType.NVarChar, 50).Value = imie;
                cmd.Parameters.Add("@Nazwisko", SqlDbType.NVarChar, 50).Value = nazwisko;
                object existingId = cmd.ExecuteScalar();

                if (existingId != null)
                {
                    return Convert.ToInt32(existingId);
                }
            }

            using (SqlCommand cmd = new SqlCommand(insertSql, conn, transaction))
            {
                cmd.Parameters.Add("@Imie", SqlDbType.NVarChar, 50).Value = imie;
                cmd.Parameters.Add("@Nazwisko", SqlDbType.NVarChar, 50).Value = nazwisko;
                return (int)cmd.ExecuteScalar();
            }
        }

        private void PowiazAutoraZKsiazka(SqlConnection conn, SqlTransaction transaction, int ksiazkaId, int autorId)
        {
            const string sql = "INSERT INTO KsiazkaKatalog_Autorzy (KsiazkaID, AutorID) VALUES (@KsiazkaID, @AutorID);";

            using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
            {
                cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = ksiazkaId;
                cmd.Parameters.Add("@AutorID", SqlDbType.Int).Value = autorId;
                cmd.ExecuteNonQuery();
            }
        }

        private void DodajEgzemplarze(SqlConnection conn, SqlTransaction transaction, int ksiazkaId, int liczbaSztuk, int bibliotekarzId)
        {
            const string sql = @"
INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID)
VALUES (@KsiazkaID, @Status, @ZarejestrowanePrzezID);";

            for (int i = 0; i < liczbaSztuk; i++)
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
                {
                    cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = ksiazkaId;
                    cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = "Dostepna";
                    cmd.Parameters.Add("@ZarejestrowanePrzezID", SqlDbType.Int).Value = bibliotekarzId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void OznaczBlad(Control ctrl, string msg)
        {
            ctrl.BackColor = Color.MistyRose;
            error_add_book_form.SetError(ctrl, msg);
        }

        private void ResetFieldColors()
        {
            ResetFieldColors(this.Controls);
        }

        private void ResetFieldColors(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox || ctrl is RichTextBox)
                {
                    ctrl.BackColor = SystemColors.Window;
                }

                if (ctrl.HasChildren)
                {
                    ResetFieldColors(ctrl.Controls);
                }
            }
        }

        private void WyczyscFormularz()
        {
            WyczyscKontrolki(this.Controls);
            ResetFieldColors();
            error_add_book_form.Clear();
        }

        private void WyczyscKontrolki(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (ctrl is RichTextBox richTextBox)
                {
                    richTextBox.Clear();
                }

                if (ctrl.HasChildren)
                {
                    WyczyscKontrolki(ctrl.Controls);
                }
            }
        }

        private bool TryParseCena(string tekst, out decimal cena)
        {
            return decimal.TryParse(tekst, NumberStyles.Number, CultureInfo.CurrentCulture, out cena) ||
                   decimal.TryParse(tekst, NumberStyles.Number, CultureInfo.InvariantCulture, out cena);
        }

        private decimal ParseCena(string tekst)
        {
            decimal cena;

            if (TryParseCena(tekst, out cena))
            {
                return cena;
            }

            throw new FormatException("Niepoprawny format ceny.");
        }
    }
}
