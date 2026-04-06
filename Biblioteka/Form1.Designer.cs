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
            this.btn_manage_permissions = new System.Windows.Forms.Button();
            this.btn_find_forgotten_users = new System.Windows.Forms.Button();
            this.btn_forget_users = new System.Windows.Forms.Button();
            this.btn_show_users = new System.Windows.Forms.Button();
            this.btn_add_user = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btn_manage_permissions);
            this.panel1.Controls.Add(this.btn_find_forgotten_users);
            this.panel1.Controls.Add(this.btn_forget_users);
            this.panel1.Controls.Add(this.btn_show_users);
            this.panel1.Controls.Add(this.btn_add_user);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 555);
            this.panel1.TabIndex = 0;
            // 
            // btn_manage_permissions
            // 
            this.btn_manage_permissions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_manage_permissions.Location = new System.Drawing.Point(0, 233);
            this.btn_manage_permissions.Margin = new System.Windows.Forms.Padding(2);
            this.btn_manage_permissions.Name = "btn_manage_permissions";
            this.btn_manage_permissions.Size = new System.Drawing.Size(225, 58);
            this.btn_manage_permissions.TabIndex = 8;
            this.btn_manage_permissions.Text = "Zarządzanie uprawnieniami";
            this.btn_manage_permissions.UseVisualStyleBackColor = true;
            this.btn_manage_permissions.Click += new System.EventHandler(this.btn_manage_permissions_Click);
            // 
            // btn_find_forgotten_users
            // 
            this.btn_find_forgotten_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_find_forgotten_users.Location = new System.Drawing.Point(0, 175);
            this.btn_find_forgotten_users.Margin = new System.Windows.Forms.Padding(2);
            this.btn_find_forgotten_users.Name = "btn_find_forgotten_users";
            this.btn_find_forgotten_users.Size = new System.Drawing.Size(225, 58);
            this.btn_find_forgotten_users.TabIndex = 7;
            this.btn_find_forgotten_users.Text = "Wyszukaj zapomnianego użytkownika";
            this.btn_find_forgotten_users.UseVisualStyleBackColor = true;
            this.btn_find_forgotten_users.Click += new System.EventHandler(this.btn_find_forgotten_users_Click);
            // 
            // btn_forget_users
            // 
            this.btn_forget_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_forget_users.Location = new System.Drawing.Point(0, 117);
            this.btn_forget_users.Margin = new System.Windows.Forms.Padding(2);
            this.btn_forget_users.Name = "btn_forget_users";
            this.btn_forget_users.Size = new System.Drawing.Size(225, 58);
            this.btn_forget_users.TabIndex = 6;
            this.btn_forget_users.Text = "Zapomnij użytkownika";
            this.btn_forget_users.UseVisualStyleBackColor = true;
            this.btn_forget_users.Click += new System.EventHandler(this.btn_forget_users_Click);
            // 
            // btn_show_users
            // 
            this.btn_show_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_show_users.Location = new System.Drawing.Point(0, 60);
            this.btn_show_users.Margin = new System.Windows.Forms.Padding(2);
            this.btn_show_users.Name = "btn_show_users";
            this.btn_show_users.Size = new System.Drawing.Size(225, 57);
            this.btn_show_users.TabIndex = 2;
            this.btn_show_users.Text = "Wyświetl listę użytkowników";
            this.btn_show_users.UseVisualStyleBackColor = true;
            this.btn_show_users.Click += new System.EventHandler(this.btn_show_users_Click);
            // 
            // btn_add_user
            // 
            this.btn_add_user.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_add_user.Location = new System.Drawing.Point(0, 0);
            this.btn_add_user.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add_user.Name = "btn_add_user";
            this.btn_add_user.Size = new System.Drawing.Size(225, 60);
            this.btn_add_user.TabIndex = 1;
            this.btn_add_user.Text = "Dodaj użytkownika";
            this.btn_add_user.UseVisualStyleBackColor = true;
            this.btn_add_user.Click += new System.EventHandler(this.btn_add_user_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(225, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(869, 555);
            this.MainPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1094, 555);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button btn_manage_permissions;
    }
}

