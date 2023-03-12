--2. �� ������ ������ AUDITORIUM � AUDITORIUM_TYPE ����������� ������, ����������� ��� ������� 
--���� ��������� ������������, �����������, ������� ����������� ���������, ��������� ���-�������� ���� ���������
--� ����� ������-���� ��������� ������� ����. 
--�������������� ����� ������ �����-���� ������� � ������������� ���� ����-����� � ������� � ������������ ������-����. 
--������������ ���������� ���������� ������, ������ GROUP BY � ���������� �������. 

use UNIVER

select 
AUDITORIUM_TYPE.AUDITORIUM_TYPENAME, 
max(AUDITORIUM.AUDITORIUM_CAPACITY) as 'MAX', 
min(AUDITORIUM.AUDITORIUM_CAPACITY) as 'MIN', 
avg(AUDITORIUM.AUDITORIUM_CAPACITY) as 'AVG',
sum(AUDITORIUM.AUDITORIUM_CAPACITY) as 'SUM', 
count(AUDITORIUM.AUDITORIUM_TYPE) as 'COUNT'

from AUDITORIUM_TYPE join AUDITORIUM  on 
	AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE group by AUDITORIUM_TYPE.AUDITORIUM_TYPENAME


use Lab2

select SUPPLIERS.TITLE,
	   max(ORDERS.COUNT_ORDERED_DETAILS) as [������������ �����],
	   min(ORDERS.COUNT_ORDERED_DETAILS) as [����������� �����],
	   avg(ORDERS.COUNT_ORDERED_DETAILS) as [������� ���������� ���������� �������],
	   sum(ORDERS.COUNT_ORDERED_DETAILS) as [����� ���� ���������� �������],
	   count(*) as [����� ���������� �������]

from SUPPLIERS join ORDERS on SUPPLIERS.IDSUPPLIER = ORDERS.IDSUPPLIER
group by SUPPLIERS.TITLE, ORDERS.IDSUPPLIER