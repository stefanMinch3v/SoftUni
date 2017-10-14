BEGIN TRAN


UPDATE Towns
SET Name = UPPER(Name)
WHERE Country = 'Bulgaria'

SELECT Name
FROM Towns
WHERE Country = @Country
ROLLBACK