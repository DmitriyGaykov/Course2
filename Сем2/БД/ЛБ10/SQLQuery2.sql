--2. Создать временную локальную таблицу. Заполнить ее данными (10000 строк или больше). 
--Разработать SELECT-запрос. По-лучить план запроса и определить его стоимость. 
--Создать некластеризованный не-уникальный составной индекс. 
--Оценить процедуры поиска ин-формации.
USE tempdb; -- САМОЕ ОБЯЗАТЕЛЬНОЕ ДЛЯ 5 и 6 ЗАДАНИЯ

CREATE table #EX
(    TKEY int, 
      CC int identity(1, 1),
      TF varchar(100)
);



set nocount on;           
declare @i int = 0;
while   @i < 10000       -- добавление в таблицу 20000 строк
begin
     INSERT #EX(TKEY, TF) values(floor(30000*RAND()), replicate('строка ', 10));
      set @i = @i + 1; 
end;

SELECT count(*)[количество строк] from #EX;
SELECT * from #EX

CREATE index #EX_NONCLU on #EX(TKEY, CC)

SELECT * from  #EX where  TKEY > 1500 and  CC < 4500;  
SELECT * from  #EX order by  TKEY, CC

SELECT * from  #EX where  TKEY = 1055 and  CC > 3

DROP INDEX #EX_NONCLU ON #EX;

--3. Создать временную локальную таблицу. Заполнить ее данными (не менее 10000 строк). 
--Разработать SELECT-запрос. По-лучить план запроса и определить его стоимость. 
--Создать некластеризованный ин-декс покрытия, уменьшающий сто-имость SELECT-запроса. 

CREATE  index #EX_TKEY_X on #EX(TKEY) INCLUDE (CC);
SELECT CC from #EX where TKEY>15000;
DROP index #EX_TKEY_X on #EX;

--4. Создать и заполнить временную локальную таблицу. 
--Разработать SELECT-запрос, получить план запроса и определить его стоимость. 
--Создать некластеризованный фильтруемый индекс, уменьшающий стоимость SELECT-запроса.

CREATE  index #EX_WHERE on #EX(TKEY) where (TKEY>=15000 and 
 TKEY < 20000);  

 SELECT TKEY from  #EX where TKEY>15000 and  TKEY < 20000

 DROP INDEX #EX_WHERE ON #EX;


-- 5. Заполнить временную локальную таблицу. 
--Создать некластеризованный индекс. Оценить уровень фрагментации индекса. 
--Разработать сценарий на T-SQL, выполнение которого приводит к уровню фрагментации индекса выше 90%. 
--Оценить уровень фрагментации индекса. 
--Выполнить процедуру реорганизации индекса, оценить уровень фрагментации. 
--Выполнить процедуру перестройки индекса и оценить уровень фрагментации индекса.

--Операции добавления и изменения строк базы данных могут повлечь
--образование не-используемых фрагментов в области памяти индекса. 
--Процесс образования неиспользу-емых фрагментов памяти называется фрагментацией.
--Фрагментация индексов снижает эффект от их применения. Пусть создан индекс:

CHECKPOINT;
DBCC DROPCLEANBUFFERS

CREATE   index #EX_TKEY ON #EX(TKEY); 

--Получить информацию о степени фрагментации индекса можно с помощью операторов: 

SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM SYS.DM_DB_INDEX_PHYSICAL_STATS(DB_ID(N'TEMPDB'),
OBJECT_ID(N'#EX'), NULL, NULL, NULL) SS
JOIN SYS.INDEXES II ON SS.OBJECT_ID = II.OBJECT_ID
AND SS.INDEX_ID = II.INDEX_ID WHERE NAME IS NOT NULL; 

--Если вставить 10000 строк с помощью

INSERT top(10000) #EX(TKEY, TF) select TKEY, TF from #EX;
SELECT * FROM #EX

--и получить данные о фрагментации с помощью операторов, приведенных выше, то можно увидеть, что уровень фрагментации превысит 99%. 
--Для избавления от фрагментации индекса предусмотрены две специальные операции: реорганизация и перестройка индекса.

--Реорганизация (REORGANIZE) выполняется быстро, но после нее фрагментация бу-дет убрана только на самом нижнем уровне.
--Пусть выполнена реорганизация с помощью оператора ALTER для индекса #EX_TKEY.

ALTER index #EX_TKEY on #EX reorganize;

--Тогда выполнение соответствующего запроса покажет, что уровень фрагментации значительно снизился, но не до конца.
--Операция перестройки (REBUILD) затрагивает все узлы дерева, поэтому после ее выполнения степень фрагментации равна нулю.
--Пусть выполнена перестройка с помощью оператора ALTER для индекса #EX_TKEY в режиме OFFLINE.

ALTER index #EX_TKEY on #EX rebuild with (online = off);

--Выполнением запроса о фрагментации можно оценить ее уровень.

DROP INDEX #EX_TKEY ON #EX

--6. Разработать пример, демон-стрирующий применение параметра FILLFACTOR при создании некла-стеризованного индекса.

--Уровнем фрагментации можно в некоторой степени управлять, если при 
--создании или изменении индекса использовать параметры FILLFACTOR и PAD_INDEX. 
--Параметр FILLFACTOR указывает процент заполнения индексных страниц нижнего уровня.
--Пусть индекс пересоздан со значением параметра FILLFACTOR равным 65: 


CREATE index #EX_TKEY1 on #EX(TKEY) with (fillfactor = 65);

--После добавления строк в таблицу #EX можно оценить уровень фрагментации:

INSERT top(50) percent INTO #EX(TKEY, TF) select TKEY, TF from #EX

SELECT TKEY, TF  FROM #EX;

SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'),    
OBJECT_ID(N'#EX'), NULL, NULL, NULL) ss  JOIN sys.indexes ii 
ON ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;

DROP index #EX_TKEY1 on #EX
