namespace Biblioteka
{
    partial class UCManagePermissions
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
            this.dgv_permissions = new System.Windows.Forms.DataGridView();
            this.lbl_search = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search_permission = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permissions)).BeginInit();
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
            this.lbl_title.Text = "ZARZĄDZANIE ROLAMI";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_permissions
            // 
            this.dgv_permissions.AllowUserToAddRows = false;
            this.dgv_permissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_permissions.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_permissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_permissions.Location = new System.Drawing.Point(23, 152);
            this.dgv_permissions.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_permissions.Name = "dgv_permissions";
            this.dgv_permissions.ReadOnly = true;
            this.dgv_permissions.RowHeadersVisible = false;
            this.dgv_permissions.RowHeadersWidth = 51;
            this.dgv_permissions.RowTemplate.Height = 24;
            this.dgv_permissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_permissions.Size = new System.Drawing.Size(425, 342);
            this.dgv_permissions.TabIndex = 21;
            this.dgv_permissions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_permissions_CellDoubleClick);
            // 
            // lbl_search
            // 
            this.lbl_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_search.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_search.Location = new System.Drawing.Point(18, 64);
            this.lbl_search.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(426, 33);
            this.lbl_search.TabIndex = 20;
            this.lbl_search.Text = "Szukaj roli: ";
            this.lbl_search.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_search
            // 
            this.btn_search.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_search.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_search.Location = new System.Drawing.Point(478, 104);
            this.btn_search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(178, 36);
            this.btn_search.TabIndex = 19;
            this.btn_search.Text = "Szukaj";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search_permission
            // 
            this.txt_search_permission.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_search_permission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_search_permission.Location = new System.Drawing.Point(22, 109);
            this.txt_search_permission.Margin = new System.Windows.Forms.Padding(2);
            this.txt_search_permission.Name = "txt_search_permission";
            this.txt_search_permission.Size = new System.Drawing.Size(426, 26);
            this.txt_search_permission.TabIndex = 18;
            this.txt_search_permission.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_permission_KeyDown);
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
            this.panel1.TabIndex = 17;
            // 
            // lbl_count
            // 
            this.lbl_count.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_count.Location = new System.Drawing.Point(20, 517);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(107, 17);
            this.lbl_count.TabIndex = 25;
            this.lbl_count.Text = "Znaleziono: 0";
            this.lbl_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCManagePermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.dgv_permissions);
            this.Controls.Add(this.lbl_search);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search_permission);
            this.Controls.Add(this.panel1);
            this.Name = "UCManagePermissions";
            this.Size = new System.Drawing.Size(888, 556);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permissions)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.DataGridView dgv_permissions;
        private System.Windows.Forms.Label lbl_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_search_permission;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_count;
    }
}
