CREATE DATABASE BibliotekaDB;
GO
	
USE BibliotekaDB;
GO

-- modu³ u¿ytkowników i uprawnieñ

-- Tabela ról/uprawnieñ
CREATE TABLE Uprawnienia (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nazwa NVARCHAR(50) NOT NULL UNIQUE
);
GO

-- G³ówna tabela u¿ytkowników (Czytelnicy, Bibliotekarze, Administratorzy, Managerzy)
CREATE TABLE Uzytkownicy (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Login NVARCHAR(50) NOT NULL UNIQUE,
    HasloHash NVARCHAR(255) NOT NULL, -- Has³o musi byæ zahaszowane
    Imie NVARCHAR(50) NOT NULL,
    Nazwisko NVARCHAR(50) NOT NULL,
    Miejscowosc NVARCHAR(100) NOT NULL,
    KodPocztowy NVARCHAR(10) NOT NULL,
    Ulica NVARCHAR(100) NULL,
    NumerPosesji NVARCHAR(20) NOT NULL,
    NumerLokalu NVARCHAR(20) NULL,
    PESEL CHAR(11) NOT NULL UNIQUE,
    DataUrodzenia DATE NOT NULL,
    Plec CHAR(1) NOT NULL CHECK (Plec IN ('K', 'M')),
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Telefon VARCHAR(9) NOT NULL,

	-- Flagi systemowe i RODO
    CzyZapomniany BIT NOT NULL DEFAULT 0,
    DataZapomnienia DATETIME NULL,
    ZapomnianyPrzezUzytkownikaID INT NULL,
    
    -- Obs³uga logowania i blokad
    CzyZablokowany BIT NOT NULL DEFAULT 0,
    LiczbaBlednychLogowan INT NOT NULL DEFAULT 0,
    CzasOdblokowania DATETIME NULL,
    
    CONSTRAINT FK_Uzytkownicy_ZapomnianyPrzez FOREIGN KEY (ZapomnianyPrzezUzytkownikaID) REFERENCES Uzytkownicy(ID)
);
GO

-- sprawdzanie poprawnoœci emaila
ALTER TABLE Uzytkownicy
ADD CONSTRAINT CHK_Email_Format CHECK (
    Email LIKE '%_@_%._%'  
    AND Email NOT LIKE '%@%@%'
    AND LEN(Email) <= 255
);
GO

-- sprawdzanie poprawnoœci PESELu
ALTER TABLE Uzytkownicy
ADD CONSTRAINT CHK_Uzytkownicy_PESEL_Format CHECK (
    -- PESEL musi mieæ dok³adnie 11 cyfr 
    PESEL LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    
    -- Walidacja p³ci: nieparzyste - M, parzyste/0 - K 
    AND (
        (Plec = 'M' AND CAST(SUBSTRING(PESEL, 10, 1) AS INT) % 2 <> 0) OR
        (Plec = 'K' AND CAST(SUBSTRING(PESEL, 10, 1) AS INT) % 2 = 0)
    )
    
    -- Walidacja daty urodzenia (pierwsze 6 cyfr RRMMDD) 
    AND SUBSTRING(PESEL, 1, 2) = RIGHT(CAST(YEAR(DataUrodzenia) AS VARCHAR), 2)
    AND (
        -- Obs³uga osób urodzonych po roku 2000 (miesi¹c + 20)
        (YEAR(DataUrodzenia) >= 2000 AND CAST(SUBSTRING(PESEL, 3, 2) AS INT) = MONTH(DataUrodzenia) + 20) OR
        (YEAR(DataUrodzenia) < 2000 AND CAST(SUBSTRING(PESEL, 3, 2) AS INT) = MONTH(DataUrodzenia))
    )
    AND CAST(SUBSTRING(PESEL, 5, 2) AS INT) = DAY(DataUrodzenia)
);
GO
-- Relacja N:M pomiêdzy U¿ytkownikami a Uprawnieniami
CREATE TABLE Uzytkownicy_Uprawnienia (
    UzytkownikID INT NOT NULL,
    UprawnienieID INT NOT NULL,
    PRIMARY KEY (UzytkownikID, UprawnienieID),
    FOREIGN KEY (UzytkownikID) REFERENCES Uzytkownicy(ID),
    FOREIGN KEY (UprawnienieID) REFERENCES Uprawnienia(ID)
);
GO

