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
        UCFindUsers ucFindUsers = new UCFindUsers();
        UCForgetUsers ucForgetUsers = new UCForgetUsers();
        UCFindForgottenUsers ucFindForgottenUsers = new UCFindForgottenUsers();

        public Form1()
        {
            InitializeComponent();
        }

        private void PokazWidokZeStanem(UserControl widok)
        {
            MainPanel.Controls.Clear();
            widok.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(widok);
            
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucAddUsers);
        }

        private void btn_show_users_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucShowUsers);
        }

        private void btn_edit_data_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucEditData);
        }

        private void btn_show_users_data_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucShowUsersData);
        }

        private void btn_find_users_Click(object sender, EventArgs e)
        {
            PokazWidokZeStanem(ucFindUsers);
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
