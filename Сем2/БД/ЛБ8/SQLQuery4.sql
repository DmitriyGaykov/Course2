--5. ����������� ������������� � ������ ���-�������. 
--������������� ������ ���� ��-������� �� ������ SELECT-������� 
--� ������� SUBJECT, ���������� ��� ���������� � ��-�������� ������� 
--� ��������� ��������� �������: ���, ������������ ���������� � ��� �������. 
--������������ TOP � ORDER BY.

CREATE VIEW DISC
AS SELECT
	TOP(100)
	S.SUBJECT [CODE],
	S.SUBJECT_NAME [NAME],
	S.PULPIT [PULPIT CODE]
FROM [SUBJECT] S
ORDER BY S.SUBJECT_NAME


SELECT * FROM DISC

DROP VIEW DISC