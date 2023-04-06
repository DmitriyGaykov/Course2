--6. ����������� ��������, � ������� � ������� CASE ������������� ������,
--���������� ���������� ���������� ��-�������� ��� ����� ���������.
use UNIVER

DECLARE @FACULTY NVARCHAR(4) = '����' 

SELECT 
	S.[NAME],
	CASE 
		WHEN AVG(P.NOTE) BETWEEN 0 AND 3 THEN '�����'
		WHEN AVG(P.NOTE) BETWEEN 4 AND 7 THEN '�����'
		WHEN AVG(P.NOTE) BETWEEN 7 AND 10 THEN '�������'
	END [������������]
FROM STUDENT S
	 JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
	 JOIN GROUPS G ON S.IDGROUP = G.IDGROUP AND G.FACULTY = @FACULTY
GROUP BY S.[NAME]