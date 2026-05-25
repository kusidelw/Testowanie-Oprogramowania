using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Biblioteka
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                List<string> role;
                int userId;

                using (login1 loginForm = new login1())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                        break; // Zamknięcie okna logowania = koniec aplikacji

                    userId = loginForm.GetLoggedUserId();
                    role = loginForm.ZalogowaneRole;
                }

                using (Biblioteka mainForm = new Biblioteka())
                {
                    mainForm.SetSession(userId, role);
                    mainForm.ShowDialog();
                    // zamknięcie okna (wylogowanie) → pętla → nowy login1
                }
            }
        }
    }
}