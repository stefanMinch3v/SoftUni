USE CarRental

CREATE TABLE Categories
(
	Id int NOT NULL,
	CategoryName varchar(50) NOT NULL,
	DailyRate decimal(10, 2) NULL,
	WeeklyRate decimal(10, 2) NULL,
	MonthlyRate decimal(10, 2) NULL,
	WeekendRate decimal(10, 2) NULL,
	PRIMARY KEY(Id)
)

CREATE TABLE Cars
(
	Id int NOT NULL,
	PlateNumber int NOT NULL,
	Manufacturer nvarchar(50) NOT NULL,
	Model varchar(50) NOT NULL,
	CarYear int NOT NULL,
	CategoryId int NULL,
	Doors int NOT NULL,
	Picture image NULL,
	Condition varchar(50) NOT NULL,
	Available bit NOT NULL,
	PRIMARY KEY(Id)
)

CREATE TABLE Employees
(
	Id int NOT NULL,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Title varchar(50) NULL,
	Notes varchar(500) NULL,
	PRIMARY KEY (Id)
)

CREATE TABLE Customers
(
	Id int NOT NULL,
	DriverLicenceNumber int NOT NULL,
	FullName varchar(50) NOT NULL,
	Address varchar(50) NULL,
	City varchar(50) NULL,
	ZIPCode varchar(50) NULL,
	Notes varchar(50) NULL,
	PRIMARY KEY (Id)
)

CREATE TABLE RentalOrders
(
	Id int NOT NULL,
	EmployeeId int NOT NULL,
	CustomerId int NOT NULL,
	CarId int NOT NULL,
	TankLevel varchar(1) NOT NULL,
	KilometrageStart int NOT NULL,
	KilometrageEnd int NULL,
	TotalKilometrage int NOT NULL,
	StartDate date NOT NULL,
	EndDate date NOT NULL,
	TotalDays int NOT NULL,
	RateApplied decimal(10, 2) NULL,
	TaxRate decimal(10, 2) NULL,
	OrderStatus bit NOT NULL,
	Notes varchar(50) NULL
)

INSERT INTO Categories (Id, CategoryName)
VALUES
(1, 'Speed'),
(2, 'Retro'),
(3, 'Limo')

INSERT INTO Cars (Id, PlateNumber, Manufacturer, Model, CarYear, Doors, Condition, Available)
VALUES
(1, 123123, 'Opel', 'Astra', 1999, 4, 'Second hand', 1),
(2, 456456, 'Mazda', '6', 2011, 4, 'Second hand', 0),
(3, 345777, 'Toyota', 'Corola', 2017, 4, 'New', 1)

INSERT INTO Employees (Id, FirstName, LastName)
VALUES
(1, 'Pesho', 'Peshev'),
(2, 'Ivan', 'Ivanov'),
(3, 'Kyci', 'Vypcarov')

INSERT INTO Customers (Id, DriverLicenceNumber, FullName)
VALUES
(1, 1342341, 'Grisha Ganchev'),
(2, 2342315, 'Dimitar Penev'),
(3, 2353451, 'Kubrat Pulev')

INSERT INTO RentalOrders(Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, TotalKilometrage, StartDate, EndDate,TotalDays, OrderStatus)
VALUES
(1, 1, 1, 1, 50, 120, 195200, GETDATE(), GETDATE() + 12, 12, 1),
(2, 2, 2, 2, 41, 110, 20000, GETDATE(), GETDATE() + 5, 5, 1),
(3, 3, 3, 3, 33, 16, 40000, GETDATE(), GETDATE() + 18, 18, 1)