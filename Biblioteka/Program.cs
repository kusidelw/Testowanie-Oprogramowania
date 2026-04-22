using System;
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
                int? loggedUserId = null;
                string rola;

                using (login1 loginForm = new login1())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                        break; // Zamknięcie okna logowania = koniec aplikacji

                    loggedUserId = loginForm.GetLoggedUserId();
                    rola = loginForm.ZalogowanaRola;
                }

                Form mainForm;
                switch (rola)
                {
                    case "Administrator": mainForm = new Form1(); break;
                    case "Bibliotekarz": mainForm = new FormLiblarian(); break;
                    case "Manager": mainForm = new FormMenager(); break;
                    case "Czytelnik": mainForm = new FormReader(); break;
                    default: continue; // nieznana rola → wróć do logowania
                }

                // Przekazanie ID zalogowanego użytkownika do głównego formularza
                if (mainForm is Form1 f1)
                    f1.SetCurrentUser(loggedUserId);

                using (mainForm)
                {
                    mainForm.ShowDialog();
                    // zamknięcie okna (wylogowanie) → pętla → nowy login1
                }
            }
        }
    }
}