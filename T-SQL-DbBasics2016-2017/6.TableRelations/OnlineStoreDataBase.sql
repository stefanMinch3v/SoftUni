CREATE TABLE Cities
(
	CityID int PRIMARY KEY,
	Name varchar(50)
)

CREATE TABLE Customers
(
	CustomerID int PRIMARY KEY,
	Name varchar(50),
	Birthday date DEFAULT GETDATE(),
	CityID int,
	CONSTRAINT FK_CityID_Cities
	FOREIGN KEY(CityID)
	REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID int PRIMARY KEY,
	CustomerID int,
	CONSTRAINT FK_CustomerID_Customers
	FOREIGN KEY(CustomerID)
	REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID int PRIMARY KEY,
	Name varchar(50) 
)

CREATE TABLE Items
(
	ItemID int PRIMARY KEY,
	Name varchar(50),
	ItemType int,
	CONSTRAINT FK_ItemType_ItemTypes
	FOREIGN KEY(ItemType)
	REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
	OrderID int,
	ItemID int,
	CONSTRAINT PK_OrderId_ItemId
	PRIMARY KEY(OrderID, ItemID),
	CONSTRAINT FK_OrderItems_Orders
	FOREIGN KEY(OrderID)
	REFERENCES Orders(OrderID),
	CONSTRAINT FK_OrderItems_Items
	FOREIGN KEY(ItemID)
	REFERENCES Items(ItemID)
)
