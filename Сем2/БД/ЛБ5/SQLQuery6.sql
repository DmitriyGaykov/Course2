--. На основе таблицы PROGRESS сформи-ровать строку, содержащую средние зна-чения 
--оценок (столбец NOTE) по дисци-плинам, имеющим следующие коды: ОАиП, БД и СУБД. 
--Примечание: исполь-зовать три некоррелированных подзапроса в списке SELECT;
--в подзапросах приме-нить агрегатные функции AVG. 
use UNIVER

SELECT 
top(1)
(SELECT  AVG(NOTE) FROM PROGRESS WHERE [SUBJECT] = 'ОАиП') AS 'ОАиП',
(SELECT AVG(NOTE) FROM PROGRESS WHERE [SUBJECT] = 'КГ') AS 'КГ',
(SELECT  AVG(NOTE) FROM PROGRESS WHERE [SUBJECT] = 'СУБД') AS 'СУБД'
FROM PROGRESS;

use Lab2

select top(1)
(select avg(INVENTORIES.COUNT_DETAILS) from INVENTORIES where INVENTORIES.IDSUPPLIER = 1) as 'П1',
(select avg(INVENTORIES.COUNT_DETAILS) from INVENTORIES where INVENTORIES.IDSUPPLIER = 2) as 'П2',
(select avg(INVENTORIES.COUNT_DETAILS) from INVENTORIES where INVENTORIES.IDSUPPLIER = 3) as 'П3',
(select avg(INVENTORIES.COUNT_DETAILS) from INVENTORIES where INVENTORIES.IDSUPPLIER = 4) as 'П4'
