use Lab2;

--create table DETAILS
--(
--	IDDETAIL int primary key,
--	TITLE nvarchar(50),
--	PRICE int,
--	[DESCRIPTION] nvarchar(300)
--)

--create table SUPPLIERS
--(
--	IDSUPPLIER int primary key,
--	TITLE nvarchar(50),
--	[ADDRESS] nvarchar(150),
--	NUMBER nvarchar(15)
--)

--create table INVENTORIES
--(
--	IDSUPPLIER int foreign key references SUPPLIERS(IDSUPPLIER),
--	IDDETAIL int foreign key references DETAILS(IDDETAIL),
--	COUNT_DETAILS int
--)

--create table ORDERS
--(
--	IDORDER int primary key,
--	IDDETAIL int foreign key references DETAILS(IDDETAIL),
--	IDSUPPLIER int foreign key references SUPPLIERS(IDSUPPLIER),
--	COUNT_ORDERED_DETAILS int,
--	[DATE] date
--)

--insert into DETAILS values(1, '�1', 23, '�1'),
--						 (2, '�2', 53, '�2'),
--						 (3, '�3', 74, '�3'),
--						 (4, '�4', 30, '�4'),
--						 (5, '�5', 63, '�5')

--insert into SUPPLIERS values(1, '�1', 'A1', '543123'),
--							 (2, '�2', 'A2', '533123'),
--							 (3, '�3', 'A3', '443123'),
--							 (4, '�4', 'A4', '343123')

--insert into INVENTORIES values(1, 2, 23),
--							  (1, 3, 42),
--							  (1, 5, 23),
--							  (2, 2, 23),
--							  (3, 4, 13),
--							  (4, 2, 95)

--insert into ORDERS values(1, 1, 1, 10, '2022-12-12'),
--						 (2, 2, 4, 20, '2022-02-12'),
--						 (3, 4, 3, 4, '2023-01-02')
-- ex1
select SUPPLIERS.TITLE, DETAILS.TITLE, INVENTORIES.COUNT_DETAILS from
SUPPLIERS join INVENTORIES
	on SUPPLIERS.IDSUPPLIER = INVENTORIES.IDSUPPLIER
		join DETAILS 
			on DETAILS.IDDETAIL = INVENTORIES.IDDETAIL

--ex2

select SUPPLIERS.TITLE, DETAILS.TITLE, INVENTORIES.COUNT_DETAILS from
SUPPLIERS join INVENTORIES
	on SUPPLIERS.IDSUPPLIER = INVENTORIES.IDSUPPLIER
		join DETAILS 
			on DETAILS.IDDETAIL = INVENTORIES.IDDETAIL
			and DETAILS.TITLE like '%2%'

-- ex3

select DETAILS.TITLE, SUPPLIERS.TITLE, 
case
	when(ORDERS.COUNT_ORDERED_DETAILS <= INVENTORIES.COUNT_DETAILS) then '�������'
	else '�� �������'
end [LACK]
from
SUPPLIERS join INVENTORIES
	on SUPPLIERS.IDSUPPLIER = INVENTORIES.IDSUPPLIER
		join DETAILS 
			on DETAILS.IDDETAIL = INVENTORIES.IDDETAIL
				join ORDERS 
					on ORDERS.IDDETAIL = INVENTORIES.IDDETAIL and ORDERS.IDSUPPLIER = INVENTORIES.IDSUPPLIER

-- ex4

select SUPPLIERS.TITLE, DETAILS.TITLE, isnull(INVENTORIES.COUNT_DETAILS, 0) from
SUPPLIERS cross join DETAILS left join INVENTORIES on
	SUPPLIERS.IDSUPPLIER = INVENTORIES.IDSUPPLIER and DETAILS.IDDETAIL = INVENTORIES.IDDETAIL
