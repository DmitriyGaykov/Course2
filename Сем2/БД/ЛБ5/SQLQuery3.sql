--. ���������� ������, ����������� 1 ����� ��� ������������� ����������.
--�������-���: ������������ ���������� INNER JOIN ���� ������. 
use UNIVER
select distinct PULPIT.PULPIT_NAME from
		PROFESSION inner join FACULTY on
			PROFESSION.FACULTY = FACULTY.FACULTY and 
			(PROFESSION.PROFESSION_NAME like '%����������%' or PROFESSION.PROFESSION_NAME like '%����������%')
		inner join PULPIT on PULPIT.FACULTY = FACULTY.FACULTY;
		
-----------------------------------------------------------------------------------

use Lab2
select SUPPLIERS.TITLE, DETAILS.TITLE, INVENTORIES.COUNT_DETAILS from (SUPPLIERS join INVENTORIES on SUPPLIERS.IDSUPPLIER = INVENTORIES.IDSUPPLIER) join DETAILS on INVENTORIES.IDDETAIL = DETAILS.IDDETAIL
where INVENTORIES.COUNT_DETAILS > 50