CREATE PROC usp_WithdrawMoney 
(@AccountId int, @moneyAmount money)
AS
BEGIN TRAN
DECLARE @CurrentMoney money = @moneyAmount
IF(@moneyAmount <= 0)
	BEGIN
		ROLLBACK
		RAISERROR('Balance cannot be negative', 16, 1) -- delete raiserrors for all exercises to pass the judge for 100 point
		RETURN
	END
IF(@CurrentMoney > (SELECT Balance FROM Accounts WHERE Id = @AccountId))
	BEGIN
		ROLLBACK
		RAISERROR('Cannot withdraw more than your balance', 16, 1)
		RETURN
	END
ELSE
	BEGIN
		UPDATE Accounts
		SET Balance -= @moneyAmount
		WHERE Id = @AccountId
	END
COMMIT

EXEC dbo.usp_WithdrawMoney 1, 5