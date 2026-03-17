USE BibliotekaDB;
GO

-- uprawnienia
INSERT INTO Uprawnienia (Nazwa) VALUES ('Administrator'), ('Bibliotekarz'), ('Manager'), ('Czytelnik');
GO

-- dodanie u¿ytkownikow
INSERT INTO Uzytkownicy (Login, HasloHash, Imie, Nazwisko, Miejscowosc, KodPocztowy, NumerPosesji, PESEL, DataUrodzenia, Plec, Email, Telefon)
VALUES
('admin_kacper', 'Haslo123!', 'Kacper', 'Bednarek', 'Warszawa', '00-001', '10', '95010111111', '1995-01-01', 'M', 'k.bednarek@biblioteka.pl', '123456789'),
('biblio_natalia', 'Biblio123!', 'Natalia', 'Flaszka', 'Kraków', '30-001', '5A', '98020222222', '1998-02-02', 'K', 'n.flaszka@biblioteka.pl', '987654321'),
('user_krystian', 'User123!', 'Krystian', 'Krynicki', '£ódŸ', '90-001', '12', '90030333333', '1990-03-03', 'M', 'k.krynicki@poczta.pl', '555666777'),
('maly_marek', 'Marek2005!', 'Marek', 'Nowak', 'Gdañsk', '80-001', '120', '05251555557', '2005-05-15', 'M', 'm.nowak@szkola.pl', '600100200'),
('ksiazkowa_ola', 'Ola12345!', 'Aleksandra', 'Wisniewska', 'Poznañ', '60-001', '3/4', '10322444444', '2010-12-24', 'K', 'ola.w@domena.com', '700800900'),
('babcia_stasia', 'Stasia55!', 'Stanislawa', 'Wojcik', 'Wroc³aw', '50-001', '15', '55081011100', '1955-08-10', 'K', 's.wojcik@poczta.pl', '500400300'),
('biblio_adam', 'AdamBiblio!', 'Adam', 'Kowalski', 'Kraków', '30-100', '44', '85112099999', '1985-11-20', 'M', 'a.kowalski@biblioteka.pl', '666555444');
GO

-- przypisanie uprawnien do uzytkownikow
INSERT INTO Uzytkownicy_Uprawnienia (UzytkownikID, UprawnienieID)
SELECT u.ID, p.ID FROM Uzytkownicy u, Uprawnienia p WHERE u.Login = 'admin_kacper' AND p.Nazwa = 'Administrator' UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u, Uprawnienia p WHERE u.Login = 'biblio_natalia' AND p.Nazwa = 'Bibliotekarz' UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u, Uprawnienia p WHERE u.Login = 'biblio_adam' AND p.Nazwa = 'Bibliotekarz' UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u, Uprawnienia p WHERE u.Login = 'user_krystian' AND p.Nazwa = 'Czytelnik' UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u, Uprawnienia p WHERE u.Login = 'maly_marek' AND p.Nazwa = 'Czytelnik' UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u, Uprawnienia p WHERE u.Login = 'ksiazkowa_ola' AND p.Nazwa = 'Czytelnik' UNION ALL
SELECT u.ID, p.ID FROM Uzytkownicy u, Uprawnienia p WHERE u.Login = 'babcia_stasia' AND p.Nazwa = 'Czytelnik';
GO

-- dodawanie katalogu ksiazek
IF NOT EXISTS (SELECT 1 FROM Gatunki WHERE Nazwa = 'Fantastyka')
INSERT INTO Gatunki (Nazwa) VALUES ('Fantastyka'), ('Krymina³'), ('Literatura faktu'), ('Klasyka');
GO

INSERT INTO Autorzy (Imie, Nazwisko) VALUES ('Andrzej', 'Sapkowski'), ('Stephen', 'King'), ('Adam', 'Mickiewicz');
GO

--przykladowe ksiazki
INSERT INTO KatalogKsiazek (Tytul, GatunekID, LiczbaStron, Wydawnictwo, RokWydania, Cena, Opis)
VALUES 
('WiedŸmin: Ostatnie ¯yczenie', (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), 320, 'SuperNova', 1993, 39.99, 'Zbiór opowiadañ o wiedŸminie Geralcie.'),
('Pan Tadeusz', (SELECT ID FROM Gatunki WHERE Nazwa='Klasyka'), 450, 'PWN', 1834, 25.00, 'Epopeja narodowa.');
GO

-- powiazanie autorow z ksiazkami
INSERT INTO KsiazkKatalog_Autorzy (KsiazkaID, AutorID) 
SELECT k.ID, a.ID FROM KatalogKsiazek k, Autorzy a WHERE k.Tytul = 'WiedŸmin: Ostatnie ¯yczenie' AND a.Nazwisko = 'Sapkowski' UNION ALL
SELECT k.ID, a.ID FROM KatalogKsiazek k, Autorzy a WHERE k.Tytul = 'Pan Tadeusz' AND a.Nazwisko = 'Mickiewicz';
GO

-- fizyczne egzemplarze - sztuki dostepne w bibliotece
INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID)
VALUES 
((SELECT ID FROM KatalogKsiazek WHERE Tytul='WiedŸmin: Ostatnie ¯yczenie'), 'Dostêpna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul='Pan Tadeusz'), 'Dostêpna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia'));
GO

