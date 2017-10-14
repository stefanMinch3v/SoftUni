BEGIN TRAN

SELECT v.Name
FROM Villians AS v
WHERE v.VillianId = @VillianId

SELECT COUNT(*) FROM MinionsVillians 
WHERE VillianId = @VillianId

DELETE FROM Villians
WHERE VillianId = @VillianId

ROLLBACK