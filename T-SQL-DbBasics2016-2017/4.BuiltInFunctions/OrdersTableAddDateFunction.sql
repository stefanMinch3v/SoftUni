SELECT ProductName, OrderDate, [Pay Due] = DATEADD(day, 3, OrderDate), [Deliver Due] = DATEADD(month, 1, OrderDate)
FROM Orders