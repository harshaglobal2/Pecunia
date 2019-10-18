create database InventoryDatabase
go

use InventoryDatabase
go

create table InventoryDatabase.dbo.Suppliers
(
	SupplierID uniqueidentifier primary key,
	SupplierName varchar(40)
)
go
