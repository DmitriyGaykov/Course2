--2. Разработать скрипт, в котором определяется общая вместимость ауди-торий.
--Если общая вместимость превышает 200, то вывести количество аудиторий, среднюю вместимость аудиторий,
--коли-чество аудиторий, вместимость которых меньше средней, и процент таких ауди-торий. 
--Если общая вместимость аудиторий меньше 200, то вывести сообщение о размере общей вместимости.

use UNIVER;

DECLARE @SUM INT = 0,
		@COUNT INT,
		@AVG INT,
		@COUNTLESS INT,
		@PERCENT INT

SELECT @SUM = sum(A.AUDITORIUM_CAPACITY)
FROM AUDITORIUM A

IF @SUM > 200
BEGIN
	SET @COUNT = (SELECT COUNT(*) FROM AUDITORIUM)
	SET @AVG = (SELECT AVG(A.AUDITORIUM_CAPACITY) FROM AUDITORIUM A)
	SET @COUNTLESS = (SELECT COUNT(*) FROM AUDITORIUM A WHERE A.AUDITORIUM_CAPACITY < @AVG)
	SET @PERCENT = CAST(@COUNTLESS AS FLOAT) / CAST(@COUNT AS FLOAT) * 100;

	PRINT 'COUNT: ' + CONVERT(NVARCHAR, @COUNT) + '   AVG: ' + CONVERT(NVARCHAR, @AVG) + 
	'   COUNTLESS: ' + CONVERT(NVARCHAR, @COUNTLESS) + '   PERCENT: ' + CONVERT(NVARCHAR, @PERCENT)  
END
ELSE
BEGIN
	PRINT 'SUM: ' + CONVERT(NVARCHAR, @SUM)
END