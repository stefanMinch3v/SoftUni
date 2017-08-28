CREATE PROC usp_AssignProject
(@emloyeeId int, @projectID int)
AS
BEGIN TRAN
	INSERT INTO EmployeesProjects VALUES(@emloyeeId, @projectID)
	IF((SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId) > 3)
		BEGIN
			ROLLBACK
			RAISERROR('The employee has too many projects!', 16, 1)
			RETURN
		END
COMMIT

--EXEC dbo.usp_AssignProject 2, 4