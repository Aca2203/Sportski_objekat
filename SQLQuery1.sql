create database Sportski_objekat
use Sportski_objekat

create table Korisnik(
id int primary key identity(1,1),
email varchar(50) not null,
lozinka varchar(30) not null,
ime varchar(20) not null,
prezime varchar(50) not null
);
create table Objekat(
id int primary key identity(1,1),
naziv varchar(100) not null,
adresa varchar(100) not null,
opis varchar(1000)
);
create table Zaposleni(
id int primary key identity(1,1),
email varchar(50) not null,
lozinka varchar(30) not null,
ime varchar(20) not null,
prezime varchar(50) not null,
objekat_id int foreign key references Objekat(id)
);
create table Termini(
id int primary key identity(1,1),
datum date not null,
vreme int not null,
cena int not null,
objekat_id int foreign key references Objekat(id)
);
create table Rezervacija(
id int primary key identity(1,1),
korisnik_id int foreign key references Korisnik(id),
objekat_id int foreign key references Objekat(id),
datum date not null,
pocetak int not null,
kraj int not null
);

insert into Korisnik values('milanmaric@gmail.com', 'milan123', 'Milan', 'Maric')
insert into Korisnik values('dusanstankovic@gmail.com', 'duleCR7', 'Dusan', 'Stankovic')
insert into Korisnik values('bogdankolovic@gmail.com', 'autizmo', 'Bogdan', 'Kolovic')
insert into Korisnik values('andrejbratic@gmail.com', 'bratke123', 'Andrej', 'Bratic')
select * from korisnik

insert into Objekat values('Balon Juzni Bulevar', 'Juzni bulevar 69', 'Parking, tusevi, teren za 5 na 5 ili 6 na 6')
insert into Objekat values('Zlatna lopta Vracar', 'Djerdapska 19', 'Parking, tusevi, teren za 5 na 5 ili 6 na 6')
insert into Objekat values('Imperija sport', 'Vukosaviceva 21a', 'Parking, tusevi, teren za 5 na 5')
select * from Objekat

insert into zaposleni values('milanmariczp@gmail.com', 'milan123', 'Milan', 'Maric', 1)
select * from zaposleni