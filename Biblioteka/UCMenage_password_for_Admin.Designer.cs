namespace Biblioteka
{
    partial class UCMenage_password_for_Admin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_forget_users = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_forget_users);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1226, 66);
            this.panel1.TabIndex = 2;
            // 
            // lbl_forget_users
            // 
            this.lbl_forget_users.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_forget_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_forget_users.Location = new System.Drawing.Point(-5, 11);
            this.lbl_forget_users.Name = "lbl_forget_users";
            this.lbl_forget_users.Size = new System.Drawing.Size(1248, 44);
            this.lbl_forget_users.TabIndex = 0;
            this.lbl_forget_users.Text = "ZARZĄDZAJ HASŁAMI UŻYTKOWNIKÓW";
            this.lbl_forget_users.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCMenage_password_for_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UCMenage_password_for_Admin";
            this.Size = new System.Drawing.Size(1226, 648);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_forget_users;
    }
}
