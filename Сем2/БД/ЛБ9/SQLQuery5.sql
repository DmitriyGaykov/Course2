--6. Разработать сценарий, в котором с помощью CASE анализируются оценки,
--полученные студентами некоторого фа-культета при сдаче экзаменов.
use UNIVER

DECLARE @FACULTY NVARCHAR(4) = 'ИДИП' 

SELECT 
	S.[NAME],
	CASE 
		WHEN AVG(P.NOTE) BETWEEN 0 AND 3 THEN 'Плохо'
		WHEN AVG(P.NOTE) BETWEEN 4 AND 7 THEN 'Норма'
		WHEN AVG(P.NOTE) BETWEEN 7 AND 10 THEN 'Отлично'
	END [Успеваемость]
FROM STUDENT S
	 JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
	 JOIN GROUPS G ON S.IDGROUP = G.IDGROUP AND G.FACULTY = @FACULTY
GROUP BY S.[NAME]