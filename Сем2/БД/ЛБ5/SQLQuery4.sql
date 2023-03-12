--4. �� ������ ������� AUDITORIUM ������������ ������ ��������� ����� �������
--������������ ��� ������� ���� ���������. ��� ���� ��������� ������� �������������
--� ������� �������� ���-��������. ����������: ������������ ���-���������� ���������
--c �������� TOP � ORDER BY. 
use UNIVER

select distinct a.AUDITORIUM_TYPE, AUDITORIUM_CAPACITY from
	AUDITORIUM as a
	where a.AUDITORIUM_CAPACITY = (select top(1) aa.AUDITORIUM_CAPACITY from AUDITORIUM as aa
								   where aa.AUDITORIUM_TYPE = a.AUDITORIUM_TYPE 
								   order by aa.AUDITORIUM_CAPACITY desc) order by a.AUDITORIUM_CAPACITY desc

----------------------------------------------------------
use Lab2

select SUPPLIERS.TITLE, o1.COUNT_ORDERED_DETAILS from ORDERS as o1 join SUPPLIERS on o1.IDSUPPLIER = SUPPLIERS.IDSUPPLIER
where o1.COUNT_ORDERED_DETAILS = (select top(1) o2.COUNT_ORDERED_DETAILS from ORDERS as o2
								  where o2.IDSUPPLIER = o1.IDSUPPLIER order by o2.COUNT_ORDERED_DETAILS desc) order by o1.COUNT_ORDERED_DETAILS desc
