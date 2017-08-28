ALTER PROC usp_CalculateFutureValueForAccount
(@AccountId int, @Interest float)
AS
SELECT ah.Id AS [Account Id],
	   ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name],
	   a.Balance AS [Current Balance],
	   dbo.ufn_CalculateFutureValue (a.Balance, @Interest, 5) AS [Balance in 5 years]
FROM AccountHolders AS ah
INNER JOIN Accounts AS a
	ON ah.Id = a.AccountHolderId
WHERE ah.Id = @AccountId 

EXEC usp_CalculateFutureValueForAccount 1 ,0.1