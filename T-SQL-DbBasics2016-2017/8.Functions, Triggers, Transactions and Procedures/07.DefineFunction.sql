CREATE FUNCTION ufn_IsWordComprised
(@setOfLetters varchar(MAX), @word varchar(MAX))
RETURNS bit
AS
BEGIN
	DECLARE @ResultTrueOrFalse bit
	DECLARE @FoundedSymbols int = 0
	DECLARE @StartIndex int = 1

	WHILE(@StartIndex <= LEN(@word))
		BEGIN
			DECLARE @CurrentSymbol char(1) = SUBSTRING(@word, @StartIndex, 1)
			IF(CHARINDEX(@CurrentSymbol, @setOfLetters) > 0)
				BEGIN
					SET @FoundedSymbols += 1
				END
			SET @StartIndex += 1
		END
	IF(@FoundedSymbols = LEN(@word))
		BEGIN
			SET @ResultTrueOrFalse = 1
		END
	ELSE
		BEGIN
			SET @ResultTrueOrFalse = 0
		END
	RETURN @ResultTrueOrFalse
END


--DECLARE @asd bit
--EXEC @asd = dbo.ufn_IsWordComprised 'oistmiahf', 'halves'
--PRINT @asd
