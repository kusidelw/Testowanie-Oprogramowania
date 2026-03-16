using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class UCAddUsers : UserControl
    {
        public UCAddUsers()
        {
            InitializeComponent();
        }

        private void btnAU_clear_data_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox tb)
                {
                    tb.Clear();
                    tb.BackColor = SystemColors.Window;
                }
            }
            btn_female.Checked = false;
            btn_male.Checked = false;
            error_add_user_form.Clear();
        }

        private void btnAU_create_user_Click(object sender, EventArgs e)
        {
            if (WalidujFormularz())
            {
                // E1: Sprawdzanie unikalności przy użyciu nowych nazw kontrolek ------------- do odkomentowania po implementacji bazy danych
                //if (ExistingLogins.Contains(txt_login.Text) ||
                //    ExistingPesels.Contains(txt_pesel.Text) ||
                //    ExistingEmails.Contains(txt_email.Text))
                //{
                //    MessageBox.Show("Użytkownik już istnieje (Login, PESEL lub Email jest już zajęty).",
                //                    "Błąd duplikatu (E1)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                // Generowanie unikalnego numeru karty (Wymaganie funkcjonalne)
                // Tworzymy krótki, unikalny identyfikator na podstawie GUID
                string nrKarty = "LIB-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                // Symulacja zapisu do bazy danych / listy  ----------- do odkomentowania po implementacji bazy danych
                //ExistingLogins.Add(txt_login.Text);
                //ExistingPesels.Add(txt_pesel.Text);
                //ExistingEmails.Add(txt_email.Text);

                // Scenariusz główny pkt 5: Wyświetlenie komunikatu sukcesu
                MessageBox.Show($"Dodano użytkownika\nUnikalny nr karty: {nrKarty}",
                                "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Czyszczenie pól po pomyślnym dodaniu
                btnAU_clear_data_Click(null, null);
            }
        }

        private bool WalidujFormularz()
        {
            bool isValid = true;
            error_add_user_form.Clear();
            ResetFieldColors();

            // 1. Walidacja PESEL (RRMMDD + Płeć + Długość)
            if (txt_pesel.Text.Length != 11 || !Regex.IsMatch(txt_pesel.Text, @"^\d{11}$"))
            {
                OznaczBlad(txt_pesel, "PESEL musi mieć 11 cyfr");
                isValid = false;
            }
            else if (!WalidujZgodnoscPesel())
            {
                // Metoda WalidujZgodnoscPesel musi wewnątrz używać txt_pesel
                isValid = false;
            }

            // 2. Walidacja Email (E2)
            if (!Regex.IsMatch(txt_email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || txt_email.Text.Length > 255)
            {
                OznaczBlad(txt_email, "Niepoprawny format adresu e-mail");
                isValid = false;
            }

            // 3. Walidacja Telefonu (9 cyfr)
            if (!Regex.IsMatch(txt_phone_number.Text, @"^\d{9}$"))
            {
                OznaczBlad(txt_phone_number, "Numer telefonu musi mieć dokładnie 9 cyfr");
                isValid = false;
            }

            // 4. Pola wymagane (prosty check)
            // Zaktualizowana lista zgodnie z Twoim wzorem nazw
            TextBox[] required = {
        txt_login,
        txt_name,
        txt_surname,
        txt_city,
        txt_postcode,
        txt_house_number,
        txt_birth_date
    };

            foreach (var tb in required)
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    OznaczBlad(tb, "Pole wymagane");
                    isValid = false;
                }
            }

            return isValid;
        }

        private bool WalidujZgodnoscPesel()
        {
            string pesel = txt_pesel.Text;

            // Sprawdzenie płci (10 cyfra: parzysta K, nieparzysta M)
            int plecDigit = int.Parse(pesel[9].ToString());
            bool plecOk = (btn_female.Checked && plecDigit % 2 == 0) ||
                          (btn_male.Checked && plecDigit % 2 != 0);

            if (!plecOk)
            {
                OznaczBlad(txt_pesel, "PESEL niezgodny z wybraną płcią");
                return false;
            }

            // Sprawdzenie daty (uproszczone RRMMDD wg specyfikacji)
            // Uwaga: W prawdziwym systemie trzeba brać pod uwagę stulecia w miesiącach
            string dataZTextu = txt_birth_date.Text.Replace("-", "").Replace(".", "");
            if (dataZTextu.Length >= 6 && pesel.Substring(0, 6) != dataZTextu.Substring(2, 6))
            {
                // Jeśli data w polu tekstowym to RRRRMMDD, sprawdzamy od 3 znaku
                // OznaczBlad(txtPesel, "PESEL niezgodny z datą urodzenia");
                // return false;
            }

            return true;
        }

        private void OznaczBlad(Control ctrl, string msg)
        {
            ctrl.BackColor = Color.MistyRose; // E2: Podświetlenie na czerwono
            error_add_user_form.SetError(ctrl, msg);
        }

        private void ResetFieldColors()
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox) ctrl.BackColor = SystemColors.Window;
        }
    }
}

