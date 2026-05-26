# System Zarządzania Biblioteką 📚

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![SSMS](https://img.shields.io/badge/SSMS-D22E2E?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![NUnit](https://img.shields.io/badge/NUnit-25CA2A?style=for-the-badge&logo=nunit&logoColor=white)

Aplikacja desktopowa napisana w języku C#, służąca do kompleksowego zarządzania zasobami biblioteki, czytelnikami oraz procesem wypożyczania książek.

## 🌟 Główne funkcjonalności

* **Autoryzacja i autentykacja:**
    * Logowanie użytkowników i administratorów.
    * System odzyskiwania i zmiany hasła.
    * Zarządzanie uprawnieniami.
* **Zarządzanie zasobami (Książki):**
    * Dodawanie nowych pozycji do biblioteki.
    * Przeglądanie szczegółów książek.
    * Wyszukiwanie i filtrowanie zasobów.
* **Zarządzanie użytkownikami:**
    * Rejestracja nowych czytelników.
    * Edycja danych użytkowników.
    * Zarządzanie zapomnianymi kontami.
* **Obsługa wypożyczeń:**
    * Wypożyczanie i zwracanie książek.
    * Przedłużanie terminu wypożyczenia.
    * Przeglądanie listy aktualnych wypożyczeń.

## 🛠 Technologie

* **Język programowania:** C#
* **Interfejs użytkownika:** Windows Forms
* **Baza danych:** SQL (skrypty dostępne w folderze `DataBase`)
* **Testy jednostkowe:** Wbudowany projekt testowy (`Biblioteka.Tests`) weryfikujący logikę biznesową.

## 📁 Struktura projektu

* `/Biblioteka` - Główny kod źródłowy aplikacji.
* `/Biblioteka.Tests` - Projekt zawierający testy jednostkowe.
* `/DataBase` - Skrypty SQL potrzebne do uruchomienia projektu:
    * `Struktura_Bazy_v2.sql` - tworzenie tabel i relacji.
    * `dane_testowe_v2.sql` - przykładowe dane do zasilenia bazy.

      
## 🚀 Uruchomienie projektu lokalnie

### Wymagania wstępne
* Zainstalowane środowisko **Visual Studio 2022** z obsługą środowiska .NET desktop development.
* Serwer bazy danych **SQL Server** (np. SQL Server Management Studio 20).

1.  **Sklonuj repozytorium:**
    ```bash
    git clone [https://github.com/TwojLogin/testowanie-oprogramowania.git](https://github.com/TwojLogin/testowanie-oprogramowania.git)
    ```
2.  **Skonfiguruj bazę danych:**
    * Otwórz SQL Server Management Studio 20 lub inny menedżer baz danych.
    * Utwórz nową, pustą bazę danych.
    * Uruchom skrypt `DataBase/Struktura_Bazy_v2.sql`, aby utworzyć strukturę tabel.
    * (Opcjonalnie) Uruchom skrypt `DataBase/dane_testowe_v2.sql`, aby wypełnić bazę przykładowymi danymi i kontami.
3.  **Skonfiguruj połączenie z bazą:**
    * Otwórz plik rozwiązania `Biblioteka.sln` w Visual Studio.
    * Znajdź plik `App.config` w głównym projekcie `Biblioteka`.
    * Zaktualizuj pole `ConnectionString`, wpisując dane dostępowe do Twojej lokalnej bazy danych.
4.  **Skompiluj i uruchom:**
    * Przywróć pakiety NuGet (prawy przycisk myszy na 'Solution Biblioteka' -> *Restore NuGet Packages*).
    * Wybierz *Start*, aby uruchomić aplikację.

## 🧪 Uruchamianie testów

Aby upewnić się, że aplikacja działa poprawnie, można uruchomić zaimplementowane testy:
1. W Visual Studio 2022 otwórz okno **Test Explorer** (`Test` -> `Test Explorer`).
2. Kliknij **Run All Tests In View**, aby sprawdzić walidatory i system logowania.
