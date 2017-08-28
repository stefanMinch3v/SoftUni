--SECTION 2.DML
--Task 1 Insert
INSERT INTO DepositTypes
VALUES
(1, 'Time Deposit'),
(2, 'Call Deposit'),
(3, 'Free Deposit')

INSERT INTO Deposits (Amount, StartDate, DepositTypeID, CustomerID)
SELECT	CASE
			WHEN DateOfBirth > '1980-01-01' AND Gender = 'M' THEN 1100
			WHEN DateOfBirth > '1980-01-01' AND Gender = 'F' THEN 1200
			WHEN DateOfBirth < '1980-01-01' AND Gender = 'M' THEN 1600
			WHEN DateOfBirth < '1980-01-01' AND Gender = 'F' THEN 1700
		END AS [Amount],
		GETDATE() AS [StartDate],
		CASE
			WHEN CustomerID % 2 = 1 AND CustomerID <= 15 THEN 1
			WHEN CustomerID % 2 = 0 AND CustomerID <= 15 THEN 2
			WHEN CustomerID > 15 THEN 3
		END AS [DepositTypeID],
		CustomerID
FROM Customers
WHERE CustomerID < 20


INSERT INTO EmployeesDeposits
VALUES
(15, 4),
(20, 15),
(8, 7),
(4, 8),
(3, 13),
(3, 8),
(4, 10),
(10, 1),
(13, 4),
(14, 9)

--Task 2 Update
UPDATE Employees
SET ManagerID =
	CASE
		WHEN EmployeeID BETWEEN 2 AND 10 THEN 1
		WHEN EmployeeID BETWEEN 12 AND 20 THEN 11
		WHEN EmployeeID BETWEEN 22 AND 30 THEN 21
		WHEN EmployeeID IN(11, 21) THEN 1
	END

--Task 3 Delete
DELETE FROM EmployeesDeposits
WHERE EmployeeID = 3 OR DepositID = 9
