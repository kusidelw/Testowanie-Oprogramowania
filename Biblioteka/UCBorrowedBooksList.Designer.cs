namespace Biblioteka
{
    partial class UCBorrowedBooksList
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
            this.lbl_forget_users = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_search_filters = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.dtp_date_from = new System.Windows.Forms.DateTimePicker();
            this.dtp_date_to = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_filter_autor = new System.Windows.Forms.Label();
            this.txb_librarian = new System.Windows.Forms.TextBox();
            this.txb_reader = new System.Windows.Forms.TextBox();
            this.dgv_rentals = new System.Windows.Forms.DataGridView();
            this.btn_prev_page = new System.Windows.Forms.Button();
            this.lbl_page_info = new System.Windows.Forms.Label();
            this.btn_next_page = new System.Windows.Forms.Button();
            this.btn_add_new_rental = new System.Windows.Forms.Button();
            this.btn_extend_time = new System.Windows.Forms.Button();
            this.btn_return = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gb_search_filters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rentals)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_forget_users
            // 
            this.lbl_forget_users.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_forget_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_forget_users.Location = new System.Drawing.Point(62, 0);
            this.lbl_forget_users.Name = "lbl_forget_users";
            this.lbl_forget_users.Size = new System.Drawing.Size(1111, 67);
            this.lbl_forget_users.TabIndex = 1;
            this.lbl_forget_users.Text = "ZAPOMNIJ UŻYTKOWNIKA";
            this.lbl_forget_users.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 85);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1234, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "ZARZĄDZANIE WYPOŻYCZENIAMI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_search_filters
            // 
            this.gb_search_filters.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gb_search_filters.Controls.Add(this.label5);
            this.gb_search_filters.Controls.Add(this.label4);
            this.gb_search_filters.Controls.Add(this.btn_clear);
            this.gb_search_filters.Controls.Add(this.btn_search);
            this.gb_search_filters.Controls.Add(this.dtp_date_from);
            this.gb_search_filters.Controls.Add(this.dtp_date_to);
            this.gb_search_filters.Controls.Add(this.label3);
            this.gb_search_filters.Controls.Add(this.cb_status);
            this.gb_search_filters.Controls.Add(this.label2);
            this.gb_search_filters.Controls.Add(this.lbl_filter_autor);
            this.gb_search_filters.Controls.Add(this.txb_librarian);
            this.gb_search_filters.Controls.Add(this.txb_reader);
            this.gb_search_filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gb_search_filters.Location = new System.Drawing.Point(7, 102);
            this.gb_search_filters.Name = "gb_search_filters";
            this.gb_search_filters.Size = new System.Drawing.Size(1227, 119);
            this.gb_search_filters.TabIndex = 3;
            this.gb_search_filters.TabStop = false;
            this.gb_search_filters.Text = "Filtry Wyszukiwania";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(830, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Data do:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(830, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Data od:";
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.LightYellow;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btn_clear.Location = new System.Drawing.Point(986, 81);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(140, 32);
            this.btn_clear.TabIndex = 18;
            this.btn_clear.Text = "Wyczyść filtry";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(810, 81);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(110, 32);
            this.btn_search.TabIndex = 17;
            this.btn_search.Text = "Szukaj";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dtp_date_from
            // 
            this.dtp_date_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dtp_date_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_date_from.Location = new System.Drawing.Point(941, 15);
            this.dtp_date_from.Name = "dtp_date_from";
            this.dtp_date_from.Size = new System.Drawing.Size(185, 27);
            this.dtp_date_from.TabIndex = 16;
            // 
            // dtp_date_to
            // 
            this.dtp_date_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dtp_date_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_date_to.Location = new System.Drawing.Point(941, 48);
            this.dtp_date_to.Name = "dtp_date_to";
            this.dtp_date_to.Size = new System.Drawing.Size(185, 27);
            this.dtp_date_to.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(521, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Status:";
            // 
            // cb_status
            // 
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Location = new System.Drawing.Point(525, 62);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(235, 28);
            this.cb_status.TabIndex = 6;
            this.cb_status.SelectedIndexChanged += new System.EventHandler(this.cb_status_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(264, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bibliotekarz:";
            // 
            // lbl_filter_autor
            // 
            this.lbl_filter_autor.AutoSize = true;
            this.lbl_filter_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_filter_autor.Location = new System.Drawing.Point(14, 40);
            this.lbl_filter_autor.Name = "lbl_filter_autor";
            this.lbl_filter_autor.Size = new System.Drawing.Size(92, 20);
            this.lbl_filter_autor.TabIndex = 4;
            this.lbl_filter_autor.Text = "Czytelnik:";
            // 
            // txb_librarian
            // 
            this.txb_librarian.Location = new System.Drawing.Point(268, 63);
            this.txb_librarian.Name = "txb_librarian";
            this.txb_librarian.Size = new System.Drawing.Size(237, 27);
            this.txb_librarian.TabIndex = 1;
            // 
            // txb_reader
            // 
            this.txb_reader.Location = new System.Drawing.Point(15, 63);
            this.txb_reader.Name = "txb_reader";
            this.txb_reader.Size = new System.Drawing.Size(234, 27);
            this.txb_reader.TabIndex = 0;
            // 
            // dgv_rentals
            // 
            this.dgv_rentals.AllowUserToAddRows = false;
            this.dgv_rentals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_rentals.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_rentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_rentals.Location = new System.Drawing.Point(7, 241);
            this.dgv_rentals.Name = "dgv_rentals";
            this.dgv_rentals.ReadOnly = true;
            this.dgv_rentals.RowHeadersVisible = false;
            this.dgv_rentals.RowHeadersWidth = 51;
            this.dgv_rentals.RowTemplate.Height = 24;
            this.dgv_rentals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_rentals.Size = new System.Drawing.Size(1227, 467);
            this.dgv_rentals.TabIndex = 21;
            // 
            // btn_prev_page
            // 
            this.btn_prev_page.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_prev_page.BackColor = System.Drawing.Color.LightBlue;
            this.btn_prev_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_prev_page.Location = new System.Drawing.Point(391, 714);
            this.btn_prev_page.Name = "btn_prev_page";
            this.btn_prev_page.Size = new System.Drawing.Size(137, 31);
            this.btn_prev_page.TabIndex = 24;
            this.btn_prev_page.Text = "Poprzednia";
            this.btn_prev_page.UseVisualStyleBackColor = false;
            this.btn_prev_page.Click += new System.EventHandler(this.btn_prev_page_Click);
            // 
            // lbl_page_info
            // 
            this.lbl_page_info.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_page_info.AutoSize = true;
            this.lbl_page_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_page_info.Location = new System.Drawing.Point(556, 719);
            this.lbl_page_info.Name = "lbl_page_info";
            this.lbl_page_info.Size = new System.Drawing.Size(114, 20);
            this.lbl_page_info.TabIndex = 25;
            this.lbl_page_info.Text = "Strona: 1 / 1";
            this.lbl_page_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_next_page
            // 
            this.btn_next_page.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_next_page.BackColor = System.Drawing.Color.LightBlue;
            this.btn_next_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_next_page.Location = new System.Drawing.Point(701, 714);
            this.btn_next_page.Name = "btn_next_page";
            this.btn_next_page.Size = new System.Drawing.Size(137, 31);
            this.btn_next_page.TabIndex = 26;
            this.btn_next_page.Text = "Następna";
            this.btn_next_page.UseVisualStyleBackColor = false;
            this.btn_next_page.Click += new System.EventHandler(this.btn_next_page_Click);
            // 
            // btn_add_new_rental
            // 
            this.btn_add_new_rental.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add_new_rental.BackColor = System.Drawing.Color.LightGreen;
            this.btn_add_new_rental.Enabled = false;
            this.btn_add_new_rental.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_add_new_rental.Location = new System.Drawing.Point(22, 766);
            this.btn_add_new_rental.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add_new_rental.Name = "btn_add_new_rental";
            this.btn_add_new_rental.Size = new System.Drawing.Size(227, 45);
            this.btn_add_new_rental.TabIndex = 27;
            this.btn_add_new_rental.Text = "Nowe wypożyczenie";
            this.btn_add_new_rental.UseVisualStyleBackColor = false;
            this.btn_add_new_rental.Click += new System.EventHandler(this.btn_add_new_rental_Click);
            // 
            // btn_extend_time
            // 
            this.btn_extend_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_extend_time.BackColor = System.Drawing.Color.Khaki;
            this.btn_extend_time.Enabled = false;
            this.btn_extend_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_extend_time.Location = new System.Drawing.Point(508, 766);
            this.btn_extend_time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_extend_time.Name = "btn_extend_time";
            this.btn_extend_time.Size = new System.Drawing.Size(244, 45);
            this.btn_extend_time.TabIndex = 28;
            this.btn_extend_time.Text = "Przedłuż wypożyczenie";
            this.btn_extend_time.UseVisualStyleBackColor = false;
            this.btn_extend_time.Click += new System.EventHandler(this.btn_extend_time_Click);
            // 
            // btn_return
            // 
            this.btn_return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_return.BackColor = System.Drawing.Color.Tomato;
            this.btn_return.Enabled = false;
            this.btn_return.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_return.Location = new System.Drawing.Point(1017, 766);
            this.btn_return.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(206, 45);
            this.btn_return.TabIndex = 29;
            this.btn_return.Text = "Zarejestruj zwrot";
            this.btn_return.UseVisualStyleBackColor = false;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // UCBorrowedBooksList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.btn_extend_time);
            this.Controls.Add(this.btn_add_new_rental);
            this.Controls.Add(this.btn_prev_page);
            this.Controls.Add(this.lbl_page_info);
            this.Controls.Add(this.btn_next_page);
            this.Controls.Add(this.dgv_rentals);
            this.Controls.Add(this.gb_search_filters);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_forget_users);
            this.Name = "UCBorrowedBooksList";
            this.Size = new System.Drawing.Size(1237, 836);
            this.panel1.ResumeLayout(false);
            this.gb_search_filters.ResumeLayout(false);
            this.gb_search_filters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rentals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_forget_users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_search_filters;
        private System.Windows.Forms.TextBox txb_reader;
        private System.Windows.Forms.TextBox txb_librarian;
        private System.Windows.Forms.Label lbl_filter_autor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_date_from;
        private System.Windows.Forms.DateTimePicker dtp_date_to;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_rentals;
        private System.Windows.Forms.Button btn_prev_page;
        private System.Windows.Forms.Label lbl_page_info;
        private System.Windows.Forms.Button btn_next_page;
        private System.Windows.Forms.Button btn_add_new_rental;
        private System.Windows.Forms.Button btn_extend_time;
        private System.Windows.Forms.Button btn_return;
    }
}