-- Tabela przechowuj¹ca historiê hase³ (wymóg pamiêtania 3 ostatnich hase³)
CREATE TABLE HistoriaHasel (
    ID INT PRIMARY KEY IDENTITY(1,1),
    UzytkownikID INT NOT NULL,
    HasloHash NVARCHAR(255) NOT NULL,
    DataZmiany DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UzytkownikID) REFERENCES Uzytkownicy(ID)
);
GO

-- modu³ ksi¹¿ek (katalog i egzemplarze)

-- S³ownik gatunków literackich
CREATE TABLE Gatunki (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nazwa NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- Tabela g³ówna katalogu ksi¹¿ek (metadane)
CREATE TABLE KatalogKsiazek (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Tytul NVARCHAR(255) NOT NULL,
    GatunekID INT NOT NULL,
    LiczbaStron INT NOT NULL,
    Wydawnictwo NVARCHAR(100) NOT NULL,
    RokWydania INT NOT NULL,
    Cena DECIMAL(10,2) NOT NULL,
    Opis NVARCHAR(MAX) NULL,
    FOREIGN KEY (GatunekID) REFERENCES Gatunki(ID)
);
GO

-- Autorzy (osobna tabela dla normalizacji)
CREATE TABLE Autorzy (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Imie NVARCHAR(50) NOT NULL,
    Nazwisko NVARCHAR(50) NOT NULL
);
GO

-- Relacja N:M pomiêdzy Katalogiem a Autorami (ksi¹¿ka mo¿e mieæ wielu autorów)
CREATE TABLE KsiazkKatalog_Autorzy (
    KsiazkaID INT NOT NULL,
    AutorID INT NOT NULL,
    PRIMARY KEY (KsiazkaID, AutorID),
    FOREIGN KEY (KsiazkaID) REFERENCES KatalogKsiazek(ID),
    FOREIGN KEY (AutorID) REFERENCES Autorzy(ID)
);
GO

-- Tabela fizycznych egzemplarzy (konkretnych sztuk w bibliotece)
CREATE TABLE Egzemplarze (
    ID INT PRIMARY KEY IDENTITY(1,1),
    KsiazkaID INT NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Dostepna' CHECK (Status IN ('Dostepna', 'Wypozyczona', 'Zniszczona', 'Zagubiona')),
    DataRejestracji DATETIME NOT NULL DEFAULT GETDATE(),
    ZarejestrowanePrzezID INT NOT NULL, -- Zapisujemy, który bibliotekarz doda³ egzemplarz
    FOREIGN KEY (KsiazkaID) REFERENCES KatalogKsiazek(ID),
    FOREIGN KEY (ZarejestrowanePrzezID) REFERENCES Uzytkownicy(ID)
);
GO

-- modu³ wypo¿yczeñ
-- Nag³ówek wypo¿yczenia (Kto, od kogo i kiedy)
CREATE TABLE Wypozyczenia (
    ID INT PRIMARY KEY IDENTITY(1,1),
    CzytelnikID INT NOT NULL,
    BibliotekarzID INT NOT NULL,
    DataWypozyczenia DATETIME NOT NULL DEFAULT GETDATE(),
    OkresWypozyczeniaDni INT NOT NULL DEFAULT 14,
    OczekiwanaDataZwrotu DATETIME NOT NULL,
    DataZwrotu DATETIME NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Nowe' CHECK (Status IN ('Nowe', 'Przedluzone', 'Zakonczone')),
    FOREIGN KEY (CzytelnikID) REFERENCES Uzytkownicy(ID),
    FOREIGN KEY (BibliotekarzID) REFERENCES Uzytkownicy(ID)
);
GO

-- Pozycje wypo¿yczenia (jakie konkretnie egzemplarze wypo¿yczono)
CREATE TABLE PozycjeWypozyczenia (
    WypozyczenieID INT NOT NULL,
    EgzemplarzID INT NOT NULL,
    PRIMARY KEY (WypozyczenieID, EgzemplarzID),
    FOREIGN KEY (WypozyczenieID) REFERENCES Wypozyczenia(ID),
    FOREIGN KEY (EgzemplarzID) REFERENCES Egzemplarze(ID)
);
GO

--znormalizowana tabela na Wydawnictwa
CREATE TABLE Wydawnictwa (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nazwa NVARCHAR(100) NOT NULL UNIQUE
);
GO

--kopiujemy unikalne nazwy wydawnictw z obecnej tabeli ksiazek do nowej tabeli
INSERT INTO Wydawnictwa (Nazwa)
SELECT DISTINCT Wydawnictwo 
FROM KatalogKsiazek 
WHERE Wydawnictwo IS NOT NULL;
GO

--nowa kolumna na klucz obcy
ALTER TABLE KatalogKsiazek
ADD WydawnictwoID INT;
GO

--polaczenie starych nazw z nowymi ID i uzupełnienie nowej kolumny
UPDATE KatalogKsiazek
SET WydawnictwoID = w.ID
FROM KatalogKsiazek k
JOIN Wydawnictwa w ON k.Wydawnictwo = w.Nazwa;
GO

--usuniecie starej kolumny tekstowej
ALTER TABLE KatalogKsiazek
DROP COLUMN Wydawnictwo;
GO

ALTER TABLE KatalogKsiazek
ALTER COLUMN WydawnictwoID INT NOT NULL;
GO

ALTER TABLE KatalogKsiazek
ADD CONSTRAINT FK_KatalogKsiazek_Wydawnictwa 
FOREIGN KEY (WydawnictwoID) REFERENCES Wydawnictwa(ID);
GO

--zmiana sprawdzania peselu
ALTER TABLE Uzytkownicy
DROP CONSTRAINT CHK_Uzytkownicy_PESEL_Format;
GO

ALTER TABLE Uzytkownicy WITH NOCHECK
ADD CONSTRAINT CHK_Uzytkownicy_PESEL_Format CHECK (
    PESEL LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    
    AND (
        (Plec = 'M' AND CAST(SUBSTRING(PESEL, 10, 1) AS INT) % 2 <> 0) OR
        (Plec = 'K' AND CAST(SUBSTRING(PESEL, 10, 1) AS INT) % 2 = 0)
    )
    
    AND SUBSTRING(PESEL, 1, 2) = RIGHT('00' + CAST(YEAR(DataUrodzenia) % 100 AS VARCHAR(2)), 2)
    AND SUBSTRING(PESEL, 3, 2) = RIGHT('00' + CAST(
        MONTH(DataUrodzenia) + 
        CASE 
            WHEN YEAR(DataUrodzenia) >= 1800 AND YEAR(DataUrodzenia) < 1900 THEN 80
            WHEN YEAR(DataUrodzenia) >= 1900 AND YEAR(DataUrodzenia) < 2000 THEN 0
            WHEN YEAR(DataUrodzenia) >= 2000 AND YEAR(DataUrodzenia) < 2100 THEN 20
            WHEN YEAR(DataUrodzenia) >= 2100 AND YEAR(DataUrodzenia) < 2200 THEN 40
            WHEN YEAR(DataUrodzenia) >= 2200 AND YEAR(DataUrodzenia) < 2300 THEN 60
            ELSE 0 
        END AS VARCHAR(2)
    ), 2)
    AND SUBSTRING(PESEL, 5, 2) = RIGHT('00' + CAST(DAY(DataUrodzenia) AS VARCHAR(2)), 2)

    AND CAST(SUBSTRING(PESEL, 11, 1) AS INT) = (
        10 - (
            (
                CAST(SUBSTRING(PESEL, 1, 1) AS INT) * 1 +
                CAST(SUBSTRING(PESEL, 2, 1) AS INT) * 3 +
                CAST(SUBSTRING(PESEL, 3, 1) AS INT) * 7 +
                CAST(SUBSTRING(PESEL, 4, 1) AS INT) * 9 +
                CAST(SUBSTRING(PESEL, 5, 1) AS INT) * 1 +
                CAST(SUBSTRING(PESEL, 6, 1) AS INT) * 3 +
                CAST(SUBSTRING(PESEL, 7, 1) AS INT) * 7 +
                CAST(SUBSTRING(PESEL, 8, 1) AS INT) * 9 +
                CAST(SUBSTRING(PESEL, 9, 1) AS INT) * 1 +
                CAST(SUBSTRING(PESEL, 10, 1) AS INT) * 3
            ) % 10
        )
    ) % 10
);
GO

--normalizacja kodu pocztowego i miejscowości
CREATE TABLE KodyPocztowe_Miejscowosci (
    ID INT PRIMARY KEY IDENTITY(1,1),
    KodPocztowy NVARCHAR(10) NOT NULL,
    Miejscowosc NVARCHAR(100) NOT NULL,
    CONSTRAINT UQ_Kod_Miejscowosc UNIQUE (KodPocztowy, Miejscowosc)
);
GO

INSERT INTO KodyPocztowe_Miejscowosci (KodPocztowy, Miejscowosc)
SELECT DISTINCT KodPocztowy, Miejscowosc 
FROM Uzytkownicy 
WHERE KodPocztowy IS NOT NULL AND Miejscowosc IS NOT NULL;
GO

ALTER TABLE Uzytkownicy
ADD MiejscowoscKodID INT;
GO

UPDATE u
SET u.MiejscowoscKodID = k.ID
FROM Uzytkownicy u
JOIN KodyPocztowe_Miejscowosci k 
  ON u.KodPocztowy = k.KodPocztowy AND u.Miejscowosc = k.Miejscowosc;
GO

ALTER TABLE Uzytkownicy
DROP COLUMN KodPocztowy;
GO

ALTER TABLE Uzytkownicy
DROP COLUMN Miejscowosc;
GO

ALTER TABLE Uzytkownicy
ALTER COLUMN MiejscowoscKodID INT NOT NULL;
GO

ALTER TABLE Uzytkownicy
ADD CONSTRAINT FK_Uzytkownicy_KodyMiejscowosci 
FOREIGN KEY (MiejscowoscKodID) REFERENCES KodyPocztowe_Miejscowosci(ID);
GO

--zapomienie uzytkownika
CREATE TABLE LogiZapomnienia (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ZanonimizowanyUzytkownikID INT NOT NULL,
    WykonalAdministratorID INT NOT NULL,
    DataAnonimizacji DATETIME NOT NULL DEFAULT GETDATE(),
    Powod NVARCHAR(255) NULL,
    CONSTRAINT FK_Logi_Zanonimizowany FOREIGN KEY (ZanonimizowanyUzytkownikID) REFERENCES Uzytkownicy(ID),
    CONSTRAINT FK_Logi_Administrator FOREIGN KEY (WykonalAdministratorID) REFERENCES Uzytkownicy(ID)
);
GO

CREATE PROCEDURE sp_ZanonimizujUzytkownika
    @TargetUzytkownikID INT,         -- ID osoby, którą zapominamy
    @AdminID INT,                    -- ID administratora, który klika przycisk
    @LosoweImie NVARCHAR(50),        -- Wygenerowane w C# losowe imię
    @LosoweNazwisko NVARCHAR(50),    -- Wygenerowane w C# losowe nazwisko
    @LosowyPESEL CHAR(11),           -- Wygenerowany w C# fałszywy, ale poprawny matematycznie PESEL
    @LosowaDataUr DATE,              -- Data urodzenia zgodna z fałszywym PESELEM
    @LosowaPlec CHAR(1)              -- Płeć zgodna z fałszywym PESELEM
AS
BEGIN
    -- Używamy transakcji. Jeśli cokolwiek pójdzie nie tak, baza cofnie wszystkie zmiany.
    BEGIN TRY
        BEGIN TRANSACTION;

        -- WARUNEK 1: Odbieranie wszystkich uprawnień (brak dostępu do systemu)
        DELETE FROM Uzytkownicy_Uprawnienia
        WHERE UzytkownikID = @TargetUzytkownikID;

        -- WARUNEK 2: Ustawienie flagi i zmiana danych wrażliwych na losowe
        UPDATE Uzytkownicy
        SET Imie = @LosoweImie,
            Nazwisko = @LosoweNazwisko,
            PESEL = @LosowyPESEL,
            DataUrodzenia = @LosowaDataUr,
            Plec = @LosowaPlec,
            -- Generujemy losowy email bezpośrednio w SQL (funkcja NEWID generuje losowy ciąg), 
            -- który spełni nasz warunek LIKE '%_@_%._%'
            Email = CAST(NEWID() AS NVARCHAR(36)) + '@anonim.local', 
            HasloHash = 'ZABLOKOWANE', -- Trwale blokujemy możliwość logowania
            CzyZablokowany = 1,
            CzyZapomniany = 1
        WHERE ID = @TargetUzytkownikID;

        -- WARUNEK 3: Zapis do nowej tabeli LogiZapomnienia (kto i kiedy)
        INSERT INTO LogiZapomnienia (ZanonimizowanyUzytkownikID, WykonalAdministratorID, DataAnonimizacji, Powod)
        VALUES (@TargetUzytkownikID, @AdminID, GETDATE(), 'Realizacja User Story: Anonimizacja RODO');

        -- Zakończenie sukcesem - zapisujemy zmiany
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Jeśli aplikacja podała zły PESEL i nasza walidacja go odrzuci, baza anuluje usuwanie uprawnień i logów
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

ALTER TABLE Uzytkownicy
DROP CONSTRAINT FK_Uzytkownicy_ZapomnianyPrzez;
GO

ALTER TABLE Uzytkownicy
DROP COLUMN ZapomnianyPrzezUzytkownikaID, DataZapomnienia;
GO
