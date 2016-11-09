CREATE TRIGGER [ContactNameTrigger]
ON Customers
FOR UPDATE
AS
BEGIN
	declare @id int
	declare @oldname nvarchar(50)
	declare @name nvarchar(50)
	
	select top 1 @id = CustomerID, @name = ContactName from inserted

	select @oldname = ContactName from deleted where CustomerID = @id

	if(@oldname <> @name)
	insert into tblOldCustomer values (@name,@oldname)

END
