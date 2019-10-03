create database Team_C_Inventory
go

use Team_C_Inventory
go

create table Team_C_Inventory.dbo.Admins(
AdminID uniqueidentifier CONSTRAINT PK_Admins_AdminID PRIMARY KEY,
AdminName varchar(40) NOT NULL,
Email varchar(100) NOT NULL CONSTRAINT UQ_Admins_Email UNIQUE,
Password varchar(15) NOT NULL,
CreationDateTime datetime NOT NULL,
LastModifiedDateTime datetime NOT NULL)
go

create table Team_C_Inventory.dbo.Suppliers(
SupplierID uniqueidentifier CONSTRAINT PK_Suppliers_SupplierID PRIMARY KEY,
SupplierName varchar(40) NOT NULL,
Mobile varchar(10) NOT NULL CONSTRAINT UQ_Suppliers_Mobile UNIQUE,
Email varchar(100) NOT NULL CONSTRAINT UQ_Suppliers_Email UNIQUE,
Password varchar(15) NOT NULL,
CreationDateTime datetime NOT NULL,
LastModifiedDateTime datetime NOT NULL)
go

create procedure dbo.AddSupplier
(@SupplierID uniqueidentifier,
@SupplierName varchar(40),
@Mobile varchar(10),
@Email varchar(100),
@Password varchar(15),
@CreationDateTime datetime,
@LastModifiedDateTime datetime)
as begin
	INSERT INTO Team_C_Inventory.dbo.Suppliers(SupplierID, SupplierName, Mobile, Email, Password, CreationDateTime, LastModifiedDateTime)
	VALUES (@SupplierID, @SupplierName, @Mobile, @Email, @Password, @CreationDateTime, @LastModifiedDateTime)
end
go


create procedure dbo.UpdateSupplier
(@SupplierID uniqueidentifier,
@SupplierName varchar(40),
@Mobile varchar(10),
@Email varchar(100))
as begin
	UPDATE Team_C_Inventory.dbo.Suppliers SET 
	SupplierName=@SupplierName, Mobile=@Mobile, Email=@Email
	WHERE SupplierID = @SupplierID
end
go


create procedure dbo.UpdateSupplierPassword
(@SupplierID uniqueidentifier,
@Password varchar(15))
as begin
	UPDATE Team_C_Inventory.dbo.Suppliers SET 
	Password=@Password
	WHERE SupplierID = @SupplierID
end
go


create procedure dbo.DeleteSupplier
(@SupplierID uniqueidentifier)
as begin
	DELETE FROM Team_C_Inventory.dbo.Suppliers
	WHERE SupplierID = @SupplierID
end
go


create procedure dbo.GetSuppliers
as begin
	SELECT * FROM Team_C_Inventory.dbo.Suppliers
	ORDER BY SupplierName
end
go


create procedure dbo.GetSupplierBySupplierID
(@SupplierID uniqueidentifier)
as begin
	SELECT * FROM Team_C_Inventory.dbo.Suppliers
	WHERE SupplierID = @SupplierID
end
go


create procedure dbo.GetSuppliersBySupplierName
(@SupplierName varchar(40))
as begin
	SELECT * FROM Team_C_Inventory.dbo.Suppliers
	WHERE SupplierName = @SupplierName
end
go


create procedure dbo.GetSuppliersByEmail
(@Email varchar(100))
as begin
	SELECT * FROM Team_C_Inventory.dbo.Suppliers
	WHERE Email = @Email
end
go


create procedure dbo.GetSuppliersByEmailAndPassword
(@Email varchar(100), @Password varchar(15))
as begin
	SELECT * FROM Team_C_Inventory.dbo.Suppliers
	WHERE Email = @Email AND Password = @Password
end
go
