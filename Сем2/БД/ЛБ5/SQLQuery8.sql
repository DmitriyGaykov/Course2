--. –азработать SELECT-запрос, демонстри-рующий принцип применени€ ANY сов-местно с подзапросом.
use UNIVER

select s.[NAME],sub.SUBJECT_NAME, p.NOTE from
	(STUDENT s join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT) join [SUBJECT] sub on sub.SUBJECT = p.SUBJECT 
		where p.NOTE = any (select p2.NOTE from PROGRESS p2 where p2.NOTE >= 9)


use Lab2

select d1.TITLE, i1.COUNT_DETAILS from INVENTORIES i1 join DETAILS d1 on i1.IDDETAIL = d1.IDDETAIL
where d1.IDDETAIL = any(select i2.IDDETAIL from INVENTORIES i2 where i2.IDDETAIL = d1.IDDETAIL and i2.COUNT_DETAILS < 20)