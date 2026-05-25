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
	('20-001', 'Lublin'),
    ('70-001', 'Szczecin'),
    ('85-001', 'Bydgoszcz'),
    ('15-001', 'Białystok'),
    ('40-001', 'Katowice'),
    ('81-300', 'Gdynia'),
    ('42-200', 'Częstochowa'),
    ('25-001', 'Kielce'),
    ('30-001', 'Kraków'),
    ('80-001', 'Gdańsk'),
    ('60-001', 'Poznań'),
    ('50-001', 'Wrocław'),
    ('30-100', 'Kraków'),
    ('90-290', 'Łódź');
GO

-- dodanie uzytkownikow
INSERT INTO Uzytkownicy 
    (Login, HasloHash, Imie, Nazwisko, MiejscowoscKodID, NumerPosesji, PESEL, DataUrodzenia, Plec, Email, Telefon)
VALUES
    ('admin','Admin123!', 'Admin', 'Admin', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-290' AND Miejscowosc='Łódź'), '12', '03251753619', '2003-05-17', 'M', 'admin@mail.pl', '123456789'),
    ('admin_kacper', 'Haslo123!', 'Kacper', 'Bednarek', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='00-001' AND Miejscowosc='Warszawa'), '10', '95010111114', '1995-01-01', 'M', 'k.bednarek@biblioteka.pl', '123456789'),
    ('biblio_natalia', 'Biblio123!', 'Natalia', 'Flaszka', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-001' AND Miejscowosc='Kraków'), '5A', '98020222223', '1998-02-02', 'K', 'n.flaszka@biblioteka.pl', '987654321'),
    ('user_krystian', 'User123!', 'Krystian', 'Krynicki', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-290' AND Miejscowosc='Łódź'), '12', '90030333335', '1990-03-03', 'M', 'k.krynicki@poczta.pl', '555666777'),
    ('maly_marek', 'Marek2005!', 'Marek', 'Nowak', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='80-001' AND Miejscowosc='Gdańsk'), '120', '05251555550', '2005-05-15', 'M', 'm.nowak@szkola.pl', '600100200'),
    ('ksiazkowa_ola', 'Ola12345!', 'Aleksandra', 'Wisniewska', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='60-001' AND Miejscowosc='Poznań'), '3/4', '10322444446', '2010-12-24', 'K', 'ola.w@domena.com', '700800900'),
    ('user_jan', 'Haslo123!', 'Jan', 'Kowalski', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='20-001' AND Miejscowosc='Lublin'), '10', '80010112319', '1980-01-01', 'M', 'jan@poczta.pl', '111222333'),
    ('user_ewa', 'Mucha1981!', 'Ewa', 'Nowak', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='70-001' AND Miejscowosc='Szczecin'), '20', '81020212321', '1981-02-02', 'K', 'ewa@poczta.pl', '222333444'),
    ('wisnia1982', 'HasloHash23!', 'Piotr', 'Wisniewski', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='85-001' AND Miejscowosc='Bydgoszcz'), '30', '82030312333', '1982-03-03', 'M', 'piotr@poczta.pl', '333444555'),
    ('anna_woj', 'Haslo4!', 'Anna', 'Wojcik', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='15-001' AND Miejscowosc='Białystok'), '40', '83040412345', '1983-04-04', 'K', 'anna@poczta.pl', '444555666'),
    ('kamyk_krzysztof', 'Kamyczek25!', 'Krzysztof', 'Kamyk', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='40-001' AND Miejscowosc='Katowice'), '50', '84050512357', '1984-05-05', 'M', 'krzysztof@poczta.pl', '555666777'),
    ('babcia_stasia', 'Stasia55!', 'Stanislawa', 'Wojcik', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='50-001' AND Miejscowosc='Wrocław'), '15', '55081011100', '1955-08-10', 'K', 's.wojcik@poczta.pl', '500400300'),
    ('biblio_ania', 'AdamBiblio!', 'Ania', 'Kowalska', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-100' AND Miejscowosc='Kraków'), '54', '84112064226', '1984-11-20', 'K', 'a.kowalska@biblioteka.pl', '666555444'),
    ('biblio_adam', 'AdamBiblio!', 'Adam', 'Kowalski', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-100' AND Miejscowosc='Kraków'), '44', '85112099999', '1985-11-20', 'M', 'a.kowalski@biblioteka.pl', '666555444'),
    ('login123', 'TestoweHaslo123!', 'Marek', 'Testowy', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-290' AND Miejscowosc='Łódź'), '25/2', '99010108970', '1999-01-01', 'M', 'marek123@poczta.pl', '522728351');
GO

-- Zapisanie haseł w tabeli historii
INSERT INTO HistoriaHasel (UzytkownikID, HasloHash)
SELECT ID, HasloHash FROM Uzytkownicy;
GO

-- przypisanie uprawnien
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
((SELECT ID FROM Uzytkownicy WHERE Login = 'user_jan'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'user_ewa'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'wisnia1982'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'anna_woj'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'kamyk_krzysztof'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
-- Managerowie
((SELECT ID FROM Uzytkownicy WHERE Login = 'ksiazkowa_ola'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Manager')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_ania'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Manager')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'babcia_stasia'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Manager'));
GO

-- gatunki i autorzy
INSERT INTO Gatunki (Nazwa) 
VALUES ('Fantastyka'), ('Kryminał'), ('Literatura faktu'), ('Klasyka'), ('Horror'), ('Romans'), ('Thriller'), ('Biografia'), ('Poezja'), 
    ('Dramat'), ('Sci-Fi'), ('Poradnik'), ('Literatura dziecięca'), ('Esej'), ('Reportaż');
GO

INSERT INTO Autorzy (Imie, Nazwisko) 
VALUES ('Andrzej', 'Sapkowski'), ('Stephen', 'King'), ('Adam', 'Mickiewicz'), ('J.K.', 'Rowling'), ('Bolesław', 'Prus'), ('Henryk', 'Sienkiewicz'), 
	('Stanisław', 'Lem'), ('Remigiusz', 'Mróz'), ('Olga', 'Tokarczuk'), ('George R.R.', 'Martin'), ('J.R.R.', 'Tolkien'), ('Agatha', 'Christie'), 
	('Stephenie', 'Meyer'), ('Dan', 'Brown'), ('Terry', 'Pratchett');
GO

-- wydawnictwa
INSERT INTO Wydawnictwa (Nazwa) 
VALUES ('SuperNova'), ('PWN'), ('Media Rodzina'), ('Znak'), ('Czarna Owca'), ('Prószyński i S-ka'), ('Fabryka Słów'), 
    ('Albatros'), ('Wydawnictwo Literackie'), ('Rebis'), ('Świat Książki'), ('Nasza Księgarnia'), ('Zysk i S-ka'), 
	('Helion'), ('Sonia Draga');
GO

-- katalog ksiazek
INSERT INTO KatalogKsiazek (Tytul, GatunekID, WydawnictwoID, LiczbaStron, RokWydania, Cena, Opis)
VALUES
    ('Wiedźmin: Ostatnie Życzenie', (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='SuperNova'), 320, 1993, 39.99, 'Zbiór opowiadań o wiedzminie Geralcie.'),
    ('Pan Tadeusz', (SELECT ID FROM Gatunki WHERE Nazwa='Klasyka'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='PWN'), 450, 1834, 25.00, 'Epopeja narodowa.'),
    ('Harry Potter i kamień filozoficzny. Tom 1', (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Media Rodzina'), 328, 2016, 31.99, 'Harry Potter i kamień filozoficzny. Tom 1'), 
    ('Harry Potter i Komnata Tajemnic. Tom 2', (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Media Rodzina'), 328, 2018, 31.99, 'Harry Potter i Komnata Tajemnic. Tom 2'),
	('Lalka', (SELECT ID FROM Gatunki WHERE Nazwa='Klasyka'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Znak'), 680, 1890, 35.00, 'Powieść społeczno-obyczajowa.'),
    ('Quo Vadis', (SELECT ID FROM Gatunki WHERE Nazwa='Klasyka'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Znak'), 550, 1896, 40.00, 'Powieść historyczna.'),
    ('Solaris', (SELECT ID FROM Gatunki WHERE Nazwa='Sci-Fi'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Wydawnictwo Literackie'), 300, 1961, 29.99, 'Klasyka science fiction.'),
    ('Kasacja', (SELECT ID FROM Gatunki WHERE Nazwa='Kryminał'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Czarna Owca'), 400, 2015, 34.99, 'Thriller prawniczy.'),
    ('Bieguni', (SELECT ID FROM Gatunki WHERE Nazwa='Literatura faktu'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Wydawnictwo Literackie'), 450, 2007, 39.99, 'Powieść uhonorowana nagrodą Nobla.'),
    ('Gra o tron', (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Zysk i S-ka'), 800, 1996, 49.99, 'Pierwszy tom sagi Pieśń Lodu i Ognia.'),
    ('Hobbit', (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Rebis'), 300, 1937, 25.99, 'Powieść fantasy dla młodzieży.'),
    ('Morderstwo w Orient Expressie', (SELECT ID FROM Gatunki WHERE Nazwa='Kryminał'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Albatros'), 250, 1934, 20.00, 'Klasyczny kryminał.'),
    ('Zmierzch', (SELECT ID FROM Gatunki WHERE Nazwa='Romans'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Świat Książki'), 400, 2005, 29.90, 'Romans paranormalny.'),
    ('Kod da Vinci', (SELECT ID FROM Gatunki WHERE Nazwa='Thriller'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Albatros'), 500, 2003, 35.50, 'Thriller spiskowy.'),
    ('Kolor magii', (SELECT ID FROM Gatunki WHERE Nazwa='Fantastyka'), (SELECT ID FROM Wydawnictwa WHERE Nazwa='Prószyński i S-ka'), 280, 1983, 24.99, 'Pierwsza książka ze Świata Dysku.');
GO

-- powiazanie autorow z ksiazkami 
INSERT INTO KsiazkaKatalog_Autorzy (KsiazkaID, AutorID)
VALUES 
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Wiedźmin: Ostatnie Życzenie'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Sapkowski')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Pan Tadeusz'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Mickiewicz')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Harry Potter i kamień filozoficzny. Tom 1'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Rowling')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Harry Potter i Komnata Tajemnic. Tom 2'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Rowling')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Lalka'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Prus')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Quo Vadis'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Sienkiewicz')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Solaris'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Lem')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Kasacja'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Mróz')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Bieguni'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Tokarczuk')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Gra o tron'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Martin')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Hobbit'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Tolkien')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Morderstwo w Orient Expressie'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Christie')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Zmierzch'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Meyer')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Kod da Vinci'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Brown')),
((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Kolor magii'), (SELECT ID FROM Autorzy WHERE Nazwisko = 'Pratchett'));
GO

-- fizyczne egzemplarze
INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID)
VALUES
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul='Wiedźmin: Ostatnie Życzenie'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul='Pan Tadeusz'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia')),
	((SELECT ID FROM KatalogKsiazek WHERE Tytul ='Harry Potter i kamień filozoficzny. Tom 1'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_ania')),
	((SELECT ID FROM KatalogKsiazek WHERE Tytul ='Harry Potter i Komnata Tajemnic. Tom 2'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_ania')),
	((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Lalka'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_natalia')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Quo Vadis'), 'Wypozyczona', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_ania')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Solaris'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_adam')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Kasacja'), 'Wypozyczona', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_natalia')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Bieguni'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_ania')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Gra o tron'), 'Wypozyczona', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_adam')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Hobbit'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_natalia')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Morderstwo w Orient Expressie'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_ania')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Zmierzch'), 'Wypozyczona', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_adam')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Kod da Vinci'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_natalia')),
    ((SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Kolor magii'), 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login = 'biblio_ania'));
GO

-- konta zapomniane (zanonimizowane)
DECLARE @TargetID INT = (SELECT ID FROM Uzytkownicy WHERE Login = 'ksiazkowa_ola');
DECLARE @AdminID INT = (SELECT ID FROM Uzytkownicy WHERE Login = 'admin');

EXEC sp_ZanonimizujUzytkownika
    @TargetUzytkownikID = @TargetID,
    @AdminID = @AdminID,
    @LosoweImie = 'Anonim',
    @LosoweNazwisko = 'Anonimowy',
    @LosowyPESEL = '80051512345', 
    @LosowaDataUr = '1980-05-15',
    @LosowaPlec = 'K';
GO
