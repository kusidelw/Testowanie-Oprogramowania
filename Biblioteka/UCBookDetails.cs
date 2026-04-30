using System;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCBookDetails : UserControl
    {
        private readonly int _ksiazkaId;

        public UCBookDetails(int ksiazkaId)
        {
            InitializeComponent();
            _ksiazkaId = ksiazkaId;
        }

        private void btn_wroc_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm is Form1 mainForm)
                mainForm.WrocDoListyKsiazek();
        }
    }
}
