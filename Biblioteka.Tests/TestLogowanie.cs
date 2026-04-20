using NUnit.Framework;
using System;
using System.Linq;
using Biblioteka;

namespace Biblioteka.Tests
{
    [TestFixture]
    public class TestLogowanie
    {
        // ── POLITYKA HASEŁ 

        [TestCase("Admin123!", ExpectedResult = true, TestName = "Hasło spełniające wszystkie wymogi")]
        [TestCase("DuzeMale1!", ExpectedResult = true, TestName = "Inne poprawne hasło")]
        [TestCase("Haslo1!", ExpectedResult = false, TestName = "E1: Za krótkie — 7 znaków (min. 8)")]
        [TestCase("Haslo12345678!", ExpectedResult = false, TestName = "E1: Za długie — powyżej 15 znaków")]
        [TestCase("tylkomale1!", ExpectedResult = false, TestName = "E1: Brak wielkiej litery")]
        [TestCase("TYLKODUZE1!", ExpectedResult = false, TestName = "E1: Brak małej litery")]
        [TestCase("BezZnaku123", ExpectedResult = false, TestName = "E1: Brak znaku specjalnego")]
        [TestCase("BezCyfry!Aa", ExpectedResult = false, TestName = "E1: Brak cyfry")]
        [TestCase("", ExpectedResult = false, TestName = "E1: Puste hasło")]
        [TestCase(null, ExpectedResult = false, TestName = "E1: Hasło null")]
        [TestCase("Aa1!Aa1!Aa1!Aa1!", ExpectedResult = false, TestName = "E1: Dokładnie 16 znaków — za długie")]
        [TestCase("Aa1!Aa1!Aa1!Aa1", ExpectedResult = false, TestName = "E1: 15 znaków bez znaku specjalnego na końcu")]
        [TestCase("Aa1-Aa1-Aa1-Aa1", ExpectedResult = false, TestName = "E1: 15 znaków ze znakiem specjalnym ale bez cyfr obok")]
        [TestCase("Abc1234$Abc123!", ExpectedResult = false, TestName = "E1: 15 znaków — graniczny górny — niepoprawne")]
        [TestCase("Abcde1!Aa", ExpectedResult = true, TestName = "Hasło 9 znaków — poprawne")]
        [TestCase("Abcdefg1!", ExpectedResult = true, TestName = "Hasło 9 znaków z innym układem")]
        public bool ValidatePasswordPolicy_TestyWymogow(string haslo)
        {
            return Walidator.ValidatePasswordPolicy(haslo);
        }

        // ── ZNAKI SPECJALNE — tylko dozwolone z analizy: - _ ! * # $ & ──────────

        [TestCase("Haslo12@", ExpectedResult = false, TestName = "E1: Niedozwolony znak specjalny @")]
        [TestCase("Haslo12%", ExpectedResult = false, TestName = "E1: Niedozwolony znak specjalny %")]
        [TestCase("Haslo12^", ExpectedResult = false, TestName = "E1: Niedozwolony znak specjalny ^")]
        [TestCase("Haslo12-", ExpectedResult = true, TestName = "Dozwolony znak specjalny -")]
        [TestCase("Haslo12_", ExpectedResult = true, TestName = "Dozwolony znak specjalny _")]
        [TestCase("Haslo12!", ExpectedResult = true, TestName = "Dozwolony znak specjalny !")]
        [TestCase("Haslo12*", ExpectedResult = true, TestName = "Dozwolony znak specjalny *")]
        [TestCase("Haslo12#", ExpectedResult = true, TestName = "Dozwolony znak specjalny #")]
        [TestCase("Haslo12$", ExpectedResult = true, TestName = "Dozwolony znak specjalny $")]
        [TestCase("Haslo12&", ExpectedResult = true, TestName = "Dozwolony znak specjalny &")]
        public bool ValidatePasswordPolicy_ZnakiSpecjalne(string haslo)
        {
            return Walidator.ValidatePasswordPolicy(haslo);
        }

        // ── GENEROWANIE HASŁA SYSTEMOWEGO

        [Test]
        public void GenerujHasloSystemowe_SprawdzenieDlugosci_Zwraca10Znakow()
        {
            string haslo = Walidator.GenerujHasloSystemowe();
            Assert.AreEqual(10, haslo.Length, "Hasło musi mieć dokładnie 10 znaków");
        }

        [Test]
        public void GenerujHasloSystemowe_Sprawdzenie3WielkichLiter()
        {
            string haslo = Walidator.GenerujHasloSystemowe();
            Assert.AreEqual(3, haslo.Count(char.IsUpper),
                "Hasło musi zawierać dokładnie 3 wielkie litery (3xW)");
        }

        [Test]
        public void GenerujHasloSystemowe_Sprawdzenie3MalychLiter()
        {
            string haslo = Walidator.GenerujHasloSystemowe();
            Assert.AreEqual(3, haslo.Count(char.IsLower),
                "Hasło musi zawierać dokładnie 3 małe litery (3xM)");
        }

