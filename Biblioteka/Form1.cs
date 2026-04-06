using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class Form1 : Form
    {
        UCAddUsers ucAddUsers = new UCAddUsers();
        UCShowUsers ucShowUsers = new UCShowUsers();
        UCEditData ucEditData = new UCEditData();
        UCShowUsersData ucShowUsersData = new UCShowUsersData();
        UCForgetUsers ucForgetUsers = new UCForgetUsers();
        UCFindForgottenUsers ucFindForgottenUsers = new UCFindForgottenUsers();
        UCManagePermissions ucManagePermissions = new UCManagePermissions();
        UCUsersWithPermission ucUsersWithPermission = new UCUsersWithPermission();
        UCEditUserPermissions ucEditUserPermissions = new UCEditUserPermissions();

        public Form1()
        {
            InitializeComponent();
        }

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
            UCShowUsers nowaLista = new UCShowUsers();
            PokazWidokZeStanem(nowaLista);
        }

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

        public void PokazEdycjeUprawnien(int userId, string userName)
        {
            ucEditUserPermissions = new UCEditUserPermissions();
            ucEditUserPermissions.ZaladujDaneUzytkownika(userId, userName);
            PokazWidokZeStanem(ucEditUserPermissions);
        }

        public void PowrotDoListyUprawnien()
        {
            PokazWidokZeStanem(ucManagePermissions);
        }


    }
}
