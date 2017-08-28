--Task 1
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

--Task 2
INSERT INTO Monasteries(Name, CountryCode)
VALUES
('Hanga Abbey', 'TZ')

--Task 3
INSERT INTO Monasteries(Name, CountryCode)
VALUES
('Myin-Tin-Daik', 'MM')

--Task 4
SELECT c.ContinentName,
	   cc.CountryName,
	   COUNT(m.CountryCode) AS [MonasteriesCount]
FROM Continents AS c
LEFT JOIN Countries AS cc
	ON c.ContinentCode = cc.ContinentCode
LEFT JOIN Monasteries AS m
	ON cc.CountryCode = m.CountryCode
WHERE cc.IsDeleted = 0
GROUP BY c.ContinentName, cc.CountryName
ORDER BY MonasteriesCount DESC, cc.CountryName ASC