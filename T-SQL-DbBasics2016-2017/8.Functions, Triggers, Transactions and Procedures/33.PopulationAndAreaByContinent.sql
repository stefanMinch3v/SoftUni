SELECT c.ContinentName,
	   SUM(CONVERT(bigint, cc.AreaInSqKm)) AS [CountriesArea],
	   SUM(CONVERT(bigint, cc.[Population])) AS [CountriesPopulation]
FROM Continents AS c
INNER JOIN Countries AS cc
	ON c.ContinentCode = cc.ContinentCode
GROUP BY c.ContinentName
ORDER BY [CountriesPopulation] DESC