--2. На основе таблиц AUDITORIUM и AUDITORIUM_TYPE разработать запрос, вычисляющий для каждого 
--типа аудиторий максимальную, минимальную, среднюю вместимость аудиторий, суммарную вме-стимость всех аудиторий
--и общее количе-ство аудиторий данного типа. 
--Результирующий набор должен содер-жать столбец с наименованием типа ауди-торий и столбцы с вычисленными величи-нами. 
--Использовать внутреннее соединение таблиц, секцию GROUP BY и агрегатные функции. 

use UNIVER

select 
AUDITORIUM_TYPE.AUDITORIUM_TYPENAME, 
max(AUDITORIUM.AUDITORIUM_CAPACITY) as 'MAX', 
min(AUDITORIUM.AUDITORIUM_CAPACITY) as 'MIN', 
avg(AUDITORIUM.AUDITORIUM_CAPACITY) as 'AVG',
sum(AUDITORIUM.AUDITORIUM_CAPACITY) as 'SUM', 
count(AUDITORIUM.AUDITORIUM_TYPE) as 'COUNT'

from AUDITORIUM_TYPE join AUDITORIUM  on 
	AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE group by AUDITORIUM_TYPE.AUDITORIUM_TYPENAME


use Lab2

select SUPPLIERS.TITLE,
	   max(ORDERS.COUNT_ORDERED_DETAILS) as [Максимальный заказ],
	   min(ORDERS.COUNT_ORDERED_DETAILS) as [Минимальный заказ],
	   avg(ORDERS.COUNT_ORDERED_DETAILS) as [Среднее количество заказанных деталей],
	   sum(ORDERS.COUNT_ORDERED_DETAILS) as [Сумма всех заказанных деталей],
	   count(*) as [Общее количество заказов]

from SUPPLIERS join ORDERS on SUPPLIERS.IDSUPPLIER = ORDERS.IDSUPPLIER
group by SUPPLIERS.TITLE, ORDERS.IDSUPPLIER