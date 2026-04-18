using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Używamy using, aby poprawnie zwolnić pamięć po login1
            using (login1 frm = new login1())
            {
                // Jeśli logowanie zakończyło się sukcesem (DialogResult.OK)
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // TO JEST KLUCZ: Uruchomienie Form1
                    Application.Run(new Form1());
                }
            }
        }
    }
}
