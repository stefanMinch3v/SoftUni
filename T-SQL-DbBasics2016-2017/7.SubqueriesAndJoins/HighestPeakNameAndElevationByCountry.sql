SELECT TOP(5)
			c.CountryName AS [Country],
			CASE 
				WHEN p.PeakName IS NULL THEN '(no highest peak)'
				ELSE p.PeakName
			END AS [HighestPeakName], 
			CASE 
				WHEN MAX(p.Elevation) IS NULL THEN 0
				ELSE MAX(p.Elevation)
			END  AS [HighestPeakElevation],
			CASE
				WHEN m.MountainRange IS NULL THEN '(no mountain)'
				ELSE m.MountainRange 
			END AS [Mountain]
FROM Countries AS c
FULL JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m
	ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p
	ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, [HighestPeakName]