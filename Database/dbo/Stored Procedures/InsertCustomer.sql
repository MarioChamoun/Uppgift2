﻿CREATE PROCEDURE [dbo].[InsertCustomer]
	(@CompanyName nvarchar(40),
     @ContactName nvarchar(30),
     @ContactTitle nvarchar(30),
     @Address nvarchar(60),
     @City nvarchar(15),
     @Region nvarchar(15),
     @PostalCode nvarchar(10),
     @Country nvarchar(15),
     @Phone nvarchar(24),
     @Fax nvarchar(24))
AS
	INSERT INTO [dbo].[Customers]
	([CompanyName]
      ,[ContactName]
      ,[ContactTitle]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostalCode]
      ,[Country]
      ,[Phone]
      ,[Fax])
VALUES
(@CompanyName,
@ContactName,
@ContactTitle,
@Address,
@City,
@Region,
@PostalCode,
@Country,
@Phone,
@Fax)

GO