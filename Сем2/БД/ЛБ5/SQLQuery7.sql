--7. Разработать SELECT-запрос, демон-стрирующий способ применения ALL совместно с подзапросом.

use UNIVER

select [SUBJECT], IDSTUDENT , NOTE from PROGRESS a
	where NOTE >= all (select NOTE from PROGRESS
					   where [SUBJECT] = a.[SUBJECT] )


use Lab2

select i.IDDETAIL, i.COUNT_DETAILS from
	INVENTORIES i where i.COUNT_DETAILS >= all (select COUNT_DETAILS from INVENTORIES where i.IDDETAIL = IDDETAIL)