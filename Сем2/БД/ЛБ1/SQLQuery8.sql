/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Заказчик]
      ,[Наименование_товара]
      ,[Цена_продажи]
      ,[Количество]
      ,[Дата_поставки]
  FROM [ПРОДАЖИ].[dbo].[View4]