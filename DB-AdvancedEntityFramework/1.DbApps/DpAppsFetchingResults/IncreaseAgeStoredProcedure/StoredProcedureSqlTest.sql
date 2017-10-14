CREATE PROC usp_GetOlder
(@MinionId int)
AS
BEGIN
	UPDATE Minions
	SET Age += 1
	WHERE MinionId = @MinionId
END

--EXEC usp_GetOlder 6