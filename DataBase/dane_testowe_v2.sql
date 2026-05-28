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
    (Login, HasloHash, Imie, Nazwisko, MiejscowoscKodID, Ulica, NumerPosesji, NumerLokalu, PESEL, DataUrodzenia, Plec, Email, Telefon)
VALUES
    ('admin','Admin123!', 'Admin', 'Admin', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-290' AND Miejscowosc='Łódź'), 'Piotrkowska', '12', NULL, '03251753619', '2003-05-17', 'M', 'admin@mail.pl', '123456789'),
    ('admin_kacper', 'Haslo123!', 'Kacper', 'Bednarek', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='00-001' AND Miejscowosc='Warszawa'), 'Marszałkowska', '10', NULL, '95010111114', '1995-01-01', 'M', 'k.bednarek@biblioteka.pl', '123456789'),
    ('biblio_natalia', 'Biblio123!', 'Natalia', 'Flaszka', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-001' AND Miejscowosc='Kraków'), 'Floriańska', '5A', NULL, '98020222223', '1998-02-02', 'K', 'n.flaszka@biblioteka.pl', '987654321'),
    ('user_krystian', 'User123!', 'Krystian', 'Krynicki', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-290' AND Miejscowosc='Łódź'), 'Zachodnia', '12', NULL, '90030333335', '1990-03-03', 'M', 'k.krynicki@poczta.pl', '555666777'),
    ('maly_marek', 'Marek2005!', 'Marek', 'Nowak', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='80-001' AND Miejscowosc='Gdańsk'), 'Długa', '120', NULL, '05251555550', '2005-05-15', 'M', 'm.nowak@szkola.pl', '600100200'),
    ('ksiazkowa_ola', 'Ola12345!', 'Aleksandra', 'Wisniewska', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='60-001' AND Miejscowosc='Poznań'), 'Półwiejska', '3', '4', '10322444446', '2010-12-24', 'K', 'ola.w@domena.com', '700800900'),
    ('user_jan', 'Haslo123!', 'Jan', 'Kowalski', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='20-001' AND Miejscowosc='Lublin'), 'Krakowskie Przedmieście', '10', NULL, '80010112319', '1980-01-01', 'M', 'jan@poczta.pl', '111222333'),
    ('user_ewa', 'Mucha1981!', 'Ewa', 'Nowak', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='70-001' AND Miejscowosc='Szczecin'), 'Wojska Polskiego', '20', NULL, '81020212321', '1981-02-02', 'K', 'ewa@poczta.pl', '222333444'),
    ('wisnia1982', 'HasloHash23!', 'Piotr', 'Wisniewski', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='85-001' AND Miejscowosc='Bydgoszcz'), 'Gdańska', '30', NULL, '82030312333', '1982-03-03', 'M', 'piotr@poczta.pl', '333444555'),
    ('anna_woj', 'Haslo4!', 'Anna', 'Wojcik', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='15-001' AND Miejscowosc='Białystok'), 'Lipowa', '40', NULL, '83040412345', '1983-04-04', 'K', 'anna@poczta.pl', '444555666'),
    ('kamyk_krzysztof', 'Kamyczek25!', 'Krzysztof', 'Kamyk', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='40-001' AND Miejscowosc='Katowice'), 'Stawowa', '50', NULL, '84050512357', '1984-05-05', 'M', 'krzysztof@poczta.pl', '555666777'),
    ('babcia_stasia', 'Stasia55!', 'Stanislawa', 'Wojcik', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='50-001' AND Miejscowosc='Wrocław'), 'Świdnicka', '15', NULL, '55081011100', '1955-08-10', 'K', 's.wojcik@poczta.pl', '500400300'),
    ('biblio_ania', 'AdamBiblio!', 'Ania', 'Kowalska', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-100' AND Miejscowosc='Kraków'), 'Grodzka', '54', NULL, '84112064226', '1984-11-20', 'K', 'a.kowalska@biblioteka.pl', '666555444'),
    ('biblio_adam', 'AdamBiblio!', 'Adam', 'Kowalski', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-100' AND Miejscowosc='Kraków'), 'Sukiennicza', '44', NULL, '85112099999', '1985-11-20', 'M', 'a.kowalski@biblioteka.pl', '666555444'),
	('t.kowal', 'Haslo123!', 'Tomasz', 'Kowal', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='00-001' AND Miejscowosc='Warszawa'), 'Emilii Plater', '15', NULL, '92051299951', '1992-05-12', 'M', 't.kowal2@biblioteka.pl', '501202303'),
    ('nowak_m', 'Haslo123!', 'Monika', 'Nowak', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='30-001' AND Miejscowosc='Kraków'), 'Basztowa', '4', '12', '94082211149', '1994-08-22', 'K', 'nowak.m@biblioteka.pl', '502303404'),
    ('karolw', 'Haslo123!', 'Karol', 'Wiśniewski', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-290' AND Miejscowosc='Łódź'), 'Zachodnia', '88', NULL, '88110522273', '1988-11-05', 'M', 'karol.w@biblioteka.pl', '503404505'),
    ('wojcik.marta', 'Haslo123!', 'Marta', 'Wójcik', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='60-001' AND Miejscowosc='Poznań'), 'Fredry', '12', NULL, '01221433327', '2001-02-14', 'K', 'marta.w@biblioteka.pl', '504504606'),
    ('pkaminski', 'Haslo123!', 'Piotr', 'Kamiński', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='50-001' AND Miejscowosc='Wrocław'), 'Oławska', '23', '5', '90073088835', '1990-07-30', 'M', 'p.kaminski2@biblioteka.pl', '505606707'),
	('zielen85', 'User123!', 'Marcin', 'Zieliński', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='80-001' AND Miejscowosc='Gdańsk'), 'Grunwaldzka', '45', NULL, '85032544417', '1985-03-25', 'M', 'zielen85@poczta.pl', '601111222'),
    ('agacia_w', 'User123!', 'Agata', 'Woźniak', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='70-001' AND Miejscowosc='Szczecin'), 'Krzywoustego', '3', '9', '99101066688', '1999-10-10', 'K', 'agacia.w@poczta.pl', '602222333'),
    ('kodziu02', 'User123!', 'Łukasz', 'Kozłowski', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='20-001' AND Miejscowosc='Lublin'), 'Lipowa', '12', NULL, '02261877739', '2002-06-18', 'M', 'kodziu02@poczta.pl', '603333444'),
    ('mazurkasia93', 'User123!', 'Katarzyna', 'Mazur', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='40-001' AND Miejscowosc='Katowice'), 'Korfantego', '50', NULL, '93120155544', '1993-12-01', 'K', 'k.mazur93@poczta.pl', '604444555'),
    ('bartekkaczmarek', 'User123!', 'Bartosz', 'Kaczmarek', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='15-001' AND Miejscowosc='Białystok'), 'Sienkiewicza', '7', '2', '05290966657', '2005-09-09', 'M', 'bartek.kaczmarek@poczta.pl', '605555666'),
    ('login123', 'TestoweHaslo123!', 'Marek', 'Testowy', (SELECT ID FROM KodyPocztowe_Miejscowosci WHERE KodPocztowy='90-290' AND Miejscowosc='Łódź'), NULL, '25', '2', '99010108970', '1999-01-01', 'M', 'marek123@poczta.pl', '522728351');
