namespace Biblioteka
{
    partial class UCManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel_header = new System.Windows.Forms.Panel();
            this.lbl_naglowek = new System.Windows.Forms.Label();
            this.lbl_filter_tytul = new System.Windows.Forms.Label();
            this.txt_filter_tytul = new System.Windows.Forms.TextBox();
            this.lbl_filter_autor = new System.Windows.Forms.Label();
            this.txt_filter_autor = new System.Windows.Forms.TextBox();
            this.lbl_filter_gatunek = new System.Windows.Forms.Label();
            this.txt_filter_gatunek = new System.Windows.Forms.TextBox();
            this.lbl_filter_wyd = new System.Windows.Forms.Label();
            this.txt_filter_wyd = new System.Windows.Forms.TextBox();
            this.lbl_filter_osoba = new System.Windows.Forms.Label();
            this.txt_filter_osoba = new System.Windows.Forms.TextBox();
            this.dtp_data_od = new System.Windows.Forms.DateTimePicker();
            this.dtp_data_do = new System.Windows.Forms.DateTimePicker();
            this.chk_data_od = new System.Windows.Forms.CheckBox();
            this.chk_data_do = new System.Windows.Forms.CheckBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.dgv_audit = new System.Windows.Forms.DataGridView();
            this.btn_prev_page = new System.Windows.Forms.Button();
            this.lbl_page_info = new System.Windows.Forms.Label();
            this.btn_next_page = new System.Windows.Forms.Button();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_audit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_header.Controls.Add(this.lbl_naglowek);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(1406, 56);
            this.panel_header.TabIndex = 0;
            // 
            // lbl_naglowek
            // 
            this.lbl_naglowek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_naglowek.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_naglowek.Location = new System.Drawing.Point(0, 0);
            this.lbl_naglowek.Name = "lbl_naglowek";
            this.lbl_naglowek.Size = new System.Drawing.Size(1406, 56);
            this.lbl_naglowek.TabIndex = 0;
            this.lbl_naglowek.Text = "AUDYT DODAWANIA KSIĄŻEK";
            this.lbl_naglowek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_filter_tytul
            // 
            this.lbl_filter_tytul.AutoSize = true;
            this.lbl_filter_tytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_filter_tytul.Location = new System.Drawing.Point(20, 75);
            this.lbl_filter_tytul.Name = "lbl_filter_tytul";
            this.lbl_filter_tytul.Size = new System.Drawing.Size(56, 20);
            this.lbl_filter_tytul.TabIndex = 1;
            this.lbl_filter_tytul.Text = "Tytuł:";
            // 
            // txt_filter_tytul
            // 
            this.txt_filter_tytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txt_filter_tytul.Location = new System.Drawing.Point(110, 72);
            this.txt_filter_tytul.Name = "txt_filter_tytul";
            this.txt_filter_tytul.Size = new System.Drawing.Size(220, 27);
            this.txt_filter_tytul.TabIndex = 2;
            this.txt_filter_tytul.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_filter_KeyDown);
            this.txt_filter_tytul.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
            // 
            // lbl_filter_autor
            // 
            this.lbl_filter_autor.AutoSize = true;
            this.lbl_filter_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_filter_autor.Location = new System.Drawing.Point(350, 75);
            this.lbl_filter_autor.Name = "lbl_filter_autor";
            this.lbl_filter_autor.Size = new System.Drawing.Size(60, 20);
            this.lbl_filter_autor.TabIndex = 3;
            this.lbl_filter_autor.Text = "Autor:";
            // 
            // txt_filter_autor
            // 
            this.txt_filter_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txt_filter_autor.Location = new System.Drawing.Point(430, 72);
            this.txt_filter_autor.Name = "txt_filter_autor";
            this.txt_filter_autor.Size = new System.Drawing.Size(220, 27);
            this.txt_filter_autor.TabIndex = 4;
            this.txt_filter_autor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_filter_KeyDown);
            this.txt_filter_autor.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
            // 
            // lbl_filter_gatunek
            // 
            this.lbl_filter_gatunek.AutoSize = true;
            this.lbl_filter_gatunek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_filter_gatunek.Location = new System.Drawing.Point(20, 115);
            this.lbl_filter_gatunek.Name = "lbl_filter_gatunek";
            this.lbl_filter_gatunek.Size = new System.Drawing.Size(84, 20);
            this.lbl_filter_gatunek.TabIndex = 5;
            this.lbl_filter_gatunek.Text = "Gatunek:";
            // 
            // txt_filter_gatunek
            // 
            this.txt_filter_gatunek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txt_filter_gatunek.Location = new System.Drawing.Point(110, 112);
            this.txt_filter_gatunek.Name = "txt_filter_gatunek";
            this.txt_filter_gatunek.Size = new System.Drawing.Size(220, 27);
            this.txt_filter_gatunek.TabIndex = 6;
            this.txt_filter_gatunek.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_filter_KeyDown);
            this.txt_filter_gatunek.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
            // 
            // lbl_filter_wyd
            // 
            this.lbl_filter_wyd.AutoSize = true;
            this.lbl_filter_wyd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_filter_wyd.Location = new System.Drawing.Point(350, 115);
            this.lbl_filter_wyd.Name = "lbl_filter_wyd";
            this.lbl_filter_wyd.Size = new System.Drawing.Size(128, 20);
            this.lbl_filter_wyd.TabIndex = 7;
            this.lbl_filter_wyd.Text = "Wydawnictwo:";
            // 
            // txt_filter_wyd
            // 
            this.txt_filter_wyd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txt_filter_wyd.Location = new System.Drawing.Point(480, 112);
            this.txt_filter_wyd.Name = "txt_filter_wyd";
            this.txt_filter_wyd.Size = new System.Drawing.Size(220, 27);
            this.txt_filter_wyd.TabIndex = 8;
            this.txt_filter_wyd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_filter_KeyDown);
            this.txt_filter_wyd.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
            // 
            // lbl_filter_osoba
            // 
            this.lbl_filter_osoba.AutoSize = true;
            this.lbl_filter_osoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_filter_osoba.Location = new System.Drawing.Point(21, 158);
            this.lbl_filter_osoba.Name = "lbl_filter_osoba";
            this.lbl_filter_osoba.Size = new System.Drawing.Size(120, 20);
            this.lbl_filter_osoba.TabIndex = 9;
            this.lbl_filter_osoba.Text = "Rejestrujący:";
            // 
            // txt_filter_osoba
            // 
            this.txt_filter_osoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txt_filter_osoba.Location = new System.Drawing.Point(141, 155);
            this.txt_filter_osoba.Name = "txt_filter_osoba";
            this.txt_filter_osoba.Size = new System.Drawing.Size(220, 27);
            this.txt_filter_osoba.TabIndex = 10;
            this.txt_filter_osoba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_filter_KeyDown);
            this.txt_filter_osoba.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
            // 
            // dtp_data_od
            // 
            this.dtp_data_od.Enabled = false;
            this.dtp_data_od.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dtp_data_od.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_data_od.Location = new System.Drawing.Point(831, 72);
            this.dtp_data_od.Name = "dtp_data_od";
            this.dtp_data_od.Size = new System.Drawing.Size(185, 27);
            this.dtp_data_od.TabIndex = 12;
            this.dtp_data_od.ValueChanged += new System.EventHandler(this.dtp_data_ValueChanged);
            // 
            // dtp_data_do
            // 
            this.dtp_data_do.Enabled = false;
            this.dtp_data_do.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dtp_data_do.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_data_do.Location = new System.Drawing.Point(831, 112);
            this.dtp_data_do.Name = "dtp_data_do";
            this.dtp_data_do.Size = new System.Drawing.Size(185, 27);
            this.dtp_data_do.TabIndex = 14;
            this.dtp_data_do.ValueChanged += new System.EventHandler(this.dtp_data_ValueChanged);
            // 
            // chk_data_od
            // 
            this.chk_data_od.AutoSize = true;
            this.chk_data_od.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.chk_data_od.Location = new System.Drawing.Point(711, 75);
            this.chk_data_od.Name = "chk_data_od";
            this.chk_data_od.Size = new System.Drawing.Size(103, 24);
            this.chk_data_od.TabIndex = 11;
            this.chk_data_od.Text = "Data od:";
            this.chk_data_od.CheckedChanged += new System.EventHandler(this.chk_data_od_CheckedChanged);
            // 
            // chk_data_do
            // 
            this.chk_data_do.AutoSize = true;
            this.chk_data_do.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.chk_data_do.Location = new System.Drawing.Point(710, 112);
            this.chk_data_do.Name = "chk_data_do";
            this.chk_data_do.Size = new System.Drawing.Size(103, 24);
            this.chk_data_do.TabIndex = 13;
            this.chk_data_do.Text = "Data do:";
            this.chk_data_do.CheckedChanged += new System.EventHandler(this.chk_data_do_CheckedChanged);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(1043, 69);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(110, 32);
            this.btn_search.TabIndex = 15;
            this.btn_search.Text = "Szukaj";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.LightYellow;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btn_clear.Location = new System.Drawing.Point(1033, 115);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(140, 32);
            this.btn_clear.TabIndex = 16;
            this.btn_clear.Text = "Wyczyść filtry";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // dgv_audit
            // 
            this.dgv_audit.AllowUserToAddRows = false;
            this.dgv_audit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_audit.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_audit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_audit.Location = new System.Drawing.Point(20, 200);
            this.dgv_audit.Name = "dgv_audit";
            this.dgv_audit.ReadOnly = true;
            this.dgv_audit.RowHeadersVisible = false;
            this.dgv_audit.RowHeadersWidth = 51;
            this.dgv_audit.RowTemplate.Height = 24;
            this.dgv_audit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_audit.Size = new System.Drawing.Size(1359, 519);
            this.dgv_audit.TabIndex = 20;
            // 
            // btn_prev_page
            // 
            this.btn_prev_page.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_prev_page.BackColor = System.Drawing.Color.LightBlue;
            this.btn_prev_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_prev_page.Location = new System.Drawing.Point(490, 732);
            this.btn_prev_page.Name = "btn_prev_page";
            this.btn_prev_page.Size = new System.Drawing.Size(137, 31);
            this.btn_prev_page.TabIndex = 21;
            this.btn_prev_page.Text = "Poprzednia";
            this.btn_prev_page.UseVisualStyleBackColor = false;
            this.btn_prev_page.Click += new System.EventHandler(this.btn_prev_page_Click);
            // 
            // lbl_page_info
            // 
            this.lbl_page_info.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_page_info.AutoSize = true;
            this.lbl_page_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_page_info.Location = new System.Drawing.Point(655, 737);
            this.lbl_page_info.Name = "lbl_page_info";
            this.lbl_page_info.Size = new System.Drawing.Size(114, 20);
            this.lbl_page_info.TabIndex = 22;
            this.lbl_page_info.Text = "Strona: 1 / 1";
            this.lbl_page_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_next_page
            // 
            this.btn_next_page.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_next_page.BackColor = System.Drawing.Color.LightBlue;
            this.btn_next_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_next_page.Location = new System.Drawing.Point(800, 732);
            this.btn_next_page.Name = "btn_next_page";
            this.btn_next_page.Size = new System.Drawing.Size(137, 31);
            this.btn_next_page.TabIndex = 23;
            this.btn_next_page.Text = "Następna";
            this.btn_next_page.UseVisualStyleBackColor = false;
            this.btn_next_page.Click += new System.EventHandler(this.btn_next_page_Click);
            // 
            // UCManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.lbl_filter_tytul);
            this.Controls.Add(this.txt_filter_tytul);
            this.Controls.Add(this.lbl_filter_autor);
            this.Controls.Add(this.txt_filter_autor);
            this.Controls.Add(this.lbl_filter_gatunek);
            this.Controls.Add(this.txt_filter_gatunek);
            this.Controls.Add(this.lbl_filter_wyd);
            this.Controls.Add(this.txt_filter_wyd);
            this.Controls.Add(this.lbl_filter_osoba);
            this.Controls.Add(this.txt_filter_osoba);
            this.Controls.Add(this.chk_data_od);
            this.Controls.Add(this.dtp_data_od);
            this.Controls.Add(this.chk_data_do);
            this.Controls.Add(this.dtp_data_do);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.dgv_audit);
            this.Controls.Add(this.btn_prev_page);
            this.Controls.Add(this.lbl_page_info);
            this.Controls.Add(this.btn_next_page);
            this.Name = "UCManager";
            this.Size = new System.Drawing.Size(1406, 776);
            this.panel_header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_audit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Label lbl_naglowek;
        private System.Windows.Forms.Label lbl_filter_tytul;
        private System.Windows.Forms.TextBox txt_filter_tytul;
        private System.Windows.Forms.Label lbl_filter_autor;
        private System.Windows.Forms.TextBox txt_filter_autor;
        private System.Windows.Forms.Label lbl_filter_gatunek;
        private System.Windows.Forms.TextBox txt_filter_gatunek;
        private System.Windows.Forms.Label lbl_filter_wyd;
        private System.Windows.Forms.TextBox txt_filter_wyd;
        private System.Windows.Forms.Label lbl_filter_osoba;
        private System.Windows.Forms.TextBox txt_filter_osoba;
        private System.Windows.Forms.CheckBox chk_data_od;
        private System.Windows.Forms.DateTimePicker dtp_data_od;
        private System.Windows.Forms.CheckBox chk_data_do;
        private System.Windows.Forms.DateTimePicker dtp_data_do;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.DataGridView dgv_audit;
        private System.Windows.Forms.Button btn_prev_page;
        private System.Windows.Forms.Label lbl_page_info;
        private System.Windows.Forms.Button btn_next_page;
    }
}
