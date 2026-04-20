using NUnit.Framework;
using System;
using System.Linq;
using Biblioteka;

namespace Biblioteka.Tests
{
    [TestFixture]
    public class TestLogowanie
    {
        // Testowanie polityki haseł (długość, znaki specjalne, wielkość liter)
        [TestCase("Admin123!", ExpectedResult = true)]  // Wszystkie wymogi spełnione
        [TestCase("Haslo1!", ExpectedResult = false)]   // Za krótkie (<8)
        [TestCase("DuzeMale1!", ExpectedResult = true)]
        [TestCase("tylkomale1!", ExpectedResult = false)] // Brak wielkiej litery
        [TestCase("TYLKODUZE1!", ExpectedResult = false)] // Brak małej litery
        [TestCase("BezZnaku123", ExpectedResult = false)] // Brak znaku specjalnego
        public bool ValidatePasswordPolicy_TestyWymogow(string haslo)
        {
            return Walidator.ValidatePasswordPolicy(haslo);
        }

        // Testowanie automatycznego generowania haseł przez system (schemat 3xW, 3xM, 2xC, 2xS)
        [Test]
        public void GenerujHasloSystemowe_SprawdzenieSchematu_ZwracaPoprawnaStrukture()
        {
            // Act
            string haslo = Walidator.GenerujHasloSystemowe();

            // Assert
            Assert.AreEqual(10, haslo.Length, "Hasło musi mieć 10 znaków");
            Assert.AreEqual(3, haslo.Count(char.IsUpper), "Musi mieć 3 wielkie litery");
            Assert.AreEqual(3, haslo.Count(char.IsLower), "Musi mieć 3 małe litery");
            Assert.AreEqual(2, haslo.Count(char.IsDigit), "Musi mieć 2 cyfry");
            Assert.AreEqual(2, haslo.Count(c => "-_!*#$&".Contains(c)), "Musi mieć 2 znaki specjalne");
        }


        // Testowanie mechanizmu sprawdzania blokady czasowej konta
        [Test]
        public void CzyKontoZablokowane_BlokadaAktywna_ZwracaTrue()
        {
            DateTime dataBlokady = DateTime.Now.AddMinutes(-1);
            bool wynik = Walidator.CzyKontoZablokowane(dataBlokady, 15);

            Assert.IsTrue(wynik);
        }

        [Test]
        public void CzyKontoZablokowane_BrakBlokady_ZwracaFalse()
        {
            // Przekazanie null oznacza brak zarejestrowanej blokady w bazie
            bool wynik = Walidator.CzyKontoZablokowane(null, 15);
            Assert.IsFalse(wynik);
        }

        [Test]
        public void CzyKontoZablokowane_BlokadaWygasla_ZwracaFalse()
        {
            // Blokada nałożona 20 minut temu na 15 minut (już wygasła)
            DateTime dataBlokady = DateTime.Now.AddMinutes(-20);
            bool wynik = Walidator.CzyKontoZablokowane(dataBlokady, 15);

            Assert.IsFalse(wynik);
        }
    }
}