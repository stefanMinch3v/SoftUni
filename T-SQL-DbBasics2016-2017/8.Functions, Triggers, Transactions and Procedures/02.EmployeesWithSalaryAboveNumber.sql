CREATE PROCEDURE  usp_GetEmployeesSalaryAboveNumber
(@moneyParameter money = 48100)
AS
SELECT FirstName AS [First Name], LastName AS [Last Name]
FROM Employees
WHERE Salary >= @moneyParameter

--EXEC usp_GetEmployeesSalaryAboveNumber 70000 for example if you want to change the default value of 48100