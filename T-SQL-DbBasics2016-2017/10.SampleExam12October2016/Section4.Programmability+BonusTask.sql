--Section 4.Programmability
--Task 1.String joiner func
CREATE FUNCTION udf_ConcatString
(@FirstString varchar(MAX), @SecondString varchar(MAX))
RETURNS varchar(MAX)
AS
BEGIN
	DECLARE @Result varchar(MAX)
	SET @Result = CONCAT(REVERSE(@FirstString),REVERSE(@SecondString))
	RETURN @Result
END

--SELECT dbo.udf_ConcatString('ivan', 'reverse') AS Result

--Task 2.Unexpired Loans Procedure
CREATE PROC usp_CustomersWithUnexpiredLoans
(@CustomerID int)
AS
BEGIN
	SELECT c.CustomerID, 
		   c.FirstName, 
		   l.LoanID
	FROM Customers AS c
	INNER JOIN Loans AS l
		ON c.CustomerID = l.CustomerID
	WHERE c.CustomerID = @CustomerID AND l.ExpirationDate IS NULL
END

--EXEC usp_CustomersWithUnexpiredLoans @CustomerID = 9

--Task 3.Take Loan Procedure
ALTER PROC usp_TakeLoan
(@CustomerID int, @LoanAmount decimal(18,2), @Interest decimal(4,2), @StartDate varchar(MAX))
AS
BEGIN
	BEGIN TRAN
		IF(@LoanAmount < 0.01 OR @LoanAmount > 100000)
			BEGIN
				RAISERROR('Invalid Loan Amount.',16 , 1)
				ROLLBACK
			END
		ELSE
			BEGIN
				INSERT INTO Loans(StartDate, Amount, Interest, CustomerID)
				VALUES
				(@StartDate, @LoanAmount, @Interest, @CustomerID)
				COMMIT
			END
END

--EXEC usp_TakeLoan @CustomerID = 1, @LoanAmount = 500, @Interest = 1, @StartDate='20160915'

--Task 4.Trigger Hire Employee
CREATE TRIGGER trg_HireEmployee
ON Employees
AFTER INSERT
AS
BEGIN
	INSERT INTO EmployeesLoans(EmployeeID, LoanID)
	SELECT i.EmployeeID, el.LoanID
	FROM inserted AS i
	INNER JOIN EmployeesLoans AS el
		ON i.EmployeeID - 1 = el.EmployeeID
END

--Task 5.Bonus Delete Trigger
CREATE TABLE AccountLogs
(
	AccountID int,
	AccountNumber char(12) NOT NULL,
	StartDate date NOT NULL,
	CustomerID int NOT NULL,
)

CREATE TRIGGER trg_DeleteAccounts
ON Accounts
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @AccountIDToDelete int
	SET @AccountIDToDelete = (SELECT d.AccountID FROM deleted AS d)

	DELETE FROM EmployeesAccounts WHERE AccountID = @AccountIDToDelete
								
	INSERT INTO AccountLogs
	SELECT * FROM deleted
	DELETE FROM Accounts WHERE AccountID = @AccountIDToDelete
END

BEGIN TRAN
DELETE FROM [dbo].[Accounts] WHERE CustomerID = 6
SELECT * FROM AccountLogs
ROLLBACK