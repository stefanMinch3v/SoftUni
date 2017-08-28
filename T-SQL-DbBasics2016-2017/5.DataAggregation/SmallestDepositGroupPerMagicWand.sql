SELECT DepositGroup 
FROM WizzardDeposits
GROUP BY DepositGroup
HAVING AVG(MagicWandSize) = (SELECT MIN(averageTable.LowestAverageWand)
							 FROM (SELECT DepositGroup, AVG(MagicWandSize) AS [LowestAverageWand]
							 FROM WizzardDeposits
							 GROUP BY DepositGroup)
							 AS averageTable)