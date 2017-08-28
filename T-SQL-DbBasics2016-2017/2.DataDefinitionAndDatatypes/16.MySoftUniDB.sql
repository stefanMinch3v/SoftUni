USE MySoftUni

CREATE TABLE Towns
(
Id int NOT NULL IDENTITY(1,1),
Name varchar(50) NOT NULL
PRIMARY KEY (Id)
)

INSERT INTO Towns
VALUES
('Sofia'),
('Plovdiv'), 
('Varna'), 
('Burgas')

CREATE TABLE Addresses 
(
Id int NOT NULL IDENTITY(1,1),
AdressText varchar(50) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL,
PRIMARY KEY (Id)
)

INSERT INTO Addresses
VALUES
('Sofia street ...', 1),
('Plovdiv street ...', 2), 
('Varna street ...', 3), 
('Burgas street ...', 4)

CREATE TABLE Departments  
(
Id int NOT NULL IDENTITY(1,1),
name varchar(50) NOT NULL
PRIMARY KEY (Id)
)

INSERT INTO Departments
VALUES
('Engineering'),
('Sales'), 
('Marketing'), 
('Software Development'),
('Quality Assurance')


CREATE TABLE Employees   
(
Id int NOT NULL IDENTITY(1,1),
FirstName varchar(50) NOT NULL,
MiddleName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
JobTitle varchar(50) NOT NULL,
DepartmentId int FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
HireDate datetime DEFAULT GetDate() NULL,
Salary float NOT NULL,
AddressId int FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
PRIMARY KEY (Id)
)	

INSERT INTO Employees
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, 01-02-2013, 3500.00, 1),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, 02-03-2004, 4000.00, 2),
('Maria', 'Petrova ', 'Ivanova ', 'Intern', 5, 28-08-2016, 525.25, 3),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, 09-12-2007, 3000.00, 4),
('Peter', 'Pan', 'Pan', 'Intern', 3, 28-08-2016, 599.88, 1)

---
SELECT Name FROM Towns ORDER BY Name ASC
SELECT Name FROM Departments ORDER BY Name ASC
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

UPDATE Employees
SET Salary *= 1.1
SELECT Salary FROM Employees ORDER BY Salary DESC

