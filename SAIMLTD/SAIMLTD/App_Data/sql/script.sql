CREATE DATABASE test_saimltd_bdd;

USE test_saimltd_bdd;

CREATE TABLE Client (
	id int auto_increment primary key,
	denomination varchar(500) not null,
	adresse text,
	telephone varchar(15),
	mail varchar(200),
	siren varchar(15),
	activite text,
	capital double,
	forme_juridique varchar(10)
);

CREATE TABLE Contact_person (
	id int auto_increment primary key,
	id_societe int,
	nom_personne varchar(500),
	poste varchar(50),
	FOREIGN KEY (id_societe) REFERENCES client(id)
);

