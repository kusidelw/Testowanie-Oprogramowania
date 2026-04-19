using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka
{
    /// <summary>
    /// Walidator uprawnień użytkowników - statyczne metody pomocnicze.
    /// Wzorowany na klasie Walidator.cs
    /// </summary>
    public static class PermissionValidator
    {
        /// <summary>
        /// Sprawdza czy użytkownik ma co najmniej jedno uprawnienie.
        /// </summary>
        /// <param name="permissionIds">Lista ID uprawnień użytkownika</param>
        /// <returns>True jeśli użytkownik ma przynajmniej jedno uprawnienie, false w przeciwnym razie</returns>
        public static bool CzyMinimalnaLiczbaUprawnien(List<int> permissionIds)
        {
            return permissionIds != null && permissionIds.Count > 0;
        }

        /// <summary>
        /// Porównuje dwie listy uprawnień i sprawdza czy się różnią (kolejność nie ma znaczenia).
        /// </summary>
        /// <param name="oryginalnePrawnienia">Oryginalna lista ID uprawnień</param>
        /// <param name="nowePrawnienia">Nowa lista ID uprawnień do porównania</param>
        /// <returns>True jeśli listy się różnią, false jeśli są identyczne</returns>
        public static bool CzyBylyZmianyWUprawnieniach(List<int> oryginalnePrawnienia, List<int> nowePrawnienia)
        {
            if (oryginalnePrawnienia == null || nowePrawnienia == null)
                return oryginalnePrawnienia != nowePrawnienia;

            if (oryginalnePrawnienia.Count != nowePrawnienia.Count)
                return true;

            List<int> sortedOriginal = oryginalnePrawnienia.OrderBy(x => x).ToList();
            List<int> sortedNew = nowePrawnienia.OrderBy(x => x).ToList();

            for (int i = 0; i < sortedOriginal.Count; i++)
            {
                if (sortedOriginal[i] != sortedNew[i])
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Sprawdza czy zaznaczono co najmniej jednego użytkownika.
        /// </summary>
        /// <param name="liczbaUzytkownikow">Liczba zaznaczonych użytkowników</param>
        /// <returns>True jeśli zaznaczono przynajmniej jednego użytkownika, false w przeciwnym razie</returns>
        public static bool CzyZaznaczonoUzytkownikow(int liczbaUzytkownikow)
        {
            return liczbaUzytkownikow > 0;
        }
    }
}
