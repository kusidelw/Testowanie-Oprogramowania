USE BibliotekaDB;
GO

-- uprawnienia
INSERT INTO Uprawnienia (Nazwa) 
VALUES ('Administrator'), ('Bibliotekarz'), ('Manager'), ('Czytelnik');
GO

-- kody pocztowe i miejscowosci
INSERT INTO KodyPocztowe_Miejscowosci (KodPocztowy, Miejscowosc) 
VALUES
    ('00-001', 'Warszawa'),
    ('30-001', 'Kraków'),
    ('80-001', 'Gdañsk'),
    ('60-001', 'Poznañ'),
    ('50-001', 'Wroc³aw'),
    ('30-100', 'Kraków'),
    ('90-290', '£ódŸ');
GO

-- dodanie uzytkownikow
INSERT INTO Uzytkownicy 
    (Login, HasloHash, Imie, Nazwisko, MiejscowoscKodID, NumerPosesji, PESEL, DataUrodzenia, Plec, Email, Telefon)
VALUES
    ('admin','Admin123!', 'Admin', 'Admin', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-290' AND Miejscowosc='£ódŸ'), '12', '03251753619', '2003-05-17', 'M', 'admin@mail.pl', '123456789'),
    ('admin_kacper', 'Haslo123!', 'Kacper', 'Bednarek', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='00-001' AND Miejscowosc='Warszawa'), '10', '95010111114', '1995-01-01', 'M', 'k.bednarek@biblioteka.pl', '123456789'),
    ('biblio_natalia', 'Biblio123!', 'Natalia', 'Flaszka', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-001' AND Miejscowosc='Kraków'), '5A', '98020222223', '1998-02-02', 'K', 'n.flaszka@biblioteka.pl', '987654321'),
    ('user_krystian', 'User123!', 'Krystian', 'Krynicki', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-290' AND Miejscowosc='£ódŸ'), '12', '90030333335', '1990-03-03', 'M', 'k.krynicki@poczta.pl', '555666777'),
    ('maly_marek', 'Marek2005!', 'Marek', 'Nowak', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='80-001' AND Miejscowosc='Gdañsk'), '120', '05251555550', '2005-05-15', 'M', 'm.nowak@szkola.pl', '600100200'),
    ('ksiazkowa_ola', 'Ola12345!', 'Aleksandra', 'Wisniewska', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='60-001' AND Miejscowosc='Poznañ'), '3/4', '10322444446', '2010-12-24', 'K', 'ola.w@domena.com', '700800900'),
    ('babcia_stasia', 'Stasia55!', 'Stanislawa', 'Wojcik', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='50-001' AND Miejscowosc='Wroc³aw'), '15', '55081011100', '1955-08-10', 'K', 's.wojcik@poczta.pl', '500400300'),
    ('biblio_ania', 'AdamBiblio!', 'Ania', 'Kowalska', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-100' AND Miejscowosc='Kraków'), '54', '84112064226', '1984-11-20', 'K', 'a.kowalska@biblioteka.pl', '666555444'),
	('biblio_adam', 'AdamBiblio!', 'Adam', 'Kowalski', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-100' AND Miejscowosc='Kraków'), '44', '85112099999', '1985-11-20', 'M', 'a.kowalski@biblioteka.pl', '666555444'),
	('login123', 'TestoweHaslo123!', 'Marek', 'Testowy', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-290' AND Miejscowosc='£ódŸ'), '25/2', '99010108970', '1999-01-01', 'M', 'marek123@poczta.pl', '522728351');
GO

-- Zapisanie hase³ w tabeli historii
INSERT INTO HistoriaHasel (UzytkownikID, HasloHash)
SELECT ID, HasloHash FROM Uzytkownicy;
GO

-- przypisanie uprawnien (skorygowana, nowoczesna sk³adnia)
INSERT INTO Uzytkownicy_Uprawnienia (UzytkownikID, UprawnienieID)
VALUES 
-- Administratorzy
((SELECT ID FROM Uzytkownicy WHERE Login = 'admin'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Administrator')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'admin_kacper'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Administrator')),
-- Bibliotekarze
((SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_natalia'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Bibliotekarz')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_adam'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Bibliotekarz')),
-- Czytelnicy
((SELECT ID FROM Uzytkownicy WHERE Login = 'user_krystian'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'maly_marek'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
-- Managerowie
((SELECT ID FROM Uzytkownicy WHERE Login = 'ksiazkowa_ola'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Manager')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_ania'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Manager')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'babcia_stasia'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Manager'));
GO

-- gatunki i autorzy
INSERT INTO Gatunki (Nazwa) 
VALUES ('Fantastyka'), ('Krymina³'), ('Literatura faktu'), ('Klasyka');
GO

INSERT INTO Autorzy (Imie, Nazwisko) 
VALUES ('Andrzej', 'Sapkowski'), ('Stephen', 'King'), ('Adam', 'Mickiewicz'), ('J.K.', 'Rowling');
GO

-- wydawnictwa
INSERT INTO Wydawnictwa (Nazwa) 
VALUES ('SuperNova'), ('PWN'), ('Media Rodzina');
GO

-- katalog ksiazek
INSERT INTO KatalogKsiazek (Tytul, GatunekID, WydawnictwoID, LiczbaStron, RokWydania, Cena, Opis)
VALUES
    ('WiedŸmin: Ostatnie ¯yczenie', 
        (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), 
        (SELECT ID FROM Wydawnictwa WHERE Nazwa='SuperNova'), 
        320, 1993, 39.99, 'Zbiór opowiadañ o wiedzminie Geralcie.'),
    ('Pan Tadeusz',                  
        (SELECT ID FROM Gatunki WHERE Nazwa='Klasyka'),    
        (SELECT ID FROM Wydawnictwa WHERE Nazwa='PWN'),       
        450, 1834, 25.00, 'Epopeja narodowa.'),
    ('Harry Potter i kamieñ filozoficzny. Tom 1',
        (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), 
        (SELECT ID FROM Wydawnictwa WHERE Nazwa='Media Rodzina'), 
        328, 2016, 31.99, 'Harry Potter i kamieñ filozoficzny. Tom 1'), 
    ('Harry Potter i Komnata Tajemnic. Tom 2',
        (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), 
        (SELECT ID FROM Wydawnictwa WHERE Nazwa='Media Rodzina'), 
        328, 2018, 31.99, 'Harry Potter i Komnata Tajemnic. Tom 2'); 
GO

-- powiazanie autorow z ksiazkami 
INSERT INTO KsiazkaKatalog_Autorzy (KsiazkaID, AutorID)
VALUES 
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'WiedŸmin: Ostatnie ¯yczenie'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Sapkowski')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Pan Tadeusz'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Mickiewicz')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Harry Potter i kamieñ filozoficzny. Tom 1'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Rowling')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Harry Potter i Komnata Tajemnic. Tom 2'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Rowling')
);
GO

-- fizyczne egzemplarze
INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID)
VALUES
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul='WiedŸmin: Ostatnie ¯yczenie'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul='Pan Tadeusz'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia')),
	((SELECT ID FROM KatalogKsiazek WHERE Tytul ='Harry Potter i kamieñ filozoficzny. Tom 1'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_ania')),
	((SELECT ID FROM KatalogKsiazek WHERE Tytul ='Harry Potter i Komnata Tajemnic. Tom 2'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_ania')
);
GO