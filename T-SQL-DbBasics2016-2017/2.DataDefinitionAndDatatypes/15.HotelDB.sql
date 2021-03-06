USE Hotel

CREATE Table Employees
(
Id int IDENTITY NOT NULL,
FirstName varchar(30) NOT NULL,
LastName varchar(30) NOT NULL,
Title varchar(30) NOT NULL,
Notes text NULL,
PRIMARY KEY(Id)
)

CREATE Table Customers
(
AccountNumber int IDENTITY NOT NULL,
FirstName varchar(30) NOT NULL,
LastName varchar(30) NOT NULL,
PhoneNumber varchar(30) NULL,
EmergencyName varchar(30) NULL,
EmergencyNumber varchar(30) NOT NULL,
Notes text NULL
)

CREATE Table RoomStatus
(
Roomstatus bit NOT NULL,
Notes text NULL,
)

CREATE Table RoomTypes
(
RoomType int NOT NULL,
Notes text NULL,
PRIMARY KEY (RoomType) 
)

CREATE Table BedTypes
(
BedType int NOT NULL,
Notes text NULL,
PRIMARY KEY (BedType) 
)

CREATE Table Rooms
(
RoomNumber int NOT NULL,
RoomType int NOT NULL,
BedType int NOT NULL,
Rate float NULL,
RoomStatus bit NOT NULL,
Notes text NULL,
PRIMARY KEY(RoomNumber)
)

CREATE Table Payments
(
Id int IDENTITY NOT NULL,
EmployeeId int NOT NULL,
PaymentDate date NOT NULL,
AccountNumber int NOT NULL,
FirstDateOccupied date NOT NULL,
LastDateOccupied date NOT NULL,
TotalDays int NOT NULL,
AmountCharged money NOT NULL,
TaxRate float NULL,
TaxAmount float NULL,
PaymentTotal money NOT NULL,
Notes text NULL,
PRIMARY KEY (Id)
)

CREATE Table Occupancies
(
Id int IDENTITY NOT NULL,
EmployeeId int NOT NULL,
DateOccupied date NOT NULL,
AccountNumber int NOT NULL,
RoomNumber int NOT NULL,
RateApplied float NULL,
PhoneCharge money NULL,
Notes text NULL,
PRIMARY KEY(Id)
)

SET IDENTITY_INSERT Employees ON
INSERT INTO Employees (Id, FirstName, LastName, Title)
VALUES 
(1, 'Pesho', 'Peshev', 'Engineer'), 
(2, 'Gosho', 'Ivanov', 'Manager'), 
(3, 'Petar', 'Petrov', 'Cleaner')
SET IDENTITY_INSERT Employees  OFF

SET IDENTITY_INSERT Customers ON
INSERT INTO Customers (AccountNumber, FirstName, LastName, EmergencyNumber)
VALUES
(11, 'Petr', 'Petrov', 666234234), 
(22, 'Mitko', 'Danev', 343565466), 
(33, 'Stefan', 'Marev', 12423424)
SET IDENTITY_INSERT Customers  OFF

INSERT INTO RoomStatus (RoomStatus)
VALUES 
(0), 
(1), 
(1)

INSERT INTO RoomTypes (RoomType)
VALUES 
(3), 
(5), 
(4)


INSERT INTO BedTypes (BedType)
VALUES 
(2),
(3),
(4)

INSERT INTO Rooms (RoomNumber, RoomType, BedType, RoomStatus)
VALUES 
(1, 2, 2, 1),
(2, 4, 2, 1),
(3, 3, 3, 0)

SET IDENTITY_INSERT Payments ON
INSERT INTO Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays,
 AmountCharged, PaymentTotal)
VALUES 
(1, 1, GETDATE(), 111111, GETDATE(), GETDATE() + 10, 10, 100, 1000),
(2, 2, GETDATE(), 534345, GETDATE(), GETDATE() + 12, 12, 200, 2400),
(3, 3, GETDATE(), 556622, GETDATE(), GETDATE() + 11, 11, 300, 3300)
SET IDENTITY_INSERT Payments  OFF

SET IDENTITY_INSERT Occupancies ON
INSERT INTO Occupancies(Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber)
VALUES 
(1, 1, GETDATE(), 11, 3),
(2, 2, GETDATE(), 22, 2),
(3, 3, GETDATE(), 33, 1)
SET IDENTITY_INSERT Occupancies OFF
