CREATE FUNCTION ufn_CashInUsersGames 
(@GameName varchar(30))
RETURNS @SomeTable TABLE (SumCash money)
AS
BEGIN
		DECLARE @ResultSum money = (SELECT SUM(FinalResult.Cash) FROM
										(SELECT * FROM 
											(SELECT g.Name,
												   ug.Cash,
												   ROW_NUMBER() OVER (ORDER BY Cash DESC) AS [RowNumber]
												FROM UsersGames AS ug
												INNER JOIN Games AS g
												ON g.Id = ug.GameId
												WHERE g.Name = @GameName
											) AS result
											WHERE result.RowNumber % 2 = 1
										) AS FinalResult
									)
		INSERT INTO @SomeTable (SumCash)
		VALUES (@ResultSum)
		RETURN
END

DECLARE @table AS TABLE (SumCash money)

INSERT INTO @table
SELECT * FROM ufn_CashInUsersGames('Love in a mist')

SELECT * FROM @table