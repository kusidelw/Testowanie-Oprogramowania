namespace Biblioteka
{
    partial class UCFindUsers
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
            this.lbl_find_users = new System.Windows.Forms.Label();
            this.lbl_search_criteria = new System.Windows.Forms.Label();
            this.txt_search_query = new System.Windows.Forms.TextBox();
            this.btn_search_user = new System.Windows.Forms.Button();
            this.lbl_search_results = new System.Windows.Forms.Label();
            this.dgv_user_results = new System.Windows.Forms.DataGridView();
            this.lbl_results_message = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user_results)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_find_users);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 57);
            this.panel1.TabIndex = 2;
            // 
            // lbl_find_users
            // 
            this.lbl_find_users.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_find_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_find_users.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_find_users.Location = new System.Drawing.Point(3, 12);
            this.lbl_find_users.Name = "lbl_find_users";
            this.lbl_find_users.Size = new System.Drawing.Size(1052, 37);
            this.lbl_find_users.TabIndex = 1;
            this.lbl_find_users.Text = "WYSZUKAJ UŻYTKOWNIKÓW\r\n\r\n";
            this.lbl_find_users.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_search_criteria
            // 
            this.lbl_search_criteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_search_criteria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_search_criteria.Location = new System.Drawing.Point(69, 76);
            this.lbl_search_criteria.Name = "lbl_search_criteria";
            this.lbl_search_criteria.Size = new System.Drawing.Size(908, 37);
            this.lbl_search_criteria.TabIndex = 3;
            this.lbl_search_criteria.Text = "Podaj kryteria wyszukiwania użytkownika: (login, imię i nazwisko, pesel)";
            this.lbl_search_criteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_search_query
            // 
            this.txt_search_query.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_search_query.BackColor = System.Drawing.SystemColors.Window;
            this.txt_search_query.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_search_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_search_query.Location = new System.Drawing.Point(62, 120);
            this.txt_search_query.Name = "txt_search_query";
            this.txt_search_query.Size = new System.Drawing.Size(685, 30);
            this.txt_search_query.TabIndex = 4;
            // 
            // btn_search_user
            // 
            this.btn_search_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search_user.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_search_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_search_user.Location = new System.Drawing.Point(753, 116);
            this.btn_search_user.Name = "btn_search_user";
            this.btn_search_user.Size = new System.Drawing.Size(224, 39);
            this.btn_search_user.TabIndex = 5;
            this.btn_search_user.Text = "Szukaj";
            this.btn_search_user.UseVisualStyleBackColor = false;
            this.btn_search_user.Click += new System.EventHandler(this.btn_search_user_Click);
            // 
            // lbl_search_results
            // 
            this.lbl_search_results.AutoSize = true;
            this.lbl_search_results.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_search_results.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_search_results.Location = new System.Drawing.Point(58, 187);
            this.lbl_search_results.Name = "lbl_search_results";
            this.lbl_search_results.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lbl_search_results.Size = new System.Drawing.Size(223, 30);
            this.lbl_search_results.TabIndex = 6;
            this.lbl_search_results.Text = "WYNIKI WYSZUKIWANIA:";
            // 
            // dgv_user_results
            // 
            this.dgv_user_results.AllowUserToAddRows = false;
            this.dgv_user_results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_user_results.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_user_results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_user_results.Location = new System.Drawing.Point(62, 220);
            this.dgv_user_results.Name = "dgv_user_results";
            this.dgv_user_results.ReadOnly = true;
            this.dgv_user_results.RowHeadersVisible = false;
            this.dgv_user_results.RowHeadersWidth = 51;
            this.dgv_user_results.RowTemplate.Height = 24;
            this.dgv_user_results.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_user_results.Size = new System.Drawing.Size(914, 248);
            this.dgv_user_results.TabIndex = 7;
            this.dgv_user_results.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_user_results_CellDoubleClick);
            // 
            // lbl_results_message
            // 
            this.lbl_results_message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_results_message.AutoSize = true;
            this.lbl_results_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_results_message.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_results_message.Location = new System.Drawing.Point(58, 471);
            this.lbl_results_message.Name = "lbl_results_message";
            this.lbl_results_message.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lbl_results_message.Size = new System.Drawing.Size(213, 30);
            this.lbl_results_message.TabIndex = 8;
            this.lbl_results_message.Text = "Wyświetlono X wyników!";
            // 
            // UCFindUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lbl_results_message);
            this.Controls.Add(this.dgv_user_results);
            this.Controls.Add(this.lbl_search_results);
            this.Controls.Add(this.btn_search_user);
            this.Controls.Add(this.txt_search_query);
            this.Controls.Add(this.lbl_search_criteria);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCFindUsers";
            this.Size = new System.Drawing.Size(1055, 555);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user_results)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_search_criteria;
        private System.Windows.Forms.TextBox txt_search_query;
        private System.Windows.Forms.Button btn_search_user;
        private System.Windows.Forms.Label lbl_search_results;
        private System.Windows.Forms.DataGridView dgv_user_results;
        private System.Windows.Forms.Label lbl_results_message;
        private System.Windows.Forms.Label lbl_find_users;
    }
}
