namespace Biblioteka
{
    partial class UCUsersWithPermission
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_title = new System.Windows.Forms.Label();
            this.dgv_users = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_title.Location = new System.Drawing.Point(0, 6);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(888, 26);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "UŻYTKOWNICY Z UPRAWNIENIEM:";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_users
            // 
            this.dgv_users.AllowUserToAddRows = false;
            this.dgv_users.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_users.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_users.Location = new System.Drawing.Point(25, 66);
            this.dgv_users.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_users.Name = "dgv_users";
            this.dgv_users.ReadOnly = true;
            this.dgv_users.RowHeadersVisible = false;
            this.dgv_users.RowHeadersWidth = 51;
            this.dgv_users.RowTemplate.Height = 24;
            this.dgv_users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_users.Size = new System.Drawing.Size(841, 204);
            this.dgv_users.TabIndex = 29;
            this.dgv_users.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_users_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 46);
            this.panel1.TabIndex = 25;
            // 
            // lbl_count
            // 
            this.lbl_count.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_count.Location = new System.Drawing.Point(22, 291);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(176, 17);
            this.lbl_count.TabIndex = 30;
            this.lbl_count.Text = "Liczba: 0 użytkowników";
            this.lbl_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCUsersWithPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.dgv_users);
            this.Controls.Add(this.panel1);
            this.Name = "UCUsersWithPermission";
            this.Size = new System.Drawing.Size(888, 556);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.DataGridView dgv_users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_count;
    }
}
