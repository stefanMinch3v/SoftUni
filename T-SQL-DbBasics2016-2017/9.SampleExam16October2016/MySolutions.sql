--DB FlightCompany OR AMS
--Task 1
CREATE TABLE Flights
(
	FlightID int PRIMARY KEY,
	DepartureTime datetime NOT NULL,
	ArrivalTime datetime NOT NULL,
	[Status] varchar(9) NOT NULL CONSTRAINT CHK_StatusPermissions CHECK ([Status] IN ('Departing', 'Delayed', 'Arrived', 'Cancelled')),
	OriginAirportID int,
	DestinationAirportID int,
	AirlineID int,
	CONSTRAINT FK_FlightsAirlineID_AirlinesAirlineID FOREIGN KEY(AirlineID) REFERENCES Airlines(AirlineID),
    CONSTRAINT FK_FlightsOriginAirportID_AirportsAirportID FOREIGN KEY(OriginAirportID) REFERENCES Airports(AirportID),
	CONSTRAINT FK_FlightsDestinationAirportID_AirportsAirportID FOREIGN KEY (DestinationAirportID)REFERENCES Airports(AirportID)
)

CREATE TABLE Tickets
(
	TicketID int PRIMARY KEY,
	Price decimal(8, 2) NOT NULL,
	Class varchar(6) NOT NULL CONSTRAINT CHK_ClassPermissions CHECK (Class IN('First', 'Second', 'Third')),
	Seat varchar(5) NOT NULL,
	CustomerID int,
	FlightID int,
	CONSTRAINT FK_TicketsCustomerID_CustomersCustomerID FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
	CONSTRAINT FK_TicketsFlightID_FlightsFlightID FOREIGN KEY(FlightID) REFERENCES Flights(FlightID)
)

--Section 2: Database Manipulations
--Task 1

