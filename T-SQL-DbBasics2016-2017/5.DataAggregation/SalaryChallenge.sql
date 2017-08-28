--join way
SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentId
FROM Employees e
INNER JOIN (SELECT DepartmentId, AVG(Salary) AS AverageSalary
			FROM Employees
			GROUP BY DepartmentId) AS salary
ON e.DepartmentId = salary.DepartmentId
WHERE e.Salary > salary.AverageSalary
ORDER BY e.DepartmentId

--without join
SELECT TOP(10) FirstName, LastName, DepartmentId 
FROM Employees AS e
WHERE Salary > (
				SELECT AVG(Salary) FROM Employees AS emp
				WHERE e.DepartmentID = emp.DepartmentID
				GROUP BY DepartmentID
				)