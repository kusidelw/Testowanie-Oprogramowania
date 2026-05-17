namespace Biblioteka
{
    partial class PrzedluzWypozyczenie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_filter_autor = new System.Windows.Forms.Label();
            this.txb_reader = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_books = new System.Windows.Forms.TextBox();
            this.dtp_return_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.nup_borrow_period = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_libralian = new System.Windows.Forms.TextBox();
            this.dtp_borrow_date = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_borrow_period)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 64);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(808, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aktualne Dane Wypożyczenia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_filter_autor
            // 
            this.lbl_filter_autor.AutoSize = true;
            this.lbl_filter_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_filter_autor.Location = new System.Drawing.Point(188, 150);
            this.lbl_filter_autor.Name = "lbl_filter_autor";
            this.lbl_filter_autor.Size = new System.Drawing.Size(92, 20);
            this.lbl_filter_autor.TabIndex = 6;
            this.lbl_filter_autor.Text = "Czytelnik:";
            // 
            // txb_reader
            // 
            this.txb_reader.Location = new System.Drawing.Point(311, 148);
            this.txb_reader.Name = "txb_reader";
            this.txb_reader.Size = new System.Drawing.Size(342, 22);
            this.txb_reader.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(79, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Wypożyczone Książki:";
            // 
            // txb_books
            // 
            this.txb_books.Location = new System.Drawing.Point(311, 228);
            this.txb_books.Multiline = true;
            this.txb_books.Name = "txb_books";
            this.txb_books.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_books.Size = new System.Drawing.Size(535, 142);
            this.txb_books.TabIndex = 7;
            // 
            // dtp_return_date
            // 
            this.dtp_return_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_return_date.Location = new System.Drawing.Point(709, 388);
            this.dtp_return_date.Name = "dtp_return_date";
            this.dtp_return_date.Size = new System.Drawing.Size(129, 22);
            this.dtp_return_date.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(467, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Oczekiwana data zwrotu:";
            // 
            // nup_borrow_period
            // 
            this.nup_borrow_period.Location = new System.Drawing.Point(602, 84);
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
            this.nup_borrow_period.Size = new System.Drawing.Size(71, 22);
            this.nup_borrow_period.TabIndex = 12;
            this.nup_borrow_period.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(161, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(380, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Wybierz o ile dni przedłużasz wypożyczenie";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_cancel.Location = new System.Drawing.Point(707, 435);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 45);
            this.btn_cancel.TabIndex = 14;
            this.btn_cancel.Text = "Anuluj ";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(12, 434);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(249, 45);
            this.btn_save.TabIndex = 13;
            this.btn_save.Text = "Zapisz przedłużenie";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(161, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Bibliotekarz:";
            // 
            // txb_libralian
            // 
            this.txb_libralian.Location = new System.Drawing.Point(311, 188);
            this.txb_libralian.Name = "txb_libralian";
            this.txb_libralian.Size = new System.Drawing.Size(342, 22);
            this.txb_libralian.TabIndex = 15;
            // 
            // dtp_borrow_date
            // 
            this.dtp_borrow_date.Enabled = false;
            this.dtp_borrow_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_borrow_date.Location = new System.Drawing.Point(221, 388);
            this.dtp_borrow_date.Name = "dtp_borrow_date";
            this.dtp_borrow_date.Size = new System.Drawing.Size(129, 22);
            this.dtp_borrow_date.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(22, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Data wypożyczenia:";
            // 
            // PrzedluzWypozyczenie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 492);
            this.Controls.Add(this.dtp_borrow_date);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_libralian);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.nup_borrow_period);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtp_return_date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_books);
            this.Controls.Add(this.lbl_filter_autor);
            this.Controls.Add(this.txb_reader);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PrzedluzWypozyczenie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PRZEDŁUŻENIE WYPOŻYCZENIA";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nup_borrow_period)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_filter_autor;
        private System.Windows.Forms.TextBox txb_reader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_books;
        private System.Windows.Forms.DateTimePicker dtp_return_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nup_borrow_period;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_libralian;
        private System.Windows.Forms.DateTimePicker dtp_borrow_date;
        private System.Windows.Forms.Label label6;
    }
}