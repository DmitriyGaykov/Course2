--3. На основе таблиц GROUPS, STU-DENT и PROGRESS разработать SELECT-запрос, в котором определяются результаты сдачи экзаменов.
--В запросе должны отражаться специаль-ности, дисциплины, средние оценки студен-тов на факультете ТОВ.
--Отдельно разработать запрос, в котором определяются результаты сдачи экзаменов на факультете ХТиТ.
--Объединить результаты двух запросов с использованием операторов UNION и UN-ION ALL. Объяснить результаты. 

use UNIVER

SELECT
	G.PROFESSION,
	P.SUBJECT,
	AVG(P.NOTE) as [Средняя оценка]
FROM
	GROUPS G
	JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
	JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
WHERE G.FACULTY = N'ИДИП'
GROUP BY G.PROFESSION, P.SUBJECT

UNION ALL


SELECT
	G.PROFESSION,
	P.SUBJECT,
	AVG(P.NOTE) as [Средняя оценка]
FROM
	GROUPS G
	JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
	JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
WHERE G.FACULTY = N'ИДИП'
GROUP BY G.PROFESSION, P.SUBJECT

------------------------------------------------------------------

use Lab2

SELECT
	*
FROM
	INVENTORIES I
	JOIN SUPPLIERS S ON I.IDSUPPLIER = S.IDSUPPLIER
WHERE S.IDSUPPLIER = 1

UNION

SELECT
	*
FROM
	INVENTORIES I
	JOIN SUPPLIERS S ON I.IDSUPPLIER = S.IDSUPPLIER
WHERE S.IDSUPPLIER = 2