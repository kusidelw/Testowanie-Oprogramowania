using NUnit.Framework;
using System;
using Biblioteka;

namespace Biblioteka.Tests
{
    [TestFixture]
    public class WalidatorTests
    {
        //Testy dla SprawdzEmail 
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

        //Testy dla SprawdzTelefon
        [TestCase("123456789", ExpectedResult = true)]
        [TestCase("000000000", ExpectedResult = true)]
        [TestCase("12345678", ExpectedResult = false)] 
        [TestCase("1234567890", ExpectedResult = false)] 
        [TestCase("123 456 789", ExpectedResult = false)]
        [TestCase("abcdefghi", ExpectedResult = false)] 
        [TestCase("", ExpectedResult = false)]
        public bool SprawdzTelefon_TestWariantu(string telefon)
        {
            return Walidator.SprawdzTelefon(telefon);
        }

        //Testy dla SprawdzKodPocztowy
        [TestCase("12-345", ExpectedResult = true)]
        [TestCase("00-000", ExpectedResult = true)]
        [TestCase("12345", ExpectedResult = false)]
        [TestCase("12-3456", ExpectedResult = false)]
        [TestCase("ab-cde", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        public bool SprawdzKodPocztowy_TestWariantu(string kod)
        {
            return Walidator.SprawdzKodPocztowy(kod);
        }

        //Testy dla SprawdzDateUrodzenia
        [Test]
        public void SprawdzDateUrodzenia_PrawidlowaData_ZwracaTrue()
        {
            string dataWejsciowa = "2000-01-01";
            bool wynik = Walidator.SprawdzDateUrodzenia(dataWejsciowa, out DateTime poprawnaData);

            Assert.That(wynik, Is.True);
            Assert.That(poprawnaData, Is.EqualTo(new DateTime(2000, 1, 1)));
        }

        [Test]
        public void SprawdzDateUrodzenia_DataZPrzyszlosci_ZwracaFalse()
        {
            string dataWejsciowa = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            bool wynik = Walidator.SprawdzDateUrodzenia(dataWejsciowa, out _);

            Assert.That(wynik, Is.False);
        }

        [Test]
        public void SprawdzDateUrodzenia_DataZbytOdlegla_ZwracaFalse()
        {
            string dataWejsciowa = "1899-12-31"; // Limit ustawiony na >= 1900
            bool wynik = Walidator.SprawdzDateUrodzenia(dataWejsciowa, out _);

            Assert.That(wynik, Is.False);
        }

        [Test]
        public void SprawdzDateUrodzenia_NieprawidlowyFormat_ZwracaFalse()
        {
            string dataWejsciowa = "to-nie-jest-data";
            bool wynik = Walidator.SprawdzDateUrodzenia(dataWejsciowa, out _);

            Assert.That(wynik, Is.False);
        }

        //Testy dla SprawdzNumer
        [TestCase("12A", false, ExpectedResult = true)]
        [TestCase("1234567890", false, ExpectedResult = true)]
        [TestCase("12345678901", false, ExpectedResult = false)]
        [TestCase("12@#", false, ExpectedResult = false)] 
        [TestCase("", true, ExpectedResult = true)] 
        [TestCase("", false, ExpectedResult = false)] 
        [TestCase(null, true, ExpectedResult = true)]
        public bool SprawdzNumer_TestWariantu(string numer, bool opcjonalny)
        {
            return Walidator.SprawdzNumer(numer, opcjonalny);
        }

        //Testy dla WalidujScislyPESEL
        [Test]
        public void WalidujScislyPESEL_PrawidlowyWymyslonyPESELMeczczyzny_ZwracaTrue()
        {
            string pesel = "00222912318";
            string plec = "Mężczyzna";
            DateTime dataUr = new DateTime(2000, 2, 29);

            bool wynik = Walidator.WalidujScislyPESEL(pesel, plec, dataUr);

            Assert.That(wynik, Is.True);
        }

        [Test]
        public void WalidujScislyPESEL_NiezgodnoscPlci_ZwracaFalse()
        {
            string pesel = "00222912318";
            string plec = "Kobieta";
            DateTime dataUr = new DateTime(2000, 2, 29);

            bool wynik = Walidator.WalidujScislyPESEL(pesel, plec, dataUr);

            Assert.That(wynik, Is.False);
        }

        [Test]
        public void WalidujScislyPESEL_ZlaSumaKontrolna_ZwracaFalse()
        {
            string pesel = "00222912319";
            string plec = "Mężczyzna";
            DateTime dataUr = new DateTime(2000, 2, 29);

            bool wynik = Walidator.WalidujScislyPESEL(pesel, plec, dataUr);

            Assert.That(wynik, Is.False);
        }

        [Test]
        public void WalidujScislyPESEL_ZlyMiesiacDlaRoku_ZwracaFalse()
        {
            string pesel = "90010112345";
            string plec = "Mężczyzna";
            DateTime dataUr = new DateTime(2000, 1, 1);

            bool wynik = Walidator.WalidujScislyPESEL(pesel, plec, dataUr);

            Assert.That(wynik, Is.False);
        }
    }
}