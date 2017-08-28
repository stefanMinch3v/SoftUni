CREATE TABLE Cities
(
	CityID int,
	CityName varchar(50) NOT NULL,
	CONSTRAINT PK_Cities PRIMARY KEY(CityID)
)

INSERT INTO Cities(CityID, CityName)
VALUES
(1,'Povorino'),
(2,'Tanumshede'),
(3,'Santa Mara'),
(4,'Uppsala'),
(5,'Nanpu'),
(6,'Char Bhadrāsan'),
(7,'Darungan Lor'),
(8,'Orlu'),
(9,'Leiden'),
(10,'Rio do Sul'),
(11,'Pinhais'),
(12,'Budapest'),
(13,'Skrunda'),
(14,'Tumaco'),
(15,'Jiangmen'),
(16,'Belyy Yar'),
(17,'Nevers'),
(18,'Boje'),
(19,'Sungaibengkal'),
(20,'Nueva Guadalupe')

CREATE TABLE Customers
(
	CustomerID int,
	FirstName varchar(30) NOT NULL,
	LastName varchar(30) NOT NULL,
	Gender char(1) NOT NULL,
	DateOfBirth date NOT NULL,
	Height float,
	CityID int,
	CONSTRAINT PK_Customers PRIMARY KEY(CustomerID),
	CONSTRAINT FK_Customers_Cities FOREIGN KEY(CityID) REFERENCES Cities(CityID)
)

INSERT INTO Customers (CustomerID, FirstName, LastName, Gender, DateOfBirth, Height, CityID)
VALUES
(1,'Bruce','Armstrong','M','19700917',2.11,10),
(2,'Carolyn','Wells','F','19400623',2.11,18),
(3,'Rachel','White','F','20150611',1.65,9),
(4,'Brenda','Boyd','F','19451125',2.05,17),
(5,'Aaron','Campbell','M','19780806',2.14,7),
(6,'Mary','Gordon','F','19390510',1.66,14),
(7,'Amy','Allen','F','20070425',1.7,11),
(8,'Frank','Armstrong','M','19800520',1.95,20),
(9,'Bobby','Hughes','M','19671012',1.72,8),
(10,'Gregory','Hansen','M','19770816',1.37,4),
(11,'Russell','Lawrence','M','19941117',1.78,3),
(12,'Henry','Henry','M','19451013',1.85,8),
(13,'Christina','Little','F','19540102',1.14,12),
(14,'George','Bennett','M','19560416',2.12,14),
(15,'Carolyn','Pierce','F','20040310',1.89,10),
(16,'Tammy','Crawford','F','19931128',1.46,6),
(17,'Samuel','Cooper','M','20000513',1.22,8),
(18,'Patrick','Mills','M','19740804',2.1,14),
(19,'Matthew','Davis','M','19410901',1.82,8),
(20,'Clarence','Meyer','M','20160123',1.18,12),
(21,'Karen','Mason','F','19570312',2.15,19),
(22,'Lawrence','Diaz','M','19800217',1.78,1),
(23,'Deborah','Taylor','F','19461106',1.5,12),
(24,'Robert','Fuller','M','20030105',2.11,13),
(25,'Debra','Crawford','F','19890524',2.16,1),
(26,'Albert','Flores','M','20050303',1.9,6),
(27,'Howard','Wood','M','19651216',1.11,16),
(28,'Sarah','Wheeler','F','20051103',1.76,11),
(29,'Roy','Rogers','M','19851218',2.14,16),
(30,'John','Pierce','M','19990516',1.01,12),
(31,'Justin','Dixon','M','19560830',1.6,17),
(32,'Karen','Cook','F','19670321',1.93,16),
(33,'Shirley','Williamson','F','19841006',1.62,16),
(34,'Joe','Sanders','M','19720629',1.78,1),
(35,'Mildred','Ferguson','F','19580607',1.34,15),
(36,'Mary','Harper','F','19910330',1.44,15),
(37,'George','Ryan','M','19550809',1.91,13),
(38,'Carl','Turner','M','19750128',1.51,17),
(39,'Mark','Wheeler','M','19540202',1.14,1),
(40,'William','Fox','M','19940812',1.92,3)


