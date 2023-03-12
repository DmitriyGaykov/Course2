use UNIVER;

--На основе таблиц AUDITORIUM_ TYPE и AUDITORIUM сформировать перечень кодов аудиторий и соответствующих им наименований типов аудиторий. 
--Использовать соединение таблиц INNER JOIN. 

select AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
from AUDITORIUM inner join AUDITORIUM_TYPE
on AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE


--2. На основе таблиц AUDITORI-UM_TYPE и AUDITORIUM сформировать перечень кодов аудиторий и 
--соответствую-щих им наименований типов аудиторий, вы-брав только те аудитории, в наименовании 
--которых присутствует подстрока компьютер. Использовать соединение таблиц INNER JOIN и предикат LIKE

select AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
from AUDITORIUM inner join AUDITORIUM_TYPE
on AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE 
and AUDITORIUM_TYPE.AUDITORIUM_TYPENAME like '%компьютер%'


--3. На основе таблиц PRORGESS, STUDENT, GROUPS, SUBJECT, PULPIT и FACULTY 
--сформировать перечень студентов, получивших экзаменационные оценки от 6 до 8.

--Результирующий набор должен содержать столбцы: Факультет, Кафедра, Специальность,
--Дисциплина, Имя Студента, Оценка. В столбце Оценка должны быть записаны экзаменационные оценки прописью: шесть, семь, восемь.

--Результат отсортировать в порядке убывания по столбцу PROGRESS.NOTE.
--Использовать соединение INNER JOIN, предикат BETWEEN и выражение CASE.

select FACULTY.FACULTY_NAME, PULPIT.PULPIT_NAME, PROFESSION.PROFESSION_NAME, SUBJECT.SUBJECT_NAME, STUDENT.NAME, 
case
	when(PROGRESS.NOTE = 6) then 'шесть'
	when(PROGRESS.NOTE = 7) then 'семь'
	when(PROGRESS.NOTE = 8) then 'восемь'
end[Оценка]

from 
STUDENT join PROGRESS on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
		join SUBJECT on PROGRESS.SUBJECT = SUBJECT.SUBJECT
		join GROUPS on GROUPS.IDGROUP = STUDENT.IDGROUP
		join FACULTY on FACULTY.FACULTY = GROUPS.FACULTY
		join PROFESSION on PROFESSION.FACULTY = FACULTY.FACULTY
		join PULPIT on PULPIT.FACULTY = FACULTY.FACULTY
		where NOTE between 6 and 8
		order by NOTE
-----------------------------------------------------------------------------------------------------
select STUDENT.[NAME], FACULTY.FACULTY,PULPIT.PULPIT, PROFESSION.PROFESSION_NAME, SUBJECT.SUBJECT_NAME,
       case
           when (PROGRESS.NOTE = 6) then 'шесть'
           when (PROGRESS.NOTE = 7) then 'семь'
           when (PROGRESS.NOTE = 8) then 'восемь'
           end [Oценка]
from PROGRESS
          join STUDENT on PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
          join [SUBJECT] on [SUBJECT].[SUBJECT] = PROGRESS.[SUBJECT]
          join GROUPS on GROUPS.IDGROUP = STUDENT.IDGROUP
          join PROFESSION on PROFESSION.PROFESSION = GROUPS.PROFESSION
          join PULPIT on PULPIT.PULPIT = [SUBJECT].PULPIT
          join FACULTY on FACULTY.FACULTY = PULPIT.FACULTY
where PROGRESS.NOTE between 6 and 8
order by NOTE
--4. На основе таблиц PULPIT и TEACHER получить полный перечень кафедр и преподавателей на этих кафедрах. 
--Результирующий набор должен содержать два столбца: Кафедра и Преподаватель. Если на кафедре нет преподавателей,
--то в столбце Преподаватель должна быть выведена строка ***. 
--Примечание: использовать соединение таблиц LEFT OUTER JOIN и функцию isnull.

select PULPIT.PULPIT_NAME, isnull(TEACHER.TEACHER_NAME, '***')
from PULPIT left outer join TEACHER
on PULPIT.PULPIT = TEACHER.PULPIT

--5. Создав две таблицы показать на примере, что соединение FULL OUTER JOIN двух таблиц является коммутативной операцией.
--Создать три новых запроса:
--− запрос, результат которого содержит данные левой (в операции FULL OUTER JOIN) таблицы и не содержит данные правой; 
--− запрос, результат которого содержит данные правой таблицы и не содержащие данные левой; 
--− запрос, результат которого содержит данные правой таблицы и левой таблиц;
--Использовать в запросах выражение IS NULL и IS NOT NULL.

--create table table1 (
--  id int primary key,
--  [name] varchar(50)
--);

--create table table2 (
--  id int primary key,
--  age int
--);

--insert into table1 values (1, 'Alice'), (2, 'Bob'), (3, 'Charlie');
--insert into table2 values (1, 25), (3, 30), (4, 35);

-- Данные только из левой таблицы
select * from table1
LEFT OUTER JOIN table2 on table1.id = table2.id
WHERE table2.id IS NULL;

-- Данные только из правой таблицы
select * from table1
RIGHT OUTER JOIN table2 on table1.id = table2.id
WHERE table1.id IS NULL;

-- Данные из обеих таблиц
select * from table1
FULL OUTER JOIN table2 on table1.id = table2.id
WHERE table1.id IS NOT NULL OR table2.id IS NOT NULL;

--6. Разработать SELECT-запрос на основе CROSS JOIN-соединения 
--таблиц AUDITORIUM_TYPE и AUDITORIUM, формирующего результат, 
--аналогичный результату запроса в задании 1.

select AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
from AUDITORIUM cross join AUDITORIUM_TYPE 
where AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE