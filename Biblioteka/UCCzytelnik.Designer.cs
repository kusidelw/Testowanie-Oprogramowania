namespace Biblioteka
{
    partial class UCCzytelnik
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lbl_info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lbl_info.ForeColor = System.Drawing.Color.Gray;
            this.lbl_info.Location = new System.Drawing.Point(30, 30);
            this.lbl_info.Text = "Sekcja Czytelnika — do implementacji";
            // 
            // UCCzytelnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_info);
            this.Name = "UCCzytelnik";
            this.Size = new System.Drawing.Size(700, 400);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lbl_info;
    }
}
