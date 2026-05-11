using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCAddBook : UserControl
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private readonly KsiazkaRepository _repo;

        private readonly int? _ksiazkaId;
        private readonly bool _czyEdycja;

        public int? CurrentUserId { get; set; }

        private bool CzyTrybEgzemplarzy => _ksiazkaId.HasValue && !_czyEdycja;

        // ── KONSTRUKTORY ────────────────────────────────────────────────────────

        public UCAddBook()
        {
            InitializeComponent();
            _repo = new KsiazkaRepository(ConnStr);
            WczytajAutorowDoListy();
            WczytajGatunkiDoListy();
            KonfigurujTrybDodawania();
        }

        public UCAddBook(int ksiazkaId, bool czyEdycja)

        {
            _ksiazkaId = ksiazkaId;
            _czyEdycja = czyEdycja;
            InitializeComponent();
            _repo = new KsiazkaRepository(ConnStr);
            WczytajAutorowDoListy();
            WczytajGatunkiDoListy();
            ZaladujDaneKsiazki();
            if (_czyEdycja) KonfigurujTrybEdycji();
            else KonfigurujTrybDodawaniaEgzemplarzy();
        }

        // ── KONFIGURACJA TRYBU ──────────────────────────────────────────────────

        private void KonfigurujTrybDodawania()
        {
            lbl_naglowek.Text = "REJESTRACJA KSIĄŻEK";
            txt_liczba_sztuk.Visible  = true;
            lbl_liczba_sztuk.Visible  = true;
        }

        private void KonfigurujTrybDodawaniaEgzemplarzy()
        {
            lbl_naglowek.Text = "DODAWANIE EGZEMPLARZY";

            UstawPoleTylkoDoOdczytu(txt_tytul,        true);
            UstawPoleTylkoDoOdczytu(txt_wydawnictwo,  true);
            UstawPoleTylkoDoOdczytu(txt_liczba_stron, true);
            UstawPoleTylkoDoOdczytu(txt_rok_wydania,  true);
            UstawPoleTylkoDoOdczytu(txt_cena,         true);
            UstawPoleTylkoDoOdczytu(txt_opis,         true);

            chlb_autorzy.Enabled = false;
            chlb_gatunki.Enabled = false;

            txt_autor_imie.Visible     = false;
            txt_autor_nazwisko.Visible = false;
            lbl_autor_imie.Text        = "Autorzy:";   // etykieta sekcji zamiast "Imię autora:"
            lbl_autor_nazwisko.Visible = false;
            btn_search.Visible         = false;
            btn_add_author.Visible     = false;
            btn_delete_autor.Visible   = false;
            txt_gatunek.Visible        = false;
            lbl_gatunek.Text           = "Gatunki:";   // etykieta sekcji zamiast "Gatunek:"
            btn_search_gatunek.Visible = false;
            btn_add_gatunek.Visible    = false;
            btn_delete_gatunek.Visible = false;

            txt_liczba_sztuk.Visible = true;
            lbl_liczba_sztuk.Visible = true;
        }

        private void KonfigurujTrybEdycji()
        {
            lbl_naglowek.Text = "EDYCJA KSIĄŻKI";

            txt_liczba_sztuk.Visible = false;
            lbl_liczba_sztuk.Visible = false;
        }

        // ── ŁADOWANIE DANYCH ────────────────────────────────────────────────────

        private void ZaladujDaneKsiazki()
        {
            try
            {
                DaneKsiazki dane = _repo.PobierzDaneKsiazki(_ksiazkaId.Value);
                if (dane == null)
                {
                    MessageBox.Show("Nie znaleziono książki o podanym ID.", "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txt_tytul.Text        = dane.Tytul;
                txt_wydawnictwo.Text  = dane.Wydawnictwo;
                txt_liczba_stron.Text = dane.LiczbaStron.ToString();
                txt_rok_wydania.Text  = dane.RokWydania.ToString();
                txt_cena.Text         = dane.Cena.ToString(CultureInfo.InvariantCulture);
                txt_opis.Text         = dane.Opis;

                List<int> autorzyIds = _repo.PobierzAutorzyKsiazki(_ksiazkaId.Value);
                ZaznaczAutorowWListach(autorzyIds);
                ZaznaczGatunekWListach(dane.GatunekId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania danych książki: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZaznaczAutorowWListach(List<int> autorzyIds)
        {
            for (int i = 0; i < chlb_autorzy.Items.Count; i++)
            {
                var autor = (Autor)chlb_autorzy.Items[i];
                chlb_autorzy.SetItemChecked(i, autorzyIds.Contains(autor.ID));
            }
        }

        private void ZaznaczGatunekWListach(int gatunekId)
        {
            for (int i = 0; i < chlb_gatunki.Items.Count; i++)
            {
                var gatunek = (Gatunek)chlb_gatunki.Items[i];
                chlb_gatunki.SetItemChecked(i, gatunek.ID == gatunekId);
            }
        }

        private void WczytajAutorowDoListy(string imie = null, string nazwisko = null)
        {
            chlb_autorzy.Items.Clear();
            try
            {
                var autorzy = _repo.PobierzAutorow(imie ?? string.Empty, nazwisko ?? string.Empty);
                foreach (var autor in autorzy)
                    chlb_autorzy.Items.Add(autor, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas wczytywania autorów: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WczytajGatunkiDoListy(string nazwa = null)
        {
            chlb_gatunki.Items.Clear();
            try
            {
                var gatunki = _repo.PobierzGatunki(nazwa ?? string.Empty);
                foreach (var gatunek in gatunki)
                    chlb_gatunki.Items.Add(gatunek, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas wczytywania gatunków: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── WALIDACJA ───────────────────────────────────────────────────────────

        private bool WalidujFormularz()
        {
            bool isValid = true;
            error_add_book_form.Clear();
            ResetFieldColors();

            if (!txt_tytul.ReadOnly)
            {
                if (string.IsNullOrWhiteSpace(txt_tytul.Text))
                    { OznaczBlad(txt_tytul, "Tytuł jest wymagany"); isValid = false; }
                else if (txt_tytul.Text.Trim().Length > 255)
                    { OznaczBlad(txt_tytul, "Tytuł może mieć maksymalnie 255 znaków"); isValid = false; }
            }

            if (!txt_wydawnictwo.ReadOnly)
            {
                if (string.IsNullOrWhiteSpace(txt_wydawnictwo.Text))
                    { OznaczBlad(txt_wydawnictwo, "Wydawnictwo jest wymagane"); isValid = false; }
                else if (txt_wydawnictwo.Text.Trim().Length > 100)
                    { OznaczBlad(txt_wydawnictwo, "Wydawnictwo może mieć maksymalnie 100 znaków"); isValid = false; }
            }

            if (chlb_gatunki.Enabled)
            {
                if (chlb_gatunki.CheckedItems.Count != 1)
                    { error_add_book_form.SetError(chlb_gatunki, "Należy wybrać dokładnie jeden gatunek"); isValid = false; }
            }

            if (chlb_autorzy.Enabled)
            {
                if (chlb_autorzy.CheckedItems.Count == 0)
                    { error_add_book_form.SetError(chlb_autorzy, "Wybierz co najmniej jednego autora"); isValid = false; }
            }

            if (!txt_liczba_stron.ReadOnly)
            {
                if (!int.TryParse(txt_liczba_stron.Text.Trim(), out int liczbaStron) || liczbaStron <= 0)
                    { OznaczBlad(txt_liczba_stron, "Liczba stron musi być liczbą większą od zera"); isValid = false; }
            }

            if (!txt_rok_wydania.ReadOnly)
            {
                if (!int.TryParse(txt_rok_wydania.Text.Trim(), out int rokWydania)
                    || rokWydania < 1450 || rokWydania > DateTime.Now.Year + 1)
                    { OznaczBlad(txt_rok_wydania, "Podaj poprawny rok wydania"); isValid = false; }
            }

            if (!txt_cena.ReadOnly)
            {
                if (!decimal.TryParse(txt_cena.Text.Trim(), out decimal cena) || cena <= 0)
                    { OznaczBlad(txt_cena, "Cena musi być liczbą większą od zera"); isValid = false; }
            }

            if (txt_liczba_sztuk.Visible)
            {
                if (!int.TryParse(txt_liczba_sztuk.Text.Trim(), out int sztuki) || sztuki <= 0)
                    { OznaczBlad(txt_liczba_sztuk, "Liczba sztuk musi być liczbą większą od zera"); isValid = false; }
            }

            if (!txt_opis.ReadOnly)
            {
                if (string.IsNullOrWhiteSpace(txt_opis.Text))
                    { OznaczBlad(txt_opis, "Opis jest wymagany"); isValid = false; }
            }

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
                if (ctrl is TextBoxBase tb)
                    tb.BackColor = tb.ReadOnly ? SystemColors.Control : SystemColors.Window;
                foreach (Control child in ctrl.Controls) stack.Push(child);
            }
        }

        private void WyczyscFormularz()
        {
            txt_tytul.Clear();
            txt_wydawnictwo.Clear();
            txt_liczba_stron.Clear();
            txt_rok_wydania.Clear();
            txt_cena.Clear();
            txt_liczba_sztuk.Clear();
            txt_opis.Clear();
            txt_autor_imie.Clear();
            txt_autor_nazwisko.Clear();
            txt_gatunek.Clear();

            for (int i = 0; i < chlb_autorzy.Items.Count; i++)
                chlb_autorzy.SetItemChecked(i, false);
            for (int i = 0; i < chlb_gatunki.Items.Count; i++)
                chlb_gatunki.SetItemChecked(i, false);

            ResetFieldColors();
            error_add_book_form.Clear();
        }

        private void UstawPoleTylkoDoOdczytu(TextBoxBase pole, bool tylkoDoOdczytu)
        {
            pole.ReadOnly  = tylkoDoOdczytu;
            pole.BackColor = tylkoDoOdczytu ? SystemColors.Control : SystemColors.Window;
        }

        // ── OPERACJE ZAPISU ─────────────────────────────────────────────────────

        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            if (!CurrentUserId.HasValue)
            {
                MessageBox.Show("Brak informacji o zalogowanym użytkowniku.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_ksiazkaId.HasValue && SprawdzDuplikat()) return;

            if (!WalidujFormularz()) return;

            if (!_ksiazkaId.HasValue) WykonajDodawanie();
            else if (!_czyEdycja)    WykonajDodawanieEgzemplarzy();
            else                     WykonajEdycje();
        }

        private bool SprawdzDuplikat()
        {
            if (string.IsNullOrWhiteSpace(txt_tytul.Text)) return false;
            if (chlb_autorzy.CheckedItems.Count == 0) return false;

            var autorzyIds = new List<int>();
            foreach (Autor autor in chlb_autorzy.CheckedItems)
                autorzyIds.Add(autor.ID);

            try
            {
                int? duplikatId = _repo.CzyKsiazkaIstnieje(txt_tytul.Text.Trim(), autorzyIds);
                if (!duplikatId.HasValue) return false;

                MessageBox.Show(
                    "Książka o podanym tytule i autorze już istnieje. Użyj opcji dopisania do stanu.",
                    "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas sprawdzania duplikatu: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void WykonajDodawanie()
        {
            var gatunek    = (Gatunek)chlb_gatunki.CheckedItems[0];
            int liczbaStron = int.Parse(txt_liczba_stron.Text.Trim());
            int rokWydania  = int.Parse(txt_rok_wydania.Text.Trim());
            decimal cena    = decimal.Parse(txt_cena.Text.Trim());
            int liczbaSztuk = int.Parse(txt_liczba_sztuk.Text.Trim());

            var autorzyIds = new List<int>();
            foreach (Autor autor in chlb_autorzy.CheckedItems)
                autorzyIds.Add(autor.ID);

            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    int ksiazkaId = _repo.DodajNowaKsiazke(conn, transaction,
                        txt_tytul.Text.Trim(), gatunek.ID, txt_wydawnictwo.Text.Trim(),
                        liczbaStron, rokWydania, cena, txt_opis.Text.Trim());

                    _repo.PowiazAutorowZKsiazka(conn, transaction, ksiazkaId, autorzyIds);
                    _repo.DodajEgzemplarze(conn, transaction, ksiazkaId, liczbaSztuk, CurrentUserId.Value);

                    transaction.Commit();
                }
                WyczyscFormularz();
                MessageBox.Show("Dodano książkę.", "Sukces",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (transaction?.Connection?.State == System.Data.ConnectionState.Open)
                    try { transaction.Rollback(); } catch { }
                MessageBox.Show("Błąd podczas dodawania książki: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WykonajDodawanieEgzemplarzy()
        {
            int liczbaSztuk = int.Parse(txt_liczba_sztuk.Text.Trim());
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    _repo.DodajEgzemplarze(conn, transaction, _ksiazkaId.Value, liczbaSztuk, CurrentUserId.Value);
                    transaction.Commit();
                }
                MessageBox.Show("Pomyślnie zwiększono liczbę sztuk wybranej książki.", "Sukces",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                WrocDoListyKsiazek();
            }
            catch (Exception ex)
            {
                if (transaction?.Connection?.State == System.Data.ConnectionState.Open)
                    try { transaction.Rollback(); } catch { }
                MessageBox.Show("Błąd podczas dodawania egzemplarzy: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WykonajEdycje()
        {
            var gatunek    = (Gatunek)chlb_gatunki.CheckedItems[0];
            int liczbaStron = int.Parse(txt_liczba_stron.Text.Trim());
            int rokWydania  = int.Parse(txt_rok_wydania.Text.Trim());
            decimal cena    = decimal.Parse(txt_cena.Text.Trim());

            var nowaListaAutorow = new List<int>();
            foreach (Autor autor in chlb_autorzy.CheckedItems)
                nowaListaAutorow.Add(autor.ID);

            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    _repo.AktualizujKsiazke(conn, transaction, _ksiazkaId.Value,
                        txt_tytul.Text.Trim(), gatunek.ID, txt_wydawnictwo.Text.Trim(),
                        liczbaStron, rokWydania, cena, txt_opis.Text.Trim(), nowaListaAutorow);
                    transaction.Commit();
                }
                MessageBox.Show("Zmiany zostały zapisane.", "Sukces",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                WrocDoListyKsiazek();
            }
            catch (Exception ex)
            {
                if (transaction?.Connection?.State == System.Data.ConnectionState.Open)
                    try { transaction.Rollback(); } catch { }
                MessageBox.Show("Błąd podczas aktualizacji książki: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── NAWIGACJA ───────────────────────────────────────────────────────────

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            if (_ksiazkaId.HasValue) WrocDoListyKsiazek();
            else PowrotDoMenuGlownego();
        }

        private void WrocDoListyKsiazek()
        {
            if (this.FindForm() is Biblioteka mainForm)
                mainForm.WrocDoListyKsiazek();
        }

        private void PowrotDoMenuGlownego()
        {
            if (this.FindForm() is Biblioteka mainForm)
                mainForm.PowrotDoMenuGlownego();
        }

        // ── AUTORZY ─────────────────────────────────────────────────────────────

        private void btn_search_Click(object sender, EventArgs e)
        {
            WczytajAutorowDoListy(txt_autor_imie.Text.Trim(), txt_autor_nazwisko.Text.Trim());
        }

        private void btn_add_author_Click(object sender, EventArgs e)
        {
            string imie     = txt_autor_imie.Text.Trim();
            string nazwisko = txt_autor_nazwisko.Text.Trim();

            error_add_book_form.SetError(txt_autor_imie, "");
            error_add_book_form.SetError(txt_autor_nazwisko, "");
            txt_autor_imie.BackColor     = SystemColors.Window;
            txt_autor_nazwisko.BackColor = SystemColors.Window;

            bool brakImienia   = string.IsNullOrWhiteSpace(imie);
            bool brakNazwiska  = string.IsNullOrWhiteSpace(nazwisko);

            if (brakImienia)   OznaczBlad(txt_autor_imie,     "Imię autora jest wymagane");
            if (brakNazwiska)  OznaczBlad(txt_autor_nazwisko, "Nazwisko autora jest wymagane");
            if (brakImienia || brakNazwiska) return;

            try
            {
                _repo.DodajAutora(imie, nazwisko);
                txt_autor_imie.Clear();
                txt_autor_nazwisko.Clear();
                txt_autor_imie.Focus();
                WczytajAutorowDoListy();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania autora: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_autor_Click(object sender, EventArgs e)
        {
            if (chlb_autorzy.CheckedItems.Count == 0)
            {
                MessageBox.Show("Nie zaznaczono żadnego autora do usunięcia.", "Informacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Czy na pewno chcesz usunąć zaznaczonych autorów? Ta operacja jest nieodwracalna.",
                    "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            var doSprawdzenia = new List<int>();
            foreach (Autor autor in chlb_autorzy.CheckedItems)
                doSprawdzenia.Add(autor.ID);

            try
            {
                var powiazania = _repo.PobierzLiczbePowiazanKsiazekAutorow(doSprawdzenia);
                var doUsuniecia = new List<int>();

                foreach (Autor autor in chlb_autorzy.CheckedItems)
                {
                    if (powiazania[autor.ID] > 0)
                    {
                        MessageBox.Show(
                            $"Nie można usunąć autora \"{autor.Imie} {autor.Nazwisko}\" — jest przypisany do {powiazania[autor.ID]} książek.",
                            "Operacja niemożliwa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        doUsuniecia.Add(autor.ID);
                    }
                }

                if (doUsuniecia.Count > 0)
                {
                    _repo.UsunAutorow(doUsuniecia);
                    WczytajAutorowDoListy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas usuwania autora: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── GATUNKI ─────────────────────────────────────────────────────────────

        private void btn_search_gatunek_Click(object sender, EventArgs e)
        {
            WczytajGatunkiDoListy(txt_gatunek.Text.Trim());
        }

        private void btn_add_gatunek_Click(object sender, EventArgs e)
        {
            string nazwa = txt_gatunek.Text.Trim();
            if (string.IsNullOrWhiteSpace(nazwa))
            {
                MessageBox.Show("Podaj gatunek.", "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _repo.DodajGatunek(nazwa);
                txt_gatunek.Clear();
                txt_gatunek.Focus();
                WczytajGatunkiDoListy();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania gatunku: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_gatunek_Click(object sender, EventArgs e)
        {
            if (chlb_gatunki.CheckedItems.Count == 0)
            {
                MessageBox.Show("Nie zaznaczono żadnego gatunku do usunięcia.", "Informacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone gatunki? Ta operacja jest nieodwracalna.",
                    "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            var doSprawdzenia = new List<int>();
            foreach (Gatunek g in chlb_gatunki.CheckedItems)
                doSprawdzenia.Add(g.ID);

            try
            {
                var powiazania = _repo.PobierzLiczbePowiazanKsiazekGatunkow(doSprawdzenia);
                var doUsuniecia = new List<int>();

                foreach (Gatunek g in chlb_gatunki.CheckedItems)
                {
                    if (powiazania[g.ID] > 0)
                    {
                        MessageBox.Show(
                            $"Nie można usunąć gatunku \"{g.Nazwa}\" — jest przypisany do {powiazania[g.ID]} książek.",
                            "Operacja niemożliwa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        doUsuniecia.Add(g.ID);
                    }
                }

                if (doUsuniecia.Count > 0)
                {
                    _repo.UsunGatunki(doUsuniecia);
                    WczytajGatunkiDoListy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas usuwania gatunku: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
