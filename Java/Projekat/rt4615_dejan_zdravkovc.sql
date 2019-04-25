--
-- File generated with SQLiteStudio v3.1.1 on Tue Jun 27 23:17:25 2017
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: administratori
CREATE TABLE administratori (idAdministratora INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, ime VARCHAR (30) UNIQUE NOT NULL, lozinka VARCHAR (30) NOT NULL);
INSERT INTO administratori (idAdministratora, ime, lozinka) VALUES (1, 'aDejan', '1234');

-- Table: albumi
CREATE TABLE albumi (idAlbuma INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, nazivAlbuma VARCHAR (30) NOT NULL, godinaIzdavanja INTEGER NOT NULL, idIzvodjaca INTEGER NOT NULL REFERENCES izvodjaci (idIzvodjaca), zanrAlbuma VARCHAR (30) NOT NULL);
INSERT INTO albumi (idAlbuma, nazivAlbuma, godinaIzdavanja, idIzvodjaca, zanrAlbuma) VALUES (1, 'Pogonophobia', 2017, 1, 'Punk');
INSERT INTO albumi (idAlbuma, nazivAlbuma, godinaIzdavanja, idIzvodjaca, zanrAlbuma) VALUES (2, 'The Queen Is Dead', 1986, 4, 'Alternativni rock');
INSERT INTO albumi (idAlbuma, nazivAlbuma, godinaIzdavanja, idIzvodjaca, zanrAlbuma) VALUES (3, 'U Magnovenju', 1996, 2, 'Punk');
INSERT INTO albumi (idAlbuma, nazivAlbuma, godinaIzdavanja, idIzvodjaca, zanrAlbuma) VALUES (4, 'Dzinovski', 1993, 3, 'Punk');
INSERT INTO albumi (idAlbuma, nazivAlbuma, godinaIzdavanja, idIzvodjaca, zanrAlbuma) VALUES (6, 'Heroes', 1977, 7, 'Art rock');

-- Table: izvodjaci
CREATE TABLE izvodjaci (idIzvodjaca INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, nazivIzvodjaca VARCHAR (30) NOT NULL, tipIzvodjaca VARCHAR (30) NOT NULL, godinaFormiranja INTEGER NOT NULL, godinaRaspada INTEGER, biografija TEXT (500) NOT NULL);
INSERT INTO izvodjaci (idIzvodjaca, nazivIzvodjaca, tipIzvodjaca, godinaFormiranja, godinaRaspada, biografija) VALUES (1, 'Pogonbgd', 'BEND', 2004, NULL, 'Novobeogradski punk bend.');
INSERT INTO izvodjaci (idIzvodjaca, nazivIzvodjaca, tipIzvodjaca, godinaFormiranja, godinaRaspada, biografija) VALUES (2, 'Goblini', 'BEND', 1992, NULL, 'Sabacki punk rock bend.');
INSERT INTO izvodjaci (idIzvodjaca, nazivIzvodjaca, tipIzvodjaca, godinaFormiranja, godinaRaspada, biografija) VALUES (3, 'Hladno pivo', 'BEND', 1987, NULL, 'Zagrebacki punk rock bend.');
INSERT INTO izvodjaci (idIzvodjaca, nazivIzvodjaca, tipIzvodjaca, godinaFormiranja, godinaRaspada, biografija) VALUES (4, 'The Smiths', 'BEND', 1982, 1987, 'Engleski bend, alternativni rok.');
INSERT INTO izvodjaci (idIzvodjaca, nazivIzvodjaca, tipIzvodjaca, godinaFormiranja, godinaRaspada, biografija) VALUES (5, 'Bruno Mars', 'SOLO', 2007, NULL, 'Americki kantautor i muzicki producent.');
INSERT INTO izvodjaci (idIzvodjaca, nazivIzvodjaca, tipIzvodjaca, godinaFormiranja, godinaRaspada, biografija) VALUES (6, 'Luciano Pavarotti', 'SOLO', 1961, 2006, 'Italijanski operski pevac.');
INSERT INTO izvodjaci (idIzvodjaca, nazivIzvodjaca, tipIzvodjaca, godinaFormiranja, godinaRaspada, biografija) VALUES (7, 'David Bowie', 'SOLO', 1964, 2016, 'Britanski rok muzicar, pevac, kompozitor, glumac...');