CREATE TABLE Accounts
( 
	AccountID int,
	AccountNumber char(12) NOT NULL,
	StartDate date NOT NULL,
	CustomerID int NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY(AccountID),
	CONSTRAINT FK_Accounts_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

INSERT INTO Accounts (AccountID, AccountNumber, StartDate, CustomerID)
VALUES
(1,'355074144476','20160422',40),
(2,'510014316471','20151021',13),
(3,'504837572679','20120517',5),
(4,'589360969376','20160723',37),
(5,'357737883238','20151109',5),
(6,'404137269591','20110807',40),
(7,'356665682743','20140323',30),
(8,'353336775123','20110416',24),
(9,'529906064937','20141129',22),
(10,'357300377233','20110402',37),
(11,'501845589067','20160812',16),
(12,'356698459732','20130804',31),
(13,'354165074950','20141227',26),
(14,'358964814991','20120511',30),
(15,'676702537059','20160125',16),
(16,'637847380672','20141115',19),
(17,'501012430845','20151031',2),
(18,'355030411164','20120705',5),
(19,'353551869441','20130612',13),
(20,'358186999628','20130120',36),
(21,'633110998329','20121206',19),
(22,'633110652265','20101203',30),
(23,'357865854277','20110603',19),
(24,'354587535088','20130421',28),
(25,'500766743677','20131011',8),
(26,'670618072040','20150829',33),
(27,'354413268319','20160411',23),
(28,'201924781142','20111213',7),
(29,'353792155017','20130709',31),
(30,'374288725696','20120614',26),
(31,'352806149112','20160805',4),
(32,'355708116263','20140512',37),
(33,'560222129740','20110430',5),
(34,'491305918331','20101013',27),
(35,'676226671786','20120103',26),
(36,'358415634989','20130520',23),
(37,'402677818660','20150909',1),
(38,'375374823869','20110427',6),
(39,'355945632328','20160809',39),
(40,'305517744547','20120125',20)

CREATE TABLE Loans
( 
	LoanID int IDENTITY,
	StartDate date NOT NULL,
	Amount decimal(18,2) NOT NULL,
	Interest decimal(4,2) NOT NULL,
	ExpirationDate date NULL,
	CustomerID int NOT NULL,
	CONSTRAINT PK_Loan PRIMARY KEY(LoanID),
	CONSTRAINT FK_Loans_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

SET IDENTITY_INSERT Loans ON

INSERT INTO Loans(LoanID, StartDate, Amount, Interest, ExpirationDate, CustomerID)
VALUES
(1,'20120719',39688.89,0.64,NULL,36),
(2,'20121024',27458.56,0.75,'20140717',39),
(3,'20110522',86354.31,0.96,NULL,40),
(4,'20120415',43669.45,0.84,NULL,15),
(5,'20101103',87303.9,0.19,'20150812',17),
(6,'20110110',21608.36,0.07,'20150913',24),
(7,'20110421',51176.01,0.37,NULL,34),
(8,'20110623',6906.34,0.59,NULL,27),
(9,'20130601',60755.86,0.16,'20131117',2),
(10,'20120528',10153.59,0.74,'20151107',38),
(11,'20120420',33182.13,0.39,'20160320',39),
(12,'20120404',94793.58,0.11,'20150818',30),
(13,'20130513',38042.37,0.12,'20151110',23),
(14,'20130612',64682.27,0.31,'20140403',37),
(15,'20101019',68002.42,0.48,'20160228',2),
(16,'20130704',52386.52,0.09,'20151214',18),
(17,'20110525',51732.28,0.13,'20150408',32),
(18,'20130723',49265.91,0.33,'20150708',37),
(19,'20121224',88067.24,0.23,'20140202',4),
(20,'20120305',30679.99,0.3,NULL,20),
(21,'20110819',72139.46,0.89,NULL,32),
(22,'20130609',9544.91,0.93,NULL,37),
(23,'20111226',50728.08,0.8,NULL,9),
(24,'20101212',3267.54,0.13,'20160509',19),
(25,'20111104',46492.12,0.36,NULL,28),
(26,'20111206',16837.25,0.55,NULL,10),
(27,'20120709',91980.57,0.67,'20160803',34),
(28,'20101010',55077.79,0.84,'20140405',24),
(29,'20130315',89733.18,0.19,NULL,40),
(30,'20110214',58872.88,0.53,'20131003',27),
(31,'20130313',45145.99,0.03,'20131031',27),
(32,'20121011',12684.23,0.08,'20140112',16),
(33,'20110310',92276.06,0.12,'20160806',5),
(34,'20120618',36767.29,0.64,'20141225',29),
(35,'20111004',4114,0.06,'20160310',27),
(36,'20130320',27258.64,0.16,'20160430',21),
(37,'20120404',91384.3,0.88,'20150806',26),
(38,'20120512',19019.01,0.96,'20160115',26),
(39,'20110528',86027.03,0.18,'20131029',29),
(40,'20110615',2163.08,0.67,'20140505',38),
(41,'20130510',9409.06,0.18,'20140927',5),
(42,'20120413',47901.56,0.88,'20131117',2),
(43,'20110609',16449.92,0.04,NULL,26),
(44,'20130304',85025.95,0.56,NULL,28),
(45,'20110614',42992.17,0.91,'20160528',39),
(46,'20110414',57635.73,0.6,'20131122',6),
(47,'20110221',1209.53,0.38,NULL,38),
(48,'20120723',88950.67,0.89,'20160507',21),
(49,'20121230',70819.68,0.2,'20150314',32),
(50,'20120415',12017.63,0.86,'20131006',21)


CREATE TABLE Branches
(
	BranchID int,
	Name varchar(50),
	CityID int NOT NULL,
	CONSTRAINT PK_Branches PRIMARY KEY(BranchID),
	CONSTRAINT FK_Branches_Cities FOREIGN KEY(CityID) REFERENCES Cities(CityID)
)

INSERT INTO Branches (BranchID, Name, CityID)
VALUES
(1,'Roy',13),
(2,'Roy',8),
(3,'Eugene',8),
(4,'Virginia',15),
(5,'Aaron',14),
(6,'Lois',17),
(7,'Marilyn',13),
(8,'Joseph',9),
(9,'Andrew',18),
(10,'Angela',12),
(11,'Nicole',19),
(12,'Jesse',15),
(13,'Louis',15),
(14,'Pamela',6),
(15,'Nicholas',18),
(16,'Judy',5),
(17,'Lois',15),
(18,'Lois',7),
(19,'Mildred',4),
(20,'Laura',16)


CREATE TABLE Employees
(
	EmployeeID int,
	FirstName varchar(50) NOT NULL,
	HireDate date NOT NULL,
	Salary decimal(8,2),
	BranchID int,
	CONSTRAINT PK_Employees PRIMARY KEY(EmployeeID),
	CONSTRAINT FK_Employees_Branches FOREIGN KEY(BranchID) REFERENCES Branches(BranchID)
)

INSERT INTO Employees (EmployeeID, FirstName, HireDate, Salary, BranchID)
VALUES
(1,'Jacqueline','20090114',2263.35,9),
(2,'Kathryn','20080315',1952.32,13),
(3,'Raymond','20060413',2246.48,6),
(4,'Sarah','20060518',2447.09,19),
(5,'Gregory','20091223',2295.88,12),
(6,'Christine','20070218',1554.37,9),
(7,'Laura','20080409',1985.56,15),
(8,'Harry','20060319',2884.21,19),
(9,'Shawn','20090228',2996.61,4),
(10,'Margaret','20060717',2514.07,18),
(11,'Debra','20061008',2569.8,8),
(12,'Gerald','20060613',2107.17,11),
(13,'Walter','20070104',2152.34,3),
(14,'Harold','20080312',2429.6,7),
(15,'Jeremy','20090527',2968.82,12),
(16,'Jessica','20080819',1731.33,13),
(17,'Barbara','20100704',2240.41,10),
(18,'Angela','20070207',2653.56,5),
(19,'Terry','20070409',2530.49,10),
(20,'Ryan','20070712',2401.28,19),
(21,'Michael','20060708',1109.21,19),
(22,'Susan','20090113',2296.28,8),
(23,'Randy','20081014',2925.68,3),
(24,'Anthony','20080526',2416.49,10),
(25,'Deborah','20100105',1902.53,2),
(26,'William','20091121',1639.97,14),
(27,'Jose','20060308',2500.32,17),
(28,'Shawn','20090408',2348.14,13),
(29,'Frances','20080601',2872.45,19),
(30,'Diane','20060318',2574.01,6)

CREATE TABLE EmployeesLoans
(
	EmployeeID int,
	LoanID int,
	CONSTRAINT PK_EmployeesLoans PRIMARY KEY(EmployeeID, LoanID),
	CONSTRAINT FK_EmployeesCustomers_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_EmployeesLoans_Loans FOREIGN KEY(LoanID) REFERENCES Loans(LoanID)
)

INSERT INTO EmployeesLoans (EmployeeID, LoanID)
VALUES
(16,34),
(1,34),
(11,30),
(4,45),
(26,39),
(3,14),
(19,16),
(4,26),
(23,19),
(18,35),
(22,17),
(20,11),
(18,15),
(27,30),
(12,11),
(1,8),
(7,9),
(7,6),
(24,24),
(17,9),
(17,36),
(5,31),
(22,33),
(13,5),
(3,4),
(18,34),
(4,14),
(26,49),
(1,14),
(30,7)


CREATE TABLE EmployeesAccounts
(
	EmployeeID int,
	AccountID int,
	CONSTRAINT PK_EmployeesAccounts PRIMARY KEY(EmployeeID, AccountID),
	CONSTRAINT FK_EmployeesAccounts_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_EmployeesAccounts_Account FOREIGN KEY(AccountID) REFERENCES Accounts(AccountID)
)

INSERT INTO EmployeesAccounts (EmployeeID, AccountID)
VALUES
(7,33),
(6,28),
(14,35),
(19,27),
(30,35),
(18,5),
(8,33),
(2,8),
(25,26),
(27,19),
(26,17),
(29,28),
(21,24),
(6,27),
(21,14),
(28,33),
(28,14),
(17,34),
(16,11),
(16,12),
(5,38),
(7,9),
(23,17),
(14,18),
(21,37),
(12,13),
(26,23),
(22,2),
(19,19),
(2,1),
(12,4),
(22,6),
(19,30),
(16,5),
(14,5),
(25,13),
(8,30),
(25,31),
(11,18),
(19,22),
(21,31),
(3,34),
(21,2),
(26,38),
(6,37),
(16,19),
(24,39),
(15,9),
(20,7),
(18,31)