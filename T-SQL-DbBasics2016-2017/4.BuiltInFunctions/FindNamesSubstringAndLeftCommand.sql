SELECT FirstName, LastName
FROM Employees
WHERE SUBSTRING(FirstName, 1, 2) = 'SA'

SELECT FirstName, LastName
FROM Employees
WHERE LEFT(FirstName, 2) = 'SA'