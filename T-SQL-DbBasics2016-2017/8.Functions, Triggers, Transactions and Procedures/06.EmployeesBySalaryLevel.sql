CREATE PROC usp_EmployeesBySalaryLevel
(@LevelOfSalary varchar(10))
AS
BEGIN
	SELECT e.FirstName AS [First Name], 
		   e.LastName AS [Last Name] 
	FROM
	(SELECT e.FirstName, 
		   e.LastName,
		   e.Salary, 
		   CASE
				WHEN e.Salary < 30000 THEN 'Low'
				WHEN e.Salary BETWEEN 30000 AND 50000 THEN 'Average'
				ELSE 'High'
		   END AS [SalaryLevel]
	FROM Employees AS e) AS e
	WHERE e.SalaryLevel = @LevelOfSalary
END

--EXEC usp_EmployeesBySalaryLevel 'High'