--10. ����� � ������� STUDENT ���������, � ������� ���� �������� � ���� � ��� �� ����. ��������� �������.

use UNIVER

select s.[NAME], s.BDAY from
	STUDENT as s where s.BDAY = any (select a.BDAY from STUDENT as a where a.IDSTUDENT != s.IDSTUDENT) order by s.BDAY
