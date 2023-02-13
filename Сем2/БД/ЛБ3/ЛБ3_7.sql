use UNIVER

create table AUDITORIUM
(
	AUDITORIUM char(20) primary key,
	AUDITORIUM_TYPE char(10),
	AUDITORIUM_CAPACITY int default 1
		check (AUDITORIUM_CAPACITY between 1 and 300),
	AUDITORIUM_NAME varchar(50)
) on FG1;