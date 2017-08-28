SELECT g.Name AS [Game],
	   gp.Name AS [Game Type],
	   u.Username AS [Username],
	   ug.Level AS [Level],
	   ug.Cash AS [Cash],
	   c.Name AS [Character] 
FROM GameTypes AS gp
INNER JOIN Games AS g
	ON gp.Id = g.GameTypeId
INNER JOIN UsersGames AS ug
	ON g.Id = ug.GameId
INNER JOIN Users AS u
	ON ug.UserId = u.Id
INNER JOIN Characters AS c
	ON ug.CharacterId = c.Id
ORDER BY [Level] DESC, [Username], [Game]