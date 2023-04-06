--3. Разработать и создать представление с именем Аудитории. 
--Представление должно быть построено на основе таблицы AUDITORIUM
--и содержать столбцы: код, наименование аудитории. 
--Представление должно отображать только лекционные аудитории 
--(в столбце AUDITORIUM_ TYPE строка, начинающаяся с символа ЛК) 
--и допускать выполнение оператора INSERT, UPDATE и DELETE.

CREATE VIEW Аудитории  (AUDITORIUM_TYPE,AUDITORIUM)
AS SELECT
	A.AUDITORIUM [Код],
	A.AUDITORIUM_TYPE [Тип]
FROM AUDITORIUM A
WHERE A.AUDITORIUM_TYPE LIKE 'ЛК%'

INSERT  [Аудитории] VALUES ('ЛК','ЛК')
DELETE FROM Аудитории where AUDITORIUM='ЛК'
UPDATE Аудитории SET  AUDITORIUM = 'TEST' 
WHERE AUDITORIUM = 'ЛК'


SELECT * FROM Аудитории

DROP VIEW Аудитории

--4. Разработать и создать представление с именем Лекционные_аудитории. 
--Представление должно быть построено на основе SELECT-запроса к 
--таблице AUDITORIUM и содержать следующие столбцы: код, наименование аудитории. 
--Представление должно отображать только лекционные аудитории 
--(в столбце AUDITORIUM_TYPE строка, начинающаяся с символов ЛК). 

USE UNIVER;
GO 
CREATE VIEW  [Лекционные аудитории] (AUDITORIUM_TYPE,AUDITORIUM)
as select 
	AUDITORIUM.AUDITORIUM_TYPE as [наименование аудитории],
	AUDITORIUM.AUDITORIUM as [код]
FROM AUDITORIUM
WHERE AUDITORIUM.AUDITORIUM_TYPE LIKE 'ЛК%' WITH CHECK OPTION

SELECT * FROM [Лекционные аудитории]