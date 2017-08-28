CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
Id INT IDENTITY(1,1),
PRIMARY KEY (Id),
DirectorName NVARCHAR(50) NOT NULL,
Notes VARCHAR(500) NULL,
)

CREATE TABLE Genres
(
Id INT IDENTITY(1,1),
PRIMARY KEY (Id),
GenreName NVARCHAR(50) NOT NULL,
Notes VARCHAR(500) NULL
)

CREATE TABLE Categories
(
Id INT IDENTITY(1,1),
PRIMARY KEY (Id),
CategoryName NVARCHAR(50) NOT NULL,
Notes VARCHAR(500) NULL
)

CREATE TABLE Movies
(
Id INT IDENTITY(1,1),
PRIMARY KEY (Id),
Title VARCHAR(50) NOT NULL,
DirectorId INT,
--/*FOREIGN KEY (DirectorId) REFERENCES Directors(Id),*/
CopyrightYear date,
Length DECIMAL(10, 2),
GenreId INT,
--FOREIGN KEY (GenreId) REFERENCES Genres(Id),
CategoryId INT,
--FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
Rating DECIMAL(10,2),
Notes VARCHAR(500),
)

SET IDENTITY_INSERT Categories 
ON INSERT INTO Categories (Id, CategoryName, Notes)
VALUES(1, 'Kids', 'notes for Categories'),
	  (2, 'Adult', 'notes for Categories'),
      (3, 'Over 18', 'notes for Categories'),
      (4, 'No restrictions', 'notes for Categories'),
      (5, 'Men only', 'notes for Categories')
SET IDENTITY_INSERT Categories OFF

SET IDENTITY_INSERT Directors ON 
INSERT INTO Directors (Id, DirectorName, Notes)
VALUES(1, 'peter', 'director notes'),
	  (2, 'ivan', 'director notes'),
	  (3, 'nakov', 'director notes'),
	  (4, 'mitko', 'director notes'),
	  (5, 'gogo', 'director notes')
SET IDENTITY_INSERT Directors OFF  

SET IDENTITY_INSERT Genres ON 
INSERT INTO Genres (Id, GenreName, Notes)
VALUES(1, 'action', 'notes for action'),
	  (2, 'drama', 'notes for drama'),
      (3, 'thriller', 'notes for thriller'),
      (4, 'crime', 'notes for crime'),
      (5, 'adventure', 'notes for adventure')
SET IDENTITY_INSERT Genres OFF

SET IDENTITY_INSERT Movies ON 
INSERT INTO Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES(1, 'batman', 1, GETDATE(), 3.3, 1, 1, 5.5, 'some movie'),
	  (2, 'spinderman', 2, GETDATE(), 3.3, 2, 2, 5.5, 'some movie'),
	  (3, 'black cat white cat', 3, GETDATE(), 3.3, 3, 3, 5.5, 'some movie'),
	  (4, 'purko', 4, GETDATE(), 3.3, 4, 4, 5.5, 'some movie'),
	  (5, 'lemon world', 5, GETDATE(), 3.3, 5, 5, 5.5, 'some movie')
SET IDENTITY_INSERT Movies OFF 