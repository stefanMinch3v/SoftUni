SELECT usages.ContinentCode, usages.CurrencyCode, usages.Usage AS [CurrencyUsage] FROM
(
	SELECT ContinentCode, CurrencyCode, COUNT(*) AS Usage FROM Countries AS c
	GROUP BY ContinentCode, CurrencyCode
	HAVING COUNT(*) > 1
) AS usages
INNER JOIN
(
	SELECT usages.ContinentCode, MAX(usages.Usage) AS MaxUsage FROM
	(
		SELECT ContinentCode, CurrencyCode, COUNT(*) AS Usage FROM Countries AS c
		GROUP BY ContinentCode, CurrencyCode
	) AS usages
	GROUP BY usages.ContinentCode
) AS maxUsages ON usages.ContinentCode = maxUsages.ContinentCode AND maxUsages.MaxUsage = usages.Usage