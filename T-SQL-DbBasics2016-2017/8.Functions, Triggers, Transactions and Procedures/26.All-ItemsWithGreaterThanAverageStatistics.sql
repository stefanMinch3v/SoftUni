SELECT i.Name,
	   i.Price,
	   i.MinLevel,
	   s.Strength,
	   s.Defence,
	   s.Speed,
	   s.Luck,
	   s.Mind
FROM Items AS i
INNER JOIN [Statistics] AS s
	ON i.StatisticId = s.Id
WHERE s.Speed > (SELECT AVG(st.Speed) FROM [Statistics] AS st) AND 
	  s.Luck > (SELECT AVG(st.Luck) FROM [Statistics] AS st) AND 
	  s.Mind > (SELECT AVG(st.Mind) FROM [Statistics] AS st)
ORDER BY i.Name