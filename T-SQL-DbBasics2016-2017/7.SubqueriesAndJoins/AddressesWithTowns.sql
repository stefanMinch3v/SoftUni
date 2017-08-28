SELECT TOP(50) FirstName, LastName, t.Name AS [Town], AddressText
FROM Employees AS e 
INNER JOIN Addresses AS a ON
e.AddressID = a.AddressID INNER JOIN Towns AS t ON
a.TownID = t.TownID
ORDER BY FirstName, LastName