use Northwind
--simple select
select * from Customers

--where condition
select CompanyName,ContactName,City
from Customers where
City='London'

--Like Operator
select CompanyName,ContactName
from Customers 
where City Like ('L%')--group of characters

select CompanyName,ContactName
from Customers 
where City Like ('L_____')--single character

use AdventureWorks
select * from Production.Product

--Not Like
select ProductNumber,Name,ListPrice 
from Production.Product
where Color Not Like ('B%')

--between operator
select ProductID,Name,StandardCost ,safetyStockLevel 
from Production.Product
where SafetyStockLevel  Not Between 500 and 800

--Logical Operators AND OR NOt
select * from Production.Product

select safetyStockLevel from Production.Product
 where ProductID =1 OR SafetyStockLevel =1000

--order by
select * 
from Production.Product 
order by ProductID desc