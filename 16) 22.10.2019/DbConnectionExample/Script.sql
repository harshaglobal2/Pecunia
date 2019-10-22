use company
go

create table Products
(ProductID uniqueidentifier primary key,
ProductName varchar(40),
UnitPrice decimal)
go

create procedure usp_CreateProduct
(@ProductID uniqueidentifier,
@ProductName varchar(40),
@UnitPrice decimal)
as begin
	insert into Products values(@ProductID, @ProductName, @UnitPrice)
end
go

create procedure usp_UpdateProduct
(@ProductID uniqueidentifier,
@ProductName varchar(40),
@UnitPrice decimal)
as begin
	update Products set ProductName=@ProductName, UnitPrice=@UnitPrice
	where ProductID=@ProductID
end
go

create procedure usp_DeleteProduct
(@ProductID uniqueidentifier)
as begin
	delete from Products
	where ProductID=@ProductID
end
go

create procedure usp_GetProducts
as begin
	select * from Products
end
go

create procedure usp_GetProductByProductID
(@ProductID uniqueidentifier)
as begin
	select * from Products
	where ProductID=@ProductID
end
go
