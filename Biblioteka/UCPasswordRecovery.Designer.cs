namespace Biblioteka
{
    partial class UCPasswordRecovery
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.Error_msg = new System.Windows.Forms.Label();
            this.btn_anuluj = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.lbl_change_pass = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(304, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 129;
            this.label1.Text = "Login:";
            // 
            // txt_login
            // 
            this.txt_login.Location = new System.Drawing.Point(410, 262);
            this.txt_login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(264, 22);
            this.txt_login.TabIndex = 127;
            // 
            // Error_msg
            // 
            this.Error_msg.AutoSize = true;
            this.Error_msg.ForeColor = System.Drawing.Color.Firebrick;
            this.Error_msg.Location = new System.Drawing.Point(421, 472);
            this.Error_msg.Name = "Error_msg";
            this.Error_msg.Size = new System.Drawing.Size(44, 16);
            this.Error_msg.TabIndex = 126;
            this.Error_msg.Text = "label1";
            // 
            // btn_anuluj
            // 
            this.btn_anuluj.AutoSize = true;
            this.btn_anuluj.BackColor = System.Drawing.Color.LightCoral;
            this.btn_anuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_anuluj.Location = new System.Drawing.Point(293, 377);
            this.btn_anuluj.Name = "btn_anuluj";
            this.btn_anuluj.Size = new System.Drawing.Size(169, 39);
            this.btn_anuluj.TabIndex = 125;
            this.btn_anuluj.Text = "ANULUJ";
            this.btn_anuluj.UseVisualStyleBackColor = false;
            this.btn_anuluj.Click += new System.EventHandler(this.btn_anuluj_Click);
            // 
            // btn_send
            // 
            this.btn_send.AutoSize = true;
            this.btn_send.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_send.Location = new System.Drawing.Point(483, 377);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(205, 39);
            this.btn_send.TabIndex = 124;
            this.btn_send.Text = "Wyślij";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // lbl_change_pass
            // 
            this.lbl_change_pass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_change_pass.AutoSize = true;
            this.lbl_change_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_change_pass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_change_pass.Location = new System.Drawing.Point(404, 72);
            this.lbl_change_pass.Name = "lbl_change_pass";
            this.lbl_change_pass.Size = new System.Drawing.Size(221, 32);
            this.lbl_change_pass.TabIndex = 122;
            this.lbl_change_pass.Text = "Odzyskaj hasło";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_name.Location = new System.Drawing.Point(304, 299);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(66, 25);
            this.lbl_name.TabIndex = 123;
            this.lbl_name.Text = "Email:";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(410, 302);
            this.txt_email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(264, 22);
            this.txt_email.TabIndex = 130;
            // 
            // UCPasswordRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_login);
            this.Controls.Add(this.Error_msg);
            this.Controls.Add(this.btn_anuluj);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lbl_change_pass);
            this.Controls.Add(this.lbl_name);
            this.Name = "UCPasswordRecovery";
            this.Size = new System.Drawing.Size(918, 684);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.Label Error_msg;
        private System.Windows.Forms.Button btn_anuluj;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label lbl_change_pass;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_email;
    }
}
