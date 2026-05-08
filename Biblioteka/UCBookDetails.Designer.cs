namespace Biblioteka
{
    partial class UCBookDetails
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
            this.btn_wroc = new System.Windows.Forms.Button();
            this.error_add_book_form = new System.Windows.Forms.ErrorProvider(this.components);
            this.txt_opis = new System.Windows.Forms.RichTextBox();
            this.lbl_opis = new System.Windows.Forms.Label();
            this.lbl_liczba_sztuk = new System.Windows.Forms.Label();
            this.lbl_cena = new System.Windows.Forms.Label();
            this.lbl_rok_wydania = new System.Windows.Forms.Label();
            this.lbl_liczba_stron = new System.Windows.Forms.Label();
            this.lbl_autorzy = new System.Windows.Forms.Label();
            this.lbl_wydawnictwo = new System.Windows.Forms.Label();
            this.lbl_gatunek = new System.Windows.Forms.Label();
            this.lbl_tytul = new System.Windows.Forms.Label();
            this.lbl_szczegoly_ksiazki = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_id_ksiazki = new System.Windows.Forms.Label();
            this.lbl_rok_wydania_ksiazki = new System.Windows.Forms.Label();
            this.lbl_liczba_stron_ksiazki = new System.Windows.Forms.Label();
            this.lbl_wydawnictwo_ksiazki = new System.Windows.Forms.Label();
            this.lbl_tytul_ksiazki = new System.Windows.Forms.Label();
            this.lbl_liczba_sztuk_ksiazki = new System.Windows.Forms.Label();
            this.lbl_cena_ksiazki = new System.Windows.Forms.Label();
            this.lbl_gatunek_ksiazki = new System.Windows.Forms.Label();
            this.dgv_autorzy = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.error_add_book_form)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_autorzy)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_wroc
            // 
            this.btn_wroc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_wroc.BackColor = System.Drawing.Color.LightBlue;
            this.btn_wroc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_wroc.Location = new System.Drawing.Point(30, 600);
            this.btn_wroc.Name = "btn_wroc";
            this.btn_wroc.Size = new System.Drawing.Size(160, 34);
            this.btn_wroc.TabIndex = 1;
            this.btn_wroc.Text = "← Wróć do listy";
            this.btn_wroc.UseVisualStyleBackColor = false;
            this.btn_wroc.Click += new System.EventHandler(this.btn_wroc_Click);
            // 
            // error_add_book_form
            // 
            this.error_add_book_form.ContainerControl = this;
            // 
            // txt_opis
            // 
            this.txt_opis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_opis.Location = new System.Drawing.Point(30, 270);
            this.txt_opis.Name = "txt_opis";
            this.txt_opis.Size = new System.Drawing.Size(521, 209);
            this.txt_opis.TabIndex = 52;
            this.txt_opis.Text = "";
            // 
            // lbl_opis
            // 
            this.lbl_opis.AutoSize = true;
            this.lbl_opis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_opis.Location = new System.Drawing.Point(25, 242);
            this.lbl_opis.Name = "lbl_opis";
            this.lbl_opis.Size = new System.Drawing.Size(59, 25);
            this.lbl_opis.TabIndex = 51;
            this.lbl_opis.Text = "Opis:";
            // 
            // lbl_liczba_sztuk
            // 
            this.lbl_liczba_sztuk.AutoSize = true;
            this.lbl_liczba_sztuk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_liczba_sztuk.Location = new System.Drawing.Point(589, 110);
            this.lbl_liczba_sztuk.Name = "lbl_liczba_sztuk";
            this.lbl_liczba_sztuk.Size = new System.Drawing.Size(126, 25);
            this.lbl_liczba_sztuk.TabIndex = 49;
            this.lbl_liczba_sztuk.Text = "Liczba sztuk:";
            // 
            // lbl_cena
            // 
            this.lbl_cena.AutoSize = true;
            this.lbl_cena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_cena.Location = new System.Drawing.Point(589, 71);
            this.lbl_cena.Name = "lbl_cena";
            this.lbl_cena.Size = new System.Drawing.Size(66, 25);
            this.lbl_cena.TabIndex = 47;
            this.lbl_cena.Text = "Cena:";
            // 
            // lbl_rok_wydania
            // 
            this.lbl_rok_wydania.AutoSize = true;
            this.lbl_rok_wydania.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_rok_wydania.Location = new System.Drawing.Point(22, 197);
            this.lbl_rok_wydania.Name = "lbl_rok_wydania";
            this.lbl_rok_wydania.Size = new System.Drawing.Size(129, 25);
            this.lbl_rok_wydania.TabIndex = 45;
            this.lbl_rok_wydania.Text = "Rok wydania:";
            // 
            // lbl_liczba_stron
            // 
            this.lbl_liczba_stron.AutoSize = true;
            this.lbl_liczba_stron.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_liczba_stron.Location = new System.Drawing.Point(22, 156);
            this.lbl_liczba_stron.Name = "lbl_liczba_stron";
            this.lbl_liczba_stron.Size = new System.Drawing.Size(123, 25);
            this.lbl_liczba_stron.TabIndex = 43;
            this.lbl_liczba_stron.Text = "Liczba stron:";
            // 
            // lbl_autorzy
            // 
            this.lbl_autorzy.AutoSize = true;
            this.lbl_autorzy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_autorzy.Location = new System.Drawing.Point(589, 242);
            this.lbl_autorzy.Name = "lbl_autorzy";
            this.lbl_autorzy.Size = new System.Drawing.Size(79, 25);
            this.lbl_autorzy.TabIndex = 39;
            this.lbl_autorzy.Text = "Autorzy";
            // 
            // lbl_wydawnictwo
            // 
            this.lbl_wydawnictwo.AutoSize = true;
            this.lbl_wydawnictwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_wydawnictwo.Location = new System.Drawing.Point(22, 113);
            this.lbl_wydawnictwo.Name = "lbl_wydawnictwo";
            this.lbl_wydawnictwo.Size = new System.Drawing.Size(139, 25);
            this.lbl_wydawnictwo.TabIndex = 37;
            this.lbl_wydawnictwo.Text = "Wydawnictwo:";
            // 
            // lbl_gatunek
            // 
            this.lbl_gatunek.AutoSize = true;
            this.lbl_gatunek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_gatunek.Location = new System.Drawing.Point(589, 153);
            this.lbl_gatunek.Name = "lbl_gatunek";
            this.lbl_gatunek.Size = new System.Drawing.Size(92, 25);
            this.lbl_gatunek.TabIndex = 35;
            this.lbl_gatunek.Text = "Gatunek:";
            // 
            // lbl_tytul
            // 
            this.lbl_tytul.AutoSize = true;
            this.lbl_tytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_tytul.Location = new System.Drawing.Point(22, 71);
            this.lbl_tytul.Name = "lbl_tytul";
            this.lbl_tytul.Size = new System.Drawing.Size(61, 25);
            this.lbl_tytul.TabIndex = 33;
            this.lbl_tytul.Text = "Tytuł:";
            // 
            // lbl_szczegoly_ksiazki
            // 
            this.lbl_szczegoly_ksiazki.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_szczegoly_ksiazki.Location = new System.Drawing.Point(3, 9);
            this.lbl_szczegoly_ksiazki.Name = "lbl_szczegoly_ksiazki";
            this.lbl_szczegoly_ksiazki.Size = new System.Drawing.Size(1178, 34);
            this.lbl_szczegoly_ksiazki.TabIndex = 0;
            this.lbl_szczegoly_ksiazki.Text = "SZCZEGÓŁY KSIĄŻKI: ";
            this.lbl_szczegoly_ksiazki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_szczegoly_ksiazki);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1287, 58);
            this.panel1.TabIndex = 32;
            // 
            // lbl_rok_wydania_ksiazki
            // 
            this.lbl_rok_wydania_ksiazki.AutoSize = true;
            this.lbl_rok_wydania_ksiazki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_rok_wydania_ksiazki.Location = new System.Drawing.Point(167, 197);
            this.lbl_rok_wydania_ksiazki.Name = "lbl_rok_wydania_ksiazki";
            this.lbl_rok_wydania_ksiazki.Size = new System.Drawing.Size(56, 25);
            this.lbl_rok_wydania_ksiazki.TabIndex = 66;
            this.lbl_rok_wydania_ksiazki.Text = "2004";
            // 
            // lbl_liczba_stron_ksiazki
            // 
            this.lbl_liczba_stron_ksiazki.AutoSize = true;
            this.lbl_liczba_stron_ksiazki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_liczba_stron_ksiazki.Location = new System.Drawing.Point(167, 156);
            this.lbl_liczba_stron_ksiazki.Name = "lbl_liczba_stron_ksiazki";
            this.lbl_liczba_stron_ksiazki.Size = new System.Drawing.Size(45, 25);
            this.lbl_liczba_stron_ksiazki.TabIndex = 65;
            this.lbl_liczba_stron_ksiazki.Text = "234";
            // 
            // lbl_wydawnictwo_ksiazki
            // 
            this.lbl_wydawnictwo_ksiazki.AutoSize = true;
            this.lbl_wydawnictwo_ksiazki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_wydawnictwo_ksiazki.Location = new System.Drawing.Point(167, 113);
            this.lbl_wydawnictwo_ksiazki.Name = "lbl_wydawnictwo_ksiazki";
            this.lbl_wydawnictwo_ksiazki.Size = new System.Drawing.Size(133, 25);
            this.lbl_wydawnictwo_ksiazki.TabIndex = 64;
            this.lbl_wydawnictwo_ksiazki.Text = "Wydawnictwo";
            // 
            // lbl_tytul_ksiazki
            // 
            this.lbl_tytul_ksiazki.AutoSize = true;
            this.lbl_tytul_ksiazki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_tytul_ksiazki.Location = new System.Drawing.Point(167, 71);
            this.lbl_tytul_ksiazki.Name = "lbl_tytul_ksiazki";
            this.lbl_tytul_ksiazki.Size = new System.Drawing.Size(119, 25);
            this.lbl_tytul_ksiazki.TabIndex = 63;
            this.lbl_tytul_ksiazki.Text = "Tytuł książki";
            // 
            // lbl_liczba_sztuk_ksiazki
            // 
            this.lbl_liczba_sztuk_ksiazki.AutoSize = true;
            this.lbl_liczba_sztuk_ksiazki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_liczba_sztuk_ksiazki.Location = new System.Drawing.Point(718, 110);
            this.lbl_liczba_sztuk_ksiazki.Name = "lbl_liczba_sztuk_ksiazki";
            this.lbl_liczba_sztuk_ksiazki.Size = new System.Drawing.Size(69, 25);
            this.lbl_liczba_sztuk_ksiazki.TabIndex = 69;
            this.lbl_liczba_sztuk_ksiazki.Text = "99 szt.";
            // 
            // lbl_cena_ksiazki
            // 
            this.lbl_cena_ksiazki.AutoSize = true;
            this.lbl_cena_ksiazki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_cena_ksiazki.Location = new System.Drawing.Point(718, 71);
            this.lbl_cena_ksiazki.Name = "lbl_cena_ksiazki";
            this.lbl_cena_ksiazki.Size = new System.Drawing.Size(64, 25);
            this.lbl_cena_ksiazki.TabIndex = 68;
            this.lbl_cena_ksiazki.Text = "200 zł";
            // 
            // lbl_gatunek_ksiazki
            // 
            this.lbl_gatunek_ksiazki.AutoSize = true;
            this.lbl_gatunek_ksiazki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_gatunek_ksiazki.Location = new System.Drawing.Point(718, 153);
            this.lbl_gatunek_ksiazki.Name = "lbl_gatunek_ksiazki";
            this.lbl_gatunek_ksiazki.Size = new System.Drawing.Size(84, 25);
            this.lbl_gatunek_ksiazki.TabIndex = 67;
            this.lbl_gatunek_ksiazki.Text = "kryminał";
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_id.Location = new System.Drawing.Point(589, 197);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.TabIndex = 71;
            this.lbl_id.Text = "ID Systemowe:";
            // 
            // lbl_id_ksiazki
            // 
            this.lbl_id_ksiazki.AutoSize = true;
            this.lbl_id_ksiazki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_id_ksiazki.Location = new System.Drawing.Point(718, 197);
            this.lbl_id_ksiazki.Name = "lbl_id_ksiazki";
            this.lbl_id_ksiazki.TabIndex = 72;
            this.lbl_id_ksiazki.Text = "";
            // 
            // dgv_autorzy
            // 
            this.dgv_autorzy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_autorzy.Location = new System.Drawing.Point(594, 270);
            this.dgv_autorzy.Name = "dgv_autorzy";
            this.dgv_autorzy.RowHeadersWidth = 51;
            this.dgv_autorzy.RowTemplate.Height = 24;
            this.dgv_autorzy.Size = new System.Drawing.Size(518, 209);
            this.dgv_autorzy.TabIndex = 70;
            // 
            // UCBookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.dgv_autorzy);
            this.Controls.Add(this.lbl_id_ksiazki);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.lbl_liczba_sztuk_ksiazki);
            this.Controls.Add(this.lbl_cena_ksiazki);
            this.Controls.Add(this.lbl_gatunek_ksiazki);
            this.Controls.Add(this.lbl_rok_wydania_ksiazki);
            this.Controls.Add(this.lbl_liczba_stron_ksiazki);
            this.Controls.Add(this.lbl_wydawnictwo_ksiazki);
            this.Controls.Add(this.lbl_tytul_ksiazki);
            this.Controls.Add(this.txt_opis);
            this.Controls.Add(this.lbl_opis);
            this.Controls.Add(this.lbl_liczba_sztuk);
            this.Controls.Add(this.lbl_cena);
            this.Controls.Add(this.lbl_rok_wydania);
            this.Controls.Add(this.lbl_liczba_stron);
            this.Controls.Add(this.lbl_autorzy);
            this.Controls.Add(this.lbl_wydawnictwo);
            this.Controls.Add(this.lbl_gatunek);
            this.Controls.Add(this.lbl_tytul);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_wroc);
            this.Name = "UCBookDetails";
            this.Size = new System.Drawing.Size(1287, 656);
            ((System.ComponentModel.ISupportInitialize)(this.error_add_book_form)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_autorzy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_wroc;
        private System.Windows.Forms.ErrorProvider error_add_book_form;
        private System.Windows.Forms.RichTextBox txt_opis;
        private System.Windows.Forms.Label lbl_opis;
        private System.Windows.Forms.Label lbl_liczba_sztuk;
        private System.Windows.Forms.Label lbl_cena;
        private System.Windows.Forms.Label lbl_rok_wydania;
        private System.Windows.Forms.Label lbl_liczba_stron;
        private System.Windows.Forms.Label lbl_autorzy;
        private System.Windows.Forms.Label lbl_wydawnictwo;
        private System.Windows.Forms.Label lbl_gatunek;
        private System.Windows.Forms.Label lbl_tytul;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_szczegoly_ksiazki;
        private System.Windows.Forms.Label lbl_rok_wydania_ksiazki;
        private System.Windows.Forms.Label lbl_liczba_stron_ksiazki;
        private System.Windows.Forms.Label lbl_wydawnictwo_ksiazki;
        private System.Windows.Forms.Label lbl_tytul_ksiazki;
        private System.Windows.Forms.Label lbl_liczba_sztuk_ksiazki;
        private System.Windows.Forms.Label lbl_cena_ksiazki;
        private System.Windows.Forms.Label lbl_gatunek_ksiazki;
        private System.Windows.Forms.DataGridView dgv_autorzy;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label lbl_id_ksiazki;
    }
}