-- Table: korisnici
CREATE TABLE korisnici (idKorisnika INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, ime VARCHAR (30) UNIQUE NOT NULL, lozinka VARCHAR (30) NOT NULL);
INSERT INTO korisnici (idKorisnika, ime, lozinka) VALUES (1, 'kDejan', '1234');
INSERT INTO korisnici (idKorisnika, ime, lozinka) VALUES (2, 'kNikola', '1234');
INSERT INTO korisnici (idKorisnika, ime, lozinka) VALUES (3, 'kKristina', '1234');
INSERT INTO korisnici (idKorisnika, ime, lozinka) VALUES (4, 'kAna', '1234');
INSERT INTO korisnici (idKorisnika, ime, lozinka) VALUES (5, 'kDusan', '1234');

-- Table: kupljenePesme
CREATE TABLE kupljenePesme (idKupljenePesme INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, idKorisnika INTEGER NOT NULL REFERENCES korisnici (idKorisnika), idPesme INTEGER REFERENCES pesme (idPesme) NOT NULL);
INSERT INTO kupljenePesme (idKupljenePesme, idKorisnika, idPesme) VALUES (11, 1, 22);
INSERT INTO kupljenePesme (idKupljenePesme, idKorisnika, idPesme) VALUES (14, 1, 21);

-- Table: kupljeniAlbumi
CREATE TABLE kupljeniAlbumi (idKupljenogAlbuma INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, idKorisnika INTEGER NOT NULL REFERENCES korisnici (idKorisnika), idAlbuma INTEGER NOT NULL REFERENCES albumi (idAlbuma));
INSERT INTO kupljeniAlbumi (idKupljenogAlbuma, idKorisnika, idAlbuma) VALUES (15, 1, 1);
INSERT INTO kupljeniAlbumi (idKupljenogAlbuma, idKorisnika, idAlbuma) VALUES (16, 1, 2);
INSERT INTO kupljeniAlbumi (idKupljenogAlbuma, idKorisnika, idAlbuma) VALUES (17, 1, 3);

-- Table: pesme
CREATE TABLE pesme (idPesme INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, nazivPesme VARCHAR (30) NOT NULL, idIzvodjaca INTEGER NOT NULL REFERENCES izvodjaci (idIzvodjaca), idAlbuma INTEGER REFERENCES albumi (idAlbuma), trajanjePesme INTEGER NOT NULL);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (1, 'Pogonbgd', 1, 1, 212);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (2, 'Ja bicu tu', 1, 1, 312);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (3, 'Haos je zivot moj', 1, 1, 198);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (4, 'Pustinja', 1, 1, 225);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (5, 'Moj svet', 1, 1, 300);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (6, 'U redu', 1, 1, 230);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (7, 'Vetrenjace', 1, 1, 312);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (8, 'Vagoni', 1, 1, 193);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (9, 'Sjeban', 1, 1, 260);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (10, 'Znak', 1, 1, 400);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (11, 'The queen is dead', 4, 2, 460);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (12, 'There Is a Light That Never Goes Out
', 4, 2, 356);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (13, 'Some Girls Are Bigger Than Others
', 4, 2, 256);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (14, 'Anja, volim te', 2, 3, 200);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (15, 'Ima nas!', 2, 3, 250);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (16, 'Ona', 2, 3, 175);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (17, 'Pjevajte nešto ljubavno', 3, 4, 210);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (18, 'Heroin', 3, 4, 192);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (19, 'Trening za umiranje', 3, 4, 215);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (20, 'Uptown funk', 5, NULL, 232);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (21, 'Treasure', 5, NULL, 250);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (22, 'O'' sole mio', 6, NULL, 300);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (27, 'Heroes', 7, 6, 212);
INSERT INTO pesme (idPesme, nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES (39, 'Pobednik', 1, NULL, 181);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