        [Test]
        public void GenerujHasloSystemowe_Sprawdzenie2Cyfr()
        {
            string haslo = Walidator.GenerujHasloSystemowe();
            Assert.AreEqual(2, haslo.Count(char.IsDigit),
                "Hasło musi zawierać dokładnie 2 cyfry (2xC)");
        }

        [Test]
        public void GenerujHasloSystemowe_Sprawdzenie2ZnakowSpecjalnych()
        {
            string haslo = Walidator.GenerujHasloSystemowe();
            Assert.AreEqual(2, haslo.Count(c => "-_!*#$&".Contains(c)),
                "Hasło musi zawierać dokładnie 2 znaki specjalne z zestawu: - _ ! * # $ &");
        }

        [Test]
        public void GenerujHasloSystemowe_SprawdzeniePelnegoSchematu_3W3M2C2S()
        {
            // Jeden test sprawdzający cały schemat
            string haslo = Walidator.GenerujHasloSystemowe();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(10, haslo.Length, "Długość: 10 znaków");
                Assert.AreEqual(3, haslo.Count(char.IsUpper), "3 wielkie litery (W)");
                Assert.AreEqual(3, haslo.Count(char.IsLower), "3 małe litery (M)");
                Assert.AreEqual(2, haslo.Count(char.IsDigit), "2 cyfry (C)");
                Assert.AreEqual(2, haslo.Count(c => "-_!*#$&".Contains(c)), "2 znaki specjalne (S)");
            });
        }

        [Test]
        public void GenerujHasloSystemowe_SprawdzenieLosowosc_DwaHaslaSaRozne()
        {
            // Hasło tymczasowe musi być nieprzewidywalne 
            string haslo1 = Walidator.GenerujHasloSystemowe();
            string haslo2 = Walidator.GenerujHasloSystemowe();
            Assert.AreNotEqual(haslo1, haslo2,
                "Dwa kolejne wygenerowane hasła powinny być różne (losowość)");
        }

        [Test]
        public void GenerujHasloSystemowe_SprawdzeniePolityki_WygenerowanePrzekazujeWalidacje()
        {
            // Wygenerowane hasło musi spełniać tę samą politykę co hasło użytkownika
            string haslo = Walidator.GenerujHasloSystemowe();
            Assert.IsTrue(Walidator.ValidatePasswordPolicy(haslo),
                "Wygenerowane hasło systemowe musi przejść walidację polityki haseł");
        }

        // ── BLOKADA KONTA  ──────────────────────

        [Test]
        public void CzyKontoZablokowane_BlokadaNalozonaMinuteTemu_ZwracaTrue()
        {
            // blokada aktywna — konto zablokowane 1 minutę temu na 15 minut
            DateTime dataBlokady = DateTime.Now.AddMinutes(-1);
            bool wynik = Walidator.CzyKontoZablokowane(dataBlokady, 15);
            Assert.IsTrue(wynik, "Konto powinno być zablokowane — blokada wciąż trwa");
        }

        [Test]
        public void CzyKontoZablokowane_BrakBlokady_ZwracaFalse()
        {
            // Brak wpisu daty blokady w bazie (CzasOdblokowania = NULL)
            bool wynik = Walidator.CzyKontoZablokowane(null, 15);
            Assert.IsFalse(wynik, "Konto bez blokady powinno być odblokowane");
        }

        [Test]
        public void CzyKontoZablokowane_BlokadaWygasla20MinutTemu_ZwracaFalse()
        {
            //blokada nałożona 20 minut temu na 15 minut — już wygasła
            DateTime dataBlokady = DateTime.Now.AddMinutes(-20);
            bool wynik = Walidator.CzyKontoZablokowane(dataBlokady, 15);
            Assert.IsFalse(wynik, "Blokada wygasła — konto powinno być odblokowane");
        }

        [Test]
        public void CzyKontoZablokowane_BlokadaWygaslaDokładnieTeras_ZwracaFalse()
        {
            // Blokada nałożona dokładnie 15 minut temu — właśnie wygasła
            DateTime dataBlokady = DateTime.Now.AddMinutes(-15);
            bool wynik = Walidator.CzyKontoZablokowane(dataBlokady, 15);
            Assert.IsFalse(wynik, "Blokada właśnie wygasła — konto powinno być odblokowane");
        }

        [Test]
        public void CzyKontoZablokowane_BlokadaNalozonaSekundeTemu_ZwracaTrue()
        {
            // Blokada nałożona sekundę temu — wciąż aktywna
            DateTime dataBlokady = DateTime.Now.AddSeconds(-1);
            bool wynik = Walidator.CzyKontoZablokowane(dataBlokady, 15);
            Assert.IsTrue(wynik, "Blokada nałożona sekundę temu powinna być wciąż aktywna");
        }

    }
}