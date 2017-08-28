SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS [AverageInterest]
FROM WizzardDeposits
WHERE DATEPART(year, DepositStartDate) >= 1985 --or WHERE DepositStartDate > '01/01/1985' // shortcut
		AND DATEPART(month, DepositStartDate) >= 01
		AND DATEPART(day, DepositStartDate) >= 01
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

