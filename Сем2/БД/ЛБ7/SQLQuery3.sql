--3. �� ������ ������ GROUPS, STU-DENT � PROGRESS ����������� SELECT-������, � ������� ������������ ���������� ����� ���������.
--� ������� ������ ���������� ��������-�����, ����������, ������� ������ ������-��� �� ���������� ���.
--�������� ����������� ������, � ������� ������������ ���������� ����� ��������� �� ���������� ����.
--���������� ���������� ���� �������� � �������������� ���������� UNION � UN-ION ALL. ��������� ����������. 

use UNIVER

SELECT
	G.PROFESSION,
	P.SUBJECT,
	AVG(P.NOTE) as [������� ������]
FROM
	GROUPS G
	JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
	JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
WHERE G.FACULTY = N'����'
GROUP BY G.PROFESSION, P.SUBJECT

--UNION ALL
UNION

SELECT
	G.PROFESSION,
	P.SUBJECT,
	AVG(P.NOTE) as [������� ������]
FROM
	GROUPS G
	JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
	JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
WHERE G.FACULTY = N'����'
GROUP BY G.PROFESSION, P.SUBJECT