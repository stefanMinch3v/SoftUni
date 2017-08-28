CREATE PROC usp_GetHoldersFullName 
AS
SELECT a.FirstName + ' ' + a.LastName AS [Full Name]
FROM AccountHolders a

EXEC usp_GetHoldersFullName