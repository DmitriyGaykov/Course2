--7. ������� ��������� ��������� ������� �� ����
--�������� � 10 �����, ��������� �� � ������� ����������.
--������������ �������� WHILE

CREATE TABLE #TABLE(
	ID INT PRIMARY KEY,
	[NAME] NVARCHAR(30),
	AGE INT
);

DECLARE @I INT = 0

DECLARE @ID INT
DECLARE @NAME NVARCHAR(30)
DECLARE @AGE INT

WHILE @I < 10
BEGIN
	SET @ID = @I;
	SET @NAME = 'NAME' + CONVERT(nvarchar, @I);
	SET @AGE = FLOOR(RAND() * 50) + 20;

	INSERT #TABLE VALUES(@ID, @NAME, @AGE);

	SET @I = @I + 1
END


SELECT * FROM #TABLE

DROP TABLE #TABLE