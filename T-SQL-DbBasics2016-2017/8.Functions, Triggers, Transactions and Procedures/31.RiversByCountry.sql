SELECT c.CountryName,
	   cc.ContinentName,
	   COUNT(cr.RiverId) AS [RiverCount],
	   CASE
			WHEN SUM(r.Length) IS NULL THEN 0
			ELSE SUM(r.Length)
		END AS [TotalLength]
FROM Countries AS c
FULL JOIN Continents AS cc
	ON c.ContinentCode = cc.ContinentCode
FULL JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
FULL JOIN Rivers AS r
	ON cr.RiverId = r.Id
GROUP BY c.CountryName, cc.ContinentName
ORDER BY COUNT(cr.RiverId) DESC, SUM(r.Length) DESC, c.CountryName ASC