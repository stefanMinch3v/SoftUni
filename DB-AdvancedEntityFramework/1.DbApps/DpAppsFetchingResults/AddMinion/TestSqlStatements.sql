﻿BEGIN TRAN
INSERT INTO Minions(Name, TownId)
VALUES
(@Name, @TownId)
ROLLBACK
