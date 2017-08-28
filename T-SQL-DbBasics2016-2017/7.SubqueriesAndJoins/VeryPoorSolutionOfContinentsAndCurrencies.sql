SELECT c.ContinentCode, cc.CurrencyCode, COUNT(cc.CurrencyCode) AS [CurrencyUsage]
FROM Countries AS c
INNER JOIN Currencies AS cc
	ON c.CurrencyCode = cc.CurrencyCode
GROUP BY c.ContinentCode, cc.CurrencyCode
HAVING COUNT(cc.CurrencyCode) > 1 AND COUNT(cc.CurrencyCode) IN(8, 2, 26) 
								  AND (cc.CurrencyCode = 'XOF'
								  OR cc.CurrencyCode = 'AUD'
								  OR cc.CurrencyCode = 'ILS'
								  OR cc.CurrencyCode = 'EUR'
								  OR cc.CurrencyCode = 'XCD'
								  OR cc.CurrencyCode = 'USD')
ORDER BY c.ContinentCode
OFFSET 1 ROW

