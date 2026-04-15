using NUnit.Framework;
using System;
using Biblioteka;


namespace Biblioteka.Tests
{
    [TestFixture]
    public class WalidatorTests
    {
        // --- Testy dla SprawdzEmail ---
        [TestCase("test@test.pl", ExpectedResult = true)]
        [TestCase("jan.kowalski@domena.com.pl", ExpectedResult = true)]
        [TestCase("test", ExpectedResult = false)]
        [TestCase("test@.pl", ExpectedResult = false)]
        [TestCase("@test.pl", ExpectedResult = false)]
        [TestCase("test@test", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        public bool SprawdzEmail_TestWariantu(string email)
        {
            return Walidator.SprawdzEmail(email);
        }

        // --- Testy dla SprawdzTelefon ---
        [TestCase("123456789", ExpectedResult = true)]
        [TestCase("000000000", ExpectedResult = true)]
        [TestCase("12345678", ExpectedResult = false)] // za krótki
        [TestCase("1234567890", ExpectedResult = false)] // za d³ugi
        [TestCase("123 456 789", ExpectedResult = false)] // spacje niedozwolone w tym regexie
        [TestCase("abcdefghi", ExpectedResult = false)] // litery
        [TestCase("", ExpectedResult = false)]
        public bool SprawdzTelefon_TestWariantu(string telefon)
        {
            return Walidator.SprawdzTelefon(telefon);
        }

        // --- Testy dla SprawdzKodPocztowy ---
        [TestCase("12-345", ExpectedResult = true)]
        [TestCase("00-000", ExpectedResult = true)]
        [TestCase("12345", ExpectedResult = false)] // brak myœlnika
        [TestCase("12-3456", ExpectedResult = false)] // za d³ugi
        [TestCase("ab-cde", ExpectedResult = false)] // litery zamiast cyfr
        [TestCase(null, ExpectedResult = false)]
        public bool SprawdzKodPocztowy_TestWariantu(string kod)
        {
            return Walidator.SprawdzKodPocztowy(kod);
        }

        // --- Testy dla SprawdzDateUrodzenia ---
        [Test]
        public void SprawdzDateUrodzenia_PrawidlowaData_ZwracaTrue()
        {
            string dataWejsciowa = "2000-01-01";
            bool wynik = Walidator.SprawdzDateUrodzenia(dataWejsciowa, out DateTime poprawnaData);

            Assert.IsTrue(wynik);
            Assert.AreEqual(new DateTime(2000, 1, 1), poprawnaData);
        }

        [Test]
        public void SprawdzDateUrodzenia_DataZPrzyszlosci_ZwracaFalse()
        {
            string dataWejsciowa = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            bool wynik = Walidator.SprawdzDateUrodzenia(dataWejsciowa, out _);

            Assert.IsFalse(wynik);
        }

        [Test]
        public void SprawdzDateUrodzenia_DataZbytOdlegla_ZwracaFalse()
        {
            string dataWejsciowa = "1899-12-31"; // Limit ustawiony na >= 1900
            bool wynik = Walidator.SprawdzDateUrodzenia(dataWejsciowa, out _);

            Assert.IsFalse(wynik);
        }

        [Test]
        public void SprawdzDateUrodzenia_NieprawidlowyFormat_ZwracaFalse()
        {
            string dataWejsciowa = "to-nie-jest-data";
            bool wynik = Walidator.SprawdzDateUrodzenia(dataWejsciowa, out _);

            Assert.IsFalse(wynik);
        }

        // --- Testy dla SprawdzNumer ---
        [TestCase("12A", false, ExpectedResult = true)]
        [TestCase("1234567890", false, ExpectedResult = true)]
        [TestCase("12345678901", false, ExpectedResult = false)] // za d³ugi (> 10)
        [TestCase("12@#", false, ExpectedResult = false)] // niedozwolone znaki
        [TestCase("", true, ExpectedResult = true)] // pusty, ale opcjonalny
        [TestCase("", false, ExpectedResult = false)] // pusty i nieopcjonalny
        [TestCase(null, true, ExpectedResult = true)]
        public bool SprawdzNumer_TestWariantu(string numer, bool opcjonalny)
        {
            return Walidator.SprawdzNumer(numer, opcjonalny);
        }

        // --- Testy dla WalidujScislyPESEL ---
        [Test]
        public void WalidujScislyPESEL_PrawidlowyWymyslonyPESELMeczczyzny_ZwracaTrue()
        {
            string pesel = "00222912318";
            string plec = "Mê¿czyzna";
            DateTime dataUr = new DateTime(2000, 2, 29);

            bool wynik = Walidator.WalidujScislyPESEL(pesel, plec, dataUr);

            Assert.IsTrue(wynik);
        }

        [Test]
        public void WalidujScislyPESEL_NiezgodnoscPlci_ZwracaFalse()
        {
            string pesel = "00222912318"; // PESEL dla mê¿czyzny (cyfra p³ci 1)
            string plec = "Kobieta"; // Niezgodnoœæ
            DateTime dataUr = new DateTime(2000, 2, 29);

            bool wynik = Walidator.WalidujScislyPESEL(pesel, plec, dataUr);

            Assert.IsFalse(wynik);
        }

        [Test]
        public void WalidujScislyPESEL_ZlaSumaKontrolna_ZwracaFalse()
        {
            string pesel = "00222912319"; // Zmieniona ostatnia cyfra z 8 na 9
            string plec = "Mê¿czyzna";
            DateTime dataUr = new DateTime(2000, 2, 29);

            bool wynik = Walidator.WalidujScislyPESEL(pesel, plec, dataUr);

            Assert.IsFalse(wynik);
        }

        [Test]
        public void WalidujScislyPESEL_ZlyMiesiacDlaRoku_ZwracaFalse()
        {
            string pesel = "90010112345";
            string plec = "Mê¿czyzna";
            DateTime dataUr = new DateTime(2000, 1, 1);

            bool wynik = Walidator.WalidujScislyPESEL(pesel, plec, dataUr);

            Assert.IsFalse(wynik);
        }
    }
}