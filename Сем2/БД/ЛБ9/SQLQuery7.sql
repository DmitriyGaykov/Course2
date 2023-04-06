--8. Разработать скрипт, демонстриру-ющий использование оператора RE-TURN. 

DECLARE @I INT = 0;

WHILE 0 = 0
BEGIN
	IF @I > 30
	BEGIN
		RETURN
	END

	PRINT CONVERT(NVARCHAR, @I)

	SET @I = @I + 1
END