SELECT TOP (50)
	   e.EmployeeID, 
	   e.FirstName + ' ' + e.LastName AS [EmployeeName], 
	   ee.FirstName + ' ' + ee.LastName AS [ManagerName],
	   d.Name AS [DepartmentName]
FROM Employees AS e
INNER JOIN Employees AS ee
	ON e.ManagerID = ee.EmployeeID
INNER JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID