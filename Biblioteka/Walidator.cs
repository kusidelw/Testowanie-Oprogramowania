using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Biblioteka
{
    public static class Walidator
    {
        public static bool SprawdzTekstTylkoLitery(string tekst)
        {
            if (string.IsNullOrWhiteSpace(tekst)) return false;

            // Usuwamy białe znaki na początku i końcu
            tekst = tekst.Trim();

            // 1. Zabezpieczenie: Nie może zaczynać się ani kończyć myślnikiem
            if (tekst.StartsWith("-") || tekst.EndsWith("-"))
                return false;

            // 2. Zabezpieczenie: Nie może zawierać wielokrotnych myślników lub spacji obok siebie
            if (tekst.Contains("--") || tekst.Contains("  "))
                return false;

            // 3. Właściwa walidacja: Tylko litery, spacje i myślniki
            return Regex.IsMatch(tekst, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-]+$");
        }

        public static bool SprawdzUlice(string ulica)
        {
            if (string.IsNullOrWhiteSpace(ulica))
                return true;

            ulica = ulica.Trim();

            // Podstawowe zabezpieczenia przed ciągami znaków typu "--" czy ".."
            if (ulica.StartsWith("-") || ulica.EndsWith("-") || ulica.StartsWith("."))
                return false;

            if (ulica.Contains("--") || ulica.Contains("..") || ulica.Contains("  ")) 
                return false;

            // Dozwolone: litery (z polskimi znakami), cyfry, spacje, myślniki i kropki
            return Regex.IsMatch(ulica, @"^[a-zA-Z0-9ąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-\.]+$");
        }
        public static bool SprawdzEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return email.Length <= 255 && Regex.IsMatch(email.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        public static bool SprawdzTelefon(string telefon)
        {
            if (string.IsNullOrWhiteSpace(telefon)) return false;
            return Regex.IsMatch(telefon.Trim(), @"^\d{9}$");
        }

        public static bool SprawdzKodPocztowy(string kod)
        {
            if (string.IsNullOrWhiteSpace(kod)) return false;
            return Regex.IsMatch(kod.Trim(), @"^\d{2}-\d{3}$");
        }

        public static bool SprawdzDateUrodzenia(string dataWejsciowa, out DateTime poprawnaData)
        {
            // 1. Sprawdzenie czy to poprawna data kalendarzowa
            if (!DateTime.TryParse(dataWejsciowa.Trim(), out poprawnaData))
                return false;

            // 2. Data nie może być z przyszłości ani zbyt odległa 
            if (poprawnaData > DateTime.Now || poprawnaData.Year < 1900)
                return false;

            return true;
        }

        public static bool SprawdzNumer(string numer, bool czyOpcjonalny)
        {
            // Jeśli opcjonalny (jak lokal) i jest pusty -> przepuszczamy
            if (string.IsNullOrWhiteSpace(numer))
                return czyOpcjonalny;

            // Reguła: dowolna liczba cyfr, po których może wystąpić dokładnie jedna litera na samym końcu
            return numer.Length <= 10 && Regex.IsMatch(numer.Trim(), @"^\d+[a-zA-Z]?$");
        }

        // WALIDACJA ŚCISŁA PESEL 
        public static bool WalidujScislyPESEL(string pesel, string plecFormularz, DateTime dataUr)
        {
            if (string.IsNullOrWhiteSpace(pesel) || pesel.Length != 11 || !Regex.IsMatch(pesel, @"^\d{11}$"))
                return false;

            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int suma = 0;
            for (int i = 0; i < 10; i++) suma += int.Parse(pesel[i].ToString()) * wagi[i];
            int cyfraKontrolna = (10 - (suma % 10)) % 10;
            if (cyfraKontrolna != int.Parse(pesel[10].ToString())) return false;

            int cyfraPlci = int.Parse(pesel[9].ToString());
            bool toKobieta = (cyfraPlci % 2 == 0);
            if ((plecFormularz == "Kobieta" && !toKobieta) || (plecFormularz == "Mężczyzna" && toKobieta))
                return false;

            int rok = dataUr.Year;
            int miesiac = dataUr.Month;
            int dzien = dataUr.Day;

            if (rok >= 2000 && rok < 2100) miesiac += 20;
            else if (rok >= 1800 && rok < 1900) miesiac += 80;
            else if (rok >= 2100 && rok < 2200) miesiac += 40;
            else if (rok >= 2200 && rok < 2300) miesiac += 60;

            string peselData = $"{rok % 100:D2}{miesiac:D2}{dzien:D2}";
            if (pesel.Substring(0, 6) != peselData) return false;

            return true;
        }

        // WALIDACJA HASEŁ
        public static bool ValidatePasswordPolicy(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return false;

            if (pass.Length < 8 || pass.Length > 15) return false;

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            const string allowedSpecial = "-_!*#$&";

            foreach (char c in pass)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (allowedSpecial.Contains(c)) hasSpecial = true;
                else return false; // niedozwolony znak → od razu false
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        public static string GenerujHasloSystemowe()
        {
            const string wielkie = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string male = "abcdefghijklmnopqrstuvwxyz";
            const string cyfry = "0123456789";
            const string specjalne = "-_!*#$&";
            Random rnd = new Random();

            var haslo = new List<char>();
            for (int i = 0; i < 3; i++) haslo.Add(wielkie[rnd.Next(wielkie.Length)]);
            for (int i = 0; i < 3; i++) haslo.Add(male[rnd.Next(male.Length)]);
            for (int i = 0; i < 2; i++) haslo.Add(cyfry[rnd.Next(cyfry.Length)]);
            for (int i = 0; i < 2; i++) haslo.Add(specjalne[rnd.Next(specjalne.Length)]);

            // Pomieszanie znaków, aby nie były zawsze w tej samej kolejności
            return new string(haslo.OrderBy(x => rnd.Next()).ToArray());
        }

        //Sprawdzanie czy konto jest zablokowane
        public static bool CzyKontoZablokowane(DateTime? dataBlokady, int minutyBlokady)
        {
            if (!dataBlokady.HasValue) return false;
            return DateTime.Now < dataBlokady.Value.AddMinutes(minutyBlokady);
        }
    }
}
