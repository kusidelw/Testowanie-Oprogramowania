namespace Biblioteka
{
    partial class UCShowUsers
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
            this.lbl_show_users = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_search_criteria = new System.Windows.Forms.Label();
            this.btn_search_user = new System.Windows.Forms.Button();
            this.txt_search_user = new System.Windows.Forms.TextBox();
            this.dgv_users_list = new System.Windows.Forms.DataGridView();
            this.btn_prev_page = new System.Windows.Forms.Button();
            this.btn_next_page = new System.Windows.Forms.Button();
            this.lbl_page_info = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users_list)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_show_users
            // 
            this.lbl_show_users.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_show_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_show_users.Location = new System.Drawing.Point(0, 8);
            this.lbl_show_users.Name = "lbl_show_users";
            this.lbl_show_users.Size = new System.Drawing.Size(1287, 32);
            this.lbl_show_users.TabIndex = 0;
            this.lbl_show_users.Text = "LISTA UŻYTKOWNIKÓW";
            this.lbl_show_users.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_show_users);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1287, 56);
            this.panel1.TabIndex = 2;
            // 
            // lbl_search_criteria
            // 
            this.lbl_search_criteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_search_criteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_search_criteria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_search_criteria.Location = new System.Drawing.Point(244, 82);
            this.lbl_search_criteria.Name = "lbl_search_criteria";
            this.lbl_search_criteria.Size = new System.Drawing.Size(826, 41);
            this.lbl_search_criteria.TabIndex = 12;
            this.lbl_search_criteria.Text = "Podaj  kryteria wyszukiwania:  Login, Imię i nazwisko, PESEL:";
            this.lbl_search_criteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_search_user
            // 
            this.btn_search_user.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_search_user.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_search_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_search_user.Location = new System.Drawing.Point(825, 126);
            this.btn_search_user.Name = "btn_search_user";
            this.btn_search_user.Size = new System.Drawing.Size(237, 44);
            this.btn_search_user.TabIndex = 11;
            this.btn_search_user.Text = "Szukaj";
            this.btn_search_user.UseVisualStyleBackColor = false;
            // 
            // txt_search_user
            // 
            this.txt_search_user.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_search_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_search_user.Location = new System.Drawing.Point(252, 133);
            this.txt_search_user.Name = "txt_search_user";
            this.txt_search_user.Size = new System.Drawing.Size(567, 30);
            this.txt_search_user.TabIndex = 10;
            // 
            // dgv_users_list
            // 
            this.dgv_users_list.AllowUserToAddRows = false;
            this.dgv_users_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_users_list.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_users_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_users_list.Location = new System.Drawing.Point(207, 176);
            this.dgv_users_list.Name = "dgv_users_list";
            this.dgv_users_list.ReadOnly = true;
            this.dgv_users_list.RowHeadersVisible = false;
            this.dgv_users_list.RowHeadersWidth = 51;
            this.dgv_users_list.RowTemplate.Height = 24;
            this.dgv_users_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_users_list.Size = new System.Drawing.Size(897, 361);
            this.dgv_users_list.TabIndex = 13;
            // 
            // btn_prev_page
            // 
            this.btn_prev_page.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_prev_page.BackColor = System.Drawing.Color.LightBlue;
            this.btn_prev_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_prev_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_prev_page.Location = new System.Drawing.Point(457, 554);
            this.btn_prev_page.Name = "btn_prev_page";
            this.btn_prev_page.Size = new System.Drawing.Size(137, 31);
            this.btn_prev_page.TabIndex = 14;
            this.btn_prev_page.Text = "Poprzednia";
            this.btn_prev_page.UseVisualStyleBackColor = false;
            // 
            // btn_next_page
            // 
            this.btn_next_page.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_next_page.BackColor = System.Drawing.Color.LightBlue;
            this.btn_next_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_next_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_next_page.Location = new System.Drawing.Point(705, 554);
            this.btn_next_page.Name = "btn_next_page";
            this.btn_next_page.Size = new System.Drawing.Size(136, 31);
            this.btn_next_page.TabIndex = 15;
            this.btn_next_page.Text = "Następna";
            this.btn_next_page.UseVisualStyleBackColor = false;
            // 
            // lbl_page_info
            // 
            this.lbl_page_info.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_page_info.AutoSize = true;
            this.lbl_page_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_page_info.Location = new System.Drawing.Point(600, 559);
            this.lbl_page_info.Name = "lbl_page_info";
            this.lbl_page_info.Size = new System.Drawing.Size(86, 20);
            this.lbl_page_info.TabIndex = 16;
            this.lbl_page_info.Text = "Strona: 1";
            this.lbl_page_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_page_info.Click += new System.EventHandler(this.lbl_page_info_Click);
            // 
            // UCShowUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lbl_page_info);
            this.Controls.Add(this.btn_next_page);
            this.Controls.Add(this.btn_prev_page);
            this.Controls.Add(this.dgv_users_list);
            this.Controls.Add(this.lbl_search_criteria);
            this.Controls.Add(this.btn_search_user);
            this.Controls.Add(this.txt_search_user);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCShowUsers";
            this.Size = new System.Drawing.Size(1287, 656);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_show_users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_search_criteria;
        private System.Windows.Forms.Button btn_search_user;
        private System.Windows.Forms.TextBox txt_search_user;
        private System.Windows.Forms.DataGridView dgv_users_list;
        private System.Windows.Forms.Button btn_prev_page;
        private System.Windows.Forms.Button btn_next_page;
        private System.Windows.Forms.Label lbl_page_info;
    }
}
