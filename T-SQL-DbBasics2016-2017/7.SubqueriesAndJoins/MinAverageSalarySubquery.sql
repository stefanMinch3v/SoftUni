SELECT MIN(a.AverageSalary) AS [MinAverageSalary]
FROM
(
	SELECT e.DepartmentID, AVG(Salary) AS [AverageSalary]
	FROM Employees AS e
	GROUP BY e.DepartmentID
) AS a
