namespace Biblioteka
{
    partial class UCFindForgottenUsers
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
            this.lbl_find_forgotten_users = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_forgotten_users = new System.Windows.Forms.DataGridView();
            this.lbl_info_message = new System.Windows.Forms.Label();
            this.btn_search_users = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forgotten_users)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_find_forgotten_users
            // 
            this.lbl_find_forgotten_users.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_find_forgotten_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_find_forgotten_users.Location = new System.Drawing.Point(-29, 8);
            this.lbl_find_forgotten_users.Name = "lbl_find_forgotten_users";
            this.lbl_find_forgotten_users.Size = new System.Drawing.Size(1191, 34);
            this.lbl_find_forgotten_users.TabIndex = 0;
            this.lbl_find_forgotten_users.Text = "ZAPOMNIANI UŻYTKOWNICY";
            this.lbl_find_forgotten_users.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_find_forgotten_users);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 63);
            this.panel1.TabIndex = 2;
            // 
            // dgv_forgotten_users
            // 
            this.dgv_forgotten_users.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_forgotten_users.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_forgotten_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_forgotten_users.Location = new System.Drawing.Point(101, 124);
            this.dgv_forgotten_users.Name = "dgv_forgotten_users";
            this.dgv_forgotten_users.RowHeadersWidth = 51;
            this.dgv_forgotten_users.RowTemplate.Height = 24;
            this.dgv_forgotten_users.Size = new System.Drawing.Size(954, 415);
            this.dgv_forgotten_users.TabIndex = 3;
            // 
            // lbl_info_message
            // 
            this.lbl_info_message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_info_message.AutoSize = true;
            this.lbl_info_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_info_message.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_info_message.Location = new System.Drawing.Point(97, 542);
            this.lbl_info_message.Name = "lbl_info_message";
            this.lbl_info_message.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lbl_info_message.Size = new System.Drawing.Size(809, 38);
            this.lbl_info_message.TabIndex = 9;
            this.lbl_info_message.Text = "Wyświetlono X wyników! Kliknij dwukrotnie wiersz, aby zobaczyć szczegóły.";
            // 
            // btn_search_users
            // 
            this.btn_search_users.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search_users.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_search_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_search_users.Location = new System.Drawing.Point(101, 79);
            this.btn_search_users.Name = "btn_search_users";
            this.btn_search_users.Size = new System.Drawing.Size(954, 39);
            this.btn_search_users.TabIndex = 10;
            this.btn_search_users.Text = "WYŚWIETL LISTĘ ZAPOMNIANYCH UŻYTKOWNIKÓW";
            this.btn_search_users.UseVisualStyleBackColor = false;
            // 
            // UCFindForgottenUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btn_search_users);
            this.Controls.Add(this.lbl_info_message);
            this.Controls.Add(this.dgv_forgotten_users);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCFindForgottenUsers";
            this.Size = new System.Drawing.Size(1133, 626);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forgotten_users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_find_forgotten_users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_forgotten_users;
        private System.Windows.Forms.Label lbl_info_message;
        private System.Windows.Forms.Button btn_search_users;
    }
}
