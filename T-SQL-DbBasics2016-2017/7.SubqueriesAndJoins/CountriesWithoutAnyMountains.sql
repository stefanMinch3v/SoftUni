SELECT COUNT(*) AS CountryCode
FROM
(SELECT c.CountryCode, m.MountainRange AS [CountriesWithoutMountains]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m
	ON mc.MountainId = m.Id) AS a
WHERE a.CountriesWithoutMountains IS NULL