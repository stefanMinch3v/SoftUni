CREATE TABLE DepositTypes
(
	DepositTypeID int PRIMARY KEY,
	Name varchar(20)
)

CREATE TABLE Deposits
(
	DepositID int PRIMARY KEY IDENTITY,
	Amount decimal(10,2),
	StartDate date,
	EndDate date,
	DepositTypeID int,
	CustomerID int
	CONSTRAINT FK_DepositsDepositType_DepositTypes FOREIGN KEY(DepositTypeID) REFERENCES DepositTypes(DepositTypeID),
	CONSTRAINT FK_DepositsCustomerID_CustomersCustomerID FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE EmployeesDeposits
(
	EmployeeID int,
	DepositID int,
	CONSTRAINT PK_EmployeeIDDepositID PRIMARY KEY(EmployeeID, DepositID),
	CONSTRAINT FK_EmployeesDepositsEmployeeID_EmployeesEmployeeID FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_EmployeesDepositsDepositID_DepositsDepositID FOREIGN KEY(DepositID) REFERENCES Deposits(DepositID)
)

CREATE TABLE CreditHistory
(
	CreaditHistoryID int PRIMARY KEY,
	Mark char(1),
	StartDate date,
	EndDate date,
	CustomerID int,
	CONSTRAINT FK_CreditHistoryCustomerID_CustomersCustomerID FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE Payments
(
	PaymentID int PRIMARY KEY,
	[Date] date,
	Amount decimal(10,2),
	LoanID int,
	CONSTRAINT FK_PaymentsLoanID_LoansLoanID FOREIGN KEY(LoanID) REFERENCES Loans(LoanID)
)

CREATE TABLE Users
(
	UserID int PRIMARY KEY,
	UserName varchar(50),
	[Password] varchar(50),
	CustomerID int UNIQUE,
	CONSTRAINT FK_UsersCustomerID_CustomersCustomerID FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

ALTER TABLE Employees
ADD ManagerID int CONSTRAINT SFK_ManagerID_EmployeeID FOREIGN KEY REFERENCES Employees(EmployeeID)