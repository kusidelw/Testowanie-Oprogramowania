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
            this.panel_naglowek          = new System.Windows.Forms.Panel();
            this.lbl_tytul               = new System.Windows.Forms.Label();
            this.panel_dol               = new System.Windows.Forms.Panel();
            this.btnWypozycz             = new System.Windows.Forms.Button();
            this.btn_anuluj              = new System.Windows.Forms.Button();
            this.tableLayoutPanel1       = new System.Windows.Forms.TableLayoutPanel();
            this.panelLewy               = new System.Windows.Forms.Panel();
            this.lbl_czytelnicy          = new System.Windows.Forms.Label();
            this.panelSzukajCzytelnika   = new System.Windows.Forms.Panel();
            this.txtSzukajCzytelnika     = new System.Windows.Forms.TextBox();
            this.btnSzukajCzytelnika     = new System.Windows.Forms.Button();
            this.dgvCzytelnicy           = new System.Windows.Forms.DataGridView();
            this.panelPrawy              = new System.Windows.Forms.Panel();
            this.lbl_egzemplarze         = new System.Windows.Forms.Label();
            this.panelSzukajEgzemplarza  = new System.Windows.Forms.Panel();
            this.txtSzukajEgzemplarza    = new System.Windows.Forms.TextBox();
            this.btnSzukajEgzemplarza    = new System.Windows.Forms.Button();
            this.chlbEgzemplarze         = new System.Windows.Forms.CheckedListBox();
            this.panel_naglowek.SuspendLayout();
            this.panel_dol.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelLewy.SuspendLayout();
            this.panelSzukajCzytelnika.SuspendLayout();
            this.panelPrawy.SuspendLayout();
            this.panelSzukajEgzemplarza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCzytelnicy)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_naglowek
            // 
            this.panel_naglowek.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_naglowek.Controls.Add(this.lbl_tytul);
            this.panel_naglowek.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_naglowek.Location = new System.Drawing.Point(0, 0);
            this.panel_naglowek.Name = "panel_naglowek";
            this.panel_naglowek.Size = new System.Drawing.Size(1133, 63);
            this.panel_naglowek.TabIndex = 0;
            // 
            // lbl_tytul
            // 
            this.lbl_tytul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_tytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_tytul.Location = new System.Drawing.Point(0, 0);
            this.lbl_tytul.Name = "lbl_tytul";
            this.lbl_tytul.Size = new System.Drawing.Size(1133, 63);
            this.lbl_tytul.TabIndex = 0;
            this.lbl_tytul.Text = "WYPOŻYCZENIE KSIĄŻKI";
            this.lbl_tytul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_dol
            // 
            this.panel_dol.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_dol.Controls.Add(this.btn_anuluj);
            this.panel_dol.Controls.Add(this.btnWypozycz);
            this.panel_dol.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_dol.Name = "panel_dol";
            this.panel_dol.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.panel_dol.Size = new System.Drawing.Size(1133, 65);
            this.panel_dol.TabIndex = 2;
            // 
            // btnWypozycz
            // 
            this.btnWypozycz.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnWypozycz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnWypozycz.ForeColor = System.Drawing.Color.White;
            this.btnWypozycz.Location = new System.Drawing.Point(10, 10);
            this.btnWypozycz.Name = "btnWypozycz";
            this.btnWypozycz.Size = new System.Drawing.Size(220, 45);
            this.btnWypozycz.TabIndex = 0;
            this.btnWypozycz.Text = "✔ Wypożycz";
            this.btnWypozycz.UseVisualStyleBackColor = false;
            this.btnWypozycz.Click += new System.EventHandler(this.btnWypozycz_Click);
            // 
            // btn_anuluj
            // 
            this.btn_anuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_anuluj.Location = new System.Drawing.Point(240, 10);
            this.btn_anuluj.Name = "btn_anuluj";
            this.btn_anuluj.Size = new System.Drawing.Size(150, 45);
            this.btn_anuluj.TabIndex = 1;
            this.btn_anuluj.Text = "Anuluj";
            this.btn_anuluj.UseVisualStyleBackColor = true;
            this.btn_anuluj.Click += new System.EventHandler(this.btn_anuluj_Click);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1133, 498);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelLewy
            // 
            this.panelLewy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLewy.Padding = new System.Windows.Forms.Padding(8, 8, 4, 8);
            this.panelLewy.Name = "panelLewy";
            this.panelLewy.TabIndex = 0;
            // Kolejność Add: Fill (dgvCzytelnicy) pierwszy → przetwarzany ostatni przez docking engine
            this.panelLewy.Controls.Add(this.dgvCzytelnicy);
            this.panelLewy.Controls.Add(this.panelSzukajCzytelnika);
            this.panelLewy.Controls.Add(this.lbl_czytelnicy);
            // 
            // lbl_czytelnicy
            // 
            this.lbl_czytelnicy.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_czytelnicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_czytelnicy.Height = 28;
            this.lbl_czytelnicy.Name = "lbl_czytelnicy";
            this.lbl_czytelnicy.TabIndex = 0;
            this.lbl_czytelnicy.Text = "Wyszukaj czytelnika:";
            this.lbl_czytelnicy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSzukajCzytelnika
            // 
            this.panelSzukajCzytelnika.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSzukajCzytelnika.Height = 36;
            this.panelSzukajCzytelnika.Name = "panelSzukajCzytelnika";
            this.panelSzukajCzytelnika.TabIndex = 1;
            // Kolejność Add: TextBox (Fill) pierwszy, Button (Right) drugi → docking: Button najpierw, TextBox reszta
            this.panelSzukajCzytelnika.Controls.Add(this.txtSzukajCzytelnika);
            this.panelSzukajCzytelnika.Controls.Add(this.btnSzukajCzytelnika);
            // 
            // txtSzukajCzytelnika
            // 
            this.txtSzukajCzytelnika.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSzukajCzytelnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtSzukajCzytelnika.Name = "txtSzukajCzytelnika";
            this.txtSzukajCzytelnika.TabIndex = 0;
            this.txtSzukajCzytelnika.TextChanged += new System.EventHandler(this.txtSzukajCzytelnika_TextChanged);
            // 
            // btnSzukajCzytelnika
            // 
            this.btnSzukajCzytelnika.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSzukajCzytelnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSzukajCzytelnika.Name = "btnSzukajCzytelnika";
            this.btnSzukajCzytelnika.Size = new System.Drawing.Size(90, 36);
            this.btnSzukajCzytelnika.TabIndex = 1;
            this.btnSzukajCzytelnika.Text = "Szukaj";
            this.btnSzukajCzytelnika.Click += new System.EventHandler(this.btnSzukajCzytelnika_Click);
            // 
            // dgvCzytelnicy
            // 
            this.dgvCzytelnicy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCzytelnicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dgvCzytelnicy.Name = "dgvCzytelnicy";
            this.dgvCzytelnicy.TabIndex = 2;
            // 
            // panelPrawy
            // 
            this.panelPrawy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrawy.Padding = new System.Windows.Forms.Padding(4, 8, 8, 8);
            this.panelPrawy.Name = "panelPrawy";
            this.panelPrawy.TabIndex = 1;
            // Kolejność Add: Fill (chlbEgzemplarze) pierwszy → przetwarzany ostatni
            this.panelPrawy.Controls.Add(this.chlbEgzemplarze);
            this.panelPrawy.Controls.Add(this.panelSzukajEgzemplarza);
            this.panelPrawy.Controls.Add(this.lbl_egzemplarze);
            // 
            // lbl_egzemplarze
            // 
            this.lbl_egzemplarze.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_egzemplarze.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_egzemplarze.Height = 28;
            this.lbl_egzemplarze.Name = "lbl_egzemplarze";
            this.lbl_egzemplarze.TabIndex = 0;
            this.lbl_egzemplarze.Text = "Wyszukaj egzemplarz (zaznacz do wypożyczenia):";
            this.lbl_egzemplarze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSzukajEgzemplarza
            // 
            this.panelSzukajEgzemplarza.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSzukajEgzemplarza.Height = 36;
            this.panelSzukajEgzemplarza.Name = "panelSzukajEgzemplarza";
            this.panelSzukajEgzemplarza.TabIndex = 1;
            this.panelSzukajEgzemplarza.Controls.Add(this.txtSzukajEgzemplarza);
            this.panelSzukajEgzemplarza.Controls.Add(this.btnSzukajEgzemplarza);
            // 
            // txtSzukajEgzemplarza
            // 
            this.txtSzukajEgzemplarza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSzukajEgzemplarza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtSzukajEgzemplarza.Name = "txtSzukajEgzemplarza";
            this.txtSzukajEgzemplarza.TabIndex = 0;
            this.txtSzukajEgzemplarza.TextChanged += new System.EventHandler(this.txtSzukajEgzemplarza_TextChanged);
            // 
            // btnSzukajEgzemplarza
            // 
            this.btnSzukajEgzemplarza.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSzukajEgzemplarza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSzukajEgzemplarza.Name = "btnSzukajEgzemplarza";
            this.btnSzukajEgzemplarza.Size = new System.Drawing.Size(90, 36);
            this.btnSzukajEgzemplarza.TabIndex = 1;
            this.btnSzukajEgzemplarza.Text = "Szukaj";
            this.btnSzukajEgzemplarza.Click += new System.EventHandler(this.btnSzukajEgzemplarza_Click);
            // 
            // chlbEgzemplarze
            // 
            this.chlbEgzemplarze.CheckOnClick = true;
            this.chlbEgzemplarze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chlbEgzemplarze.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.chlbEgzemplarze.FormattingEnabled = true;
            this.chlbEgzemplarze.Name = "chlbEgzemplarze";
            this.chlbEgzemplarze.TabIndex = 2;
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
            this.Size = new System.Drawing.Size(1133, 626);
            this.panel_naglowek.ResumeLayout(false);
            this.panel_dol.ResumeLayout(false);
            this.panelSzukajCzytelnika.ResumeLayout(false);
            this.panelSzukajCzytelnika.PerformLayout();
            this.panelLewy.ResumeLayout(false);
            this.panelSzukajEgzemplarza.ResumeLayout(false);
            this.panelSzukajEgzemplarza.PerformLayout();
            this.panelPrawy.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCzytelnicy)).EndInit();
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
    }
}
