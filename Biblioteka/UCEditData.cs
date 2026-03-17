using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Biblioteka
{
    public partial class UCEditData : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;


        public UCEditData()
        {
            InitializeComponent();
        }

        //funkcja, która ładuje dane do pól tekstowych
        public void ZaladujDaneDoEdycji(int userId)
        {

        }
    }
}