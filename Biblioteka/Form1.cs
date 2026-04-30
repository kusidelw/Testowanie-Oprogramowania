using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class Form1 : Form
    {
        // ID zalogowanego użytkownika 
        private int? currentUserId;
        private List<string> _role = new List<string>();


        // ── MENU AKORDEONOWE ──────────────────────────────────────────────────────
        private System.Windows.Forms.FlowLayoutPanel menuAkordeon;
        private System.Windows.Forms.Button btnKatAdministrator;
        private System.Windows.Forms.Button btnKatManager;
        private System.Windows.Forms.Button btnKatBibliotekarz;
        private System.Windows.Forms.Button btnKatCzytelnik;
        private System.Windows.Forms.FlowLayoutPanel panelAdmin;
        private System.Windows.Forms.FlowLayoutPanel panelManager;
        private System.Windows.Forms.FlowLayoutPanel panelBibliotekarz;
        private System.Windows.Forms.FlowLayoutPanel panelCzytelnik;

        // Kontrolki tworzone leniwie (tylko gdy potrzebne) lub na żądanie
        private UCAddUsers ucAddUsers;
        private UCAddBook ucAddBook;
        private UCShowUsers ucShowUsers;
        private UCEditData ucEditData;
        private UCShowUsersData ucShowUsersData;
        private UCForgetUsers ucForgetUsers;
        private UCFindForgottenUsers ucFindForgottenUsers;
        private UCManagePermissions ucManagePermissions;
        private UCUsersWithPermission ucUsersWithPermission;
        private UCShowBooks ucShowBooks;
        private UCBorrowBook ucBorrowBook;
        private UCReturnBook ucReturnBook;
        private UCCzytelnik ucCzytelnik;
        private UCManager ucManager;

        public Form1()
        {

            InitializeComponent();

            // Inicjalizacja po InitializeComponent — bezpieczna kolejność
            ucAddUsers = new UCAddUsers();
            ucAddBook = new UCAddBook();
            ucShowUsers = new UCShowUsers();
            ucEditData = new UCEditData();
            ucShowUsersData = new UCShowUsersData();
            ucForgetUsers = new UCForgetUsers();
            ucFindForgottenUsers = new UCFindForgottenUsers();
            ucManagePermissions = new UCManagePermissions();
            ucShowBooks = new UCShowBooks();
            ucBorrowBook = new UCBorrowBook();
            ucReturnBook = new UCReturnBook();
            ucCzytelnik  = new UCCzytelnik();
            ucManager    = new UCManager();

            BudujMenuAkordeonowe();
        }

        // ── MENU AKORDEONOWE — BUDOWANIE ──────────────────────────────────────────

        private void BudujMenuAkordeonowe()
        {
            const int szerokoscMenu = 300;
            var kolorNaglowka = System.Drawing.Color.FromArgb(30, 90, 150);
            var kolorElementu = System.Drawing.Color.FromArgb(50, 120, 180);
            var kolorTekstu   = System.Drawing.Color.White;

            // ── 1. Główny FlowLayoutPanel ──────────────────────────────────────────
            menuAkordeon = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock          = DockStyle.Left,
                FlowDirection = FlowDirection.TopDown,
                WrapContents  = false,
                AutoScroll    = true,
                Width         = szerokoscMenu,
                BackColor     = panel1.BackColor
            };

            // ── Lokalne funkcje pomocnicze ─────────────────────────────────────────

            Button UtworzNaglowek(string tekst)
            {
                var btn = new Button
                {
                    Text      = "▶  " + tekst,
                    Width     = szerokoscMenu,
                    Height    = 44,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = kolorNaglowka,
                    ForeColor = kolorTekstu,
                    Font      = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold),
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                    Padding   = new Padding(10, 0, 0, 0),
                    Cursor    = Cursors.Hand,
                    Margin    = new Padding(0, 2, 0, 0)
                };
                btn.FlatAppearance.BorderSize = 0;
                return btn;
            }

            System.Windows.Forms.FlowLayoutPanel UtworzPodPanel()
            {
                return new System.Windows.Forms.FlowLayoutPanel
                {
                    Width        = szerokoscMenu,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    AutoSize     = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Visible      = false,
                    BackColor    = kolorElementu,
                    Margin       = new Padding(0)
                };
            }

            void StylujPrzyciskMenu(Button btn)
            {
                btn.Dock      = DockStyle.None;
                btn.Width     = szerokoscMenu;
                btn.Height    = 40;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = kolorElementu;
                btn.ForeColor = kolorTekstu;
                btn.Font      = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Padding   = new Padding(22, 0, 0, 0);
                btn.Margin    = new Padding(0, 0, 0, 1);
                btn.Cursor    = Cursors.Hand;
            }

            void PodepnijZdarzenie(Button naglowek, System.Windows.Forms.FlowLayoutPanel podPanel, string nazwaKategorii)
            {
                naglowek.Click += (s, e) =>
                {
                    podPanel.Visible = !podPanel.Visible;
                    naglowek.Text = (podPanel.Visible ? "▼  " : "▶  ") + nazwaKategorii;
                };
            }

            // ── Wstrzymanie przeliczeń layoutu na czas budowania ──────────────────
            this.SuspendLayout();
            menuAkordeon.SuspendLayout();

            // ── 4a. ADMINISTRATOR ─────────────────────────────────────────────────
            // Podmień nazwy przycisków na dokładne nazwy z Designera
            btnKatAdministrator = UtworzNaglowek("Administrator");
            panelAdmin = UtworzPodPanel();
            panelAdmin.SuspendLayout();
            foreach (var btn in new[] { btn_add_user, btn_show_users, btn_forget_users, btn_find_forgotten_users, btn_menage_password, btn_manage_permissions })
            {
                StylujPrzyciskMenu(btn);
                panelAdmin.Controls.Add(btn);
            }
            panelAdmin.ResumeLayout(false);

            // ── 4b. BIBLIOTEKARZ ──────────────────────────────────────────────────
            btnKatBibliotekarz = UtworzNaglowek("Bibliotekarz");
            panelBibliotekarz = UtworzPodPanel();
            panelBibliotekarz.SuspendLayout();
            foreach (var btn in new[] { btn_show_books, btn_add_book, btn_borrow_book, btn_return_book })
            {
                StylujPrzyciskMenu(btn);
                panelBibliotekarz.Controls.Add(btn);
            }
            panelBibliotekarz.ResumeLayout(false);

            // ── 4c. CZYTELNIK — przykładowy przycisk + puste UC ───────────────────
            btnKatCzytelnik = UtworzNaglowek("Czytelnik");
            panelCzytelnik = UtworzPodPanel();
            panelCzytelnik.SuspendLayout();
            var btnCzytelnikDemo = new Button { Text = "Przykładowy przycisk" };
            StylujPrzyciskMenu(btnCzytelnikDemo);
            btnCzytelnikDemo.Click += (s, e) => PokazWidokZeStanem(ucCzytelnik);
            panelCzytelnik.Controls.Add(btnCzytelnikDemo);
            panelCzytelnik.ResumeLayout(false);

            // ── 4d. MANAGER — przykładowy przycisk + puste UC ────────────────────
            btnKatManager = UtworzNaglowek("Manager");
            panelManager = UtworzPodPanel();
            panelManager.SuspendLayout();
            var btnManagerDemo = new Button { Text = "Przykładowy przycisk" };
            StylujPrzyciskMenu(btnManagerDemo);
            btnManagerDemo.Click += (s, e) => PokazWidokZeStanem(ucManager);
            panelManager.Controls.Add(btnManagerDemo);
            panelManager.ResumeLayout(false);

            // ── 5. Zdarzenia przełączania sekcji ──────────────────────────────────
            PodepnijZdarzenie(btnKatAdministrator, panelAdmin,        "Administrator");
            PodepnijZdarzenie(btnKatBibliotekarz,  panelBibliotekarz, "Bibliotekarz");
            PodepnijZdarzenie(btnKatCzytelnik,     panelCzytelnik,    "Czytelnik");
            PodepnijZdarzenie(btnKatManager,       panelManager,      "Manager");

            // ── Przycisk wylogowania — zawsze widoczny, poza sekcjami ─────────────
            btn_logout.Dock      = DockStyle.None;
            btn_logout.Width     = szerokoscMenu;
            btn_logout.Height    = 44;
            btn_logout.Margin    = new Padding(0, 8, 0, 0);
            btn_logout.FlatStyle = FlatStyle.Flat;
            btn_logout.FlatAppearance.BorderSize = 0;

            // ── 6. Złożenie FlowLayoutPanel w kolejności sekcji ───────────────────
            menuAkordeon.Controls.Add(btnKatAdministrator);
            menuAkordeon.Controls.Add(panelAdmin);
            menuAkordeon.Controls.Add(btnKatBibliotekarz);
            menuAkordeon.Controls.Add(panelBibliotekarz);
            menuAkordeon.Controls.Add(btnKatCzytelnik);
            menuAkordeon.Controls.Add(panelCzytelnik);
            menuAkordeon.Controls.Add(btnKatManager);
            menuAkordeon.Controls.Add(panelManager);
            menuAkordeon.Controls.Add(btn_logout);

            // ── 7. Podmiana starego panelu ────────────────────────────────────────
            panel1.Visible = false;
            this.Controls.Add(menuAkordeon);

            menuAkordeon.ResumeLayout(false);
            this.ResumeLayout(true);
        }

        // Synchronizuje tekst strzałki nagłówka z aktualnym stanem widoczności pod-panelu
        private void UstawSekcje(Button naglowek, System.Windows.Forms.FlowLayoutPanel podPanel, bool widoczna, string nazwaKategorii)
        {
            naglowek.Visible = widoczna;
            if (!widoczna)
                podPanel.Visible = false;
            naglowek.Text = (podPanel.Visible ? "▼  " : "▶  ") + nazwaKategorii;
        }

        // ── NAWIGACJA ─────────────────────────────────────────────────────────────

        public void PokazWidokZeStanem(UserControl widok)
        {
            MainPanel.Controls.Clear();
            widok.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(widok);
            MainPanel.Focus();
        }

        public void PowrotDoMenuGlownego()
        {
            MainPanel.Controls.Clear();
        }

        // ── PRZYCISKI MENU ────────────────────────────────────────────────────────

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucAddUsers);
        }

        private void btn_add_book_Click(object sender, EventArgs e)
        {
            if (ucAddBook != null)
                ucAddBook.CurrentUserId = currentUserId;

            PokazWidokZeStanem(ucAddBook);
        }

        private void btn_show_books_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucShowBooks);
        }

        private void btn_borrow_book_Click(object sender, EventArgs e)
        {
            if (ucBorrowBook != null)
                ucBorrowBook.CurrentUserId = currentUserId;

            PokazWidokZeStanem(ucBorrowBook);
        }

        private void btn_return_book_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucReturnBook);
        }

        private void btn_show_users_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucShowUsers);
        }

        private void btn_forget_users_Click(object sender, EventArgs e)
        {
            // Przekaż ID aktualnie zalogowanego użytkownika 
            if (ucForgetUsers != null)
                ucForgetUsers.CurrentUserId = currentUserId;

            PokazWidokZeStanem(ucForgetUsers);
        }

        private void btn_find_forgotten_users_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucFindForgottenUsers);
        }

        private void btn_manage_permissions_Click(object sender, EventArgs e)
        {
            PokazZarzadzanieUprawnieniami();
        }

        private void btn_menage_password_Click(object sender, EventArgs e)
        {
            // Nowa instancja przy każdym otwarciu — czysty stan (brak starych wyników wyszukiwania)
            PokazWidokZeStanem(new UCMenage_password_for_Admin());
        }

        // ── METODY PUBLICZNE (wywoływane przez UserControls) ──────────────────────

        public void PrzejdzDoEdycji(int userId)
        {
            PokazWidokZeStanem(ucEditData);
            ucEditData.ZaladujDaneDoEdycji(userId);
        }

        public void PokazKarteUzytkownika(int userId)
        {
            PokazWidokZeStanem(ucShowUsersData);
            ucShowUsersData.ZaladujDaneUzytkownika(userId);
        }

        public void WrocDoWyszukiwarki()
        {
            // Nowa instancja — odświeżona lista użytkowników
            ucShowUsers = new UCShowUsers();
            PokazWidokZeStanem(ucShowUsers);
        }

        public void WrocDoListyKsiazek()
        {
            PokazWidokZeStanem(ucShowBooks);
        }

        public void PokazZarzadzanieUprawnieniami()
        {
            PokazWidokZeStanem(ucManagePermissions);
        }

        public void PokazUzytkownikowZUprawnieniem(int permissionId, string permissionName)
        {
            ucUsersWithPermission = new UCUsersWithPermission();
            ucUsersWithPermission.ZaladujDane(permissionId, permissionName);
            PokazWidokZeStanem(ucUsersWithPermission);
        }

        public void PowrotDoListyUprawnien()
        {
            PokazWidokZeStanem(ucManagePermissions);
        }

        // Ustawia sesję: ID użytkownika i jego role — ukrywa/pokazuje przyciski menu
        public void SetSession(int userId, List<string> role)
        {
            currentUserId = userId;
            _role = role ?? new List<string>();

            if (ucForgetUsers != null)
                ucForgetUsers.CurrentUserId = currentUserId;

            if (ucAddBook != null)
                ucAddBook.CurrentUserId = currentUserId;

            if (ucBorrowBook != null)
                ucBorrowBook.CurrentUserId = currentUserId;

            AplikujRole();
        }

        // Ukrywa lub pokazuje przyciski menu na podstawie listy ról użytkownika
        private void AplikujRole()
        {
            bool jestAdmin        = _role.Contains("Administrator");
            bool jestBibliotekarz = _role.Contains("Bibliotekarz");
            bool jestManager      = _role.Contains("Manager");
            bool jestCzytelnik    = _role.Contains("Czytelnik");

            // ── Nagłówki kategorii — widoczność pochodna od przycisków w sekcji ──

            // Administrator: zawiera przyciski Admin + Bibliotekarz (btn_add_user, btn_show_users) + Manager (btn_manage_permissions)
            UstawSekcje(btnKatAdministrator, panelAdmin,
                widoczna: jestAdmin || jestBibliotekarz || jestManager,
                nazwaKategorii: "Administrator");

            // Bibliotekarz: btn_show_books widoczne dla wszystkich ról
            UstawSekcje(btnKatBibliotekarz, panelBibliotekarz,
                widoczna: jestAdmin || jestBibliotekarz || jestManager || jestCzytelnik,
                nazwaKategorii: "Bibliotekarz");

            // Czytelnik: placeholder — widoczny tylko dla roli Czytelnik
            UstawSekcje(btnKatCzytelnik, panelCzytelnik,
                widoczna: jestCzytelnik,
                nazwaKategorii: "Czytelnik");

            // Manager: placeholder — widoczny tylko dla roli Manager
            UstawSekcje(btnKatManager, panelManager,
                widoczna: jestManager,
                nazwaKategorii: "Manager");

            // ── Widoczność poszczególnych przycisków (niezmieniona logika RBAC) ──
            btn_add_user.Visible             = jestAdmin || jestBibliotekarz;
            btn_add_book.Visible             = jestAdmin || jestBibliotekarz;
            btn_show_books.Visible           = jestAdmin || jestBibliotekarz || jestManager || jestCzytelnik;
            btn_borrow_book.Visible          = jestAdmin || jestBibliotekarz;
            btn_return_book.Visible          = jestAdmin || jestBibliotekarz;
            btn_show_users.Visible           = jestAdmin || jestBibliotekarz || jestManager;
            btn_forget_users.Visible         = jestAdmin;
            btn_find_forgotten_users.Visible = jestAdmin;
            btn_manage_permissions.Visible   = jestAdmin || jestManager;
            btn_menage_password.Visible      = jestAdmin;
        }

        // ── WYLOGOWANIE — WYLOG_UZY_1 ─────────────────────────────────────────────

        private void btn_logout_Click(object sender, EventArgs e)
        {
            // potwierdzenie
            DialogResult result = MessageBox.Show(
                "Czy na pewno chcesz się wylogować?",
                "Wylogowanie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // rezygnacja
            if (result == DialogResult.No)
                return;

            //  zamknięcie okna
            currentUserId = null;
            this.Close();

        }

    }
}
