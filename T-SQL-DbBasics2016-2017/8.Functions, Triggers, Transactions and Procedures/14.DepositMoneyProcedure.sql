CREATE PROC usp_DepositMoney 
(@AccountId int, @moneyAmount money)
AS
BEGIN TRAN
IF(@moneyAmount  <= 0)
	BEGIN
		ROLLBACK
		RAISERROR('Deposit cannot be negative', 16, 1)
		RETURN
	END
ELSE
	UPDATE Accounts
	SET Balance += @moneyAmount
	WHERE Id = @AccountId
COMMIT

EXEC dbo.usp_DepositMoney 5, -55