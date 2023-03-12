--. ѕереписать запрос, реализующий 1 пункт без использовани€ подзапроса.
--ѕримеча-ние: использовать соединение INNER JOIN трех таблиц. 
use UNIVER
select distinct PULPIT.PULPIT_NAME from
		PROFESSION inner join FACULTY on
			PROFESSION.FACULTY = FACULTY.FACULTY and 
			(PROFESSION.PROFESSION_NAME like '%технологии%' or PROFESSION.PROFESSION_NAME like '%технологи€%')
		inner join PULPIT on PULPIT.FACULTY = FACULTY.FACULTY;
		
-----------------------------------------------------------------------------------

use Lab2
select SUPPLIERS.TITLE, DETAILS.TITLE, INVENTORIES.COUNT_DETAILS from (SUPPLIERS join INVENTORIES on SUPPLIERS.IDSUPPLIER = INVENTORIES.IDSUPPLIER) join DETAILS on INVENTORIES.IDDETAIL = DETAILS.IDDETAIL
where INVENTORIES.COUNT_DETAILS > 50