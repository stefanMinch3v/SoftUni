﻿BEGIN TRAN


UPDATE Minions
SET Name = CONCAT(LOWER(LEFT(Name, 1)), RIGHT(Name, LEN(Name) - 1)), Age+=1
WHERE MinionID = 3


SELECT * FROM Minions
ROLLBACK