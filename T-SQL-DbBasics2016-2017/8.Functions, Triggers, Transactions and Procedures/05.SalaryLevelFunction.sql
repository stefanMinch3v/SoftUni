CREATE function ufn_GetSalaryLevel
(@salary money)
RETURNS varchar(7) 
AS 
BEGIN
	DECLARE @resultString varchar(7)
	IF(@salary < 30000)
		BEGIN
			SET @resultString = 'Low'
		END
	ELSE IF(@salary BETWEEN 30000 AND 50000)
		BEGIN
			SET @resultString = 'Average'
		END
	ELSE
		BEGIN
			SET @resultString = 'High'
		END
	RETURN @resultString
END

--SELECT Salary, dbo.ufn_GetSalaryLevel([Salary]) AS [Salary Level]
--FROM Employees