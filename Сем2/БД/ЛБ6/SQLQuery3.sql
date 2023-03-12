
--3. ����������� ������ �� ������ ������� PROGRESS, ������� ����� ��������� �������� ��������������� ������ � �� ��-�������� � �������� ���������. 
--���������� ����� ������ ������������-�� � �������, �������� �������� ������.
--������������ ��������� � ������ FROM, � ���������� ��������� GROUP BY � CASE. 


use UNIVER

select *
from (select case
                 when (PROGRESS.NOTE in (6, 7)) then '6-7'
                 when (PROGRESS.NOTE in (8, 9)) then '8-9'
                 when (PROGRESS.NOTE in (4, 5)) then '4-5'
                 when (PROGRESS.NOTE = 10) then '10'
                 end  [������],
             count(*) [����������]
      from PROGRESS
      group by case
                   when (PROGRESS.NOTE in (6, 7)) then '6-7'
                   when (PROGRESS.NOTE in (8, 9)) then '8-9'
                   when (PROGRESS.NOTE in (4, 5)) then '4-5'
                   when (PROGRESS.NOTE = 10) then '10'
                   end
     ) as a
order by case a.������
               when '6-7' then 3
               when '8-9' then 2
               when '4-5' then 4
               when '10' then 1
               end


use Lab2

select * 
from (select case
				when(INVENTORIES.COUNT_DETAILS between 0 and 100) then '0-100'
				when(INVENTORIES.COUNT_DETAILS between 101 and 200) then '101-200'
				when(INVENTORIES.COUNT_DETAILS between 201 and 500) then '201-500'
				when(INVENTORIES.COUNT_DETAILS > 500) then '501 and more'
			 end [���������� �������],
			 count(*) as [���������� �����������]
			 from INVENTORIES
			 group by case 
				when(INVENTORIES.COUNT_DETAILS between 0 and 100) then '0-100'
				when(INVENTORIES.COUNT_DETAILS between 101 and 200) then '101-200'
				when(INVENTORIES.COUNT_DETAILS between 201 and 500) then '201-500'
				when(INVENTORIES.COUNT_DETAILS > 500) then '501 and more'
			 end) as i

order by case i.[���������� �������]
	when '0-100' then 4
	when '101-200' then 3
	when '201-500' then 2
	when '501 and more' then 1
end;