GO

-- Symulacja starego hasla dla usera
INSERT INTO HistoriaHasel (UzytkownikID, HasloHash)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login = 'user_krystian'), 'StareHasloKrystiana1!');
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
((SELECT ID FROM Uzytkownicy WHERE Login = 't.kowal'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Bibliotekarz')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'nowak_m'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Bibliotekarz')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'karolw'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Bibliotekarz')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'wojcik.marta'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Bibliotekarz')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'pkaminski'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Bibliotekarz')),
-- Czytelnicy
((SELECT ID FROM Uzytkownicy WHERE Login = 'user_krystian'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'maly_marek'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'user_jan'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'user_ewa'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'wisnia1982'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'anna_woj'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'login123'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'kamyk_krzysztof'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'zielen85'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'agacia_w'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'kodziu02'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'mazurkasia93'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
((SELECT ID FROM Uzytkownicy WHERE Login = 'bartekkaczmarek'), (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')),
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
    @LosoweImie = 'qqmeswrm',
    @LosoweNazwisko = 'qqmeswrmtx',
    @LosowyPESEL = '64120929364', 
    @LosowaDataUr = '1964-12-09',
    @LosowaPlec = 'K';
GO

-- dodanie roli czytelnik użytkownikowi 'login123'
IF NOT EXISTS (
    SELECT 1 FROM Uzytkownicy_Uprawnienia 
    WHERE UzytkownikID = (SELECT ID FROM Uzytkownicy WHERE Login = 'login123')
      AND UprawnienieID = (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')
)
BEGIN
    INSERT INTO Uzytkownicy_Uprawnienia (UzytkownikID, UprawnienieID)
    VALUES (
        (SELECT ID FROM Uzytkownicy WHERE Login = 'login123'),
        (SELECT ID FROM Uprawnienia WHERE Nazwa = 'Czytelnik')
    );
END
GO

-- zmiana hasła na 'juz zmienione'
UPDATE Uzytkownicy
SET CzyPierwszeLogowanie = 0
WHERE Login IN ('user_krystian', 'admin', 'biblio_natalia');
GO

-- Dodanie egzemplarzy 
INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID)
SELECT ID, 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia')
FROM KatalogKsiazek 
WHERE Tytul IN (
    'Wiedźmin: Ostatnie Życzenie', 
    'Harry Potter i kamień filozoficzny. Tom 1', 
    'Hobbit', 
    'Pan Tadeusz',
    'Lalka'
);
GO

INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID)
SELECT ID, 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_adam')
FROM KatalogKsiazek 
WHERE Tytul IN (
    'Wiedźmin: Ostatnie Życzenie', 
    'Harry Potter i kamień filozoficzny. Tom 1', 
    'Harry Potter i Komnata Tajemnic. Tom 2',
    'Hobbit', 
    'Solaris'
);
GO

INSERT INTO Egzemplarze (KsiazkaID, Status, ZarejestrowanePrzezID)
SELECT ID, 'Dostepna', (SELECT ID FROM Uzytkownicy WHERE Login='biblio_ania')
FROM KatalogKsiazek 
WHERE Tytul IN (
    'Morderstwo w Orient Expressie', 
    'Kod da Vinci', 
    'Bieguni'
);
GO

-- inserty z  przykładowymi wypożyczeniami
DECLARE @WypozyczenieID INT;
DECLARE @EgzemplarzID INT;

-- 1. Zwykłe  - termin w przyszłości
SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Pan Tadeusz');
UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EgzemplarzID;

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='login123'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_ania'), DATEADD(day, -5, GETDATE()), 14, DATEADD(day, 9, GETDATE()), 'Nowe');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Pan Tadeusz');
UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EgzemplarzID;

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, Status) 
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='zielen85'), (SELECT ID FROM Uzytkownicy WHERE Login='t.kowal'), DATEADD(day, -3, GETDATE()), 14, DATEADD(day, 11, GETDATE()), 'Nowe');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

