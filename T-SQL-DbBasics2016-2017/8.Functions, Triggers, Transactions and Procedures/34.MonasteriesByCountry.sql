--Task 1
CREATE TABLE [dbo].[Monasteries]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CountryCode] [char](2) NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0,
	CONSTRAINT [FK_Monasteries_Countries] FOREIGN KEY([CountryCode])
	REFERENCES [dbo].[Countries] ([CountryCode])
)

--Task 2
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sumela Monastery', 'TR')

--Task 3
ALTER TABLE Countries
ADD IsDeleted bit DEFAULT 0 NOT NULL

--Task 4
UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN  ( 
						SELECT cr.CountryCode 
						FROM
							(
								SELECT cr.CountryCode,
									   COUNT(cr.RiverId) AS [CountRivers]
								FROM CountriesRivers AS cr
								GROUP BY cr.CountryCode
								HAVING COUNT(cr.RiverId) > 3
							) AS cr					 
					 )

--Task 5
SELECT m.Name AS [Monastery],
	   c.CountryName AS [Country]
FROM Monasteries AS m
INNER JOIN Countries AS c
	ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name