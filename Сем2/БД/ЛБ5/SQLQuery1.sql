--1. �� ������ ������ FACULTY, PULPIT � PROFESSION ������������ ������ ������������ ������, ������� ��������� �� ����������,
--�������������� ���������� �� �������������, � ������������ �������� ���������� ����� ���������� ��� ����������. 
--������������ � ������ WHERE �������� IN c ����������������� ����������� � ������� PROFESSION. 

use UNIVER

select PULPIT.PULPIT_NAME from FACULTY, PULPIT
	where FACULTY.FACULTY = PULPIT.FACULTY and
		  FACULTY.FACULTY in (select PROFESSION.FACULTY from PROFESSION
									where PROFESSION.PROFESSION_NAME like N'%����������%' or
										  PROFESSION.PROFESSION_NAME like N'%����������%')

select * from PROFESSION where PROFESSION.PROFESSION_NAME like N'%����������%' or
										  PROFESSION.PROFESSION_NAME like N'%����������%'

--------------------------------------------------------------------------------------------------

use Lab2

select SUPPLIERS.TITLE, DETAILS.TITLE, INVENTORIES.COUNT_DETAILS from SUPPLIERS, INVENTORIES join DETAILS on INVENTORIES.IDDETAIL = DETAILS.IDDETAIL where SUPPLIERS.IDSUPPLIER = INVENTORIES.IDSUPPLIER and
														 SUPPLIERS.IDSUPPLIER in (select i.IDSUPPLIER from INVENTORIES i
																						where i.COUNT_DETAILS > 50)  