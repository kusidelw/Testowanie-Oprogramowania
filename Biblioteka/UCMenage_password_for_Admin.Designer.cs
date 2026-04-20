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
            this.lbl_search_criteria = new System.Windows.Forms.Label();
            this.dgv_users = new System.Windows.Forms.DataGridView();
            this.btn_search_user = new System.Windows.Forms.Button();
            this.txt_search_user = new System.Windows.Forms.TextBox();
            this.btn_back_to_list = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_repeat_password = new System.Windows.Forms.TextBox();
            this.txt_new_password = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_edit_data = new System.Windows.Forms.Label();
            this.lbl_error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_search_criteria
            // 
            this.lbl_search_criteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_search_criteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_search_criteria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_search_criteria.Location = new System.Drawing.Point(231, 122);
            this.lbl_search_criteria.Name = "lbl_search_criteria";
            this.lbl_search_criteria.Size = new System.Drawing.Size(929, 51);
            this.lbl_search_criteria.TabIndex = 13;
            this.lbl_search_criteria.Text = "Podaj  kryteria wyszukiwania: Login, PESEL lub E-mail:";
            this.lbl_search_criteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_users
            // 
            this.dgv_users.AllowUserToAddRows = false;
            this.dgv_users.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_users.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_users.Location = new System.Drawing.Point(185, 238);
            this.dgv_users.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_users.Name = "dgv_users";
            this.dgv_users.ReadOnly = true;
            this.dgv_users.RowHeadersVisible = false;
            this.dgv_users.RowHeadersWidth = 51;
            this.dgv_users.RowTemplate.Height = 24;
            this.dgv_users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_users.Size = new System.Drawing.Size(1009, 268);
            this.dgv_users.TabIndex = 12;
            // 
            // btn_search_user
            // 
            this.btn_search_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_search_user.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_search_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_search_user.Location = new System.Drawing.Point(885, 177);
            this.btn_search_user.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_search_user.Name = "btn_search_user";
            this.btn_search_user.Size = new System.Drawing.Size(267, 55);
            this.btn_search_user.TabIndex = 11;
            this.btn_search_user.Text = "Szukaj";
            this.btn_search_user.UseVisualStyleBackColor = false;
            this.btn_search_user.Click += new System.EventHandler(this.btn_search_user_Click);
            // 
            // txt_search_user
            // 
            this.txt_search_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_search_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_search_user.Location = new System.Drawing.Point(241, 186);
            this.txt_search_user.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_search_user.Name = "txt_search_user";
            this.txt_search_user.Size = new System.Drawing.Size(637, 35);
            this.txt_search_user.TabIndex = 10;
            // 
            // btn_back_to_list
            // 
            this.btn_back_to_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_back_to_list.AutoSize = true;
            this.btn_back_to_list.BackColor = System.Drawing.Color.LightCoral;
            this.btn_back_to_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_back_to_list.Location = new System.Drawing.Point(185, 660);
            this.btn_back_to_list.Name = "btn_back_to_list";
            this.btn_back_to_list.Size = new System.Drawing.Size(250, 89);
            this.btn_back_to_list.TabIndex = 34;
            this.btn_back_to_list.Text = "WRÓĆ DO LISTY";
            this.btn_back_to_list.UseVisualStyleBackColor = false;
            this.btn_back_to_list.Click += new System.EventHandler(this.btn_back_to_list_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(654, 597);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 29);
            this.label1.TabIndex = 125;
            this.label1.Text = "Powtórz nowe hasło:";
            // 
            // txt_repeat_password
            // 
            this.txt_repeat_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_repeat_password.Location = new System.Drawing.Point(898, 597);
            this.txt_repeat_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_repeat_password.Name = "txt_repeat_password";
            this.txt_repeat_password.PasswordChar = '*';
            this.txt_repeat_password.Size = new System.Drawing.Size(296, 26);
            this.txt_repeat_password.TabIndex = 124;
            // 
            // txt_new_password
            // 
            this.txt_new_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_new_password.Location = new System.Drawing.Point(898, 551);
            this.txt_new_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_new_password.Name = "txt_new_password";
            this.txt_new_password.PasswordChar = '*';
            this.txt_new_password.Size = new System.Drawing.Size(296, 26);
            this.txt_new_password.TabIndex = 123;
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl.Location = new System.Drawing.Point(653, 551);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(150, 29);
            this.lbl.TabIndex = 122;
            this.lbl.Text = "Nowe hasło:";
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_save.AutoSize = true;
            this.btn_save.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_save.Location = new System.Drawing.Point(925, 660);
            this.btn_save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(269, 89);
            this.btn_save.TabIndex = 126;
            this.btn_save.Text = "ZAPISZ";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_edit_data);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1392, 80);
            this.panel1.TabIndex = 127;
            // 
            // lbl_edit_data
            // 
            this.lbl_edit_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_edit_data.Location = new System.Drawing.Point(3, 25);
            this.lbl_edit_data.Name = "lbl_edit_data";
            this.lbl_edit_data.Size = new System.Drawing.Size(1332, 36);
            this.lbl_edit_data.TabIndex = 0;
            this.lbl_edit_data.Text = "ZARZĄDZAJ HASŁAMI UŻYTKOWNIKÓW";
            this.lbl_edit_data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_error.Location = new System.Drawing.Point(624, 685);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(114, 20);
            this.lbl_error.TabIndex = 128;
            this.lbl_error.Text = "Wyświetla błąd";
            // 
            // UCMenage_password_for_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_repeat_password);
            this.Controls.Add(this.txt_new_password);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btn_back_to_list);
            this.Controls.Add(this.lbl_search_criteria);
            this.Controls.Add(this.dgv_users);
            this.Controls.Add(this.btn_search_user);
            this.Controls.Add(this.txt_search_user);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCMenage_password_for_Admin";
            this.Size = new System.Drawing.Size(1392, 810);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_search_criteria;
        private System.Windows.Forms.DataGridView dgv_users;
        private System.Windows.Forms.Button btn_search_user;
        private System.Windows.Forms.TextBox txt_search_user;
        private System.Windows.Forms.Button btn_back_to_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_repeat_password;
        private System.Windows.Forms.TextBox txt_new_password;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_edit_data;
        private System.Windows.Forms.Label lbl_error;
    }
}
