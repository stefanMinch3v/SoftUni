CREATE PROC usp_EmployeesBySalaryLevel
(@LevelOfSalary varchar(10))
AS
BEGIN
	SELECT e.FirstName AS [First Name], 
		   e.LastName AS [Last Name]
	FROM Employees AS e
	WHERE [dbo].[ufn_GetSalaryLevel](e.Salary) = @LevelOfSalary
END


--EXEC [dbo].[usp_EmployeesBySalaryLevel2] 'High'
