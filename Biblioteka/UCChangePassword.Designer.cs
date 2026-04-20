namespace Biblioteka
{
    partial class UCChangePassword
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
            this.components = new System.ComponentModel.Container();
            this.Error_msg = new System.Windows.Forms.Label();
            this.btn_anuluj = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_change_pass = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt_new_password = new System.Windows.Forms.TextBox();
            this.txt_repeat_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Error_msg
            // 
            this.Error_msg.AutoSize = true;
            this.Error_msg.ForeColor = System.Drawing.Color.Firebrick;
            this.Error_msg.Location = new System.Drawing.Point(358, 409);
            this.Error_msg.Name = "Error_msg";
            this.Error_msg.Size = new System.Drawing.Size(44, 16);
            this.Error_msg.TabIndex = 115;
            this.Error_msg.Text = "label1";
            // 
            // btn_anuluj
            // 
            this.btn_anuluj.AutoSize = true;
            this.btn_anuluj.BackColor = System.Drawing.Color.LightCoral;
            this.btn_anuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_anuluj.Location = new System.Drawing.Point(230, 314);
            this.btn_anuluj.Name = "btn_anuluj";
            this.btn_anuluj.Size = new System.Drawing.Size(169, 39);
            this.btn_anuluj.TabIndex = 114;
            this.btn_anuluj.Text = "ANULUJ";
            this.btn_anuluj.UseVisualStyleBackColor = false;
            this.btn_anuluj.Click += new System.EventHandler(this.btn_anuluj_Click);
            // 
            // btn_save
            // 
            this.btn_save.AutoSize = true;
            this.btn_save.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_save.Location = new System.Drawing.Point(420, 314);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(205, 39);
            this.btn_save.TabIndex = 113;
            this.btn_save.Text = "ZAPISZ";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_change_pass
            // 
            this.lbl_change_pass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_change_pass.AutoSize = true;
            this.lbl_change_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_change_pass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_change_pass.Location = new System.Drawing.Point(295, 69);
            this.lbl_change_pass.Name = "lbl_change_pass";
            this.lbl_change_pass.Size = new System.Drawing.Size(180, 32);
            this.lbl_change_pass.TabIndex = 108;
            this.lbl_change_pass.Text = "Zmień hasło";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_name.Location = new System.Drawing.Point(143, 214);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(120, 25);
            this.lbl_name.TabIndex = 110;
            this.lbl_name.Text = "Nowe hasło:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txt_new_password
            // 
            this.txt_new_password.Location = new System.Drawing.Point(361, 214);
            this.txt_new_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_new_password.Name = "txt_new_password";
            this.txt_new_password.PasswordChar = '*';
            this.txt_new_password.Size = new System.Drawing.Size(264, 22);
            this.txt_new_password.TabIndex = 119;
            // 
            // txt_repeat_password
            // 
            this.txt_repeat_password.Location = new System.Drawing.Point(361, 251);
            this.txt_repeat_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_repeat_password.Name = "txt_repeat_password";
            this.txt_repeat_password.PasswordChar = '*';
            this.txt_repeat_password.Size = new System.Drawing.Size(264, 22);
            this.txt_repeat_password.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(144, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 121;
            this.label1.Text = "Powtórz nowe hasło:";
            // 
            // UCChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_repeat_password);
            this.Controls.Add(this.txt_new_password);
            this.Controls.Add(this.Error_msg);
            this.Controls.Add(this.btn_anuluj);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_change_pass);
            this.Controls.Add(this.lbl_name);
            this.Name = "UCChangePassword";
            this.Size = new System.Drawing.Size(786, 594);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Error_msg;
        private System.Windows.Forms.Button btn_anuluj;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_change_pass;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txt_new_password;
        private System.Windows.Forms.TextBox txt_repeat_password;
        private System.Windows.Forms.Label label1;
    }
}
