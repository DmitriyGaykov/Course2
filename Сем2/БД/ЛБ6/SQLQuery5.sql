--6. �� ������ ������ FACULTY, GROUPS, STUDENT � PROGRESS �����-������ ������,
--� ������� ��������� �����-��������, ���������� � ������� ������ ��� ����� 
--��������� �� ���������� ���. 

use UNIVER

select GROUPS.PROFESSION,
	   PROGRESS.[SUBJECT], 
	   avg(PROGRESS.NOTE) as [������� ������]
from STUDENT join PROGRESS on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
		     join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP
			 join FACULTY on GROUPS.FACULTY = FACULTY.FACULTY and FACULTY.FACULTY = '����'

			 group by PROGRESS.[SUBJECT], GROUPS.PROFESSION


---------------------------------------------------------------------------------

use Lab2

select 
s.TITLE, 
d.TITLE,
avg(i.COUNT_DETAILS) as [�������]

from INVENTORIES i join SUPPLIERS s on
									i.IDSUPPLIER = s.IDSUPPLIER
				   join DETAILS d on
									d.IDDETAIL = i.IDDETAIL and i.IDDETAIL = 3
group by s.TITLE, d.TITLE