CREATE TABLE Logs
(
	LogId int PRIMARY KEY IDENTITY,
	AccountId int CONSTRAINT FK_Logs_Accounts FOREIGN KEY REFERENCES Accounts(Id), 
	OldSum money, 
	NewSum money
)

CREATE TRIGGER trg_Accounts_After_Update 
ON Accounts
AFTER UPDATE -- FOR UPDATE is the same command
AS
BEGIN
	 INSERT INTO Logs (AccountId, OldSum, NewSum)
	 SELECT i.Id, d.Balance, i.Balance FROM inserted AS i --inserted -- the table results after the update command
	 INNER JOIN deleted AS d ON d.Id = i.Id --deleted -- the table results before the update command
END

SELECT * FROM Accounts
WHERE Id = 1

UPDATE Accounts
SET Balance += 10
WHERE Id = 1

SELECT * FROM Logs