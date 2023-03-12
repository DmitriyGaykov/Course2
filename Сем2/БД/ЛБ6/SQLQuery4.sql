--4. ����������� SELECT-������� �� ����-�� ������ FACULTY, GROUPS, STU-DENT � PROGRESS,
--������� �������� ������� ��������������� ������ ��� ������� ����� ������ ������������� � ��-��������. 
--������ ������������� � ������� �����-��� ������� ������.
--������� ������ ������ �������������� � ��������� �� ���� ������ ����� �������.
--������������ ���������� ���������� ������, ���������� ������� AVG � �����-����� ������� CAST � ROUND.

use UNIVER

select a.FACULTY,
       G.PROFESSION,
       (2014 - G.YEAR_FIRST ) [����],
       round(avg(cast(NOTE as float(4))), 2) as [������� ������]
from FACULTY a
         join GROUPS G on a.FACULTY = G.FACULTY
         join STUDENT S on G.IDGROUP = S.IDGROUP
         join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT
group by a.FACULTY, G.PROFESSION, G.YEAR_FIRST


--5. ���������� SELECT-������, �������-������ � ������� 4, ��� ����� � ������� 
--�������� �������� ������ �������������� ������ ������ �� ����������� � ������ 
--�� � ����. ������������ WHERE.

select a.FACULTY,
       G.PROFESSION,
       (2014 - G.YEAR_FIRST ) [����],
       round(avg(cast(NOTE as float(4))), 2) as [������� ������]
from FACULTY a
         join GROUPS G on a.FACULTY = G.FACULTY
         join STUDENT S on G.IDGROUP = S.IDGROUP
         join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT and P.SUBJECT in ('����', '����')
group by a.FACULTY, G.PROFESSION, G.YEAR_FIRST

-------------------------------------------------------------
use Lab2

select 
SUPPLIERS.TITLE, 
ORDERS.IDDETAIL, 
round(avg(cast(ORDERS.COUNT_ORDERED_DETAILS as float(4))), 2) as [������� ���������� ������������ �������]

from SUPPLIERS join ORDERS on SUPPLIERS.IDSUPPLIER = ORDERS.IDSUPPLIER
group by SUPPLIERS.TITLE, ORDERS.IDDETAIL 
order by len(TITLE), IDDETAIL

use Lab2

select 
SUPPLIERS.TITLE, 
ORDERS.IDDETAIL, 
round(avg(cast(ORDERS.COUNT_ORDERED_DETAILS as float(4))), 2) as [������� ���������� ������������ �������]

from SUPPLIERS join ORDERS on SUPPLIERS.IDSUPPLIER = ORDERS.IDSUPPLIER and SUPPLIERS.IDSUPPLIER = 1
group by SUPPLIERS.TITLE, ORDERS.IDDETAIL 
order by len(TITLE), IDDETAIL