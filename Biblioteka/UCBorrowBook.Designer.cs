namespace Biblioteka
{
    partial class UCBorrowBook
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        private void InitializeComponent()
        {
            this.panel_naglowek = new System.Windows.Forms.Panel();
            this.lbl_tytul = new System.Windows.Forms.Label();
            this.panel_dol = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nup_borrow_period = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_return_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_borrow_date = new System.Windows.Forms.DateTimePicker();
            this.lbl_filter_autor = new System.Windows.Forms.Label();
            this.btn_anuluj = new System.Windows.Forms.Button();
            this.btnWypozycz = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelLewy = new System.Windows.Forms.Panel();
            this.dgvCzytelnicy = new System.Windows.Forms.DataGridView();
            this.panelSzukajCzytelnika = new System.Windows.Forms.Panel();
            this.txtSzukajCzytelnika = new System.Windows.Forms.TextBox();
            this.btnSzukajCzytelnika = new System.Windows.Forms.Button();
            this.lbl_czytelnicy = new System.Windows.Forms.Label();
            this.panelPrawy = new System.Windows.Forms.Panel();
            this.chlbEgzemplarze = new System.Windows.Forms.CheckedListBox();
            this.panelSzukajEgzemplarza = new System.Windows.Forms.Panel();
            this.txtSzukajEgzemplarza = new System.Windows.Forms.TextBox();
            this.btnSzukajEgzemplarza = new System.Windows.Forms.Button();
            this.lbl_egzemplarze = new System.Windows.Forms.Label();
            this.panel_naglowek.SuspendLayout();
            this.panel_dol.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_borrow_period)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelLewy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCzytelnicy)).BeginInit();
            this.panelSzukajCzytelnika.SuspendLayout();
            this.panelPrawy.SuspendLayout();
            this.panelSzukajEgzemplarza.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_naglowek
            // 
            this.panel_naglowek.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_naglowek.Controls.Add(this.lbl_tytul);
            this.panel_naglowek.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_naglowek.Location = new System.Drawing.Point(0, 0);
            this.panel_naglowek.Name = "panel_naglowek";
            this.panel_naglowek.Size = new System.Drawing.Size(1174, 63);
            this.panel_naglowek.TabIndex = 0;
            // 
            // lbl_tytul
            // 
            this.lbl_tytul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_tytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_tytul.Location = new System.Drawing.Point(0, 0);
            this.lbl_tytul.Name = "lbl_tytul";
            this.lbl_tytul.Size = new System.Drawing.Size(1174, 63);
            this.lbl_tytul.TabIndex = 0;
            this.lbl_tytul.Text = "WYPOŻYCZENIE KSIĄŻKI";
            this.lbl_tytul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_dol
            // 
            this.panel_dol.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_dol.Controls.Add(this.groupBox1);
            this.panel_dol.Controls.Add(this.btn_anuluj);
            this.panel_dol.Controls.Add(this.btnWypozycz);
            this.panel_dol.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_dol.Location = new System.Drawing.Point(0, 498);
            this.panel_dol.Name = "panel_dol";
            this.panel_dol.Padding = new System.Windows.Forms.Padding(10);
            this.panel_dol.Size = new System.Drawing.Size(1174, 176);
            this.panel_dol.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nup_borrow_period);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp_return_date);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_borrow_date);
            this.groupBox1.Controls.Add(this.lbl_filter_autor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1154, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Szczegóły wypożyczenia";
            // 
            // nup_borrow_period
            // 
            this.nup_borrow_period.Location = new System.Drawing.Point(627, 37);
            this.nup_borrow_period.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nup_borrow_period.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nup_borrow_period.Name = "nup_borrow_period";
            this.nup_borrow_period.Size = new System.Drawing.Size(71, 27);
            this.nup_borrow_period.TabIndex = 10;
            this.nup_borrow_period.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(424, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Okres wypożyczenia:";
            // 
            // dtp_return_date
            // 
            this.dtp_return_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_return_date.Location = new System.Drawing.Point(1019, 37);
            this.dtp_return_date.Name = "dtp_return_date";
            this.dtp_return_date.Size = new System.Drawing.Size(129, 27);
            this.dtp_return_date.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(760, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Oczekiwana data zwrotu:";
            // 
            // dtp_borrow_date
            // 
            this.dtp_borrow_date.Enabled = false;
            this.dtp_borrow_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_borrow_date.Location = new System.Drawing.Point(205, 39);
            this.dtp_borrow_date.Name = "dtp_borrow_date";
            this.dtp_borrow_date.Size = new System.Drawing.Size(129, 27);
            this.dtp_borrow_date.TabIndex = 6;
            // 
            // lbl_filter_autor
            // 
            this.lbl_filter_autor.AutoSize = true;
            this.lbl_filter_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_filter_autor.Location = new System.Drawing.Point(6, 39);
            this.lbl_filter_autor.Name = "lbl_filter_autor";
            this.lbl_filter_autor.Size = new System.Drawing.Size(177, 20);
            this.lbl_filter_autor.TabIndex = 5;
            this.lbl_filter_autor.Text = "Data wypożyczenia:";
            // 
            // btn_anuluj
            // 
            this.btn_anuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_anuluj.Location = new System.Drawing.Point(1001, 116);
            this.btn_anuluj.Name = "btn_anuluj";
            this.btn_anuluj.Size = new System.Drawing.Size(150, 45);
            this.btn_anuluj.TabIndex = 1;
            this.btn_anuluj.Text = "Anuluj i wróć";
            this.btn_anuluj.UseVisualStyleBackColor = true;
            this.btn_anuluj.Click += new System.EventHandler(this.btn_anuluj_Click);
            // 
            // btnWypozycz
            // 
            this.btnWypozycz.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnWypozycz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnWypozycz.ForeColor = System.Drawing.Color.White;
            this.btnWypozycz.Location = new System.Drawing.Point(13, 116);
            this.btnWypozycz.Name = "btnWypozycz";
            this.btnWypozycz.Size = new System.Drawing.Size(277, 45);
            this.btnWypozycz.TabIndex = 0;
            this.btnWypozycz.Text = "Zapisz wypożyczenie";
            this.btnWypozycz.UseVisualStyleBackColor = false;
            this.btnWypozycz.Click += new System.EventHandler(this.btnWypozycz_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelLewy, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelPrawy, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1174, 435);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelLewy
            // 
            this.panelLewy.Controls.Add(this.dgvCzytelnicy);
            this.panelLewy.Controls.Add(this.panelSzukajCzytelnika);
            this.panelLewy.Controls.Add(this.lbl_czytelnicy);
            this.panelLewy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLewy.Location = new System.Drawing.Point(3, 3);
            this.panelLewy.Name = "panelLewy";
            this.panelLewy.Padding = new System.Windows.Forms.Padding(8, 8, 4, 8);
            this.panelLewy.Size = new System.Drawing.Size(581, 429);
            this.panelLewy.TabIndex = 0;
            // 
            // dgvCzytelnicy
            // 
            this.dgvCzytelnicy.ColumnHeadersHeight = 29;
            this.dgvCzytelnicy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCzytelnicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dgvCzytelnicy.Location = new System.Drawing.Point(8, 80);
            this.dgvCzytelnicy.Name = "dgvCzytelnicy";
            this.dgvCzytelnicy.RowHeadersWidth = 51;
            this.dgvCzytelnicy.Size = new System.Drawing.Size(569, 341);
            this.dgvCzytelnicy.TabIndex = 2;
            // 
            // panelSzukajCzytelnika
            // 
            this.panelSzukajCzytelnika.Controls.Add(this.txtSzukajCzytelnika);
            this.panelSzukajCzytelnika.Controls.Add(this.btnSzukajCzytelnika);
            this.panelSzukajCzytelnika.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSzukajCzytelnika.Location = new System.Drawing.Point(8, 44);
            this.panelSzukajCzytelnika.Name = "panelSzukajCzytelnika";
            this.panelSzukajCzytelnika.Size = new System.Drawing.Size(569, 36);
            this.panelSzukajCzytelnika.TabIndex = 1;
            // 
            // txtSzukajCzytelnika
            // 
            this.txtSzukajCzytelnika.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSzukajCzytelnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtSzukajCzytelnika.Location = new System.Drawing.Point(0, 0);
            this.txtSzukajCzytelnika.Name = "txtSzukajCzytelnika";
            this.txtSzukajCzytelnika.Size = new System.Drawing.Size(479, 27);
            this.txtSzukajCzytelnika.TabIndex = 0;
            this.txtSzukajCzytelnika.TextChanged += new System.EventHandler(this.txtSzukajCzytelnika_TextChanged);
            // 
            // btnSzukajCzytelnika
            // 
            this.btnSzukajCzytelnika.BackColor = System.Drawing.Color.LightBlue;
            this.btnSzukajCzytelnika.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSzukajCzytelnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSzukajCzytelnika.Location = new System.Drawing.Point(479, 0);
            this.btnSzukajCzytelnika.Name = "btnSzukajCzytelnika";
            this.btnSzukajCzytelnika.Size = new System.Drawing.Size(90, 36);
            this.btnSzukajCzytelnika.TabIndex = 1;
            this.btnSzukajCzytelnika.Text = "Szukaj";
            this.btnSzukajCzytelnika.UseVisualStyleBackColor = false;
            this.btnSzukajCzytelnika.Click += new System.EventHandler(this.btnSzukajCzytelnika_Click);
            // 
            // lbl_czytelnicy
            // 
            this.lbl_czytelnicy.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_czytelnicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_czytelnicy.Location = new System.Drawing.Point(8, 8);
            this.lbl_czytelnicy.Name = "lbl_czytelnicy";
            this.lbl_czytelnicy.Size = new System.Drawing.Size(569, 36);
            this.lbl_czytelnicy.TabIndex = 0;
            this.lbl_czytelnicy.Text = "Wyszukaj czytelnika:";
            this.lbl_czytelnicy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelPrawy
            // 
            this.panelPrawy.Controls.Add(this.chlbEgzemplarze);
            this.panelPrawy.Controls.Add(this.panelSzukajEgzemplarza);
            this.panelPrawy.Controls.Add(this.lbl_egzemplarze);
            this.panelPrawy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrawy.Location = new System.Drawing.Point(590, 3);
            this.panelPrawy.Name = "panelPrawy";
            this.panelPrawy.Padding = new System.Windows.Forms.Padding(4, 8, 8, 8);
            this.panelPrawy.Size = new System.Drawing.Size(581, 429);
            this.panelPrawy.TabIndex = 1;
            // 
            // chlbEgzemplarze
            // 
            this.chlbEgzemplarze.CheckOnClick = true;
            this.chlbEgzemplarze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chlbEgzemplarze.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.chlbEgzemplarze.FormattingEnabled = true;
            this.chlbEgzemplarze.Location = new System.Drawing.Point(4, 72);
            this.chlbEgzemplarze.Name = "chlbEgzemplarze";
            this.chlbEgzemplarze.Size = new System.Drawing.Size(569, 349);
            this.chlbEgzemplarze.TabIndex = 2;
            // 
            // panelSzukajEgzemplarza
            // 
            this.panelSzukajEgzemplarza.Controls.Add(this.txtSzukajEgzemplarza);
            this.panelSzukajEgzemplarza.Controls.Add(this.btnSzukajEgzemplarza);
            this.panelSzukajEgzemplarza.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSzukajEgzemplarza.Location = new System.Drawing.Point(4, 36);
            this.panelSzukajEgzemplarza.Name = "panelSzukajEgzemplarza";
            this.panelSzukajEgzemplarza.Size = new System.Drawing.Size(569, 36);
            this.panelSzukajEgzemplarza.TabIndex = 1;
            // 
            // txtSzukajEgzemplarza
            // 
            this.txtSzukajEgzemplarza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSzukajEgzemplarza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtSzukajEgzemplarza.Location = new System.Drawing.Point(0, 0);
            this.txtSzukajEgzemplarza.Name = "txtSzukajEgzemplarza";
            this.txtSzukajEgzemplarza.Size = new System.Drawing.Size(479, 27);
            this.txtSzukajEgzemplarza.TabIndex = 0;
            this.txtSzukajEgzemplarza.TextChanged += new System.EventHandler(this.txtSzukajEgzemplarza_TextChanged);
            // 
            // btnSzukajEgzemplarza
            // 
            this.btnSzukajEgzemplarza.BackColor = System.Drawing.Color.LightBlue;
            this.btnSzukajEgzemplarza.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSzukajEgzemplarza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSzukajEgzemplarza.Location = new System.Drawing.Point(479, 0);
            this.btnSzukajEgzemplarza.Name = "btnSzukajEgzemplarza";
            this.btnSzukajEgzemplarza.Size = new System.Drawing.Size(90, 36);
            this.btnSzukajEgzemplarza.TabIndex = 1;
            this.btnSzukajEgzemplarza.Text = "Szukaj";
            this.btnSzukajEgzemplarza.UseVisualStyleBackColor = false;
            this.btnSzukajEgzemplarza.Click += new System.EventHandler(this.btnSzukajEgzemplarza_Click);
            // 
            // lbl_egzemplarze
            // 
            this.lbl_egzemplarze.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_egzemplarze.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_egzemplarze.Location = new System.Drawing.Point(4, 8);
            this.lbl_egzemplarze.Name = "lbl_egzemplarze";
            this.lbl_egzemplarze.Size = new System.Drawing.Size(569, 28);
            this.lbl_egzemplarze.TabIndex = 0;
            this.lbl_egzemplarze.Text = "Wyszukaj książkę (zaznacz do wypożyczenia):";
            this.lbl_egzemplarze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCBorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel_dol);
            this.Controls.Add(this.panel_naglowek);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCBorrowBook";
            this.Size = new System.Drawing.Size(1174, 674);
            this.panel_naglowek.ResumeLayout(false);
            this.panel_dol.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_borrow_period)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelLewy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCzytelnicy)).EndInit();
            this.panelSzukajCzytelnika.ResumeLayout(false);
            this.panelSzukajCzytelnika.PerformLayout();
            this.panelPrawy.ResumeLayout(false);
            this.panelSzukajEgzemplarza.ResumeLayout(false);
            this.panelSzukajEgzemplarza.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel              panel_naglowek;
        private System.Windows.Forms.Label              lbl_tytul;
        private System.Windows.Forms.Panel              panel_dol;
        private System.Windows.Forms.Button             btnWypozycz;
        private System.Windows.Forms.Button             btn_anuluj;
        private System.Windows.Forms.TableLayoutPanel   tableLayoutPanel1;
        private System.Windows.Forms.Panel              panelLewy;
        private System.Windows.Forms.Label              lbl_czytelnicy;
        private System.Windows.Forms.Panel              panelSzukajCzytelnika;
        private System.Windows.Forms.TextBox            txtSzukajCzytelnika;
        private System.Windows.Forms.Button             btnSzukajCzytelnika;
        private System.Windows.Forms.DataGridView       dgvCzytelnicy;
        private System.Windows.Forms.Panel              panelPrawy;
        private System.Windows.Forms.Label              lbl_egzemplarze;
        private System.Windows.Forms.Panel              panelSzukajEgzemplarza;
        private System.Windows.Forms.TextBox            txtSzukajEgzemplarza;
        private System.Windows.Forms.Button             btnSzukajEgzemplarza;
        private System.Windows.Forms.CheckedListBox     chlbEgzemplarze;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_filter_autor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_return_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_borrow_date;
        private System.Windows.Forms.NumericUpDown nup_borrow_period;
    }
}
