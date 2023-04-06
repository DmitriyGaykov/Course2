--2. Разработать и создать представление с именем Количество кафедр. 
--Представление должно быть построено на основе SELECT-запроса к таблицам
--FACULTY и PULPIT.
--Представление должно содержать следую-щие столбцы:
--факультет, количество кафедр (вычисляется на основе строк таблицы PULPIT). 

use UNIVER;

GO
CREATE VIEW [Количество кафедр]
as SELECT
	F.FACULTY_NAME [Факультет],
	COUNT(*) AS [Количество кафедр]
FROM 
	FACULTY F
	JOIN PULPIT P ON F.FACULTY = P.FACULTY
GROUP BY F.FACULTY_NAME

SELECT * FROM [Количество кафедр]

DROP VIEW [Количество кафедр]