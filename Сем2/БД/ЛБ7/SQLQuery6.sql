--7*. Подсчитать количество студентов в каждой группе, 
--на каждом факультете и всего в университете одним запросом.
--Под-считать количество аудиторий по типам и суммарной вместимости в 
--корпусах и всего одним запросом.

SELECT
	F.FACULTY,
	G.IDGROUP,
	COUNT(*) AS [Count in group]
FROM 
	FACULTY F
	JOIN GROUPS G ON F.FACULTY = G.FACULTY
	JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
GROUP BY F.FACULTY, G.IDGROUP
