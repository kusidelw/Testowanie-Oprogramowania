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
        public static bool SprawdzEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return email.Length <= 255 && Regex.IsMatch(email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
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

            // Zabezpieczenie przed przepełnieniem bazy i dziwnymi znakami specjalnymi
            return numer.Length <= 10 && Regex.IsMatch(numer.Trim(), @"^[a-zA-Z0-9\s/-]+$");
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

            // Kryteria: 8-15 znaków
            if (pass.Length < 8 || pass.Length > 15) return false;

            // Wielka litera, mała litera, cyfra
            bool hasUpper = pass.Any(char.IsUpper);
            bool hasLower = pass.Any(char.IsLower);
            bool hasDigit = pass.Any(char.IsDigit);

            // Znaki specjalne zgodnie z wymogami: -, _, !, *, #, $, &
            bool hasSpecial = Regex.IsMatch(pass, @"[-_!*#$&]");

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
