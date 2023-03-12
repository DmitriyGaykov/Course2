--6. На основе таблиц FACULTY, GROUPS, STUDENT и PROGRESS разра-ботать запрос,
--в котором выводятся специ-альность, дисциплины и средние оценки при сдаче 
--экзаменов на факультете ТОВ. 

use UNIVER

select GROUPS.PROFESSION,
	   PROGRESS.[SUBJECT], 
	   avg(PROGRESS.NOTE) as [Средняя оценка]
from STUDENT join PROGRESS on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
		     join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP
			 join FACULTY on GROUPS.FACULTY = FACULTY.FACULTY and FACULTY.FACULTY = 'ИДИП'

			 group by PROGRESS.[SUBJECT], GROUPS.PROFESSION


---------------------------------------------------------------------------------

use Lab2

select 
s.TITLE, 
d.TITLE,
avg(i.COUNT_DETAILS) as [Среднее]

from INVENTORIES i join SUPPLIERS s on
									i.IDSUPPLIER = s.IDSUPPLIER
				   join DETAILS d on
									d.IDDETAIL = i.IDDETAIL and i.IDDETAIL = 3
group by s.TITLE, d.TITLE