--9. Разработать сценарий с ошибками, в котором 
--используются для обработки ошибок блоки TRY и CATCH. 
--Применить функции ER-ROR_NUMBER (код последней ошиб-ки),
--ERROR_MESSAGE (сообщение об ошибке), ERROR_LINE (номер строки
--с ошибкой), ERROR_PROCEDURE (имя процедуры или NULL), ER-ROR_SEVERITY
--(уровень серьезности ошибки), ERROR_STATE (метка ошиб-ки). 
--Проанализировать результат.

USE UNIVER;
BEGIN TRY
	UPDATE PROGRESS SET NOTE = 'hello world' WHERE NOTE = 9
END TRY
BEGIN CATCH
	PRINT ERROR_NUMBER()
	PRINT ERROR_MESSAGE() 
	PRINT ERROR_LINE() 
	PRINT ERROR_PROCEDURE() 
	PRINT ERROR_SEVERITY() 
	PRINT ERROR_STATE() 
END CATCH