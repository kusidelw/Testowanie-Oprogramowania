using System;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class Form1 : Form
    {
        // Kontrolki tworzone leniwie (tylko gdy potrzebne) lub na żądanie
        private UCAddUsers ucAddUsers;
        private UCShowUsers ucShowUsers;
        private UCEditData ucEditData;
        private UCShowUsersData ucShowUsersData;
        private UCForgetUsers ucForgetUsers;
        private UCFindForgottenUsers ucFindForgottenUsers;
        private UCManagePermissions ucManagePermissions;
        private UCUsersWithPermission ucUsersWithPermission;

        public Form1()
        {
            InitializeComponent();

            // Inicjalizacja po InitializeComponent — bezpieczna kolejność
            ucAddUsers = new UCAddUsers();
            ucShowUsers = new UCShowUsers();
            ucEditData = new UCEditData();
            ucShowUsersData = new UCShowUsersData();
            ucForgetUsers = new UCForgetUsers();
            ucFindForgottenUsers = new UCFindForgottenUsers();
            ucManagePermissions = new UCManagePermissions();
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

        private void btn_show_users_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucShowUsers);
        }

        private void btn_forget_users_Click(object sender, EventArgs e)
        {
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
            // Program.cs otworzy świeży login1
            this.Close();
        }
    }
}