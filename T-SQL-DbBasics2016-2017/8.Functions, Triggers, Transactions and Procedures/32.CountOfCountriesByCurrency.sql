SELECT c.CurrencyCode,
	   c.Description AS [Currency],
	   COUNT(cc.CountryCode) AS [NumberOfCountries]
FROM Currencies AS c
LEFT JOIN Countries AS cc
	ON c.CurrencyCode = cc.CurrencyCode
GROUP BY c.CurrencyCode, c.Description
ORDER BY [NumberOfCountries] DESC, [Currency]
