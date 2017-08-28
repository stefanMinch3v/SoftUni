CREATE DATABASE TestRelationsBetweenDatabases

USE TestRelationsBetweenDatabases
GO

CREATE TABLE Passports 
(
	PassportID int PRIMARY KEY NOT NULL,
	PassportNumber varchar(50) UNIQUE NOT NULL
)

CREATE TABLE Persons
(
	PersonID int PRIMARY KEY NOT NULL IDENTITY,
	FirstName varchar(30) NOT NULL,
	Salary money,
	PassportID int UNIQUE
)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports
FOREIGN KEY (PassportID)
REFERENCES Passports(PassportID)

INSERT INTO Passports VALUES
(101,'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)