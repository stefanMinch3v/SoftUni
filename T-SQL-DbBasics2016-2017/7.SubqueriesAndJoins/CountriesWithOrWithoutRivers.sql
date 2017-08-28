SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
FULL JOIN CountriesRivers as cr --or LEFT JOIN
	ON c.CountryCode = cr.CountryCode
FULL JOIN Rivers AS r -- OR LEFT JOIN
	ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName