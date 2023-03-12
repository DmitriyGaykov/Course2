--1. На основе таблиц FACULTY, PULPIT и PROFESSION сформировать список наименований кафедр, которые находятся на факультете,
--обеспечивающем подготовку по специальности, в наименовании которого содержится слово технология или технологии. 
--Использовать в секции WHERE предикат IN c некоррелированным подзапросом к таблице PROFESSION. 

use UNIVER

select PULPIT.PULPIT_NAME from FACULTY, PULPIT
	where FACULTY.FACULTY = PULPIT.FACULTY and
		  FACULTY.FACULTY in (select PROFESSION.FACULTY from PROFESSION
									where PROFESSION.PROFESSION_NAME like N'%технологии%' or
										  PROFESSION.PROFESSION_NAME like N'%технология%')

select * from PROFESSION where PROFESSION.PROFESSION_NAME like N'%технологии%' or
										  PROFESSION.PROFESSION_NAME like N'%технология%'

--------------------------------------------------------------------------------------------------

use Lab2

select SUPPLIERS.TITLE, DETAILS.TITLE, INVENTORIES.COUNT_DETAILS from SUPPLIERS, INVENTORIES join DETAILS on INVENTORIES.IDDETAIL = DETAILS.IDDETAIL where SUPPLIERS.IDSUPPLIER = INVENTORIES.IDSUPPLIER and
														 SUPPLIERS.IDSUPPLIER in (select i.IDSUPPLIER from INVENTORIES i
																						where i.COUNT_DETAILS > 50)  