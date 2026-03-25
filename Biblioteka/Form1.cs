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
        UCLogin ucLogin = new UCLogin();
        UCPasswordRecovery ucPasswordRecovery = new UCPasswordRecovery();
        UCChangePassword ucChangePassword = new UCChangePassword();
        UCSetNewPassword ucSetNewPassword = new UCSetNewPassword();
        UCLogout ucLogout = new UCLogout();

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

        private void btn_login_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucLogin);
        }

        private void btn_change_password_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucChangePassword);
        }

        private void btn_password_recovery_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucPasswordRecovery);
        }

        private void btn_set_new_password_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucSetNewPassword);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucLogout);
        }
    }
}
