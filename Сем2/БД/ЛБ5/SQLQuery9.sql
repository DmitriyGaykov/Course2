--10. Найти в таблице STUDENT студентов, у которых день рождения в один и тот же день. Объяснить решение.

use UNIVER

select s.[NAME], s.BDAY from
	STUDENT as s where s.BDAY = any (select a.BDAY from STUDENT as a where a.IDSTUDENT != s.IDSTUDENT) order by s.BDAY
