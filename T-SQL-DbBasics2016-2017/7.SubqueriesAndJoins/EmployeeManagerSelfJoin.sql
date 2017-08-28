SELECT e.EmployeeID, e.FirstName, e.ManagerID, ee.FirstName as [ManagerName]
FROM Employees AS e
INNER JOIN Employees AS ee 
	ON e.ManagerID = ee.EmployeeID
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID