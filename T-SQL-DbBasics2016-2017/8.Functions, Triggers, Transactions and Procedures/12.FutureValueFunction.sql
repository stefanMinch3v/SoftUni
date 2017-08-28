CREATE FUNCTION ufn_CalculateFutureValue
(@Sum money, @InterestRate float, @NumberOfYears int)
RETURNS money
BEGIN
	DECLARE @Result AS money
	SET @Result = @Sum * (POWER(1 + @InterestRate, @NumberOfYears))
	RETURN @Result
END

DECLARE @asd decimal(18, 2)
EXEC @asd = dbo.ufn_CalculateFutureValue 1000, 0.1, 5
PRINT @asd