INSERT INTO Flights(FlightID, DepartureTime, ArrivalTime, [Status], OriginAirportID, DestinationAirportID, AirlineID)
VALUES
(1, '2016-10-13 06:00 AM', '2016-10-13 10:00 AM', 'Delayed', 1, 4, 1), 
(2, '2016-10-12 12:00 PM', '2016-10-13 12:01 PM', 'Departing', 1, 3, 2),
(3, '2016-10-14 03:00 PM', '2016-10-20 04:00 AM', 'Delayed', 4, 2, 4),
(4, '2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 'Departing', 3, 1, 3),
(5, '2016-10-12 08:11 AM', '2016-10-12 11:22 PM', 'Departing', 4, 1, 1),
(6, '1995-06-21 12:30 PM', '1995-06-22 08:30 PM', 'Arrived', 2, 3, 5),
(7, '2016-10-12 11:34 PM', '2016-10-13 03:00 AM', 'Departing', 2, 4, 2),
(8, '2016-11-11 01:00 PM', '2016-11-12 10:00 PM', 'Delayed', 4, 3, 1),
(9, '2015-10-01 12:00 PM', '2015-12-01 01:00 AM', 'Arrived', 1, 2, 1),
(10, '2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 'Departing', 2, 1, 7)

INSERT INTO Tickets(TicketID, Price, Class, Seat, CustomerID, FlightID)
VALUES
(1, 3000.00, 'First', '233-A', 3, 8),
(2, 1799.90, 'Second', '123-D', 3, 8),
(3, 1200.50, 'Second', '12-Z', 3, 8),
(4, 410.68, 'Third', '45-Q', 3, 8),
(5, 560.00, 'Third', '201-R', 3, 8),
(6, 2100.00, 'Second', '13-T', 3, 8),
(7, 5500.00, 'First', '98-O', 3, 8)

--Task 2
UPDATE Flights
SET AirlineID = 1
WHERE [Status] = 'Arrived'

--Task 3
UPDATE Tickets
SET Price *= 1.50
WHERE FlightID IN (
					SELECT Maxi.FlightID
					FROM (
							SELECT a.Maximum,
								   t.TicketID,
								   f.FlightID
							FROM
							(
								SELECT MAX(a.Rating) AS [Maximum],
									   a.AirlineID
								FROM Airlines AS a
								GROUP BY a.AirlineID
							) AS a
							INNER JOIN Flights AS f
								ON a.AirlineID = f.AirlineID
							INNER JOIN Tickets AS t
								ON f.FlightID = t.FlightID
						  ) AS Maxi
						)
--Second way 
UPDATE Tickets
SET	Price *= 1.5
FROM Tickets AS t
	 INNER JOIN Flights AS f
		ON t.FlightID = f.FlightID
	 INNER JOIN Airlines AS a
		ON f.AirlineID = a.AirlineID
WHERE a.Rating = (SELECT MAX(Rating) FROM Airlines)

--Task 4
CREATE TABLE CustomerReviews
(
	ReviewID int PRIMARY KEY,
	ReviewContent varchar(255) NOT NULL,
	ReviewGrade int NOT NULL CHECK (ReviewGrade BETWEEN 0 AND 10),
	AirlineID int,
	CustomerID int,
	CONSTRAINT FK_CustomerReviewsAirlineID_AirlinesAirlineID FOREIGN KEY(AirlineID) REFERENCES Airlines(AirlineID),
	CONSTRAINT FK_CustomerReviewsCustomerID_CustomersCustomerID FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerBankAccounts
(
	AccountID int PRIMARY KEY,
	AccountNumber varchar(10) UNIQUE NOT NULL,
	Balance decimal(10, 2) NOT NULL,
	CustomerID int CONSTRAINT FK_CustomerBankAccountCustomerID_CustomersCustomerID REFERENCES Customers(CustomerID)
)

--Task 5
INSERT INTO CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID) 
VALUES
(1,'Me is very happy. Me likey this airline. Me good.',10,1,1),
(2,'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!',10,1,4),
(3,'Meh...',5,4,3),
(4,'Well I’ve seen better, but I’ve certainly seen a lot worse...',7,3,5)


INSERT INTO CustomerBankAccounts(AccountID, AccountNumber, Balance, CustomerID)
VALUES
(1, '123456790', 2569.23, 1),
(2, '18ABC23672', 14004568.23, 2),
(3, 'F0RG0100N3', 19345.20, 5)

--Section 3: Querying
--Task 1
SELECT TicketID,
	   Price,
	   Class,
	   Seat
FROM Tickets

--Task 2
SELECT CustomerID,
	   FirstName + ' ' + LastName AS [FullName],
	   Gender
FROM Customers
ORDER BY [FullName], CustomerID

--Task 3
SELECT FlightID,
	   DepartureTime,
	   ArrivalTime
FROM Flights
WHERE [Status] = 'Delayed'
ORDER BY FlightID

--Task 4
SELECT TOP(5) a.AirlineID,
	   a.AirlineName,
	   a.Nationality,
	   a.Rating
FROM Airlines AS a
INNER JOIN Flights AS f
	ON a.AirlineID = f.AirlineID
WHERE f.AirlineID IS NOT NULL
GROUP BY a.AirlineID,
		 a.AirlineName,
	     a.Nationality,
	     a.Rating
ORDER BY a.Rating DESC, a.AirlineName

--Task 5
SELECT t.TicketID,
	   a.AirportName AS [Destination],
	   c.FirstName + ' ' + c.LastName AS [CustomerName]
FROM Tickets AS t
INNER JOIN Customers AS c
	ON t.CustomerID = c.CustomerID
INNER JOIN Flights AS f
	ON t.FlightID = f.FlightID
INNER JOIN Airports AS a
	ON f.DestinationAirportID = a.AirportID
WHERE t.Price < 5000 AND t.Class = 'First'
ORDER BY t.TicketID

--Task 6
SELECT c.CustomerID,
	   c.FirstName + ' ' + c.LastName AS [CustomerName],
	   t.TownName AS [HomeTown]
FROM Customers AS c
INNER JOIN Tickets AS tt
	ON c.CustomerID = tt.CustomerID
INNER JOIN Flights AS f
	ON tt.FlightID = f.FlightID
	AND f.[Status] = 'Departing'
INNER JOIN Airports AS a
	ON f.OriginAirportID = a.AirportID
	AND a.TownID = c.HomeTownID
INNER JOIN Towns AS t
	ON a.TownID = t.TownID

--Task 7
SELECT DISTINCT c.CustomerID,
	   CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],
	   DATEDIFF(year, c.DateOfBirth, f.DepartureTime) AS [Age]
FROM Customers AS c
INNER JOIN Tickets AS t
	ON c.CustomerID = t.CustomerID
INNER JOIN Flights AS f
	ON t.FlightID = f.FlightID
	AND f.[Status] = 'Departing'
ORDER BY [Age], c.CustomerID

--Task 8
SELECT TOP(3) c.CustomerID,
			  CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],
			  t.Price AS [TicketPrice],
			  a.AirportName AS [Destination]
FROM Customers AS c
INNER JOIN Tickets AS t
	ON c.CustomerID = t.CustomerID
INNER JOIN Flights AS f
	ON t.FlightID = f.FlightID
INNER JOIN Airports AS a
	ON f.DestinationAirportID = a.AirportID
WHERE f.[Status] = 'Delayed'
ORDER BY t.Price DESC, c.CustomerID ASC

--Task 9
SELECT TOP(5) 
	   f.FlightID,
	   f.DepartureTime,
	   f.ArrivalTime,
	   a.AirportName AS [Origin],
	   aa.AirportName AS [Destination]
