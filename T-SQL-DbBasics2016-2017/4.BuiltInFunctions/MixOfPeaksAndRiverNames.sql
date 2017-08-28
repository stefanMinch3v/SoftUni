SELECT p.PeakName, r.RiverName, LOWER(p.PeakName + RIGHT(r.RiverName, LEN(r.RiverName) - 1)) AS [Mix]
FROM Peaks AS p, Rivers AS r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix
--FROM Peaks p
--INNER JOIN Rivers r ON
--RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1) 
--ORDER BY p.PeakName ASC
