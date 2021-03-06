--Section 3.Querying
--Task 1.Employees’ Salary
SELECT EmployeeID, HireDate, Salary, BranchID
FROM Employees
WHERE Salary > 2000 AND HireDate > '2009-06-15'

--Task 2.Customer Age
SELECT FirstName, DateOfBirth, DATEDIFF(year, DateOfBirth, '2016-01-10') AS [Age] 
FROM Customers 
WHERE DATEDIFF(year, DateOfBirth, '2016-01-10') BETWEEN 40 AND 50

--Task 3.Customer City
SELECT c.CustomerID, c.FirstName, c.LastName, c.Gender, cy.CityName
FROM Customers AS c
INNER JOIN Cities AS cy
	ON c.CityID = cy.CityID
WHERE (c.LastName LIKE 'Bu%' OR c.FirstName LIKE '%a') AND LEN(cy.CityName) >= 8
ORDER BY c.CustomerID

--Task 4.Employee Accounts
SELECT TOP(5)
		e.EmployeeID, e.FirstName, a.AccountNumber
FROM Employees AS e
INNER JOIN EmployeesAccounts AS ea
	ON e.EmployeeID = ea.EmployeeID
INNER JOIN Accounts AS a
	ON ea.AccountID = a.AccountID
WHERE a.StartDate > '2012-01-01'
ORDER BY e.FirstName DESC

--Task 5.Employee Cities
SELECT c.CityName, b.Name, COUNT(e.EmployeeID) AS [EmployeesCount]
FROM Employees AS e
INNER JOIN Branches AS b
	ON e.BranchID = b.BranchID
INNER JOIN Cities AS c
	ON b.CityID = c.CityID
WHERE c.CityID NOT IN(4, 5)
GROUP BY c.CityName, b.Name
HAVING COUNT(e.EmployeeID) >= 3

--Task 6.Loan Statistics
SELECT SUM(l.Amount) AS [TotalLoanAmount],
	   MAX(l.Interest) AS [MaxInterest],
	   MIN(e.Salary) AS [MinEmployeeSalary]
FROM Employees AS e
INNER JOIN EmployeesLoans AS el
	ON e.EmployeeID = el.EmployeeID
INNER JOIN Loans AS l
	ON el.LoanID = l.LoanID

--Task 7.Unite People
SELECT TOP(3)
		e.FirstName, c.CityName
FROM Employees AS e
INNER JOIN Branches AS b
	ON e.BranchID = b.BranchID
INNER JOIN Cities AS c
	ON b.CityID = c.CityID
UNION ALL
SELECT TOP(3)
		c.FirstName, cy.CityName
FROM Customers AS c
INNER JOIN Cities AS cy
	ON c.CityID = cy.CityID

--Task 8.Customers without Accounts
SELECT c.CustomerID, c.Height
FROM Customers AS c
LEFT JOIN Accounts AS a
	ON c.CustomerID = a.CustomerID
WHERE c.Height BETWEEN 1.74 AND 2.04 AND a.CustomerID IS NULL

--Task 9.Average Loans
DECLARE @AverageMaleLoans float
SET @AverageMaleLoans = (SELECT AVG(ln.Amount)
								FROM Loans AS ln
								INNER JOIN Customers AS c
									ON ln.CustomerID = c.CustomerID
								WHERE c.Gender = 'M')
SELECT TOP(5)
		c.CustomerID,
		l.Amount
FROM Customers AS c
INNER JOIN Loans AS l
	ON c.CustomerID = l.CustomerID
WHERE l.Amount > @AverageMaleLoans
ORDER BY c.LastName 

--Task 10.Oldest Account
SELECT TOP(1)
		c.CustomerID, 
		c.FirstName,
		a.StartDate
FROM Customers AS c
INNER JOIN Accounts AS a
	ON c.CustomerID = a.CustomerID
ORDER BY a.StartDate