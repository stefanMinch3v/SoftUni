CREATE PROC usp_TransferMoney
(@senderId int, @receiverId int, @amount money)
AS
EXEC dbo.usp_WithdrawMoney @senderId, @amount
EXEC dbo.usp_DepositMoney @receiverId, @amount

EXEC dbo.usp_TransferMoney 2, 1, 100