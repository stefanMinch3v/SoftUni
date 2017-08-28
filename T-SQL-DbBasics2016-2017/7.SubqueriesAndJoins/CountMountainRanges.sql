SELECT mc.CountryCode, COUNT(m.MountainRange) AS [MountainRanges]
FROM MountainsCountries AS mc
INNER JOIN Mountains AS m
	ON mc.MountainId = m.Id
GROUP BY mc.CountryCode
HAVING mc.CountryCode IN('US', 'RU', 'BG')