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
    
    FOREIGN KEY (ZapomnianyPrzezUzytkownikaID) REFERENCES Uzytkownicy(ID)
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
    Status NVARCHAR(50) NOT NULL DEFAULT 'Dostêpna' CHECK (Status IN ('Dostêpna', 'Wypo¿yczona', 'Zniszczona', 'Zagubiona')),
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
    Status NVARCHAR(50) NOT NULL DEFAULT 'Nowe' CHECK (Status IN ('Nowe', 'Przed³u¿one', 'Zakoñczone')),
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