FROM Flights AS f
INNER JOIN Airports AS a
	ON f.OriginAirportID = a.AirportID
INNER JOIN Airports AS aa
	ON f.DestinationAirportID = aa.AirportID
WHERE f.[Status] = 'Departing' 
ORDER BY f.DepartureTime, f.FlightID

--Task 10
SELECT  c.CustomerID,
	   CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],
	   ABS(DATEDIFF(year, '2016-01-01', c.DateOfBirth)) AS [Age]
FROM Customers AS c
INNER JOIN Tickets AS t
	ON c.CustomerID = t.CustomerID
INNER JOIN Flights AS f
	ON t.FlightID = f.FlightID
	AND f.[Status] = 'Arrived'
WHERE ABS(DATEDIFF(year, '2016-01-01', c.DateOfBirth)) < 21
ORDER BY [Age] DESC, c.CustomerID

--Task 11
SELECT a.AirportID,
	   a.AirportName,
	   COUNT(c.CustomerID) AS [Passengers]
FROM Airports AS a
INNER JOIN Flights AS f
	ON a.AirportID = f.DestinationAirportID
INNER JOIN Tickets AS t
	ON f.FlightID = t.TicketID
INNER JOIN Customers AS c
	ON t.CustomerID = c.CustomerID
WHERE f.Status = 'Departing' 
GROUP BY a.AirportID, a.AirportName
HAVING COUNT(c.CustomerID) > 0
ORDER BY a.AirportID

--Section 4: Programmability
--Task 1
CREATE PROC usp_SubmitReview
(@CustomerID int, @ReviewContent varchar(255), @ReviewGrade int, @AirlineName varchar(30))
AS
BEGIN
	BEGIN TRAN
		IF(@AirlineName NOT IN (SELECT AirlineName FROM Airlines))
			BEGIN
				RAISERROR('Airline does not exist.', 16, 1)
				ROLLBACK
			END
		ELSE 
			BEGIN
				DECLARE @AirlineID int
				SET @AirlineID = (SELECT a.AirlineID FROM Airlines AS a WHERE a.AirlineName = @AirlineName)

				DECLARE @LastReviewID int
				SET @LastReviewID = (SELECT TOP(1) MAX(cr.ReviewID) FROM CustomerReviews AS cr )--ORDER BY cr.ReviewID DESC -without max)
			
				INSERT INTO CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID )
				VALUES(@LastReviewID + 1, @ReviewContent, @ReviewGrade, @AirlineID, @CustomerID)
				COMMIT
			END
END

--Task 2

CREATE PROC usp_PurchaseTicket
(@CustomerID int, @FlightID int, @TicketPrice decimal(10,2), @Class varchar(6), @Seat varchar(5))
AS
BEGIN
	BEGIN TRAN PurchTicket
		DECLARE @CustomerBalance decimal(10,2)
		SET @CustomerBalance = (SELECT Balance FROM CustomerBankAccounts WHERE CustomerID = @CustomerID)

		IF(@TicketPrice > @CustomerBalance)
			BEGIN
				RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1)
				ROLLBACK
			END
		ELSE
			BEGIN
				DECLARE @LastIndex int
				SET @LastIndex = (SELECT MAX(TicketID) FROM Tickets)

				INSERT INTO Tickets(TicketID, Price, Class, Seat, CustomerID, FlightID)
				VALUES
				(@LastIndex + 1, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

				UPDATE CustomerBankAccounts
				SET Balance -= @TicketPrice
				WHERE CustomerID = @CustomerID
				COMMIT TRAN PurchTicket
			END
END

--BONUS TASK Trigger
CREATE TABLE trg_ArrivedFlights
(
	FlightID int PRIMARY KEY,
	ArrivalTime datetime NOT NULL,
	Origin varchar(50) NOT NULL,
	Destination varchar(50) NOT NULL,
	Passengers int NOT NULL
)

CREATE TRIGGER trg_ArrivedFlights
ON Flights
AFTER UPDATE
AS
BEGIN
	INSERT INTO ArrivedFlights(FlightID, ArrivalTime, Origin, Destination, Passengers) 
	SELECT i.FlightID,
		   i.ArrivalTime, 
		   a.AirportName,
		   aa.AirportName, 
		   (SELECT COUNT(*) FROM Tickets WHERE FlightID = i.FlightID)
	FROM inserted AS i
	INNER JOIN Airports AS a
		ON i.OriginAirportID = a.AirportID
	INNER JOIN Airports AS aa
		ON i.DestinationAirportID = aa.AirportID
	INNER JOIN deleted AS d
		ON i.FlightID = d.FlightID
	WHERE i.[Status] = 'Arrived' AND d.[Status] <> 'Arrived'
	--SELECT * FROM ArrivalFlights
END

