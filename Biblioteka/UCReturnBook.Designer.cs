namespace Biblioteka
{
    partial class UCReturnBook
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
            this.panel_naglowek   = new System.Windows.Forms.Panel();
            this.lbl_tytul        = new System.Windows.Forms.Label();
            this.dgv_wypozyczenia = new System.Windows.Forms.DataGridView();
            this.btn_zwroc        = new System.Windows.Forms.Button();
            this.btn_odswiez      = new System.Windows.Forms.Button();
            this.panel_naglowek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_wypozyczenia)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_naglowek
            // 
            this.panel_naglowek.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_naglowek.Controls.Add(this.lbl_tytul);
            this.panel_naglowek.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_naglowek.Location = new System.Drawing.Point(0, 0);
            this.panel_naglowek.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.lbl_tytul.Text = "AKTYWNE WYPOŻYCZENIA — ZWROTY";
            this.lbl_tytul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_wypozyczenia
            // 
            this.dgv_wypozyczenia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_wypozyczenia.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_wypozyczenia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_wypozyczenia.Location = new System.Drawing.Point(100, 79);
            this.dgv_wypozyczenia.Name = "dgv_wypozyczenia";
            this.dgv_wypozyczenia.RowHeadersWidth = 51;
            this.dgv_wypozyczenia.RowTemplate.Height = 24;
            this.dgv_wypozyczenia.Size = new System.Drawing.Size(933, 470);
            this.dgv_wypozyczenia.TabIndex = 1;
            this.dgv_wypozyczenia.SelectionChanged += new System.EventHandler(this.dgv_wypozyczenia_SelectionChanged);
            // 
            // btn_zwroc
            // 
            this.btn_zwroc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_zwroc.BackColor = System.Drawing.Color.LightCoral;
            this.btn_zwroc.Enabled = false;
            this.btn_zwroc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btn_zwroc.Location = new System.Drawing.Point(100, 560);
            this.btn_zwroc.Name = "btn_zwroc";
            this.btn_zwroc.Size = new System.Drawing.Size(200, 45);
            this.btn_zwroc.TabIndex = 2;
            this.btn_zwroc.Text = "Zwróć";
            this.btn_zwroc.UseVisualStyleBackColor = false;
            this.btn_zwroc.Click += new System.EventHandler(this.btn_zwroc_Click);
            // 
            // btn_odswiez
            // 
            this.btn_odswiez.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_odswiez.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_odswiez.Location = new System.Drawing.Point(320, 560);
            this.btn_odswiez.Name = "btn_odswiez";
            this.btn_odswiez.Size = new System.Drawing.Size(150, 45);
            this.btn_odswiez.TabIndex = 3;
            this.btn_odswiez.Text = "Odśwież";
            this.btn_odswiez.UseVisualStyleBackColor = true;
            this.btn_odswiez.Click += new System.EventHandler(this.btn_odswiez_Click);
            // 
            // UCReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btn_odswiez);
            this.Controls.Add(this.btn_zwroc);
            this.Controls.Add(this.dgv_wypozyczenia);
            this.Controls.Add(this.panel_naglowek);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCReturnBook";
            this.Size = new System.Drawing.Size(1133, 626);
            this.panel_naglowek.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_wypozyczenia)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel_naglowek;
        private System.Windows.Forms.Label lbl_tytul;
        private System.Windows.Forms.DataGridView dgv_wypozyczenia;
        private System.Windows.Forms.Button btn_zwroc;
        private System.Windows.Forms.Button btn_odswiez;
    }
}
