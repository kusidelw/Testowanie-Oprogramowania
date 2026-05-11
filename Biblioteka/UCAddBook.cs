using Biblioteka.Models;
using System;
using System.Collections.Generic;
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

        public int? IstniejacaKsiazkaId { get; set; }

        private enum TrybFormularza { Dodawanie, DodajEgzemplarze, Edycja }
        private TrybFormularza _tryb = TrybFormularza.Dodawanie;

        private bool CzyTrybDodawaniaEgzemplarzy => _tryb == TrybFormularza.DodajEgzemplarze;
        private bool CzyTrybEdycji               => _tryb == TrybFormularza.Edycja;

        
        public UCAddBook()
        {
            InitializeComponent();

            WczytajAutorowDoListy();
            WczytajGatunkiDoListy();
            PrzygotujDoDodawaniaNowejKsiazki();
        }

        public void PrzygotujDoDodawaniaNowejKsiazki()
        {
            IstniejacaKsiazkaId = null;
            _tryb = TrybFormularza.Dodawanie;
            WyczyscFormularz();
            UstawTrybFormularza(TrybFormularza.Dodawanie);
        }

        public void ZaladujDaneIstniejacejKsiazki(int ksiazkaId)
        {
            PrzygotujDoDodawaniaNowejKsiazki();
            IstniejacaKsiazkaId = ksiazkaId;

            const string sql = @"
                SELECT K.Tytul,
                       G.Nazwa AS Gatunek,
                       G.ID AS GatunekID
                FROM KatalogKsiazek K
                JOIN Gatunki     G ON G.ID = K.GatunekID
                WHERE K.ID = @ID;";

            const string sqlAutorzy = @"
                SELECT A.ID, A.Imie, A.Nazwisko
                FROM Autorzy A
                JOIN KsiazkaKatalog_Autorzy KA ON KA.AutorID = A.ID
                WHERE KA.KsiazkaID = @ID;";

            int gatunekId = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ksiazkaId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_tytul.Text = reader["Tytul"].ToString();
                                gatunekId = (int)reader["GatunekID"];
                            }
                        }
                    }

                    // Zaznacz odpowiednich autorów w liście
                    using (SqlCommand cmd = new SqlCommand(sqlAutorzy, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ksiazkaId);
                        var autorzyIds = new System.Collections.Generic.List<int>();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                                autorzyIds.Add((int)reader["ID"]);

                        for (int i = 0; i < chlb_autorzy.Items.Count; i++)
                        {
                            var autor = (Autor)chlb_autorzy.Items[i];
                            chlb_autorzy.SetItemChecked(i, autorzyIds.Contains(autor.ID));
                        }
                    }

                    // Zaznacz gatunek w liście
                    for (int i = 0; i < chlb_gatunki.Items.Count; i++)
                    {
                        var gatunek = (Gatunek)chlb_gatunki.Items[i];
                        chlb_gatunki.SetItemChecked(i, gatunek.ID == gatunekId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania danych książki: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UstawTrybFormularza(TrybFormularza.DodajEgzemplarze);
        }

        public void ZaladujDoEdycji(int ksiazkaId)
        {
            PrzygotujDoDodawaniaNowejKsiazki();
            IstniejacaKsiazkaId = ksiazkaId;

            const string sql = @"
                SELECT K.Tytul, W.Nazwa AS Wydawnictwo, G.Nazwa AS Gatunek, G.ID AS GatunekID,
                       K.LiczbaStron, K.RokWydania, K.Cena, K.Opis
                FROM KatalogKsiazek K
                JOIN Gatunki     G ON G.ID = K.GatunekID
                JOIN Wydawnictwa W ON W.ID = K.WydawnictwoID
                WHERE K.ID = @ID;";

            const string sqlAutorzy = @"
                SELECT A.ID, A.Imie, A.Nazwisko
                FROM Autorzy A
                JOIN KsiazkaKatalog_Autorzy KA ON KA.AutorID = A.ID
                WHERE KA.KsiazkaID = @ID;";

            int gatunekId = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ksiazkaId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_tytul.Text        = reader["Tytul"].ToString();
                                txt_wydawnictwo.Text  = reader["Wydawnictwo"].ToString();
                                txt_liczba_stron.Text = reader["LiczbaStron"].ToString();
                                txt_rok_wydania.Text  = reader["RokWydania"].ToString();
                                txt_cena.Text         = ((decimal)reader["Cena"]).ToString(CultureInfo.InvariantCulture);
                                txt_opis.Text         = reader["Opis"].ToString();
                                gatunekId             = (int)reader["GatunekID"];
                            }
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(sqlAutorzy, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ksiazkaId);
                        var autorzyIds = new System.Collections.Generic.List<int>();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                                autorzyIds.Add((int)reader["ID"]);

                        for (int i = 0; i < chlb_autorzy.Items.Count; i++)
                        {
                            var autor = (Autor)chlb_autorzy.Items[i];
                            chlb_autorzy.SetItemChecked(i, autorzyIds.Contains(autor.ID));
                        }
                    }

                    for (int i = 0; i < chlb_gatunki.Items.Count; i++)
                    {
                        var gatunek = (Gatunek)chlb_gatunki.Items[i];
                        chlb_gatunki.SetItemChecked(i, gatunek.ID == gatunekId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania danych książki: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UstawTrybFormularza(TrybFormularza.Edycja);
        }

        private void WczytajAutorowDoListy(string imie = null, string nazwisko = null)
        {
            chlb_autorzy.Items.Clear();

            const string sql = @"SELECT ID, Imie, Nazwisko FROM Autorzy
                WHERE Imie LIKE @Imie AND Nazwisko LIKE @Nazwisko
                ORDER BY Nazwisko, Imie;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Imie", $"%{imie}%");
                        cmd.Parameters.Add("@Nazwisko", $"%{nazwisko}%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var autor = new Autor
                                {
                                    ID = (int)reader["ID"],
                                    Imie = reader["Imie"].ToString(),
                                    Nazwisko = reader["Nazwisko"].ToString()
                                };
                                chlb_autorzy.Items.Add(autor, false);
                            }
                             

                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas wczytywania autorów: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WczytajGatunkiDoListy(string nazwa = null)
        {
            chlb_gatunki.Items.Clear();

            const string sql = @"SELECT ID, Nazwa FROM Gatunki
                WHERE Nazwa LIKE @Nazwa
                ORDER BY Nazwa;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Nazwa", $"%{nazwa}%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var gatunek = new Gatunek
                                {
                                    ID = (int)reader["ID"],
                                    Nazwa = reader["Nazwa"].ToString()
                                };
                                chlb_gatunki.Items.Add(gatunek, false);
                            }



                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas wczytywania gatunków: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            if (!CzyTrybDodawaniaEgzemplarzy && CzyKsiazkaIstnieje())
            {
                return;
            }

            if (WalidujFormularz())
            {
                ZapiszKsiazkeDoBazy();
            }
        }

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            WyczyscFormularz();

            Form parentForm = this.FindForm();
            if (parentForm is Biblioteka mainForm)
            {
                if (CzyTrybEdycji)
                    mainForm.WrocDoListyKsiazek();
                else
                    mainForm.PowrotDoMenuGlownego();
            }
        }

        private bool WalidujFormularz()
        {
            bool isValid = true;
            int liczbaSztuk;

            error_add_book_form.Clear();
            ResetFieldColors();

            if (CzyTrybDodawaniaEgzemplarzy)
            {
                string sztukiText = txt_liczba_sztuk.Text.Trim();
                if (string.IsNullOrEmpty(sztukiText) || !int.TryParse(sztukiText, out liczbaSztuk))
                {
                    OznaczBlad(txt_liczba_sztuk, "Liczba sztuk musi być liczbą większą od zera");
                    isValid = false;
                }
                else if (liczbaSztuk <= 0)
                {
                    OznaczBlad(txt_liczba_sztuk, "Liczba sztuk musi być większa od 0");
                    isValid = false;
                }

                return isValid;
            }

            int liczbaStron;
            int rokWydania;
            decimal cena;

            if (string.IsNullOrWhiteSpace(txt_tytul.Text))
            {
                OznaczBlad(txt_tytul, "Tytuł jest wymagany");
                isValid = false;
            }
            else if (txt_tytul.Text.Trim().Length > 255)
            {
                OznaczBlad(txt_tytul, "Tytuł może mieć maksymalnie 255 znaków.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txt_wydawnictwo.Text))
            {
                OznaczBlad(txt_wydawnictwo, "Wydawnictwo jest wymagane");
                isValid = false;
            }
            else if (txt_wydawnictwo.Text.Trim().Length > 100)
            {
                OznaczBlad(txt_wydawnictwo, "Wydawnictwo może mieć maksymalnie 100 znaków.");
                isValid = false;
            }

            if (!CzyTrybDodawaniaEgzemplarzy)
            {
                if (chlb_gatunki.CheckedItems.Count == 0 || chlb_gatunki.CheckedItems.Count > 1)
                {
                    error_add_book_form.SetError(chlb_gatunki, "Gatunek jest wymagany");
                    isValid = false;
                }

                if (chlb_autorzy.CheckedItems.Count == 0)
                {
                    error_add_book_form.SetError(chlb_autorzy, "Wybierz co najmniej jednego autora.");
                    isValid = false;
                }
            }

            if (!int.TryParse(txt_liczba_stron.Text.Trim(), out liczbaStron) || liczbaStron <= 0)
            {
                OznaczBlad(txt_liczba_stron, "Liczba stron musi być liczbą większą od zera");
                isValid = false;
            }

            if (!int.TryParse(txt_rok_wydania.Text.Trim(), out rokWydania) ||
                rokWydania < 1450 ||
                rokWydania > DateTime.Now.Year + 1)
            {
                OznaczBlad(txt_rok_wydania, "Podaj poprawny rok wydania");
                isValid = false;
            }

            if (!decimal.TryParse(txt_cena.Text.Trim(), out cena) || cena <= 0)
            {
                OznaczBlad(txt_cena, "Cena musi być liczbą większą od zera");
                isValid = false;
            }

            if (!CzyTrybEdycji)
            {
                string sztukiText = txt_liczba_sztuk.Text.Trim();
                if (string.IsNullOrEmpty(sztukiText) || !int.TryParse(sztukiText, out liczbaSztuk))
                {
                    OznaczBlad(txt_liczba_sztuk, "Liczba sztuk musi być liczbą większą od zera");
                    isValid = false;
                }
                else if (liczbaSztuk <= 0)
                {
                    OznaczBlad(txt_liczba_sztuk, "Liczba sztuk musi być większa od 0");
                    isValid = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txt_opis.Text))
            {
                OznaczBlad(txt_opis, "Opis jest wymagany");
                isValid = false;
            }

            return isValid;
        }

        private void ZapiszKsiazkeDoBazy()
        {
            if (!CurrentUserId.HasValue)
            {
                MessageBox.Show("Brak informacji o zalogowanym bibliotekarzu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CzyTrybDodawaniaEgzemplarzy)
            {
                DodajEgzemplarzeDoIstniejacejKsiazki();
                return;
            }

            if (CzyTrybEdycji)
            {
                AktualizujKsiazkeDoBazy();
                return;
            }

            var gatunek = (Gatunek)chlb_gatunki.CheckedItems[0];
            int liczbaStron = int.Parse(txt_liczba_stron.Text.Trim());
            int rokWydania  = int.Parse(txt_rok_wydania.Text.Trim());
            decimal cena    = decimal.Parse(txt_cena.Text.Trim());
            int liczbaSztuk = int.Parse(txt_liczba_sztuk.Text.Trim());

            SqlTransaction transaction = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // 1. Wydawnictwo — lookup-or-insert
                    int wydawnictwoId = PobierzLubDodajWydawnictwo(conn, transaction, txt_wydawnictwo.Text.Trim());

                    // 2. Dodaj książkę
                    const string sqlKsiazka = @"INSERT INTO KatalogKsiazek (Tytul, GatunekID, WydawnictwoID, LiczbaStron, RokWydania, Cena, Opis)
                        VALUES (@Tytul, @GatunekID, @WydawnictwoID, @LiczbaStron, @RokWydania, @Cena, @Opis);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int ksiazkaId;
                    using (SqlCommand cmd = new SqlCommand(sqlKsiazka, conn, transaction))
                    {
                        cmd.Parameters.Add("@Tytul", txt_tytul.Text.Trim());
                        cmd.Parameters.Add("@GatunekID",gatunek.ID);
                        cmd.Parameters.Add("@WydawnictwoID", wydawnictwoId);
                        cmd.Parameters.Add("@LiczbaStron", liczbaStron);
                        cmd.Parameters.Add("@RokWydania", rokWydania);
                        cmd.Parameters.Add("@Cena", cena);
                        cmd.Parameters.Add("@Opis", txt_opis.Text.Trim());

                        ksiazkaId = (int)cmd.ExecuteScalar();
                    }

                    // 3. Powiąż zaznaczonych autorów
                    const string sqlAutor = "INSERT INTO KsiazkaKatalog_Autorzy (KsiazkaID, AutorID) VALUES (@KsiazkaID, @AutorID);";
                    foreach (Autor autor in chlb_autorzy.CheckedItems)
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlAutor, conn, transaction))
                        {
                            cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = ksiazkaId;
                            cmd.Parameters.Add("@AutorID",   SqlDbType.Int).Value = autor.ID;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 4. Dodaj egzemplarze
                    const string sqlEgz = "INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID) VALUES (@KsiazkaID, 'Dostepna', @BibID);";
                    for (int i = 0; i < liczbaSztuk; i++)
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlEgz, conn, transaction))
                        {
                            cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = ksiazkaId;
                            cmd.Parameters.Add("@BibID",     SqlDbType.Int).Value = CurrentUserId.Value;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }

                WyczyscFormularz();
                MessageBox.Show("Dodano książkę", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (transaction?.Connection?.State == ConnectionState.Open)
                    try { transaction.Rollback(); } catch { }

                MessageBox.Show("Błąd podczas dodawania książki: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DodajEgzemplarzeDoIstniejacejKsiazki()
        {
            int liczbaSztuk = int.Parse(txt_liczba_sztuk.Text.Trim());

            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    const string sqlEgz = @"INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID)
                        VALUES (@KsiazkaID, 'Dostepna', @BibID);";

                    for (int i = 0; i < liczbaSztuk; i++)
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlEgz, conn, transaction))
                        {
                            cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = IstniejacaKsiazkaId.Value;
                            cmd.Parameters.Add("@BibID",     SqlDbType.Int).Value = CurrentUserId.Value;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }

                MessageBox.Show($"Pomyślnie zwiększono liczbę sztuk wybranej książki", "Sukces",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form parentForm = this.FindForm();
                if (parentForm is Biblioteka mainForm)
                    mainForm.PowrotDoMenuGlownego();
            }
            catch (Exception ex)
            {
                if (transaction?.Connection?.State == ConnectionState.Open)
                    try { transaction.Rollback(); } catch { }
                MessageBox.Show("Błąd podczas dodawania egzemplarzy: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CzyKsiazkaIstnieje()
        {
            if (string.IsNullOrWhiteSpace(txt_tytul.Text))
            {
                OznaczBlad(txt_tytul, "Tytuł jest wymagany.");
                return false;
            }

            if (chlb_autorzy.CheckedItems.Count == 0)
            {
                error_add_book_form.SetError(chlb_autorzy, "Wybierz co najmniej jednego autora.");
                return false;
            }

            var autorzyIds = new List<int>();
            foreach (Autor autor in chlb_autorzy.CheckedItems)
                autorzyIds.Add(autor.ID);

            var parametry = new System.Text.StringBuilder();
            for (int i = 0; i < autorzyIds.Count; i++)
                parametry.Append(i == 0 ? $"@A{i}" : $",@A{i}");

            string sql = $@"SELECT TOP 1 K.ID FROM KatalogKsiazek K
                JOIN KsiazkaKatalog_Autorzy KA ON KA.KsiazkaID = K.ID
                WHERE K.Tytul = @Tytul AND KA.AutorID IN ({parametry});";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Tytul", SqlDbType.NVarChar, 255).Value = txt_tytul.Text.Trim();
                        for (int i = 0; i < autorzyIds.Count; i++)
                            cmd.Parameters.Add($"@A{i}", SqlDbType.Int).Value = autorzyIds[i];

                        object result = cmd.ExecuteScalar();
                        if (result == null)
                            return false;

                        IstniejacaKsiazkaId = Convert.ToInt32(result);
                        MessageBox.Show(
                            "Książka o podanym tytule i autorze już istnieje. Użyj opcji dopisania do stanu",
                            "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas sprawdzania duplikatu: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int PobierzLubDodajWydawnictwo(SqlConnection conn, SqlTransaction transaction, string nazwa)
        {
            const string selectSql = "SELECT ID FROM Wydawnictwa WHERE Nazwa = @Nazwa;";
            const string insertSql = "INSERT INTO Wydawnictwa (Nazwa) VALUES (@Nazwa); SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlCommand cmd = new SqlCommand(selectSql, conn, transaction))
            {
                cmd.Parameters.Add("@Nazwa", SqlDbType.NVarChar, 100).Value = nazwa;
                object id = cmd.ExecuteScalar();
                if (id != null) return Convert.ToInt32(id);
            }

            using (SqlCommand cmd = new SqlCommand(insertSql, conn, transaction))
            {
                cmd.Parameters.Add("@Nazwa", SqlDbType.NVarChar, 100).Value = nazwa;
                return (int)cmd.ExecuteScalar();
            }
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
                foreach (Control child in ctrl.Controls)
                    stack.Push(child);
            }
        }

        private void WyczyscFormularz()
        {
            IstniejacaKsiazkaId = null;
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

        private void UstawTrybFormularza(TrybFormularza tryb)
        {
            _tryb = tryb;
            bool czyEgzemplarze = tryb == TrybFormularza.DodajEgzemplarze;
            bool czyEdycja      = tryb == TrybFormularza.Edycja;

            switch (tryb)
            {
                case TrybFormularza.Dodawanie:
                    lbl_naglowek.Text = "REJESTRACJA KSIĄŻEK";
                    btn_zapisz.Text   = "Zapisz";
                    break;
                case TrybFormularza.DodajEgzemplarze:
                    lbl_naglowek.Text = "DODAWANIE EGZEMPLARZY";
                    btn_zapisz.Text   = "Zapisz";
                    break;
                case TrybFormularza.Edycja:
                    lbl_naglowek.Text = "EDYCJA KSIĄŻKI";
                    btn_zapisz.Text   = "Zapisz";
                    break;
            }

            UstawPoleTylkoDoOdczytu(txt_tytul, czyEgzemplarze);

            chlb_autorzy.Enabled = !czyEgzemplarze;
            chlb_gatunki.Enabled = !czyEgzemplarze;

            txt_autor_imie.Visible      = !czyEgzemplarze;
            txt_autor_nazwisko.Visible  = !czyEgzemplarze;
            btn_search.Visible          = !czyEgzemplarze;
            btn_add_author.Visible      = !czyEgzemplarze;
            btn_delete_autor.Visible    = !czyEgzemplarze;
            btn_search_gatunek.Visible  = !czyEgzemplarze;
            btn_add_gatunek.Visible     = !czyEgzemplarze;
            btn_delete_gatunek.Visible  = !czyEgzemplarze;
            txt_gatunek.Visible         = !czyEgzemplarze;

            lbl_liczba_sztuk.Visible = !czyEdycja;
            txt_liczba_sztuk.Visible = !czyEdycja;

            ResetFieldColors();
        }

        private void UstawPoleTylkoDoOdczytu(TextBoxBase pole, bool tylkoDoOdczytu)
        {
            pole.ReadOnly = tylkoDoOdczytu;
            pole.BackColor = tylkoDoOdczytu ? SystemColors.Control : SystemColors.Window;
        }


        private void btn_search_Click(object sender, EventArgs e)
        {
            WczytajAutorowDoListy(txt_autor_imie.Text.Trim(), txt_autor_nazwisko.Text.Trim());
        }

        private void btn_add_author_Click(object sender, EventArgs e)
        {
            var imieAutora     = txt_autor_imie.Text.Trim();
            var nazwiskoAutora = txt_autor_nazwisko.Text.Trim();

            error_add_book_form.SetError(txt_autor_imie, "");
            error_add_book_form.SetError(txt_autor_nazwisko, "");
            txt_autor_imie.BackColor = SystemColors.Window;
            txt_autor_nazwisko.BackColor = SystemColors.Window;

            bool brakImienia = string.IsNullOrWhiteSpace(imieAutora);
            bool brakNazwiska = string.IsNullOrWhiteSpace(nazwiskoAutora);

            if (brakImienia || brakNazwiska)
            {
                if (brakImienia)
                    OznaczBlad(txt_autor_imie, "Imię autora jest wymagane");

                if (brakNazwiska)
                    OznaczBlad(txt_autor_nazwisko, "Nazwisko autora jest wymagane");

                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                        const string insertSql = @"IF NOT EXISTS (SELECT 1 FROM Autorzy WHERE Imie = @Imie AND Nazwisko = @Nazwisko)
                                INSERT INTO Autorzy (Imie, Nazwisko) VALUES (@Imie, @Nazwisko);";

                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.Add("@Imie", imieAutora);
                        cmd.Parameters.Add("@Nazwisko", nazwiskoAutora);
                        cmd.ExecuteNonQuery();
                    }
                }

                txt_autor_imie.Clear();
                txt_autor_nazwisko.Clear();
                txt_autor_imie.Focus();

                WczytajAutorowDoListy();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania autora: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_autor_Click(object sender, EventArgs e)
        {
            if (chlb_autorzy.CheckedItems.Count == 0)
            {
                MessageBox.Show("Nie zaznaczono żadnego autora do usunięcia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczonych autorów? Ta operacja jest nieodwracalna.", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    foreach (Autor autor in chlb_autorzy.CheckedItems)
                    {
                        const string sprawdzSql = "SELECT COUNT(*) FROM KsiazkaKatalog_Autorzy WHERE AutorID = @ID";
                        using (SqlCommand cmd = new SqlCommand(sprawdzSql, conn))
                        {
                            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = autor.ID;
                            int liczbaPowiazanychKsiazek = (int)cmd.ExecuteScalar();

                            if (liczbaPowiazanychKsiazek > 0)
                            {
                                MessageBox.Show(
                                    $"Nie można usunąć autora \"{autor.Imie} {autor.Nazwisko}\" — jest przypisany do {liczbaPowiazanychKsiazek} książek.",
                                    "Operacja niemożliwa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }
                        }

                        const string deleteSql = "DELETE FROM Autorzy WHERE ID = @ID";
                        using (SqlCommand cmd = new SqlCommand(deleteSql, conn))
                        {
                            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = autor.ID;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                WczytajAutorowDoListy();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas usuwania autora: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_gatunek_Click(object sender, EventArgs e)
        {
            WczytajGatunkiDoListy(txt_gatunek.Text.Trim());
        }

        private void btn_add_gatunek_Click(object sender, EventArgs e)
        {
            var gatunek = txt_gatunek.Text.Trim();

            if (string.IsNullOrWhiteSpace(gatunek))
            {
                MessageBox.Show("Podaj gatunek", "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    const string insertSql = @"IF NOT EXISTS (SELECT 1 FROM Gatunki WHERE Nazwa = @Nazwa)
                                INSERT INTO Gatunki (Nazwa) VALUES (@Nazwa);";

                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.Add("@Nazwa", gatunek);
                        cmd.ExecuteNonQuery();
                    }
                }

                txt_gatunek.Clear();
                txt_gatunek.Focus();

                WczytajGatunkiDoListy();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania gatunku: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_gatunek_Click(object sender, EventArgs e)
        {
            if (chlb_gatunki.CheckedItems.Count == 0)
            {
                MessageBox.Show("Nie zaznaczono żadnego gatunku do usunięcia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone gatunki? Ta operacja jest nieodwracalna.", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    foreach (Gatunek gatunek in chlb_gatunki.CheckedItems)
                    {
                        const string sprawdzSql = "SELECT COUNT(*) FROM KatalogKsiazek WHERE GatunekID = @ID";
                        using (SqlCommand cmd = new SqlCommand(sprawdzSql, conn))
                        {
                            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = gatunek.ID;
                            int liczbaPowiazanychKsiazek = (int)cmd.ExecuteScalar();

                            if (liczbaPowiazanychKsiazek > 0)
                            {
                                MessageBox.Show(
                                    $"Nie można usunąć gatunku \"{gatunek.Nazwa}\" — jest przypisany do {liczbaPowiazanychKsiazek} książek.",
                                    "Operacja niemożliwa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }
                        }

                        const string deleteSql = "DELETE FROM Gatunki WHERE ID = @ID";
                        using (SqlCommand cmd = new SqlCommand(deleteSql, conn))
                        {
                            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = gatunek.ID;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                WczytajGatunkiDoListy();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas usuwania gatunku: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AktualizujKsiazkeDoBazy()
        {
            var gatunek    = (Gatunek)chlb_gatunki.CheckedItems[0];
            int liczbaStron = int.Parse(txt_liczba_stron.Text.Trim());
            int rokWydania  = int.Parse(txt_rok_wydania.Text.Trim());
            decimal cena    = decimal.Parse(txt_cena.Text.Trim());

            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    int wydawnictwoId = PobierzLubDodajWydawnictwo(conn, transaction, txt_wydawnictwo.Text.Trim());

                    const string sqlUpdate = @"
                        UPDATE KatalogKsiazek
                        SET Tytul=@Tytul, GatunekID=@GatunekID, WydawnictwoID=@WydawnictwoID,
                            LiczbaStron=@LiczbaStron, RokWydania=@RokWydania, Cena=@Cena, Opis=@Opis
                        WHERE ID=@ID;";

                    using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn, transaction))
                    {
                        cmd.Parameters.Add("@Tytul",         SqlDbType.NVarChar, 255).Value = txt_tytul.Text.Trim();
                        cmd.Parameters.Add("@GatunekID",     SqlDbType.Int).Value = gatunek.ID;
                        cmd.Parameters.Add("@WydawnictwoID", SqlDbType.Int).Value = wydawnictwoId;
                        cmd.Parameters.Add("@LiczbaStron",   SqlDbType.Int).Value = liczbaStron;
                        cmd.Parameters.Add("@RokWydania",    SqlDbType.Int).Value = rokWydania;
                        cmd.Parameters.Add("@Cena",          SqlDbType.Decimal).Value = cena;
                        cmd.Parameters.Add("@Opis",          SqlDbType.NVarChar, -1).Value = txt_opis.Text.Trim();
                        cmd.Parameters.Add("@ID",            SqlDbType.Int).Value = IstniejacaKsiazkaId.Value;
                        cmd.ExecuteNonQuery();
                    }

                    const string sqlDelAutorzy = "DELETE FROM KsiazkaKatalog_Autorzy WHERE KsiazkaID=@KsiazkaID;";
                    using (SqlCommand cmd = new SqlCommand(sqlDelAutorzy, conn, transaction))
                    {
                        cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = IstniejacaKsiazkaId.Value;
                        cmd.ExecuteNonQuery();
                    }

                    const string sqlAutor = "INSERT INTO KsiazkaKatalog_Autorzy (KsiazkaID, AutorID) VALUES (@KsiazkaID, @AutorID);";
                    foreach (Autor autor in chlb_autorzy.CheckedItems)
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlAutor, conn, transaction))
                        {
                            cmd.Parameters.Add("@KsiazkaID", SqlDbType.Int).Value = IstniejacaKsiazkaId.Value;
                            cmd.Parameters.Add("@AutorID",   SqlDbType.Int).Value = autor.ID;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }

                MessageBox.Show("Zmiany zostały zapisane", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (transaction?.Connection?.State == ConnectionState.Open)
                    try { transaction.Rollback(); } catch { }
                MessageBox.Show("Błąd podczas aktualizacji książki: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
