namespace Biblioteka
{
    partial class UCAddBook
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_naglowek = new System.Windows.Forms.Label();
            this.lbl_tytul = new System.Windows.Forms.Label();
            this.txt_tytul = new System.Windows.Forms.TextBox();
            this.lbl_gatunek = new System.Windows.Forms.Label();
            this.txt_gatunek = new System.Windows.Forms.TextBox();
            this.lbl_wydawnictwo = new System.Windows.Forms.Label();
            this.txt_wydawnictwo = new System.Windows.Forms.TextBox();
            this.lbl_autor_imie = new System.Windows.Forms.Label();
            this.txt_autor_imie = new System.Windows.Forms.TextBox();
            this.lbl_autor_nazwisko = new System.Windows.Forms.Label();
            this.txt_autor_nazwisko = new System.Windows.Forms.TextBox();
            this.lbl_liczba_stron = new System.Windows.Forms.Label();
            this.txt_liczba_stron = new System.Windows.Forms.TextBox();
            this.lbl_rok_wydania = new System.Windows.Forms.Label();
            this.txt_rok_wydania = new System.Windows.Forms.TextBox();
            this.lbl_cena = new System.Windows.Forms.Label();
            this.txt_cena = new System.Windows.Forms.TextBox();
            this.lbl_liczba_sztuk = new System.Windows.Forms.Label();
            this.txt_liczba_sztuk = new System.Windows.Forms.TextBox();
            this.lbl_opis = new System.Windows.Forms.Label();
            this.txt_opis = new System.Windows.Forms.RichTextBox();
            this.btn_anuluj = new System.Windows.Forms.Button();
            this.btn_zapisz = new System.Windows.Forms.Button();
            this.error_add_book_form = new System.Windows.Forms.ErrorProvider(this.components);
            this.chlb_autorzy = new System.Windows.Forms.CheckedListBox();
            this.btn_add_author = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_search_gatunek = new System.Windows.Forms.Button();
            this.btn_add_gatunek = new System.Windows.Forms.Button();
            this.chlb_gatunki = new System.Windows.Forms.CheckedListBox();
            this.btn_delete_autor = new System.Windows.Forms.Button();
            this.btn_delete_gatunek = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error_add_book_form)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_naglowek);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 58);
            this.panel1.TabIndex = 0;
            // 
            // lbl_naglowek
            // 
            this.lbl_naglowek.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_naglowek.Location = new System.Drawing.Point(3, 9);
            this.lbl_naglowek.Name = "lbl_naglowek";
            this.lbl_naglowek.Size = new System.Drawing.Size(1178, 34);
            this.lbl_naglowek.TabIndex = 0;
            this.lbl_naglowek.Text = "REJESTRACJA KSIĄŻEK";
            this.lbl_naglowek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_tytul
            // 
            this.lbl_tytul.AutoSize = true;
            this.lbl_tytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_tytul.Location = new System.Drawing.Point(22, 83);
            this.lbl_tytul.Name = "lbl_tytul";
            this.lbl_tytul.Size = new System.Drawing.Size(61, 25);
            this.lbl_tytul.TabIndex = 1;
            this.lbl_tytul.Text = "Tytuł:";
            // 
            // txt_tytul
            // 
            this.txt_tytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_tytul.Location = new System.Drawing.Point(165, 80);
            this.txt_tytul.Name = "txt_tytul";
            this.txt_tytul.Size = new System.Drawing.Size(264, 30);
            this.txt_tytul.TabIndex = 2;
            // 
            // lbl_gatunek
            // 
            this.lbl_gatunek.AutoSize = true;
            this.lbl_gatunek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_gatunek.Location = new System.Drawing.Point(475, 384);
            this.lbl_gatunek.Name = "lbl_gatunek";
            this.lbl_gatunek.Size = new System.Drawing.Size(92, 25);
            this.lbl_gatunek.TabIndex = 3;
            this.lbl_gatunek.Text = "Gatunek:";
            // 
            // txt_gatunek
            // 
            this.txt_gatunek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_gatunek.Location = new System.Drawing.Point(618, 381);
            this.txt_gatunek.Name = "txt_gatunek";
            this.txt_gatunek.Size = new System.Drawing.Size(264, 30);
            this.txt_gatunek.TabIndex = 4;
            // 
            // lbl_wydawnictwo
            // 
            this.lbl_wydawnictwo.AutoSize = true;
            this.lbl_wydawnictwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_wydawnictwo.Location = new System.Drawing.Point(22, 125);
            this.lbl_wydawnictwo.Name = "lbl_wydawnictwo";
            this.lbl_wydawnictwo.Size = new System.Drawing.Size(139, 25);
            this.lbl_wydawnictwo.TabIndex = 5;
            this.lbl_wydawnictwo.Text = "Wydawnictwo:";
            // 
            // txt_wydawnictwo
            // 
            this.txt_wydawnictwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_wydawnictwo.Location = new System.Drawing.Point(165, 122);
            this.txt_wydawnictwo.Name = "txt_wydawnictwo";
            this.txt_wydawnictwo.Size = new System.Drawing.Size(264, 30);
            this.txt_wydawnictwo.TabIndex = 6;
            // 
            // lbl_autor_imie
            // 
            this.lbl_autor_imie.AutoSize = true;
            this.lbl_autor_imie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_autor_imie.Location = new System.Drawing.Point(463, 83);
            this.lbl_autor_imie.Name = "lbl_autor_imie";
            this.lbl_autor_imie.Size = new System.Drawing.Size(114, 25);
            this.lbl_autor_imie.TabIndex = 7;
            this.lbl_autor_imie.Text = "Imię autora:";
            // 
            // txt_autor_imie
            // 
            this.txt_autor_imie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_autor_imie.Location = new System.Drawing.Point(596, 80);
            this.txt_autor_imie.Name = "txt_autor_imie";
            this.txt_autor_imie.Size = new System.Drawing.Size(165, 30);
            this.txt_autor_imie.TabIndex = 8;
            // 
            // lbl_autor_nazwisko
            // 
            this.lbl_autor_nazwisko.AutoSize = true;
            this.lbl_autor_nazwisko.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_autor_nazwisko.Location = new System.Drawing.Point(781, 83);
            this.lbl_autor_nazwisko.Name = "lbl_autor_nazwisko";
            this.lbl_autor_nazwisko.Size = new System.Drawing.Size(162, 25);
            this.lbl_autor_nazwisko.TabIndex = 9;
            this.lbl_autor_nazwisko.Text = "Nazwisko autora:";
            // 
            // txt_autor_nazwisko
            // 
            this.txt_autor_nazwisko.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_autor_nazwisko.Location = new System.Drawing.Point(949, 83);
            this.txt_autor_nazwisko.Name = "txt_autor_nazwisko";
            this.txt_autor_nazwisko.Size = new System.Drawing.Size(194, 30);
            this.txt_autor_nazwisko.TabIndex = 10;
            // 
            // lbl_liczba_stron
            // 
            this.lbl_liczba_stron.AutoSize = true;
            this.lbl_liczba_stron.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_liczba_stron.Location = new System.Drawing.Point(22, 168);
            this.lbl_liczba_stron.Name = "lbl_liczba_stron";
            this.lbl_liczba_stron.Size = new System.Drawing.Size(123, 25);
            this.lbl_liczba_stron.TabIndex = 11;
            this.lbl_liczba_stron.Text = "Liczba stron:";
            // 
            // txt_liczba_stron
            // 
            this.txt_liczba_stron.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_liczba_stron.Location = new System.Drawing.Point(165, 165);
            this.txt_liczba_stron.Name = "txt_liczba_stron";
            this.txt_liczba_stron.Size = new System.Drawing.Size(264, 30);
            this.txt_liczba_stron.TabIndex = 12;
            // 
            // lbl_rok_wydania
            // 
            this.lbl_rok_wydania.AutoSize = true;
            this.lbl_rok_wydania.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_rok_wydania.Location = new System.Drawing.Point(22, 209);
            this.lbl_rok_wydania.Name = "lbl_rok_wydania";
            this.lbl_rok_wydania.Size = new System.Drawing.Size(129, 25);
            this.lbl_rok_wydania.TabIndex = 13;
            this.lbl_rok_wydania.Text = "Rok wydania:";
            // 
            // txt_rok_wydania
            // 
            this.txt_rok_wydania.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_rok_wydania.Location = new System.Drawing.Point(165, 206);
            this.txt_rok_wydania.Name = "txt_rok_wydania";
            this.txt_rok_wydania.Size = new System.Drawing.Size(264, 30);
            this.txt_rok_wydania.TabIndex = 14;
            // 
            // lbl_cena
            // 
            this.lbl_cena.AutoSize = true;
            this.lbl_cena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_cena.Location = new System.Drawing.Point(22, 255);
            this.lbl_cena.Name = "lbl_cena";
            this.lbl_cena.Size = new System.Drawing.Size(66, 25);
            this.lbl_cena.TabIndex = 15;
            this.lbl_cena.Text = "Cena:";
            // 
            // txt_cena
            // 
            this.txt_cena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_cena.Location = new System.Drawing.Point(165, 252);
            this.txt_cena.Name = "txt_cena";
            this.txt_cena.Size = new System.Drawing.Size(264, 30);
            this.txt_cena.TabIndex = 16;
            // 
            // lbl_liczba_sztuk
            // 
            this.lbl_liczba_sztuk.AutoSize = true;
            this.lbl_liczba_sztuk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_liczba_sztuk.Location = new System.Drawing.Point(22, 299);
            this.lbl_liczba_sztuk.Name = "lbl_liczba_sztuk";
            this.lbl_liczba_sztuk.Size = new System.Drawing.Size(126, 25);
            this.lbl_liczba_sztuk.TabIndex = 17;
            this.lbl_liczba_sztuk.Text = "Liczba sztuk:";
            // 
            // txt_liczba_sztuk
            // 
            this.txt_liczba_sztuk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_liczba_sztuk.Location = new System.Drawing.Point(165, 299);
            this.txt_liczba_sztuk.Name = "txt_liczba_sztuk";
            this.txt_liczba_sztuk.Size = new System.Drawing.Size(264, 30);
            this.txt_liczba_sztuk.TabIndex = 18;
            // 
            // lbl_opis
            // 
            this.lbl_opis.AutoSize = true;
            this.lbl_opis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_opis.Location = new System.Drawing.Point(22, 345);
            this.lbl_opis.Name = "lbl_opis";
            this.lbl_opis.Size = new System.Drawing.Size(59, 25);
            this.lbl_opis.TabIndex = 19;
            this.lbl_opis.Text = "Opis:";
            // 
            // txt_opis
            // 
            this.txt_opis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_opis.Location = new System.Drawing.Point(87, 345);
            this.txt_opis.Name = "txt_opis";
            this.txt_opis.Size = new System.Drawing.Size(365, 209);
            this.txt_opis.TabIndex = 20;
            this.txt_opis.Text = "";
            // 
            // btn_anuluj
            // 
            this.btn_anuluj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_anuluj.AutoSize = true;
            this.btn_anuluj.BackColor = System.Drawing.Color.LightCoral;
            this.btn_anuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_anuluj.Location = new System.Drawing.Point(8, 592);
            this.btn_anuluj.Name = "btn_anuluj";
            this.btn_anuluj.Size = new System.Drawing.Size(282, 89);
            this.btn_anuluj.TabIndex = 21;
            this.btn_anuluj.Text = "ANULUJ";
            this.btn_anuluj.UseVisualStyleBackColor = false;
            this.btn_anuluj.Click += new System.EventHandler(this.btn_anuluj_Click);
            // 
            // btn_zapisz
            // 
            this.btn_zapisz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_zapisz.AutoSize = true;
            this.btn_zapisz.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_zapisz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_zapisz.Location = new System.Drawing.Point(882, 592);
            this.btn_zapisz.Name = "btn_zapisz";
            this.btn_zapisz.Size = new System.Drawing.Size(282, 89);
            this.btn_zapisz.TabIndex = 22;
            this.btn_zapisz.Text = "ZAPISZ KSIĄŻKĘ";
            this.btn_zapisz.UseVisualStyleBackColor = false;
            this.btn_zapisz.Click += new System.EventHandler(this.btn_zapisz_Click);
            // 
            // error_add_book_form
            // 
            this.error_add_book_form.ContainerControl = this;
            // 
            // chlb_autorzy
            // 
            this.chlb_autorzy.FormattingEnabled = true;
            this.chlb_autorzy.Location = new System.Drawing.Point(468, 124);
            this.chlb_autorzy.Name = "chlb_autorzy";
            this.chlb_autorzy.Size = new System.Drawing.Size(675, 191);
            this.chlb_autorzy.TabIndex = 23;
            // 
            // btn_add_author
            // 
            this.btn_add_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_add_author.BackColor = System.Drawing.Color.LightBlue;
            this.btn_add_author.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_add_author.Location = new System.Drawing.Point(634, 336);
            this.btn_add_author.Name = "btn_add_author";
            this.btn_add_author.Size = new System.Drawing.Size(160, 34);
            this.btn_add_author.TabIndex = 24;
            this.btn_add_author.Text = "Dodaj";
            this.btn_add_author.UseVisualStyleBackColor = false;
            this.btn_add_author.Click += new System.EventHandler(this.btn_add_author_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_search.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_search.Location = new System.Drawing.Point(468, 336);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(160, 34);
            this.btn_search.TabIndex = 25;
            this.btn_search.Text = "Szukaj";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_search_gatunek
            // 
            this.btn_search_gatunek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_search_gatunek.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search_gatunek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_search_gatunek.Location = new System.Drawing.Point(480, 546);
            this.btn_search_gatunek.Name = "btn_search_gatunek";
            this.btn_search_gatunek.Size = new System.Drawing.Size(160, 34);
            this.btn_search_gatunek.TabIndex = 28;
            this.btn_search_gatunek.Text = "Szukaj";
            this.btn_search_gatunek.UseVisualStyleBackColor = false;
            this.btn_search_gatunek.Click += new System.EventHandler(this.btn_search_gatunek_Click);
            // 
            // btn_add_gatunek
            // 
            this.btn_add_gatunek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_add_gatunek.BackColor = System.Drawing.Color.LightBlue;
            this.btn_add_gatunek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_add_gatunek.Location = new System.Drawing.Point(646, 546);
            this.btn_add_gatunek.Name = "btn_add_gatunek";
            this.btn_add_gatunek.Size = new System.Drawing.Size(160, 34);
            this.btn_add_gatunek.TabIndex = 27;
            this.btn_add_gatunek.Text = "Dodaj";
            this.btn_add_gatunek.UseVisualStyleBackColor = false;
            this.btn_add_gatunek.Click += new System.EventHandler(this.btn_add_gatunek_Click);
            // 
            // chlb_gatunki
            // 
            this.chlb_gatunki.FormattingEnabled = true;
            this.chlb_gatunki.Location = new System.Drawing.Point(480, 417);
            this.chlb_gatunki.Name = "chlb_gatunki";
            this.chlb_gatunki.Size = new System.Drawing.Size(663, 123);
            this.chlb_gatunki.TabIndex = 26;
            // 
            // btn_delete_autor
            // 
            this.btn_delete_autor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_delete_autor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_delete_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_delete_autor.Location = new System.Drawing.Point(983, 336);
            this.btn_delete_autor.Name = "btn_delete_autor";
            this.btn_delete_autor.Size = new System.Drawing.Size(160, 34);
            this.btn_delete_autor.TabIndex = 30;
            this.btn_delete_autor.Text = "Usuń";
            this.btn_delete_autor.UseVisualStyleBackColor = false;
            this.btn_delete_autor.Click += new System.EventHandler(this.btn_delete_autor_Click);
            // 
            // btn_delete_gatunek
            // 
            this.btn_delete_gatunek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_delete_gatunek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_delete_gatunek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_delete_gatunek.Location = new System.Drawing.Point(983, 546);
            this.btn_delete_gatunek.Name = "btn_delete_gatunek";
            this.btn_delete_gatunek.Size = new System.Drawing.Size(160, 34);
            this.btn_delete_gatunek.TabIndex = 31;
            this.btn_delete_gatunek.Text = "Usuń";
            this.btn_delete_gatunek.UseVisualStyleBackColor = false;
            this.btn_delete_gatunek.Click += new System.EventHandler(this.btn_delete_gatunek_Click);
            // 
            // UCAddBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btn_delete_gatunek);
            this.Controls.Add(this.btn_delete_autor);
            this.Controls.Add(this.btn_search_gatunek);
            this.Controls.Add(this.btn_add_gatunek);
            this.Controls.Add(this.chlb_gatunki);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_add_author);
            this.Controls.Add(this.chlb_autorzy);
            this.Controls.Add(this.btn_zapisz);
            this.Controls.Add(this.btn_anuluj);
            this.Controls.Add(this.txt_opis);
            this.Controls.Add(this.lbl_opis);
            this.Controls.Add(this.txt_liczba_sztuk);
            this.Controls.Add(this.lbl_liczba_sztuk);
            this.Controls.Add(this.txt_cena);
            this.Controls.Add(this.lbl_cena);
            this.Controls.Add(this.txt_rok_wydania);
            this.Controls.Add(this.lbl_rok_wydania);
            this.Controls.Add(this.txt_liczba_stron);
            this.Controls.Add(this.lbl_liczba_stron);
            this.Controls.Add(this.txt_autor_nazwisko);
            this.Controls.Add(this.lbl_autor_nazwisko);
            this.Controls.Add(this.txt_autor_imie);
            this.Controls.Add(this.lbl_autor_imie);
            this.Controls.Add(this.txt_wydawnictwo);
            this.Controls.Add(this.lbl_wydawnictwo);
            this.Controls.Add(this.txt_gatunek);
            this.Controls.Add(this.lbl_gatunek);
            this.Controls.Add(this.txt_tytul);
            this.Controls.Add(this.lbl_tytul);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCAddBook";
            this.Size = new System.Drawing.Size(1184, 684);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.error_add_book_form)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_naglowek;
        private System.Windows.Forms.Label lbl_tytul;
        private System.Windows.Forms.TextBox txt_tytul;
        private System.Windows.Forms.Label lbl_gatunek;
        private System.Windows.Forms.TextBox txt_gatunek;
        private System.Windows.Forms.Label lbl_wydawnictwo;
        private System.Windows.Forms.TextBox txt_wydawnictwo;
        private System.Windows.Forms.Label lbl_autor_imie;
        private System.Windows.Forms.TextBox txt_autor_imie;
        private System.Windows.Forms.Label lbl_autor_nazwisko;
        private System.Windows.Forms.TextBox txt_autor_nazwisko;
        private System.Windows.Forms.Label lbl_liczba_stron;
        private System.Windows.Forms.TextBox txt_liczba_stron;
        private System.Windows.Forms.Label lbl_rok_wydania;
        private System.Windows.Forms.TextBox txt_rok_wydania;
        private System.Windows.Forms.Label lbl_cena;
        private System.Windows.Forms.TextBox txt_cena;
        private System.Windows.Forms.Label lbl_liczba_sztuk;
        private System.Windows.Forms.TextBox txt_liczba_sztuk;
        private System.Windows.Forms.Label lbl_opis;
        private System.Windows.Forms.RichTextBox txt_opis;
        private System.Windows.Forms.Button btn_anuluj;
        private System.Windows.Forms.Button btn_zapisz;
        private System.Windows.Forms.ErrorProvider error_add_book_form;
        private System.Windows.Forms.CheckedListBox chlb_autorzy;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_add_author;
        private System.Windows.Forms.Button btn_search_gatunek;
        private System.Windows.Forms.Button btn_add_gatunek;
        private System.Windows.Forms.CheckedListBox chlb_gatunki;
        private System.Windows.Forms.Button btn_delete_autor;
        private System.Windows.Forms.Button btn_delete_gatunek;
    }
}
