namespace Biblioteka
{
    partial class login1
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
            this.Error_msg = new System.Windows.Forms.Label();
            this.btn_Recover_pass = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_personal_data = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_login = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Error_msg
            // 
            this.Error_msg.AutoSize = true;
            this.Error_msg.ForeColor = System.Drawing.Color.Firebrick;
            this.Error_msg.Location = new System.Drawing.Point(379, 428);
            this.Error_msg.Name = "Error_msg";
            this.Error_msg.Size = new System.Drawing.Size(51, 20);
            this.Error_msg.TabIndex = 107;
            this.Error_msg.Text = "label1";
            // 
            // btn_Recover_pass
            // 
            this.btn_Recover_pass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Recover_pass.AutoSize = true;
            this.btn_Recover_pass.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Recover_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Recover_pass.Location = new System.Drawing.Point(123, 324);
            this.btn_Recover_pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Recover_pass.Name = "btn_Recover_pass";
            this.btn_Recover_pass.Size = new System.Drawing.Size(307, 49);
            this.btn_Recover_pass.TabIndex = 106;
            this.btn_Recover_pass.Text = "ZAPOMNIAŁEŚ HASŁA?";
            this.btn_Recover_pass.UseVisualStyleBackColor = false;
            this.btn_Recover_pass.Click += new System.EventHandler(this.btn_Recover_pass_Click);
            // 
            // btn_login
            // 
            this.btn_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_login.AutoSize = true;
            this.btn_login.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_login.Location = new System.Drawing.Point(446, 324);
            this.btn_login.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(231, 49);
            this.btn_login.TabIndex = 105;
            this.btn_login.Text = "ZALOGUJ";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // lbl_personal_data
            // 
            this.lbl_personal_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_personal_data.AutoSize = true;
            this.lbl_personal_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_personal_data.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_personal_data.Location = new System.Drawing.Point(308, 3);
            this.lbl_personal_data.Name = "lbl_personal_data";
            this.lbl_personal_data.Size = new System.Drawing.Size(273, 38);
            this.lbl_personal_data.TabIndex = 100;
            this.lbl_personal_data.Text = "Ekran logowania";
            // 
            // txt_password
            // 
            this.txt_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_password.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_password.Location = new System.Drawing.Point(381, 256);
            this.txt_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(296, 35);
            this.txt_password.TabIndex = 104;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // txt_login
            // 
            this.txt_login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_login.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_login.Location = new System.Drawing.Point(381, 211);
            this.txt_login.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(296, 35);
            this.txt_login.TabIndex = 103;
            // 
            // lbl_name
            // 
            this.lbl_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_name.Location = new System.Drawing.Point(177, 256);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(84, 29);
            this.lbl_name.TabIndex = 102;
            this.lbl_name.Text = "Hasło:";
            // 
            // lbl_login
            // 
            this.lbl_login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_login.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_login.Location = new System.Drawing.Point(177, 211);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(79, 29);
            this.lbl_login.TabIndex = 101;
            this.lbl_login.Text = "Login:";
            // 
            // login1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 664);
            this.Controls.Add(this.Error_msg);
            this.Controls.Add(this.btn_Recover_pass);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lbl_personal_data);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_login);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "login1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Error_msg;
        private System.Windows.Forms.Button btn_Recover_pass;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lbl_personal_data;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_login;
    }
}