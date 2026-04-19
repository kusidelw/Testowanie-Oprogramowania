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
    ('30-001', 'Krakow'),
    ('90-001', 'Lodz'),
    ('80-001', 'Gdansk'),
    ('60-001', 'Poznan'),
    ('50-001', 'Wroclaw'),
    ('30-100', 'Krakow'),
    ('91-200', '£Ûdü');
GO

-- dodanie uzytkownikow
INSERT INTO Uzytkownicy 
    (Login, HasloHash, Imie, Nazwisko, MiejscowoscKodID, NumerPosesji, PESEL, DataUrodzenia, Plec, Email, Telefon)
VALUES
    ('admin',         'Admin123!',   'Admin',      'Admin',      (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='91-200' AND Miejscowosc='£Ûdü'),     '12',  '03251753619', '2003-05-17', 'M', 'admin@mail.pl',             '123456789'),
    ('admin_kacper',  'Haslo123!',   'Kacper',     'Bednarek',   (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='00-001' AND Miejscowosc='Warszawa'), '10',  '95010111114', '1995-01-01', 'M', 'k.bednarek@biblioteka.pl',  '123456789'),
    ('biblio_natalia','Biblio123!',  'Natalia',    'Flaszka',    (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-001' AND Miejscowosc='Krakow'),   '5A',  '98020222223', '1998-02-02', 'K', 'n.flaszka@biblioteka.pl',   '987654321'),
    ('user_krystian', 'User123!',    'Krystian',   'Krynicki',   (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-001' AND Miejscowosc='Lodz'),     '12',  '90030333335', '1990-03-03', 'M', 'k.krynicki@poczta.pl',      '555666777'),
    ('maly_marek',    'Marek2005!',  'Marek',      'Nowak',      (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='80-001' AND Miejscowosc='Gdansk'),   '120', '05251555550', '2005-05-15', 'M', 'm.nowak@szkola.pl',         '600100200'),
    ('ksiazkowa_ola', 'Ola12345!',   'Aleksandra', 'Wisniewska', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='60-001' AND Miejscowosc='Poznan'),   '3/4', '10322444446', '2010-12-24', 'K', 'ola.w@domena.com',          '700800900'),
    ('babcia_stasia', 'Stasia55!',   'Stanislawa', 'Wojcik',     (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='50-001' AND Miejscowosc='Wroclaw'),  '15',  '55081011100', '1955-08-10', 'K', 's.wojcik@poczta.pl',        '500400300'),
    ('biblio_adam',   'AdamBiblio!', 'Adam',       'Kowalski',   (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-100' AND Miejscowosc='Krakow'),   '44',  '85112099999', '1985-11-20', 'M', 'a.kowalski@biblioteka.pl',  '666555444');
GO

-- Zapisanie hase≥ w tabeli historii
INSERT INTO HistoriaHasel (UzytkownikID, HasloHash)
SELECT ID, HasloHash FROM Uzytkownicy;
GO

-- przypisanie uprawnien (skorygowana, nowoczesna sk≥adnia)
INSERT INTO Uzytkownicy_Uprawnienia (UzytkownikID, UprawnienieID)
SELECT u.ID, p.ID FROM Uzytkownicy u CROSS JOIN Uprawnienia p WHERE u.Login = 'admin'          AND p.Nazwa = 'Administrator' UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u CROSS JOIN Uprawnienia p WHERE u.Login = 'admin_kacper'   AND p.Nazwa = 'Administrator' UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u CROSS JOIN Uprawnienia p WHERE u.Login = 'biblio_natalia' AND p.Nazwa = 'Bibliotekarz'  UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u CROSS JOIN Uprawnienia p WHERE u.Login = 'biblio_adam'    AND p.Nazwa = 'Bibliotekarz'  UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u CROSS JOIN Uprawnienia p WHERE u.Login = 'user_krystian'  AND p.Nazwa = 'Czytelnik'     UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u CROSS JOIN Uprawnienia p WHERE u.Login = 'maly_marek'     AND p.Nazwa = 'Czytelnik'     UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u CROSS JOIN Uprawnienia p WHERE u.Login = 'ksiazkowa_ola'  AND p.Nazwa = 'Czytelnik'     UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u CROSS JOIN Uprawnienia p WHERE u.Login = 'babcia_stasia'  AND p.Nazwa = 'Czytelnik';
GO

-- gatunki i autorzy
INSERT INTO Gatunki (Nazwa) 
VALUES ('Fantastyka'), ('Kryminal'), ('Literatura faktu'), ('Klasyka');
GO

INSERT INTO Autorzy (Imie, Nazwisko) 
VALUES ('Andrzej', 'Sapkowski'), ('Stephen', 'King'), ('Adam', 'Mickiewicz');
GO

-- wydawnictwa
INSERT INTO Wydawnictwa (Nazwa) 
VALUES ('SuperNova'), ('PWN');
GO

-- katalog ksiazek
INSERT INTO KatalogKsiazek (Tytul, GatunekID, WydawnictwoID, LiczbaStron, RokWydania, Cena, Opis)
VALUES
    ('Wiedzmin: Ostatnie Zyczenie', 
        (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), 
        (SELECT ID FROM Wydawnictwa WHERE Nazwa='SuperNova'), 
        320, 1993, 39.99, 'Zbior opowiadan o wiedzminie Geralcie.'),
    ('Pan Tadeusz',                  
        (SELECT ID FROM Gatunki WHERE Nazwa='Klasyka'),    
        (SELECT ID FROM Wydawnictwa WHERE Nazwa='PWN'),       
        450, 1834, 25.00, 'Epopeja narodowa.');
GO

-- powiazanie autorow z ksiazkami 
INSERT INTO KsiazkaKatalog_Autorzy (KsiazkaID, AutorID)
SELECT k.ID, a.ID FROM KatalogKsiazek k CROSS JOIN Autorzy a WHERE k.Tytul = 'Wiedzmin: Ostatnie Zyczenie' AND a.Nazwisko = 'Sapkowski'  UNION ALL
SELECT k.ID, a.ID FROM KatalogKsiazek k CROSS JOIN Autorzy a WHERE k.Tytul = 'Pan Tadeusz'                  AND a.Nazwisko = 'Mickiewicz';
GO

-- fizyczne egzemplarze
INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID)
VALUES
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul='Wiedzmin: Ostatnie Zyczenie'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul='Pan Tadeusz'),                  'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia'));
GO