-- 2. Na dzisiaj - termin wypada dziś
SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Hobbit');
UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EgzemplarzID;

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='user_ewa'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia'), DATEADD(day, -14, GETDATE()), 14, GETDATE(), 'Nowe');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

-- 3. Przeterminowane - brak zwrotu
SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Solaris');
UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EgzemplarzID;

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='user_krystian'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_adam'), DATEADD(day, -20, GETDATE()), 14, DATEADD(day, -6, GETDATE()), 'Nowe');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

-- 4. Przedłużone - w terminie
SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Lalka');
UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EgzemplarzID;

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='maly_marek'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_ania'), DATEADD(day, -15, GETDATE()), 30, DATEADD(day, 15, GETDATE()), 'Przedluzone');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Hobbit');
UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EgzemplarzID;

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, Status) 
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='kodziu02'), (SELECT ID FROM Uzytkownicy WHERE Login='karolw'), DATEADD(day, -20, GETDATE()), 30, DATEADD(day, 10, GETDATE()), 'Przedluzone');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);


-- 5. Przedłużone, przeterminowane - brak zwrotu
SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Kod da Vinci');
UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EgzemplarzID;

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='user_jan'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia'), DATEADD(day, -40, GETDATE()), 30, DATEADD(day, -10, GETDATE()), 'Przedluzone');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

