--4. Разработать SELECT-запроса на осно-ве таблиц FACULTY, GROUPS, STU-DENT и PROGRESS,
--который содержит среднюю экзаменационную оценку для каждого курса каждой специальности и фа-культета. 
--Строки отсортировать в порядке убыва-ния средней оценки.
--Средняя оценка должна рассчитываться с точностью до двух знаков после запятой.
--Использовать внутреннее соединение таблиц, агрегатную функцию AVG и встро-енные функции CAST и ROUND.

use UNIVER

select a.FACULTY,
       G.PROFESSION,
       (2014 - G.YEAR_FIRST ) [курс],
       round(avg(cast(NOTE as float(4))), 2) as [средняя оценка]
from FACULTY a
         join GROUPS G on a.FACULTY = G.FACULTY
         join STUDENT S on G.IDGROUP = S.IDGROUP
         join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT
group by a.FACULTY, G.PROFESSION, G.YEAR_FIRST


--5. Переписать SELECT-запрос, разрабо-танный в задании 4, так чтобы в расчете 
--среднего значения оценок использовались оценки только по дисциплинам с кодами 
--БД и ОАиП. Использовать WHERE.

select a.FACULTY,
       G.PROFESSION,
       (2014 - G.YEAR_FIRST ) [курс],
       round(avg(cast(NOTE as float(4))), 2) as [средняя оценка]
from FACULTY a
         join GROUPS G on a.FACULTY = G.FACULTY
         join STUDENT S on G.IDGROUP = S.IDGROUP
         join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT and P.SUBJECT in ('СУБД', 'ОАиП')
group by a.FACULTY, G.PROFESSION, G.YEAR_FIRST

-------------------------------------------------------------
use Lab2

select 
SUPPLIERS.TITLE, 
ORDERS.IDDETAIL, 
round(avg(cast(ORDERS.COUNT_ORDERED_DETAILS as float(4))), 2) as [Среднее количество поставленных деталей]

from SUPPLIERS join ORDERS on SUPPLIERS.IDSUPPLIER = ORDERS.IDSUPPLIER
group by SUPPLIERS.TITLE, ORDERS.IDDETAIL 
order by len(TITLE), IDDETAIL

use Lab2

select 
SUPPLIERS.TITLE, 
ORDERS.IDDETAIL, 
round(avg(cast(ORDERS.COUNT_ORDERED_DETAILS as float(4))), 2) as [Среднее количество поставленных деталей]

from SUPPLIERS join ORDERS on SUPPLIERS.IDSUPPLIER = ORDERS.IDSUPPLIER and SUPPLIERS.IDSUPPLIER = 1
group by SUPPLIERS.TITLE, ORDERS.IDDETAIL 
order by len(TITLE), IDDETAIL