--. �� ������ ������� PROGRESS ������-������ ������, ���������� ������� ���-����� 
--������ (������� NOTE) �� �����-������, ������� ��������� ����: ����, �� � ����. 
--����������: ������-������ ��� ����������������� ���������� � ������ SELECT;
--� ����������� �����-���� ���������� ������� AVG. 
use UNIVER

SELECT 
top(1)
(SELECT  AVG(NOTE) FROM PROGRESS WHERE [SUBJECT] = '����') AS '����',
(SELECT AVG(NOTE) FROM PROGRESS WHERE [SUBJECT] = '��') AS '��',
(SELECT  AVG(NOTE) FROM PROGRESS WHERE [SUBJECT] = '����') AS '����'
FROM PROGRESS;

use Lab2

select top(1)
(select avg(INVENTORIES.COUNT_DETAILS) from INVENTORIES where INVENTORIES.IDSUPPLIER = 1) as '�1',
(select avg(INVENTORIES.COUNT_DETAILS) from INVENTORIES where INVENTORIES.IDSUPPLIER = 2) as '�2',
(select avg(INVENTORIES.COUNT_DETAILS) from INVENTORIES where INVENTORIES.IDSUPPLIER = 3) as '�3',
(select avg(INVENTORIES.COUNT_DETAILS) from INVENTORIES where INVENTORIES.IDSUPPLIER = 4) as '�4'
