namespace Biblioteka
{
    partial class UCShowBooks
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
            this.panel_header = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_filter_tytul = new System.Windows.Forms.Label();
            this.txt_search_tytul = new System.Windows.Forms.TextBox();
            this.lbl_filter_autor = new System.Windows.Forms.Label();
            this.txt_search_autor = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_clear_filters = new System.Windows.Forms.Button();
            this.dgv_books_list = new System.Windows.Forms.DataGridView();
            this.btn_prev_page = new System.Windows.Forms.Button();
            this.lbl_page_info = new System.Windows.Forms.Label();
            this.btn_next_page = new System.Windows.Forms.Button();
            this.btn_details = new System.Windows.Forms.Button();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_books_list)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_header.Controls.Add(this.lbl_title);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(1287, 56);
            this.panel_header.TabIndex = 0;
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbl_title.Location = new System.Drawing.Point(0, 8);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(1287, 32);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "PRZEGLĄD KSIĄŻEK";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_filter_tytul
            // 
            this.lbl_filter_tytul.AutoSize = true;
            this.lbl_filter_tytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_filter_tytul.Location = new System.Drawing.Point(30, 86);
            this.lbl_filter_tytul.Name = "lbl_filter_tytul";
            this.lbl_filter_tytul.Size = new System.Drawing.Size(56, 20);
            this.lbl_filter_tytul.TabIndex = 1;
            this.lbl_filter_tytul.Text = "Tytuł:";
            // 
            // txt_search_tytul
            // 
            this.txt_search_tytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_search_tytul.Location = new System.Drawing.Point(100, 82);
            this.txt_search_tytul.Name = "txt_search_tytul";
            this.txt_search_tytul.Size = new System.Drawing.Size(330, 27);
            this.txt_search_tytul.TabIndex = 2;
            this.txt_search_tytul.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_tytul_KeyDown);
            // 
            // lbl_filter_autor
            // 
            this.lbl_filter_autor.AutoSize = true;
            this.lbl_filter_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_filter_autor.Location = new System.Drawing.Point(460, 86);
            this.lbl_filter_autor.Name = "lbl_filter_autor";
            this.lbl_filter_autor.Size = new System.Drawing.Size(58, 20);
            this.lbl_filter_autor.TabIndex = 3;
            this.lbl_filter_autor.Text = "Autor:";
            // 
            // txt_search_autor
            // 
            this.txt_search_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_search_autor.Location = new System.Drawing.Point(530, 82);
            this.txt_search_autor.Name = "txt_search_autor";
            this.txt_search_autor.Size = new System.Drawing.Size(300, 27);
            this.txt_search_autor.TabIndex = 4;
            this.txt_search_autor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_autor_KeyDown);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.LightBlue;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_search.Location = new System.Drawing.Point(857, 78);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(130, 34);
            this.btn_search.TabIndex = 5;
            this.btn_search.Text = "Szukaj";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_clear_filters
            // 
            this.btn_clear_filters.BackColor = System.Drawing.Color.LightYellow;
            this.btn_clear_filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_clear_filters.Location = new System.Drawing.Point(1002, 78);
            this.btn_clear_filters.Name = "btn_clear_filters";
            this.btn_clear_filters.Size = new System.Drawing.Size(140, 34);
            this.btn_clear_filters.TabIndex = 6;
            this.btn_clear_filters.Text = "Wyczyść filtry";
            this.btn_clear_filters.UseVisualStyleBackColor = false;
            this.btn_clear_filters.Click += new System.EventHandler(this.btn_clear_filters_Click);
            // 
            // dgv_books_list
            // 
            this.dgv_books_list.AllowUserToAddRows = false;
            this.dgv_books_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_books_list.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_books_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_books_list.Location = new System.Drawing.Point(30, 128);
            this.dgv_books_list.Name = "dgv_books_list";
            this.dgv_books_list.ReadOnly = true;
            this.dgv_books_list.RowHeadersVisible = false;
            this.dgv_books_list.RowHeadersWidth = 51;
            this.dgv_books_list.RowTemplate.Height = 24;
            this.dgv_books_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_books_list.Size = new System.Drawing.Size(1227, 408);
            this.dgv_books_list.TabIndex = 7;
            this.dgv_books_list.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_books_list_CellDoubleClick);
            this.dgv_books_list.SelectionChanged += new System.EventHandler(this.dgv_books_list_SelectionChanged);
            // 
            // btn_prev_page
            // 
            this.btn_prev_page.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_prev_page.BackColor = System.Drawing.Color.LightBlue;
            this.btn_prev_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_prev_page.Location = new System.Drawing.Point(436, 554);
            this.btn_prev_page.Name = "btn_prev_page";
            this.btn_prev_page.Size = new System.Drawing.Size(137, 31);
            this.btn_prev_page.TabIndex = 8;
            this.btn_prev_page.Text = "Poprzednia";
            this.btn_prev_page.UseVisualStyleBackColor = false;
            this.btn_prev_page.Click += new System.EventHandler(this.btn_prev_page_Click);
            // 
            // lbl_page_info
            // 
            this.lbl_page_info.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_page_info.AutoSize = true;
            this.lbl_page_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_page_info.Location = new System.Drawing.Point(601, 559);
            this.lbl_page_info.Name = "lbl_page_info";
            this.lbl_page_info.Size = new System.Drawing.Size(100, 20);
            this.lbl_page_info.TabIndex = 9;
            this.lbl_page_info.Text = "Strona: 1 / 1";
            this.lbl_page_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_next_page
            // 
            this.btn_next_page.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_next_page.BackColor = System.Drawing.Color.LightBlue;
            this.btn_next_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_next_page.Location = new System.Drawing.Point(745, 554);
            this.btn_next_page.Name = "btn_next_page";
            this.btn_next_page.Size = new System.Drawing.Size(136, 31);
            this.btn_next_page.TabIndex = 10;
            this.btn_next_page.Text = "Następna";
            this.btn_next_page.UseVisualStyleBackColor = false;
            this.btn_next_page.Click += new System.EventHandler(this.btn_next_page_Click);
            // 
            // btn_details
            // 
            this.btn_details.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_details.BackColor = System.Drawing.Color.LightGreen;
            this.btn_details.Enabled = false;
            this.btn_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_details.Location = new System.Drawing.Point(1100, 554);
            this.btn_details.Name = "btn_details";
            this.btn_details.Size = new System.Drawing.Size(157, 31);
            this.btn_details.TabIndex = 11;
            this.btn_details.Text = "Szczegóły";
            this.btn_details.UseVisualStyleBackColor = false;
            this.btn_details.Click += new System.EventHandler(this.btn_details_Click);
            // 
            // UCShowBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btn_details);
            this.Controls.Add(this.btn_next_page);
            this.Controls.Add(this.lbl_page_info);
            this.Controls.Add(this.btn_prev_page);
            this.Controls.Add(this.dgv_books_list);
            this.Controls.Add(this.btn_clear_filters);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search_autor);
            this.Controls.Add(this.lbl_filter_autor);
            this.Controls.Add(this.txt_search_tytul);
            this.Controls.Add(this.lbl_filter_tytul);
            this.Controls.Add(this.panel_header);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCShowBooks";
            this.Size = new System.Drawing.Size(1287, 656);
            this.panel_header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_books_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_filter_tytul;
        private System.Windows.Forms.TextBox txt_search_tytul;
        private System.Windows.Forms.Label lbl_filter_autor;
        private System.Windows.Forms.TextBox txt_search_autor;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_clear_filters;
        private System.Windows.Forms.DataGridView dgv_books_list;
        private System.Windows.Forms.Button btn_prev_page;
        private System.Windows.Forms.Label lbl_page_info;
        private System.Windows.Forms.Button btn_next_page;
        private System.Windows.Forms.Button btn_details;
    }
}
