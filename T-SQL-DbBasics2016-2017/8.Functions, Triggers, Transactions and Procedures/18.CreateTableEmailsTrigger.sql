CREATE TABLE NotificationEmails
(
	Id int PRIMARY KEY IDENTITY,
	Recipient int NOT NULL,
	Subject varchar(100) NOT NULL,
	Body varchar(100) NOT NULL,
)


CREATE TRIGGER trg_EmailNotifications_Logs
ON Logs
AFTER INSERT, UPDATE
AS
BEGIN
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	SELECT d.AccountId,
		   CONCAT('Balance change for account: ',d.AccountId),
		   CONCAT('On ', GETDATE(), ' your balance was changed from ', d.OldSum, ' to ', d.NewSum, '.') 
		   FROM inserted AS d
END

UPDATE Accounts
SET Balance += 100
WHERE Id = 5

SELECT * FROM NotificationEmails