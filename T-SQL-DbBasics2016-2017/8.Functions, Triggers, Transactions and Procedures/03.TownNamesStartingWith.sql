CREATE PROCEDURE usp_GetTownsStartingWith
(@stringParameter nvarchar(MAX))
AS
SELECT Name AS [Town]
FROM Towns
WHERE LOWER(Name) LIKE LOWER(@stringParameter + '%')

--EXEC usp_GetTownsStartingWith 's'