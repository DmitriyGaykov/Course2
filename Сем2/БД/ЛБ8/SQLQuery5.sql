--6. Изменить представление Количе-ство_кафедр, 
--созданное в задании 2 так, чтобы оно было привязано к базовым таблицам.
--Продемонстрировать свойство привязанно-сти представления к базовым таблицам. 
--Использовать опцию SCHEMABINDING. 

USE UNIVER;
GO
ALTER VIEW [Количество кафедр] with schemabinding
AS SELECT 
	FACULTY.FACULTY_NAME [факультет],
	COUNT(PULPIT.FACULTY) [количество]
FROM 
	dbo.FACULTY 
	JOIN dbo.PULPIT ON FACULTY.FACULTY = PULPIT.FACULTY
GROUP BY FACULTY.FACULTY_NAME

SELECT * FROM [Количество кафедр]