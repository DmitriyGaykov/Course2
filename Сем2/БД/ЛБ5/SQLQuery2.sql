--2. Переписать запрос пункта 1 таким образом, чтобы тот же подзапрос был за-писан 
--в конструкции INNER JOIN секции FROM внешнего запроса. При этом ре-зультат 
--выполнения запроса должен быть аналогичным результату исходного запро-са. 
use UNIVER

select PULPIT.PULPIT_NAME from
	   PULPIT inner join FACULTY on
			PULPIT.FACULTY = FACULTY.FACULTY and
			FACULTY.FACULTY in (select PROFESSION.FACULTY from PROFESSION
									where PROFESSION.PROFESSION_NAME like '%технологии%' or
									      PROFESSION.PROFESSION_NAME like '%технология%')

-----------------------------------

use Lab2

select SUPPLIERS.TITLE, DETAILS.TITLE, INVENTORIES.COUNT_DETAILS from SUPPLIERS join INVENTORIES on SUPPLIERS.IDSUPPLIER = INVENTORIES.IDSUPPLIER and
														 SUPPLIERS.IDSUPPLIER in (select i.IDSUPPLIER from INVENTORIES i
																						where i.COUNT_DETAILS > 50) join DETAILS on INVENTORIES.IDDETAIL = DETAILS.IDDETAIL