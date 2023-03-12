--7. На основе таблицы PROGRESS опре-делить для каждой дисциплины количество студентов, получивших оценки 8 и 9. 
--Использовать группировку, секцию HAVING, сортировку. 

use UNIVER

select PROGRESS.[SUBJECT], 
	   count(PROGRESS.NOTE) as [Количество студентов с оценками 8, 9]
from
PROGRESS 

group by PROGRESS.[SUBJECT], PROGRESS.NOTE
having PROGRESS.NOTE in (8,9)


----------------------------------------

use Lab2

select d.TITLE, d.PRICE
from DETAILS d
group by d.TITLE, d.PRICE 
having d.PRICE between 200 and 500