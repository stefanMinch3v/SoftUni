SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM MountainsCountries AS mc
INNER JOIN Mountains AS m 
	ON mc.MountainId = m.Id
INNER JOIN Peaks AS p
	ON p.MountainId = m.Id
WHERE mc.CountryCode = 'BG'
	AND p.Elevation > 2835
ORDER BY p.Elevation DESC