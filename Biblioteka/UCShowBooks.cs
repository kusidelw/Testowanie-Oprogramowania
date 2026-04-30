using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCShowBooks : UserControl
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 1;
        private string searchTytul = "";
        private string searchAutor = "";

        public UCShowBooks()
        {
            InitializeComponent();
            KonfigurujDGV();
            this.VisibleChanged += (s, e) => { if (this.Visible) WczytajKsiążki(); };
        }

        private void KonfigurujDGV()
        {
            dgv_books_list.ReadOnly = true;
            dgv_books_list.AllowUserToAddRows = false;
            dgv_books_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_books_list.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_books_list.MultiSelect = false;
            dgv_books_list.RowHeadersVisible = false;
        }

        private void WczytajKsiążki()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    // 1. Zliczanie wszystkich wyników pasujących do filtrów
                    string sqlCount = @"
                        SELECT COUNT(*)
                        FROM KatalogKsiazek K
                        WHERE (@Tytul = '' OR K.Tytul LIKE @TytulLike)
                          AND (@Autor = '' OR EXISTS (
                                SELECT 1
                                FROM KsiazkaKatalog_Autorzy KA2
                                JOIN Autorzy A2 ON KA2.AutorID = A2.ID
                                WHERE KA2.KsiazkaID = K.ID
                                  AND (A2.Imie + ' ' + A2.Nazwisko) LIKE @AutorLike
                              ))";

                    int totalRecords;
                    using (SqlCommand cmd = new SqlCommand(sqlCount, conn))
                    {
                        cmd.Parameters.Add("@Tytul",     SqlDbType.NVarChar, 255).Value = searchTytul;
                        cmd.Parameters.Add("@TytulLike", SqlDbType.NVarChar, 257).Value = "%" + searchTytul + "%";
                        cmd.Parameters.Add("@Autor",     SqlDbType.NVarChar, 101).Value = searchAutor;
                        cmd.Parameters.Add("@AutorLike", SqlDbType.NVarChar, 103).Value = "%" + searchAutor + "%";
                        totalRecords = (int)cmd.ExecuteScalar();
                    }

                    // Brak wyników przy aktywnych filtrach — informacja dla użytkownika
                    if (totalRecords == 0 && (!string.IsNullOrEmpty(searchTytul) || !string.IsNullOrEmpty(searchAutor)))
                    {
                        MessageBox.Show(
                            "Nie znaleziono książek spełniających podane kryteria.",
                            "Brak wyników",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        if (dgv_books_list.DataSource is DataTable dt)
                            dt.Clear();

                        lbl_page_info.Text = "Strona: 1 / 1";
                        AktualizujPrzyciskiStron();
                        return;
                    }

                    // 2. Obliczanie i korygowanie numeru strony
                    totalPages = Math.Max(1, (int)Math.Ceiling((double)totalRecords / pageSize));
                    if (currentPage > totalPages) currentPage = totalPages;
                    lbl_page_info.Text = $"Strona: {currentPage} / {totalPages}";

                    // 3. Pobranie strony danych — autorzy łączeni przez FOR XML PATH z obsługą znaków specjalnych
                    string sqlData = @"
                        SELECT
                            K.ID,
                            K.Tytul                                                                   AS [Tytuł],
                            ISNULL(G.Nazwa, '')                                                       AS [Gatunek],
                            ISNULL(W.Nazwa, '')                                                       AS [Wydawnictwo],
                            ISNULL((SELECT STUFF((
                                SELECT ', ' + A2.Imie + ' ' + A2.Nazwisko
                                FROM KsiazkaKatalog_Autorzy KA2
                                JOIN Autorzy A2 ON KA2.AutorID = A2.ID
                                WHERE KA2.KsiazkaID = K.ID
                                ORDER BY A2.Nazwisko, A2.Imie
                                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')), '') AS [Autorzy],
                            K.RokWydania                                                              AS [Rok wydania],
                            (SELECT COUNT(*)
                             FROM Egzemplarze E
                             WHERE E.KsiazkaID = K.ID)                                               AS [Egzemplarze],
                            (SELECT COUNT(*)
                             FROM Egzemplarze E
                             WHERE E.KsiazkaID = K.ID
                               AND E.Status = 'Dostepna')                                            AS [Dostępne]
                        FROM KatalogKsiazek K
                        LEFT JOIN Gatunki G     ON K.GatunekID     = G.ID
                        LEFT JOIN Wydawnictwa W ON K.WydawnictwoID = W.ID
                        WHERE (@Tytul = '' OR K.Tytul LIKE @TytulLike)
                          AND (@Autor = '' OR EXISTS (
                                SELECT 1
                                FROM KsiazkaKatalog_Autorzy KA2
                                JOIN Autorzy A2 ON KA2.AutorID = A2.ID
                                WHERE KA2.KsiazkaID = K.ID
                                  AND (A2.Imie + ' ' + A2.Nazwisko) LIKE @AutorLike
                              ))
                        ORDER BY K.ID
                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    using (SqlCommand cmd = new SqlCommand(sqlData, conn))
                    {
                        cmd.Parameters.Add("@Tytul",     SqlDbType.NVarChar, 255).Value = searchTytul;
                        cmd.Parameters.Add("@TytulLike", SqlDbType.NVarChar, 257).Value = "%" + searchTytul + "%";
                        cmd.Parameters.Add("@Autor",     SqlDbType.NVarChar, 101).Value = searchAutor;
                        cmd.Parameters.Add("@AutorLike", SqlDbType.NVarChar, 103).Value = "%" + searchAutor + "%";
                        cmd.Parameters.Add("@Offset",   SqlDbType.Int).Value = (currentPage - 1) * pageSize;
                        cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        dgv_books_list.DataSource = dt;
                    }

                    // Kolumna ID jest ukryta — służy tylko do nawigacji
                    if (dgv_books_list.Columns["ID"] != null)
                        dgv_books_list.Columns["ID"].Visible = false;

                    AktualizujPrzyciskiStron();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Błąd bazy danych: " + ex.Message,
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AktualizujPrzyciskiStron()
        {
            btn_prev_page.Enabled = currentPage > 1;
            btn_next_page.Enabled = currentPage < totalPages;
            btn_details.Enabled   = dgv_books_list.SelectedRows.Count > 0;
        }

        // ── WYSZUKIWANIE ──────────────────────────────────────────────────────────

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchTytul = txt_search_tytul.Text.Trim();
            searchAutor = txt_search_autor.Text.Trim();
            currentPage = 1;
            WczytajKsiążki();
        }

        private void btn_clear_filters_Click(object sender, EventArgs e)
        {
            txt_search_tytul.Clear();
            txt_search_autor.Clear();
            searchTytul = "";
            searchAutor = "";
            currentPage = 1;
            WczytajKsiążki();
        }

        private void txt_search_tytul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search_Click(sender, e);
        }

        private void txt_search_autor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search_Click(sender, e);
        }

        // ── STRONICOWANIE ─────────────────────────────────────────────────────────

        private void btn_prev_page_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                WczytajKsiążki();
            }
        }

        private void btn_next_page_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                WczytajKsiążki();
            }
        }

        // ── SZCZEGÓŁY KSIĄŻKI ─────────────────────────────────────────────────────

        private void btn_details_Click(object sender, EventArgs e)
        {
            if (dgv_books_list.SelectedRows.Count == 0) return;

            int wybraneId = Convert.ToInt32(dgv_books_list.SelectedRows[0].Cells["ID"].Value);
            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
                mainForm.PokazWidokZeStanem(new UCBookDetails(wybraneId));
        }

        private void dgv_books_list_SelectionChanged(object sender, EventArgs e)
        {
            btn_details.Enabled = dgv_books_list.SelectedRows.Count > 0;
        }

        private void dgv_books_list_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btn_details_Click(sender, e);
        }
    }
}
