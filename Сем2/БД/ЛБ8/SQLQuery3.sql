--3. ����������� � ������� ������������� � ������ ���������. 
--������������� ������ ���� ��������� �� ������ ������� AUDITORIUM
--� ��������� �������: ���, ������������ ���������. 
--������������� ������ ���������� ������ ���������� ��������� 
--(� ������� AUDITORIUM_ TYPE ������, ������������ � ������� ��) 
--� ��������� ���������� ��������� INSERT, UPDATE � DELETE.

CREATE VIEW ���������  (AUDITORIUM_TYPE,AUDITORIUM)
AS SELECT
	A.AUDITORIUM [���],
	A.AUDITORIUM_TYPE [���]
FROM AUDITORIUM A
WHERE A.AUDITORIUM_TYPE LIKE '��%'

INSERT  [���������] VALUES ('��','��')
DELETE FROM ��������� where AUDITORIUM='��'
UPDATE ��������� SET  AUDITORIUM = 'TEST' 
WHERE AUDITORIUM = '��'


SELECT * FROM ���������

DROP VIEW ���������

--4. ����������� � ������� ������������� � ������ ����������_���������. 
--������������� ������ ���� ��������� �� ������ SELECT-������� � 
--������� AUDITORIUM � ��������� ��������� �������: ���, ������������ ���������. 
--������������� ������ ���������� ������ ���������� ��������� 
--(� ������� AUDITORIUM_TYPE ������, ������������ � �������� ��). 

USE UNIVER;
GO 
CREATE VIEW  [���������� ���������] (AUDITORIUM_TYPE,AUDITORIUM)
as select 
	AUDITORIUM.AUDITORIUM_TYPE as [������������ ���������],
	AUDITORIUM.AUDITORIUM as [���]
FROM AUDITORIUM
WHERE AUDITORIUM.AUDITORIUM_TYPE LIKE '��%' WITH CHECK OPTION

SELECT * FROM [���������� ���������]