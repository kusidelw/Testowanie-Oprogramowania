using NUnit.Framework;
using System.Collections.Generic;
using Biblioteka;

namespace Biblioteka.Tests
{
    [TestFixture]
    public class PermissionValidatorTests
    {
        // === TESTY DLA CzyMinimalnaLiczbaUprawnien ===
        
        [Test]
        public void CzyMinimalnaLiczbaUprawnien_PustaLista_ZwracaFalse()
        {
            var result = PermissionValidator.CzyMinimalnaLiczbaUprawnien(new List<int>());
            Assert.IsFalse(result);
        }

        [Test]
        public void CzyMinimalnaLiczbaUprawnien_JednoUprawnienie_ZwracaTrue()
        {
            var result = PermissionValidator.CzyMinimalnaLiczbaUprawnien(new List<int> { 1 });
            Assert.IsTrue(result);
        }

        [Test]
        public void CzyMinimalnaLiczbaUprawnien_WieleUprawnien_ZwracaTrue()
        {
            var result = PermissionValidator.CzyMinimalnaLiczbaUprawnien(new List<int> { 1, 2, 3 });
            Assert.IsTrue(result);
        }

        [Test]
        public void CzyMinimalnaLiczbaUprawnien_Null_ZwracaFalse()
        {
            var result = PermissionValidator.CzyMinimalnaLiczbaUprawnien(null);
            Assert.IsFalse(result);
        }

        // === TESTY DLA CzyBylyZmianyWUprawnieniach ===

        [Test]
        public void CzyBylyZmianyWUprawnieniach_TaSamaKolejnoscTeSameWartosci_ZwracaFalse()
        {
            var oryginalne = new List<int> { 1, 2, 3 };
            var nowe = new List<int> { 1, 2, 3 };
            
            var result = PermissionValidator.CzyBylyZmianyWUprawnieniach(oryginalne, nowe);
            
            Assert.IsFalse(result);
        }

        [Test]
        public void CzyBylyZmianyWUprawnieniach_InnaKolejnoscTeSameWartosci_ZwracaFalse()
        {
            var oryginalne = new List<int> { 1, 2, 3 };
            var nowe = new List<int> { 3, 1, 2 };
            
            var result = PermissionValidator.CzyBylyZmianyWUprawnieniach(oryginalne, nowe);
            
            Assert.IsFalse(result, "Kolejność nie powinna mieć znaczenia");
        }

        [Test]
        public void CzyBylyZmianyWUprawnieniach_RozneWartosci_ZwracaTrue()
        {
            var oryginalne = new List<int> { 1, 2, 3 };
            var nowe = new List<int> { 1, 2, 4 };
            
            var result = PermissionValidator.CzyBylyZmianyWUprawnieniach(oryginalne, nowe);
            
            Assert.IsTrue(result);
        }

        [Test]
        public void CzyBylyZmianyWUprawnieniach_RoznaLiczbaElementow_ZwracaTrue()
        {
            var oryginalne = new List<int> { 1, 2 };
            var nowe = new List<int> { 1, 2, 3 };
            
            var result = PermissionValidator.CzyBylyZmianyWUprawnieniach(oryginalne, nowe);
            
            Assert.IsTrue(result);
        }

        [Test]
        public void CzyBylyZmianyWUprawnieniach_OryginalneNullNoweNie_ZwracaTrue()
        {
            List<int> oryginalne = null;
            var nowe = new List<int> { 1, 2, 3 };
            
            var result = PermissionValidator.CzyBylyZmianyWUprawnieniach(oryginalne, nowe);
            
            Assert.IsTrue(result);
        }

        [Test]
        public void CzyBylyZmianyWUprawnieniach_ObieNull_ZwracaFalse()
        {
            List<int> oryginalne = null;
            List<int> nowe = null;
            
            var result = PermissionValidator.CzyBylyZmianyWUprawnieniach(oryginalne, nowe);
            
            Assert.IsFalse(result);
        }

        [Test]
        public void CzyBylyZmianyWUprawnieniach_PusteListy_ZwracaFalse()
        {
            var oryginalne = new List<int>();
            var nowe = new List<int>();
            
            var result = PermissionValidator.CzyBylyZmianyWUprawnieniach(oryginalne, nowe);
            
            Assert.IsFalse(result);
        }

        // === TESTY DLA CzyZaznaczonoUzytkownikow ===

        [Test]
        public void CzyZaznaczonoUzytkownikow_ZeroUzytkownikow_ZwracaFalse()
        {
            var result = PermissionValidator.CzyZaznaczonoUzytkownikow(0);
            Assert.IsFalse(result);
        }

        [Test]
        public void CzyZaznaczonoUzytkownikow_JedenUzytkownik_ZwracaTrue()
        {
            var result = PermissionValidator.CzyZaznaczonoUzytkownikow(1);
            Assert.IsTrue(result);
        }

        [Test]
        public void CzyZaznaczonoUzytkownikow_WieluUzytkownikow_ZwracaTrue()
        {
            var result = PermissionValidator.CzyZaznaczonoUzytkownikow(5);
            Assert.IsTrue(result);
        }

        [Test]
        public void CzyZaznaczonoUzytkownikow_UjemnaLiczba_ZwracaFalse()
        {
            var result = PermissionValidator.CzyZaznaczonoUzytkownikow(-1);
            Assert.IsFalse(result);
        }
    }
}
