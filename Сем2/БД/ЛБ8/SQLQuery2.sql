--2. ����������� � ������� ������������� � ������ ���������� ������. 
--������������� ������ ���� ��������� �� ������ SELECT-������� � ��������
--FACULTY � PULPIT.
--������������� ������ ��������� ������-��� �������:
--���������, ���������� ������ (����������� �� ������ ����� ������� PULPIT). 

use UNIVER;

GO
CREATE VIEW [���������� ������]
as SELECT
	F.FACULTY_NAME [���������],
	COUNT(*) AS [���������� ������]
FROM 
	FACULTY F
	JOIN PULPIT P ON F.FACULTY = P.FACULTY
GROUP BY F.FACULTY_NAME

SELECT * FROM [���������� ������]

DROP VIEW [���������� ������]