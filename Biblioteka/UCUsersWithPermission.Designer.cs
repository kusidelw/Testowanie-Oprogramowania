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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_count = new System.Windows.Forms.Label();
            this.btn_Add_Role = new System.Windows.Forms.Button();
            this.btn_Remove_Role = new System.Windows.Forms.Button();
            this.chLB_User_With_Role = new System.Windows.Forms.CheckedListBox();
            this.chbl_UserWIthout_role = new System.Windows.Forms.CheckedListBox();
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
            this.lbl_title.Text = "UŻYTKOWNICY O PODANEJ ROLI: ";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 46);
            this.panel1.TabIndex = 25;
            // 
            // lbl_count
            // 
            this.lbl_count.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_count.Location = new System.Drawing.Point(22, 511);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(176, 17);
            this.lbl_count.TabIndex = 30;
            this.lbl_count.Text = "Liczba: 0 użytkowników";
            this.lbl_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Add_Role
            // 
            this.btn_Add_Role.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Add_Role.BackColor = System.Drawing.Color.LightBlue;
            this.btn_Add_Role.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Add_Role.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Add_Role.Location = new System.Drawing.Point(442, 471);
            this.btn_Add_Role.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Add_Role.Name = "btn_Add_Role";
            this.btn_Add_Role.Size = new System.Drawing.Size(187, 25);
            this.btn_Add_Role.TabIndex = 40;
            this.btn_Add_Role.Text = "Przypisz zaznaczonym";
            this.btn_Add_Role.UseVisualStyleBackColor = false;
            this.btn_Add_Role.Click += new System.EventHandler(this.btn_Add_Role_Click);
            // 
            // btn_Remove_Role
            // 
            this.btn_Remove_Role.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Remove_Role.BackColor = System.Drawing.Color.LightBlue;
            this.btn_Remove_Role.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Remove_Role.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Remove_Role.Location = new System.Drawing.Point(25, 471);
            this.btn_Remove_Role.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Remove_Role.Name = "btn_Remove_Role";
            this.btn_Remove_Role.Size = new System.Drawing.Size(187, 25);
            this.btn_Remove_Role.TabIndex = 41;
            this.btn_Remove_Role.Text = "Odbierz zaznaczonym";
            this.btn_Remove_Role.UseVisualStyleBackColor = false;
            this.btn_Remove_Role.Click += new System.EventHandler(this.btn_Remove_Role_Click);
            // 
            // chLB_User_With_Role
            // 
            this.chLB_User_With_Role.FormattingEnabled = true;
            this.chLB_User_With_Role.Location = new System.Drawing.Point(25, 61);
            this.chLB_User_With_Role.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chLB_User_With_Role.Name = "chLB_User_With_Role";
            this.chLB_User_With_Role.Size = new System.Drawing.Size(397, 394);
            this.chLB_User_With_Role.TabIndex = 42;
            // 
            // chbl_UserWIthout_role
            // 
            this.chbl_UserWIthout_role.FormattingEnabled = true;
            this.chbl_UserWIthout_role.Location = new System.Drawing.Point(442, 61);
            this.chbl_UserWIthout_role.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chbl_UserWIthout_role.Name = "chbl_UserWIthout_role";
            this.chbl_UserWIthout_role.Size = new System.Drawing.Size(428, 394);
            this.chbl_UserWIthout_role.TabIndex = 43;
            // 
            // UCUsersWithPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.chbl_UserWIthout_role);
            this.Controls.Add(this.chLB_User_With_Role);
            this.Controls.Add(this.btn_Remove_Role);
            this.Controls.Add(this.btn_Add_Role);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.panel1);
            this.Name = "UCUsersWithPermission";
            this.Size = new System.Drawing.Size(888, 556);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Button btn_Add_Role;
        private System.Windows.Forms.Button btn_Remove_Role;
        private System.Windows.Forms.CheckedListBox chLB_User_With_Role;
        private System.Windows.Forms.CheckedListBox chbl_UserWIthout_role;
    }
}
