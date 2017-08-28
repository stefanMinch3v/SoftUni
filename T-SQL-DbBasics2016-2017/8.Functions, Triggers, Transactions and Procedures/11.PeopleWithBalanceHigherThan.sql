CREATE PROC usp_GetHoldersWithBalanceHigherThan
(@MoneyToCompare money)
AS
SELECT ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name]
FROM AccountHolders ah
INNER JOIN Accounts a
ON ah.Id = a.AccountHolderId
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > @MoneyToCompare

EXEC usp_GetHoldersWithBalanceHigherThan 1111