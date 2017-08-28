use Geography

SELECT MountainRange, PeakName, Elevation
FROM Mountains m INNER JOIN
Peaks p ON m.Id = p.MountainId
WHERE m.MountainRange = 'Rila'
ORDER BY Elevation DESC