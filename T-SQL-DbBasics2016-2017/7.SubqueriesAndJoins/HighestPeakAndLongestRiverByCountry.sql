SELECT TOP(5)
			c.CountryName, MAX(p.Elevation) AS [HighestPeakElevation], MAX(r.Length) AS [LongestRiverLength]
FROM Countries AS c
FULL JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
FULL JOIN Mountains AS m
	ON mc.MountainId = m.Id
FULL JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
FULL JOIN Rivers AS r
	ON cr.RiverId = r.Id
FULL JOIN Peaks AS p
	ON m.Id = p.MountainId
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.CountryName ASC