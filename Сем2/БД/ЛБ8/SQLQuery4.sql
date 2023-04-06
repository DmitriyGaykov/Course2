--5. Разработать представление с именем Дис-циплины. 
--Представление должно быть по-строено на основе SELECT-запроса 
--к таблице SUBJECT, отображать все дисциплины в ал-фавитном порядке 
--и содержать следующие столбцы: код, наименование дисциплины и код кафедры. 
--Использовать TOP и ORDER BY.

CREATE VIEW DISC
AS SELECT
	TOP(100)
	S.SUBJECT [CODE],
	S.SUBJECT_NAME [NAME],
	S.PULPIT [PULPIT CODE]
FROM [SUBJECT] S
ORDER BY S.SUBJECT_NAME


SELECT * FROM DISC

DROP VIEW DISC