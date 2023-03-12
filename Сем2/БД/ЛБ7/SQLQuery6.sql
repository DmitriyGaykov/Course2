--7*. ���������� ���������� ��������� � ������ ������, 
--�� ������ ���������� � ����� � ������������ ����� ��������.
--���-������� ���������� ��������� �� ����� � ��������� ����������� � 
--�������� � ����� ����� ��������.

SELECT
	F.FACULTY,
	G.IDGROUP,
	COUNT(*) AS [Count in group]
FROM 
	FACULTY F
	JOIN GROUPS G ON F.FACULTY = G.FACULTY
	JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
GROUP BY F.FACULTY, G.IDGROUP
