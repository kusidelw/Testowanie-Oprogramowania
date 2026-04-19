USE master;
GO

IF DB_ID('BibliotekaDB') IS NOT NULL
BEGIN
    ALTER DATABASE BibliotekaDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE BibliotekaDB;
END
GO

CREATE DATABASE BibliotekaDB;
GO
	
USE BibliotekaDB;
GO
-- S£OWNIKI I TABELE NIEZALEZNE
-- Tabela rol/uprawnien
CREATE TABLE Uprawnienia (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nazwa NVARCHAR(50) NOT NULL UNIQUE
);
GO

-- Slownik kodow pocztowych i miejscowosci (Znormalizowane)
CREATE TABLE KodyPocztowe_Miejscowosci (
    ID INT PRIMARY KEY IDENTITY(1,1),
    KodPocztowy NVARCHAR(10) NOT NULL,
    Miejscowosc NVARCHAR(100) NOT NULL,
    CONSTRAINT UQ_Kod_Miejscowosc UNIQUE (KodPocztowy, Miejscowosc)
);
GO

-- Slownik gatunkow literackich
CREATE TABLE Gatunki (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nazwa NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- Slownik wydawnictw (Znormalizowane)
CREATE TABLE Wydawnictwa (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nazwa NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- Autorzy
CREATE TABLE Autorzy (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Imie NVARCHAR(50) NOT NULL,
    Nazwisko NVARCHAR(50) NOT NULL
);
GO

-- G£OWNE TABELE SYSTEMOWE
-- G³owna tabela uzytkownikow (Czytelnicy, Bibliotekarze, Administratorzy, Managerzy)
CREATE TABLE Uzytkownicy (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Login NVARCHAR(50) NOT NULL UNIQUE,
    HasloHash NVARCHAR(255) NOT NULL,
    Imie NVARCHAR(50) NOT NULL,
    Nazwisko NVARCHAR(50) NOT NULL,
    
    -- Adres powi¹zany relacyjnie
    MiejscowoscKodID INT NOT NULL,
    Ulica NVARCHAR(100) NULL,
    NumerPosesji NVARCHAR(20) NOT NULL,
    NumerLokalu NVARCHAR(20) NULL,
    
    -- Dane osobowe
    PESEL CHAR(11) NOT NULL UNIQUE,
    DataUrodzenia DATE NOT NULL,
    Plec CHAR(1) NOT NULL CHECK (Plec IN ('K', 'M')),
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Telefon VARCHAR(9) NOT NULL,

    -- Flagi systemowe i RODO
    CzyZapomniany BIT NOT NULL DEFAULT 0,
    CzyZablokowany BIT NOT NULL DEFAULT 0,
    LiczbaBlednychLogowan INT NOT NULL DEFAULT 0,
    CzasOdblokowania DATETIME NULL,
    
    CONSTRAINT FK_Uzytkownicy_KodyMiejscowosci FOREIGN KEY (MiejscowoscKodID) REFERENCES KodyPocztowe_Miejscowosci(ID)
);
GO

-- Sprawdzanie poprawnosci emaila
ALTER TABLE Uzytkownicy
ADD CONSTRAINT CHK_Email_Format CHECK (
    Email LIKE '%_@_%._%'  
    AND Email NOT LIKE '%@%@%'
    AND LEN(Email) <= 255
);
GO

-- Zaawansowane matematyczne sprawdzanie poprawnosci PESELu
ALTER TABLE Uzytkownicy
ADD CONSTRAINT CHK_Uzytkownicy_PESEL_Format CHECK (
    -- PESEL musi miec dokladnie 11 cyfr 
    PESEL LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    
    -- Walidacja plci: nieparzyste - M, parzyste/0 - K 
    AND (
        (Plec = 'M' AND CAST(SUBSTRING(PESEL, 10, 1) AS INT) % 2 <> 0) OR
        (Plec = 'K' AND CAST(SUBSTRING(PESEL, 10, 1) AS INT) % 2 = 0)
    )
    
    -- Walidacja daty urodzenia (pierwsze 6 cyfr RRMMDD) 
    AND SUBSTRING(PESEL, 1, 2) = RIGHT(CAST(YEAR(DataUrodzenia) AS VARCHAR), 2)
    AND (
        -- Obsluga osob urodzonych po roku 2000 (miesiac + 20)
        (YEAR(DataUrodzenia) >= 2000 AND CAST(SUBSTRING(PESEL, 3, 2) AS INT) = MONTH(DataUrodzenia) + 20) OR
        (YEAR(DataUrodzenia) < 2000 AND CAST(SUBSTRING(PESEL, 3, 2) AS INT) = MONTH(DataUrodzenia))
    )
    AND CAST(SUBSTRING(PESEL, 5, 2) AS INT) = DAY(DataUrodzenia)
);
GO

-- Tabela glowna katalogu ksiazek 
CREATE TABLE KatalogKsiazek (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Tytul NVARCHAR(255) NOT NULL,
    GatunekID INT NOT NULL,
    WydawnictwoID INT NOT NULL,
    LiczbaStron INT NOT NULL,
    RokWydania INT NOT NULL,
    Cena DECIMAL(10,2) NOT NULL,
    Opis NVARCHAR(MAX) NULL,
    CONSTRAINT FK_KatalogKsiazek_Gatunki FOREIGN KEY (GatunekID) REFERENCES Gatunki(ID),
    CONSTRAINT FK_KatalogKsiazek_Wydawnictwa FOREIGN KEY (WydawnictwoID) REFERENCES Wydawnictwa(ID)
);
GO

-- TABELE RELACYJNE I ZALE¯NE (POWI¥ZANIA)
-- Relacja N:M pomiêezy Uzytkownikami a Uprawnieniami
CREATE TABLE Uzytkownicy_Uprawnienia (
    UzytkownikID INT NOT NULL,
    UprawnienieID INT NOT NULL,
    PRIMARY KEY (UzytkownikID, UprawnienieID),
    CONSTRAINT FK_UzytUpraw_Uzytkownik FOREIGN KEY (UzytkownikID) REFERENCES Uzytkownicy(ID),
    CONSTRAINT FK_UzytUpraw_Uprawnienie FOREIGN KEY (UprawnienieID) REFERENCES Uprawnienia(ID)
);
GO

-- Relacja N:M pomiedzy Katalogiem a Autorami
CREATE TABLE KsiazkaKatalog_Autorzy (
    KsiazkaID INT NOT NULL,
    AutorID INT NOT NULL,
    PRIMARY KEY (KsiazkaID, AutorID),
    CONSTRAINT FK_KsiazkaAutor_Ksiazka FOREIGN KEY (KsiazkaID) REFERENCES KatalogKsiazek(ID),
    CONSTRAINT FK_KsiazkaAutor_Autor FOREIGN KEY (AutorID) REFERENCES Autorzy(ID)
);
GO

---- Tabela przechowujaca historie hasel
CREATE TABLE HistoriaHasel (
    ID INT PRIMARY KEY IDENTITY(1,1),
    UzytkownikID INT NOT NULL,
    HasloHash NVARCHAR(255) NOT NULL,
    DataZmiany DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_HistoriaHasel_Uzytkownicy FOREIGN KEY (UzytkownikID) REFERENCES Uzytkownicy(ID)
);
GO

-- Logi anonimizacji RODO
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

-- Tabela fizycznych egzemplarzy w bibliotece
CREATE TABLE Egzemplarze (
    ID INT PRIMARY KEY IDENTITY(1,1),
    KsiazkaID INT NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Dostepna' CHECK (Status IN ('Dostepna', 'Wypozyczona', 'Zniszczona', 'Zagubiona')),
    DataRejestracji DATETIME NOT NULL DEFAULT GETDATE(),
    ZarejestrowanePrzezID INT NOT NULL,
    CONSTRAINT FK_Egzemplarze_Katalog FOREIGN KEY (KsiazkaID) REFERENCES KatalogKsiazek(ID),
    CONSTRAINT FK_Egzemplarze_Bibliotekarz FOREIGN KEY (ZarejestrowanePrzezID) REFERENCES Uzytkownicy(ID)
);
GO

-- MODU£ WYPO¯YCZEÑ
-- Nag³ówek wypo¿yczenia
CREATE TABLE Wypozyczenia (
    ID INT PRIMARY KEY IDENTITY(1,1),
    CzytelnikID INT NOT NULL,
    BibliotekarzID INT NOT NULL,
    DataWypozyczenia DATETIME NOT NULL DEFAULT GETDATE(),
    OkresWypozyczeniaDni INT NOT NULL DEFAULT 14,
    OczekiwanaDataZwrotu DATETIME NOT NULL,
    DataZwrotu DATETIME NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Nowe' CHECK (Status IN ('Nowe', 'Przedluzone', 'Zakonczone')),
    CONSTRAINT FK_Wypozyczenia_Czytelnik FOREIGN KEY (CzytelnikID) REFERENCES Uzytkownicy(ID),
    CONSTRAINT FK_Wypozyczenia_Bibliotekarz FOREIGN KEY (BibliotekarzID) REFERENCES Uzytkownicy(ID)
);
GO

-- Pozycje wypozyczenia
CREATE TABLE PozycjeWypozyczenia (
    WypozyczenieID INT NOT NULL,
    EgzemplarzID INT NOT NULL,
    PRIMARY KEY (WypozyczenieID, EgzemplarzID),
    CONSTRAINT FK_PozycjeWypozyczenia_Wypozyczenie FOREIGN KEY (WypozyczenieID) REFERENCES Wypozyczenia(ID),
    CONSTRAINT FK_PozycjeWypozyczenia_Egzemplarz FOREIGN KEY (EgzemplarzID) REFERENCES Egzemplarze(ID)
);
GO

-- PROCEDURY SK£ADOWANE
CREATE PROCEDURE sp_ZanonimizujUzytkownika
    @TargetUzytkownikID INT,        
    @AdminID INT,                  
    @LosoweImie NVARCHAR(50),        
    @LosoweNazwisko NVARCHAR(50),    
    @LosowyPESEL CHAR(11),          
    @LosowaDataUr DATE,             
    @LosowaPlec CHAR(1) 
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- WARUNEK 1: Odbieranie wszystkich uprawnien 
        DELETE FROM Uzytkownicy_Uprawnienia
        WHERE UzytkownikID = @TargetUzytkownikID;

        -- WARUNEK 2: Ustawienie flagi i zmiana danych wrazliwych na losowe
        UPDATE Uzytkownicy
        SET Imie = @LosoweImie,
            Nazwisko = @LosoweNazwisko,
            PESEL = @LosowyPESEL,
            DataUrodzenia = @LosowaDataUr,
            Plec = @LosowaPlec,
            Email = CAST(NEWID() AS NVARCHAR(36)) + '@anonim.local', 
            HasloHash = 'ZABLOKOWANE', -- Trwale blokujemy mozliwosc logowania
            CzyZablokowany = 1,
            CzyZapomniany = 1
        WHERE ID = @TargetUzytkownikID;

        -- WARUNEK 3: Zapis do nowej tabeli LogiZapomnienia
        INSERT INTO LogiZapomnienia (ZanonimizowanyUzytkownikID, WykonalAdministratorID, DataAnonimizacji, Powod)
        VALUES (@TargetUzytkownikID, @AdminID, GETDATE(), 'Realizacja User Story: Anonimizacja RODO');

        -- Zakonczenie sukcesem 
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Jesli aplikacja podala zly PESEL i nasza walidacja go odrzuci, baza anuluje usuwanie uprawnien i logow
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO