/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Gender]
      ,[Mobile]
      ,[Address]
      ,[AdharNumber]
  FROM [Companydb].[dbo].[Employee]