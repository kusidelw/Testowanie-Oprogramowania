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
            this.btn_find_users = new System.Windows.Forms.Button();
            this.btn_show_users_data = new System.Windows.Forms.Button();
            this.btn_edit_data = new System.Windows.Forms.Button();
            this.btn_show_users = new System.Windows.Forms.Button();
            this.btn_add_user = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btn_find_forgotten_users);
            this.panel1.Controls.Add(this.btn_forget_users);
            this.panel1.Controls.Add(this.btn_find_users);
            this.panel1.Controls.Add(this.btn_show_users_data);
            this.panel1.Controls.Add(this.btn_edit_data);
            this.panel1.Controls.Add(this.btn_show_users);
            this.panel1.Controls.Add(this.btn_add_user);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 653);
            this.panel1.TabIndex = 0;
            // 
            // btn_find_forgotten_users
            // 
            this.btn_find_forgotten_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_find_forgotten_users.Location = new System.Drawing.Point(0, 428);
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
            this.btn_forget_users.Location = new System.Drawing.Point(0, 357);
            this.btn_forget_users.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_forget_users.Name = "btn_forget_users";
            this.btn_forget_users.Size = new System.Drawing.Size(300, 71);
            this.btn_forget_users.TabIndex = 6;
            this.btn_forget_users.Text = "Zapomnij użytkownika";
            this.btn_forget_users.UseVisualStyleBackColor = true;
            this.btn_forget_users.Click += new System.EventHandler(this.btn_forget_users_Click);
            // 
            // btn_find_users
            // 
            this.btn_find_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_find_users.Location = new System.Drawing.Point(0, 286);
            this.btn_find_users.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_find_users.Name = "btn_find_users";
            this.btn_find_users.Size = new System.Drawing.Size(300, 71);
            this.btn_find_users.TabIndex = 5;
            this.btn_find_users.Text = "Wyszukaj użytkownika";
            this.btn_find_users.UseVisualStyleBackColor = true;
            this.btn_find_users.Click += new System.EventHandler(this.btn_find_users_Click);
            // 
            // btn_show_users_data
            // 
            this.btn_show_users_data.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_show_users_data.Location = new System.Drawing.Point(0, 215);
            this.btn_show_users_data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_show_users_data.Name = "btn_show_users_data";
            this.btn_show_users_data.Size = new System.Drawing.Size(300, 71);
            this.btn_show_users_data.TabIndex = 4;
            this.btn_show_users_data.Text = "Pokaż dane użytkowników";
            this.btn_show_users_data.UseVisualStyleBackColor = true;
            this.btn_show_users_data.Click += new System.EventHandler(this.btn_show_users_data_Click);
            // 
            // btn_edit_data
            // 
            this.btn_edit_data.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_edit_data.Location = new System.Drawing.Point(0, 144);
            this.btn_edit_data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_edit_data.Name = "btn_edit_data";
            this.btn_edit_data.Size = new System.Drawing.Size(300, 71);
            this.btn_edit_data.TabIndex = 3;
            this.btn_edit_data.Text = "Edytuj dane";
            this.btn_edit_data.UseVisualStyleBackColor = true;
            this.btn_edit_data.Click += new System.EventHandler(this.btn_edit_data_Click);
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
            this.MainPanel.Size = new System.Drawing.Size(1282, 653);
            this.MainPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1582, 653);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1600, 700);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add_user;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button btn_edit_data;
        private System.Windows.Forms.Button btn_show_users;
        private System.Windows.Forms.Button btn_find_forgotten_users;
        private System.Windows.Forms.Button btn_forget_users;
        private System.Windows.Forms.Button btn_find_users;
        private System.Windows.Forms.Button btn_show_users_data;
    }
}

