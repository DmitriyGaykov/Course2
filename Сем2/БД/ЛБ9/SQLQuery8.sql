--9. ����������� �������� � ��������, � ������� 
--������������ ��� ��������� ������ ����� TRY � CATCH. 
--��������� ������� ER-ROR_NUMBER (��� ��������� ����-��),
--ERROR_MESSAGE (��������� �� ������), ERROR_LINE (����� ������
--� �������), ERROR_PROCEDURE (��� ��������� ��� NULL), ER-ROR_SEVERITY
--(������� ����������� ������), ERROR_STATE (����� ����-��). 
--���������������� ���������.

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