-- 6. Zakończone w terminie (Zakonczone)
SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Wiedźmin: Ostatnie Życzenie');

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, DataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='wisnia1982'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_adam'), DATEADD(day, -30, GETDATE()), 14, DATEADD(day, -16, GETDATE()), DATEADD(day, -18, GETDATE()), 'Zakonczone');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

-- 7. Zakończone po terminie (Zakonczone)
SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Bieguni');

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, DataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='anna_woj'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_ania'), DATEADD(day, -30, GETDATE()), 14, DATEADD(day, -16, GETDATE()), DATEADD(day, -10, GETDATE()), 'Zakonczone');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Lalka');

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, DataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='login123'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia'), DATEADD(day, -30, GETDATE()), 14, DATEADD(day, -16, GETDATE()), DATEADD(day, -10, GETDATE()), 'Zakonczone');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Wiedźmin: Ostatnie Życzenie');

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, DataZwrotu, Status) 
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='agacia_w'), (SELECT ID FROM Uzytkownicy WHERE Login='nowak_m'), DATEADD(day, -20, GETDATE()), 14, DATEADD(day, -6, GETDATE()), DATEADD(day, -11, GETDATE()), 'Zakonczone');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

-- 8. Nowe - wypożyczone dzisiaj
SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Harry Potter i kamień filozoficzny. Tom 1');
UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EgzemplarzID;

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='kamyk_krzysztof'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_natalia'), GETDATE(), 14, DATEADD(day, 14, GETDATE()), 'Nowe');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

-- 9. Przedłużone na dzisiaj (Przedluzone)
SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Morderstwo w Orient Expressie');
UPDATE Egzemplarze SET Status = 'Wypozyczona' WHERE ID = @EgzemplarzID;

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='login123'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_adam'), DATEADD(day, -28, GETDATE()), 28, DATEADD(day, -1, GETDATE()), 'Nowe');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);

-- 10. Zakończone dzisiaj 
SELECT TOP 1 @EgzemplarzID = ID FROM Egzemplarze 
WHERE Status = 'Dostepna' AND KsiazkaID = (SELECT ID FROM KatalogKsiazek WHERE Tytul = 'Harry Potter i Komnata Tajemnic. Tom 2');

INSERT INTO Wypozyczenia (CzytelnikID, BibliotekarzID, DataWypozyczenia, OkresWypozyczeniaDni, OczekiwanaDataZwrotu, DataZwrotu, Status)
VALUES ((SELECT ID FROM Uzytkownicy WHERE Login='maly_marek'), (SELECT ID FROM Uzytkownicy WHERE Login='biblio_ania'), DATEADD(day, -20, GETDATE()), 14, DATEADD(day, -6, GETDATE()), GETDATE(), 'Zakonczone');
SET @WypozyczenieID = SCOPE_IDENTITY();
INSERT INTO PozycjeWypozyczenia (WypozyczenieID, EgzemplarzID) VALUES (@WypozyczenieID, @EgzemplarzID);
GO
