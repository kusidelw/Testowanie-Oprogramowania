namespace Biblioteka
{
    partial class UCEditUserPermissions
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_user_name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_instruction = new System.Windows.Forms.Label();
            this.clb_permissions = new System.Windows.Forms.CheckedListBox();
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
            this.lbl_title.Text = "EDYCJA UPRAWNIEŃ UŻYTKOWNIKA";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_cancel.BackColor = System.Drawing.Color.LightBlue;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_cancel.Location = new System.Drawing.Point(292, 369);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(102, 25);
            this.btn_cancel.TabIndex = 32;
            this.btn_cancel.Text = "Anuluj";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_save.BackColor = System.Drawing.Color.LightBlue;
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_save.Location = new System.Drawing.Point(30, 369);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(103, 25);
            this.btn_save.TabIndex = 31;
            this.btn_save.Text = "Zapisz";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_user_name
            // 
            this.lbl_user_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_user_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_user_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_user_name.Location = new System.Drawing.Point(26, 66);
            this.lbl_user_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_user_name.Name = "lbl_user_name";
            this.lbl_user_name.Size = new System.Drawing.Size(541, 33);
            this.lbl_user_name.TabIndex = 29;
            this.lbl_user_name.Text = "Użytkownik: ...";
            this.lbl_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel1.TabIndex = 26;
            // 
            // lbl_instruction
            // 
            this.lbl_instruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_instruction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_instruction.Location = new System.Drawing.Point(15, 110);
            this.lbl_instruction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_instruction.Name = "lbl_instruction";
            this.lbl_instruction.Size = new System.Drawing.Size(0, 33);
            this.lbl_instruction.TabIndex = 35;
            this.lbl_instruction.Text = "Zaznacz uprawnienia: ";
            this.lbl_instruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clb_permissions
            // 
            this.clb_permissions.CheckOnClick = true;
            this.clb_permissions.FormattingEnabled = true;
            this.clb_permissions.Location = new System.Drawing.Point(30, 160);
            this.clb_permissions.Name = "clb_permissions";
            this.clb_permissions.Size = new System.Drawing.Size(364, 184);
            this.clb_permissions.TabIndex = 36;
            // 
            // UCEditUserPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.clb_permissions);
            this.Controls.Add(this.lbl_instruction);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_user_name);
            this.Controls.Add(this.panel1);
            this.Name = "UCEditUserPermissions";
            this.Size = new System.Drawing.Size(888, 556);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_user_name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_instruction;
        private System.Windows.Forms.CheckedListBox clb_permissions;
    }
}
