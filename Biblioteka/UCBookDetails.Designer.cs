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
            this.lbl_placeholder = new System.Windows.Forms.Label();
            this.btn_wroc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_placeholder
            // 
            this.lbl_placeholder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_placeholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_placeholder.Location = new System.Drawing.Point(250, 280);
            this.lbl_placeholder.Name = "lbl_placeholder";
            this.lbl_placeholder.Size = new System.Drawing.Size(787, 40);
            this.lbl_placeholder.TabIndex = 0;
            this.lbl_placeholder.Text = "Szczegóły książki — w przygotowaniu";
            this.lbl_placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // UCBookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btn_wroc);
            this.Controls.Add(this.lbl_placeholder);
            this.Name = "UCBookDetails";
            this.Size = new System.Drawing.Size(1287, 656);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_placeholder;
        private System.Windows.Forms.Button btn_wroc;
    }
}
