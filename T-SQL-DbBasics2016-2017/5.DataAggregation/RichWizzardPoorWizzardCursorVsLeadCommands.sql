--cursor way
--DECLARE @previousDeposit DECIMAL(8,2)
--DECLARE @currentDeposit DECIMAL(8,2)
--DECLARE @totalSum DECIMAL(8,2) = 0 

--DECLARE wizardCursors CURSOR FOR SELECT DepositAmount FROM WizzardDeposits
--OPEN wizardCursors
--FETCH NEXT FROM wizardCursors INTO @currentDeposit

--WHILE(@@FETCH_STATUS = 0)
--BEGIN
--IF(@previousDeposit IS NOT NULL)
--BEGIN
--	SET @totalSum += (@previousDeposit - @currentDeposit)
--END

--SET @previousDeposit = @currentDeposit
--FETCH NEXT FROM wizardCursors INTO @currentDeposit
--END

--CLOSE wizardCursors 
--DEALLOCATE wizardCursors

--SELECT @totalSum

--lead way - easy way 
SELECT SUM(wizzardDep.Difference) FROM
(
SELECT 
	FirstName,
	DepositAmount,
	LEAD(FirstName) OVER (ORDER BY Id) AS GuestWizzard,
	LEAD(DepositAmount) OVER (ORDER BY Id) AS GuestDeposit,
	DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Difference
FROM WizzardDeposits
) AS wizzardDep

--LEAD is for the next row and LAG is for the previous row