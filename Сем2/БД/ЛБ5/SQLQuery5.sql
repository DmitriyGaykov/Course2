--5. На основе таблиц FACULTY и PUL-PIT сформировать список наименований 
--факультетов на котором нет ни одной ка-федры (таблица PULPIT). 
--Использовать предикат EXISTS и кор-релированный подзапрос. 
use UNIVER

select FACULTY.FACULTY_NAME from 
	   FACULTY where not exists (select PULPIT.FACULTY from PULPIT
								 where FACULTY.FACULTY = PULPIT.FACULTY)


use Lab2
select SUPPLIERS.TITLE from SUPPLIERS where not exists (select ORDERS.IDDETAIL from ORDERS where SUPPLIERS.IDSUPPLIER = ORDERS.IDSUPPLIER)