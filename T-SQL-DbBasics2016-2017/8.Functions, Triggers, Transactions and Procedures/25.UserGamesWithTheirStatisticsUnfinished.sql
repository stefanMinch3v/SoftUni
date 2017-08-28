SELECT u.Username AS [Username],
	   g.Name AS [Games],
	   c.Name AS [Characters],
	   SUM(s.Strength) AS [Strength],
	   SUM(s.Defence) AS [Defence],
	   SUM(s.Speed) AS [Speed],
	   SUM(s.Mind) AS [Mind],
	   SUM(s.Luck) AS [Luck]
FROM Users AS u
INNER JOIN UsersGames AS ug
	ON u.Id = ug.UserId
INNER JOIN Games AS g
	ON ug.GameId = g.Id
INNER JOIN Characters AS c
	ON ug.CharacterId = c.Id
INNER JOIN [Statistics] AS s
	ON c.StatisticId = s.Id
INNER JOIN UserGameItems AS ugi
	ON ug.Id = ugi.UserGameId
INNER JOIN Items AS i
	ON ugi.ItemId = i.Id
GROUP BY u.Username, g.Name, c.Name