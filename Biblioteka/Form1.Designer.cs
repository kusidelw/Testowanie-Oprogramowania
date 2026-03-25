namespace Biblioteka
{
    partial class Form1
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_find_forgotten_users = new System.Windows.Forms.Button();
            this.btn_forget_users = new System.Windows.Forms.Button();
            this.btn_show_users = new System.Windows.Forms.Button();
            this.btn_add_user = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_change_password = new System.Windows.Forms.Button();
            this.btn_password_recovery = new System.Windows.Forms.Button();
            this.btn_set_new_password = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btn_logout);
            this.panel1.Controls.Add(this.btn_set_new_password);
            this.panel1.Controls.Add(this.btn_password_recovery);
            this.panel1.Controls.Add(this.btn_change_password);
            this.panel1.Controls.Add(this.btn_login);
            this.panel1.Controls.Add(this.btn_find_forgotten_users);
            this.panel1.Controls.Add(this.btn_forget_users);
            this.panel1.Controls.Add(this.btn_show_users);
            this.panel1.Controls.Add(this.btn_add_user);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 683);
            this.panel1.TabIndex = 0;
            // 
            // btn_find_forgotten_users
            // 
            this.btn_find_forgotten_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_find_forgotten_users.Location = new System.Drawing.Point(0, 215);
            this.btn_find_forgotten_users.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_find_forgotten_users.Name = "btn_find_forgotten_users";
            this.btn_find_forgotten_users.Size = new System.Drawing.Size(300, 71);
            this.btn_find_forgotten_users.TabIndex = 7;
            this.btn_find_forgotten_users.Text = "Wyszukaj zapomnianego użytkownika";
            this.btn_find_forgotten_users.UseVisualStyleBackColor = true;
            this.btn_find_forgotten_users.Click += new System.EventHandler(this.btn_find_forgotten_users_Click);
            // 
            // btn_forget_users
            // 
            this.btn_forget_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_forget_users.Location = new System.Drawing.Point(0, 144);
            this.btn_forget_users.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_forget_users.Name = "btn_forget_users";
            this.btn_forget_users.Size = new System.Drawing.Size(300, 71);
            this.btn_forget_users.TabIndex = 6;
            this.btn_forget_users.Text = "Zapomnij użytkownika";
            this.btn_forget_users.UseVisualStyleBackColor = true;
            this.btn_forget_users.Click += new System.EventHandler(this.btn_forget_users_Click);
            // 
            // btn_show_users
            // 
            this.btn_show_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_show_users.Location = new System.Drawing.Point(0, 74);
            this.btn_show_users.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_show_users.Name = "btn_show_users";
            this.btn_show_users.Size = new System.Drawing.Size(300, 70);
            this.btn_show_users.TabIndex = 2;
            this.btn_show_users.Text = "Wyświetl listę użytkowników";
            this.btn_show_users.UseVisualStyleBackColor = true;
            this.btn_show_users.Click += new System.EventHandler(this.btn_show_users_Click);
            // 
            // btn_add_user
            // 
            this.btn_add_user.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_add_user.Location = new System.Drawing.Point(0, 0);
            this.btn_add_user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add_user.Name = "btn_add_user";
            this.btn_add_user.Size = new System.Drawing.Size(300, 74);
            this.btn_add_user.TabIndex = 1;
            this.btn_add_user.Text = "Dodaj użytkownika";
            this.btn_add_user.UseVisualStyleBackColor = true;
            this.btn_add_user.Click += new System.EventHandler(this.btn_add_user_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(300, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1158, 683);
            this.MainPanel.TabIndex = 1;
            // 
            // btn_login
            // 
            this.btn_login.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_login.Location = new System.Drawing.Point(0, 286);
            this.btn_login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(300, 71);
            this.btn_login.TabIndex = 8;
            this.btn_login.Text = "Zaloguj";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_change_password
            // 
            this.btn_change_password.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_change_password.Location = new System.Drawing.Point(0, 357);
            this.btn_change_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_change_password.Name = "btn_change_password";
            this.btn_change_password.Size = new System.Drawing.Size(300, 71);
            this.btn_change_password.TabIndex = 9;
            this.btn_change_password.Text = "Zmiana hasła";
            this.btn_change_password.UseVisualStyleBackColor = true;
            this.btn_change_password.Click += new System.EventHandler(this.btn_change_password_Click);
            // 
            // btn_password_recovery
            // 
            this.btn_password_recovery.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_password_recovery.Location = new System.Drawing.Point(0, 428);
            this.btn_password_recovery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_password_recovery.Name = "btn_password_recovery";
            this.btn_password_recovery.Size = new System.Drawing.Size(300, 71);
            this.btn_password_recovery.TabIndex = 10;
            this.btn_password_recovery.Text = "Odzyskanie hasła";
            this.btn_password_recovery.UseVisualStyleBackColor = true;
            this.btn_password_recovery.Click += new System.EventHandler(this.btn_password_recovery_Click);
            // 
            // btn_set_new_password
            // 
            this.btn_set_new_password.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_set_new_password.Location = new System.Drawing.Point(0, 499);
            this.btn_set_new_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_set_new_password.Name = "btn_set_new_password";
            this.btn_set_new_password.Size = new System.Drawing.Size(300, 71);
            this.btn_set_new_password.TabIndex = 11;
            this.btn_set_new_password.Text = "Ustaw nowe hasło";
            this.btn_set_new_password.UseVisualStyleBackColor = true;
            this.btn_set_new_password.Click += new System.EventHandler(this.btn_set_new_password_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_logout.Location = new System.Drawing.Point(0, 570);
            this.btn_logout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(300, 71);
            this.btn_logout.TabIndex = 12;
            this.btn_logout.Text = "Wyloguj";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1458, 683);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add_user;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button btn_show_users;
        private System.Windows.Forms.Button btn_find_forgotten_users;
        private System.Windows.Forms.Button btn_forget_users;
        private System.Windows.Forms.Button btn_set_new_password;
        private System.Windows.Forms.Button btn_password_recovery;
        private System.Windows.Forms.Button btn_change_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_logout;
    }
}

