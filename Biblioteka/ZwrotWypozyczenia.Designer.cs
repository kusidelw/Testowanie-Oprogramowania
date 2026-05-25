namespace Biblioteka
{
    partial class ZwrotWypozyczenia
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
            this.dtp_borrow_date = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_libralian = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.dtp_return_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_books = new System.Windows.Forms.TextBox();
            this.lbl_filter_autor = new System.Windows.Forms.Label();
            this.txb_reader = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_days = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_delay = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_borrow_date
            // 
            this.dtp_borrow_date.Enabled = false;
            this.dtp_borrow_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_borrow_date.Location = new System.Drawing.Point(261, 338);
            this.dtp_borrow_date.Name = "dtp_borrow_date";
            this.dtp_borrow_date.Size = new System.Drawing.Size(129, 22);
            this.dtp_borrow_date.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(52, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Data wypożyczenia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(160, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Bibliotekarz:";
            // 
            // txb_libralian
            // 
            this.txb_libralian.Location = new System.Drawing.Point(310, 114);
            this.txb_libralian.Name = "txb_libralian";
            this.txb_libralian.Size = new System.Drawing.Size(342, 22);
            this.txb_libralian.TabIndex = 30;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_cancel.Location = new System.Drawing.Point(705, 443);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 45);
            this.btn_cancel.TabIndex = 29;
            this.btn_cancel.Text = "Anuluj ";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(12, 443);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(249, 45);
            this.btn_save.TabIndex = 28;
            this.btn_save.Text = "Zatwierdź zwrot";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // dtp_return_date
            // 
            this.dtp_return_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_return_date.Location = new System.Drawing.Point(691, 342);
            this.dtp_return_date.Name = "dtp_return_date";
            this.dtp_return_date.Size = new System.Drawing.Size(129, 22);
            this.dtp_return_date.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(473, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Aktualna data zwrotu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(70, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Wypożyczone Książki:";
            // 
            // txb_books
            // 
            this.txb_books.Location = new System.Drawing.Point(302, 158);
            this.txb_books.Multiline = true;
            this.txb_books.Name = "txb_books";
            this.txb_books.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_books.Size = new System.Drawing.Size(535, 142);
            this.txb_books.TabIndex = 22;
            // 
            // lbl_filter_autor
            // 
            this.lbl_filter_autor.AutoSize = true;
            this.lbl_filter_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_filter_autor.Location = new System.Drawing.Point(187, 76);
            this.lbl_filter_autor.Name = "lbl_filter_autor";
            this.lbl_filter_autor.Size = new System.Drawing.Size(92, 20);
            this.lbl_filter_autor.TabIndex = 21;
            this.lbl_filter_autor.Text = "Czytelnik:";
            // 
            // txb_reader
            // 
            this.txb_reader.Location = new System.Drawing.Point(310, 74);
            this.txb_reader.Name = "txb_reader";
            this.txb_reader.Size = new System.Drawing.Size(342, 22);
            this.txb_reader.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 64);
            this.panel1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(808, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aktualne Dane Wypożyczenia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(37, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Liczba dni wypozyczenia:";
            // 
            // txb_days
            // 
            this.txb_days.Location = new System.Drawing.Point(305, 390);
            this.txb_days.Name = "txb_days";
            this.txb_days.Size = new System.Drawing.Size(75, 22);
            this.txb_days.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(460, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Przekroczenie terminu:";
            // 
            // txb_delay
            // 
            this.txb_delay.Location = new System.Drawing.Point(714, 392);
            this.txb_delay.Name = "txb_delay";
            this.txb_delay.Size = new System.Drawing.Size(97, 22);
            this.txb_delay.TabIndex = 36;
            // 
            // ZwrotWypozyczenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 511);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_delay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_days);
            this.Controls.Add(this.dtp_borrow_date);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_libralian);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.dtp_return_date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_books);
            this.Controls.Add(this.lbl_filter_autor);
            this.Controls.Add(this.txb_reader);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "ZwrotWypozyczenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ZWROT WYPOŻYCZENIA";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_borrow_date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_libralian;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DateTimePicker dtp_return_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_books;
        private System.Windows.Forms.Label lbl_filter_autor;
        private System.Windows.Forms.TextBox txb_reader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_days;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_delay;
    }
}