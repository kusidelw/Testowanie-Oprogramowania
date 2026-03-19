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
            ucEditData.ZaladujDaneDoEdycji(userId); 
            PokazWidokZeStanem(ucEditData);         
        }

        public void PokazKarteUzytkownika(int userId)
        {
            ucShowUsersData.ZaladujDaneUzytkownika(userId);
            PokazWidokZeStanem(ucShowUsersData);
        }
        public void WrocDoWyszukiwarki()
        {
            PokazWidokZeStanem(ucShowUsers);
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

    }
}
