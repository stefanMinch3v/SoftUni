SELECT Username, REPLACE(SUBSTRING(Email, CHARINDEX('@', Email), LEN(Email)), '@', '') AS EmailProvider
FROM Users
ORDER BY EmailProvider, Username