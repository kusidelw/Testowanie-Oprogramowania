namespace Biblioteka
{
    partial class UCForgetUsers
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
            this.lbl_forget_users = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_search_user = new System.Windows.Forms.TextBox();
            this.btn_search_user = new System.Windows.Forms.Button();
            this.dgv_users = new System.Windows.Forms.DataGridView();
            this.lbl_search_criteria = new System.Windows.Forms.Label();
            this.btn_anuluj = new System.Windows.Forms.Button();
            this.btn_forget_user = new System.Windows.Forms.Button();
            this.lbl_info_message = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_forget_users
            // 
            this.lbl_forget_users.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_forget_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_forget_users.Location = new System.Drawing.Point(-5, 11);
            this.lbl_forget_users.Name = "lbl_forget_users";
            this.lbl_forget_users.Size = new System.Drawing.Size(1248, 44);
            this.lbl_forget_users.TabIndex = 0;
            this.lbl_forget_users.Text = "ZAPOMNIJ UŻYTKOWNIKA";
            this.lbl_forget_users.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel1.TabIndex = 1;
            // 
            // txt_search_user
            // 
            this.txt_search_user.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_search_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_search_user.Location = new System.Drawing.Point(220, 139);
            this.txt_search_user.Name = "txt_search_user";
            this.txt_search_user.Size = new System.Drawing.Size(567, 30);
            this.txt_search_user.TabIndex = 2;
            // 
            // btn_search_user
            // 
            this.btn_search_user.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_search_user.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_search_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_search_user.Location = new System.Drawing.Point(793, 132);
            this.btn_search_user.Name = "btn_search_user";
            this.btn_search_user.Size = new System.Drawing.Size(237, 44);
            this.btn_search_user.TabIndex = 6;
            this.btn_search_user.Text = "Szukaj";
            this.btn_search_user.UseVisualStyleBackColor = false;
            this.btn_search_user.Click += new System.EventHandler(this.btn_search_user_Click);
            // 
            // dgv_users
            // 
            this.dgv_users.AllowUserToAddRows = false;
            this.dgv_users.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_users.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_users.Location = new System.Drawing.Point(171, 181);
            this.dgv_users.Name = "dgv_users";
            this.dgv_users.ReadOnly = true;
            this.dgv_users.RowHeadersVisible = false;
            this.dgv_users.RowHeadersWidth = 51;
            this.dgv_users.RowTemplate.Height = 24;
            this.dgv_users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_users.Size = new System.Drawing.Size(897, 361);
            this.dgv_users.TabIndex = 8;
            // 
            // lbl_search_criteria
            // 
            this.lbl_search_criteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_search_criteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_search_criteria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_search_criteria.Location = new System.Drawing.Point(212, 88);
            this.lbl_search_criteria.Name = "lbl_search_criteria";
            this.lbl_search_criteria.Size = new System.Drawing.Size(826, 41);
            this.lbl_search_criteria.TabIndex = 9;
            this.lbl_search_criteria.Text = "Podaj  kryteria wyszukiwania: Login, PESEL lub E-mail:";
            this.lbl_search_criteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_search_criteria.Click += new System.EventHandler(this.lbl_search_criteria_Click);
            // 
            // btn_anuluj
            // 
            this.btn_anuluj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_anuluj.AutoSize = true;
            this.btn_anuluj.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_anuluj.BackColor = System.Drawing.Color.LightCoral;
            this.btn_anuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_anuluj.Location = new System.Drawing.Point(2161, 1989);
            this.btn_anuluj.Name = "btn_anuluj";
            this.btn_anuluj.Size = new System.Drawing.Size(230, 35);
            this.btn_anuluj.TabIndex = 96;
            this.btn_anuluj.Text = "AULUJ DODAWANIE";
            this.btn_anuluj.UseVisualStyleBackColor = false;
            // 
            // btn_forget_user
            // 
            this.btn_forget_user.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_forget_user.AutoSize = true;
            this.btn_forget_user.BackColor = System.Drawing.Color.LightCoral;
            this.btn_forget_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_forget_user.Location = new System.Drawing.Point(770, 548);
            this.btn_forget_user.Name = "btn_forget_user";
            this.btn_forget_user.Size = new System.Drawing.Size(298, 56);
            this.btn_forget_user.TabIndex = 97;
            this.btn_forget_user.Text = "ZAPOMNIJ UŻYTKOWNIKA";
            this.btn_forget_user.UseVisualStyleBackColor = false;
            this.btn_forget_user.Click += new System.EventHandler(this.btn_forget_user_Click);
            // 
            // lbl_info_message
            // 
            this.lbl_info_message.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_info_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_info_message.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_info_message.Location = new System.Drawing.Point(338, 663);
            this.lbl_info_message.Name = "lbl_info_message";
            this.lbl_info_message.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lbl_info_message.Size = new System.Drawing.Size(542, 38);
            this.lbl_info_message.TabIndex = 98;
            this.lbl_info_message.Text = "Wybierz użytkownika z listy i kliknij przycisk aby go zapomnieć\r\n";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(168, 545);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(596, 49);
            this.label1.TabIndex = 99;
            this.label1.Text = "Zaznacz użytkownika i kliknij przycisk obok aby go zapomnieć ➔";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCForgetUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lbl_info_message);
            this.Controls.Add(this.btn_forget_user);
            this.Controls.Add(this.btn_anuluj);
            this.Controls.Add(this.lbl_search_criteria);
            this.Controls.Add(this.dgv_users);
            this.Controls.Add(this.btn_search_user);
            this.Controls.Add(this.txt_search_user);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCForgetUsers";
            this.Size = new System.Drawing.Size(1226, 648);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_forget_users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_search_user;
        private System.Windows.Forms.Button btn_search_user;
        private System.Windows.Forms.DataGridView dgv_users;
        private System.Windows.Forms.Label lbl_search_criteria;
        private System.Windows.Forms.Button btn_anuluj;
        private System.Windows.Forms.Button btn_forget_user;
        private System.Windows.Forms.Label lbl_info_message;
        private System.Windows.Forms.Label label1;
    }
}
