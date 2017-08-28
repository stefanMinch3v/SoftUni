CREATE VIEW V_EmployeeNameJobTitle4 AS 
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS 'Full Name', JobTitle AS 'Job Title'
FROM Employees