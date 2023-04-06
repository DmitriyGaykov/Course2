--2. ������� ��������� ��������� �������. ��������� �� ������� (10000 ����� ��� ������). 
--����������� SELECT-������. ��-������ ���� ������� � ���������� ��� ���������. 
--������� ������������������ ��-���������� ��������� ������. 
--������� ��������� ������ ��-��������.
USE tempdb; -- ����� ������������ ��� 5 � 6 �������

CREATE table #EX
(    TKEY int, 
      CC int identity(1, 1),
      TF varchar(100)
);



set nocount on;           
declare @i int = 0;
while   @i < 10000       -- ���������� � ������� 20000 �����
begin
     INSERT #EX(TKEY, TF) values(floor(30000*RAND()), replicate('������ ', 10));
      set @i = @i + 1; 
end;

SELECT count(*)[���������� �����] from #EX;
SELECT * from #EX

CREATE index #EX_NONCLU on #EX(TKEY, CC)

SELECT * from  #EX where  TKEY > 1500 and  CC < 4500;  
SELECT * from  #EX order by  TKEY, CC

SELECT * from  #EX where  TKEY = 1055 and  CC > 3

DROP INDEX #EX_NONCLU ON #EX;

--3. ������� ��������� ��������� �������. ��������� �� ������� (�� ����� 10000 �����). 
--����������� SELECT-������. ��-������ ���� ������� � ���������� ��� ���������. 
--������� ������������������ ��-���� ��������, ����������� ���-������ SELECT-�������. 

CREATE  index #EX_TKEY_X on #EX(TKEY) INCLUDE (CC);
SELECT CC from #EX where TKEY>15000;
DROP index #EX_TKEY_X on #EX;

--4. ������� � ��������� ��������� ��������� �������. 
--����������� SELECT-������, �������� ���� ������� � ���������� ��� ���������. 
--������� ������������������ ����������� ������, ����������� ��������� SELECT-�������.

CREATE  index #EX_WHERE on #EX(TKEY) where (TKEY>=15000 and 
 TKEY < 20000);  

 SELECT TKEY from  #EX where TKEY>15000 and  TKEY < 20000

 DROP INDEX #EX_WHERE ON #EX;


-- 5. ��������� ��������� ��������� �������. 
--������� ������������������ ������. ������� ������� ������������ �������. 
--����������� �������� �� T-SQL, ���������� �������� �������� � ������ ������������ ������� ���� 90%. 
--������� ������� ������������ �������. 
--��������� ��������� ������������� �������, ������� ������� ������������. 
--��������� ��������� ����������� ������� � ������� ������� ������������ �������.

--�������� ���������� � ��������� ����� ���� ������ ����� �������
--����������� ��-������������ ���������� � ������� ������ �������. 
--������� ����������� ����������-���� ���������� ������ ���������� �������������.
--������������ �������� ������� ������ �� �� ����������. ����� ������ ������:

CHECKPOINT;
DBCC DROPCLEANBUFFERS

CREATE   index #EX_TKEY ON #EX(TKEY); 

--�������� ���������� � ������� ������������ ������� ����� � ������� ����������: 

SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
FROM SYS.DM_DB_INDEX_PHYSICAL_STATS(DB_ID(N'TEMPDB'),
OBJECT_ID(N'#EX'), NULL, NULL, NULL) SS
JOIN SYS.INDEXES II ON SS.OBJECT_ID = II.OBJECT_ID
AND SS.INDEX_ID = II.INDEX_ID WHERE NAME IS NOT NULL; 

--���� �������� 10000 ����� � �������

INSERT top(10000) #EX(TKEY, TF) select TKEY, TF from #EX;
SELECT * FROM #EX

--� �������� ������ � ������������ � ������� ����������, ����������� ����, �� ����� �������, ��� ������� ������������ �������� 99%. 
--��� ���������� �� ������������ ������� ������������� ��� ����������� ��������: ������������� � ����������� �������.

--������������� (REORGANIZE) ����������� ������, �� ����� ��� ������������ ��-��� ������ ������ �� ����� ������ ������.
--����� ��������� ������������� � ������� ��������� ALTER ��� ������� #EX_TKEY.

ALTER index #EX_TKEY on #EX reorganize;

--����� ���������� ���������������� ������� �������, ��� ������� ������������ ����������� ��������, �� �� �� �����.
--�������� ����������� (REBUILD) ����������� ��� ���� ������, ������� ����� �� ���������� ������� ������������ ����� ����.
--����� ��������� ����������� � ������� ��������� ALTER ��� ������� #EX_TKEY � ������ OFFLINE.

ALTER index #EX_TKEY on #EX rebuild with (online = off);

--����������� ������� � ������������ ����� ������� �� �������.

DROP INDEX #EX_TKEY ON #EX

--6. ����������� ������, �����-���������� ���������� ��������� FILLFACTOR ��� �������� �����-�������������� �������.

--������� ������������ ����� � ��������� ������� ���������, ���� ��� 
--�������� ��� ��������� ������� ������������ ��������� FILLFACTOR � PAD_INDEX. 
--�������� FILLFACTOR ��������� ������� ���������� ��������� ������� ������� ������.
--����� ������ ���������� �� ��������� ��������� FILLFACTOR ������ 65: 


CREATE index #EX_TKEY1 on #EX(TKEY) with (fillfactor = 65);

--����� ���������� ����� � ������� #EX ����� ������� ������� ������������:

INSERT top(50) percent INTO #EX(TKEY, TF) select TKEY, TF from #EX

SELECT TKEY, TF  FROM #EX;

SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'),    
OBJECT_ID(N'#EX'), NULL, NULL, NULL) ss  JOIN sys.indexes ii 
ON ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;

DROP index #EX_TKEY1 on #EX
