SELECT REPLACE(SUBSTRING(Email, CHARINDEX('@', Email), LEN(Email)), '@', '') AS EmailProvider, 
	   COUNT(Id) AS [Number Of Users]
FROM Users
GROUP BY REPLACE(SUBSTRING(Email, CHARINDEX('@', Email), LEN(Email)), '@', '')
ORDER BY [Number Of Users] DESC, EmailProvider ASC