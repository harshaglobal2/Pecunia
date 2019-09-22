use Northwind

select * from Customers

select CustomerID, CompanyName from Customers where City in('London');

select CustomerID,CompanyName from Customers where City Not  in('London');

Select * from Products

select * from Products where ReorderLevel between 10 and 25;
select * from Products where ReorderLevel not between 10 and 25;


CREATE TABLE t (col1 char(30));

INSERT INTO t VALUES ('Robert King');

SELECT * 
FROM t 
WHERE col1 LIKE '% King';   -- returns 1 row

-- Unicode pattern matching with nchar column
CREATE TABLE t (col1 nchar(30));

INSERT INTO t VALUES ('Robert King');

SELECT * 
FROM t 
WHERE col1 LIKE '% King';   -- no rows returned

-- Unicode pattern matching with nchar column and RTRIM
CREATE TABLE t1 (col1 nchar (30));

INSERT INTO t VALUES ('Robert King');

SELECT * 
FROM t1 
WHERE RTRIM(col1) LIKE '% King';   -- returns 1 row

---

/*LIKE '5[%]'
 

5%
 



LIKE '[_]n'
 

_n
 



LIKE '[a-cdf]'
 

a, b, c, d, or f
 



LIKE '[-acdf]'
 

-, a, c, d, or f
 



LIKE '[ [ ]'
 

[
 



LIKE ']'
 

]
 



LIKE 'abc[_]d%'
 

abc_d and abc_de
 



--LIKE 'abc[def]'
 

--abcd, abce, and abcf
 
*/

use AdventureWorksDW2008
SELECT p.FirstName, p.LastName, ph.PhoneNumber
FROM Person.PersonPhone AS ph
INNER JOIN Person.Person AS p
ON ph.BusinessEntityID = p.BusinessEntityID
WHERE ph.PhoneNumber NOT LIKE '415%' AND p.FirstName = 'Gail'
ORDER BY p.LastName;
GO

--Escape
CREATE TABLE mytbl2
(
 c1 sysname
);
GO

INSERT mytbl2 VALUES ('iscount is 10-15% off'), 
('Discount is .10-.15 off');
GO

SELECT c1 FROM mytbl2 WHERE c1
 LIKE '%10-15!% off%' ESCAPE '!';
GO

---Any
/*Similarly, >ANY means that for a
 row to satisfy the condition specified 
 in the outer query, the value in the column that introduces the subquery must be greater than at least one of the values in the list of values returned by the subquery.

The following query provides an example of a subquery introduced with a comparison operator modified by ANY. It finds the products whose list prices are greater than or equal to the maximum list price of any product subcategory.

*/ 

USE AdventureWorks;
GO

SELECT Name
FROM Production.Product
WHERE ListPrice >= ANY
	(SELECT MAX (ListPrice)
     	FROM Production.Product
	GROUP BY ProductSubcategoryID)
 
--Distinct
USE AdventureWorks ;
GO
SELECT DISTINCT Title
FROM HumanResources.Employee
ORDER BY Title ;
GO

--corelated subquery example
USE AdventureWorks ;
GO
SELECT DISTINCT Name
FROM Production.Product p 
WHERE EXISTS
	(SELECT *
	FROM Production.ProductModel pm 
	WHERE p.ProductModelID = pm.ProductModelID
	AND pm.Name = 'Long-sleeve logo jersey') ;
GO

--Group By
USE AdventureWorks ;
GO

SELECT SalesOrderID, SUM(LineTotal) AS SubTotal
FROM Sales.SalesOrderDetail sod
GROUP BY SalesOrderID
ORDER BY SalesOrderID ;
GO

USE AdventureWorks;
GO

SELECT ProductModelID, AVG(ListPrice) AS 'Average List Price'
FROM Production.Product
WHERE ListPrice > $1000
GROUP BY ProductModelID
ORDER BY ProductModelID ;
GO

USE AdventureWorks;
GO

SELECT ProductModelID, AVG(ListPrice) AS 'Average List Price'
FROM Production.Product
WHERE ListPrice > $1000
GROUP BY ProductModelID
ORDER BY ProductModelID ;
GO



--A. Using SELECT to retrieve rows and columns
/*The following example shows three code examples. This first code example returns all rows (no WHERE clause is specified) and all columns (using the *) from the Product table in the AdventureWorks database.*/

USE AdventureWorks ;
GO
SELECT *
FROM Production.Product
ORDER BY Name ASC ;

-- Alternate way.
USE AdventureWorks ;
GO
SELECT p.*
FROM Production.Product p
ORDER BY Name ASC ;
GO

 

/*This example returns all rows (no WHERE clause is specified), and only a subset of the columns (Name, ProductNumber, ListPrice) from the Product table in the AdventureWorks database. Additionally, a column heading is added.*/

 
USE AdventureWorks ;
GO
SELECT Name, ProductNumber, ListPrice AS Price
FROM Production.Product 
ORDER BY Name ASC ;
GO

 

--This example returns only the rows for Product that have a product line of R and that have days to manufacture that is less than 4.

 
USE AdventureWorks ;
GO
SELECT Name, ProductNumber, ListPrice AS Price
FROM Production.Product 
WHERE ProductLine = 'R' 
AND DaysToManufacture < 4
ORDER BY Name ASC ;
GO

 

-- Using SELECT with column headings and calculations
/*The following examples return all rows from the Product table. The first example returns total sales and the discounts for each product. In the second example, the total revenue is calculated for each product.*/

 
USE AdventureWorks ;
GO
SELECT p.Name AS ProductName, 
NonDiscountSales = (OrderQty * UnitPrice),
Discounts = ((OrderQty * UnitPrice) * UnitPriceDiscount)
FROM Production.Product p 
INNER JOIN Sales.SalesOrderDetail sod
ON p.ProductID = sod.ProductID 
ORDER BY ProductName DESC ;
GO

 

--This is the query that calculates the revenue for each product in each sales order.

 
USE AdventureWorks ;
GO
SELECT 'Total income is', ((OrderQty * UnitPrice) * (1.0 - UnitPriceDiscount)), ' for ',
p.Name AS ProductName 
FROM Production.Product p 
INNER JOIN Sales.SalesOrderDetail sod
ON p.ProductID = sod.ProductID 
ORDER BY ProductName ASC ;
GO

 

-- Using DISTINCT with SELECT
--The following example uses DISTINCT to prevent the retrieval of duplicate titles.

 
USE AdventureWorks ;
GO
SELECT DISTINCT Title
FROM HumanResources.Employee
ORDER BY Title ;
GO

 

-- Creating tables with SELECT INTO
/*The following first example creates a temporary table named #Bicycles in tempdb. To use this table, always refer to it with the exact name that is shown. This includes the number sign (#).*/

 
USE tempdb ;
IF OBJECT_ID (N'#Bicycles',N'U') IS NOT NULL
DROP TABLE #Bicycles ;
GO
USE AdventureWorks;
GO
SET NOCOUNT ON

SELECT * 
INTO #Bicycles
FROM Production.Product
WHERE ProductNumber LIKE 'BK%'

SET NOCOUNT OFF

SELECT name 
FROM tempdb..sysobjects 
WHERE name LIKE '#Bicycles%' ;
GO

 


--This second example creates the permanent table NewProducts.

 
USE AdventureWorks ;
GO
IF OBJECT_ID ('dbo.NewProducts', 'U') IS NOT NULL
DROP TABLE dbo.NewProducts ;
GO
ALTER DATABASE AdventureWorks SET RECOVERY BULK_LOGGED ;
GO

SELECT * INTO dbo.NewProducts
FROM Production.Product
WHERE ListPrice > $25 
AND ListPrice < $100

SELECT name 
FROM sysobjects 
WHERE name LIKE 'New%'

-- Using correlated subqueries
/*The following example shows queries that are semantically equivalent and illustrates the difference between using the EXISTS keyword and the IN keyword. Both are examples of a valid subquery that retrieves one instance of each product name for which the product model is a long sleeve logo jersey, and the ProductModelID numbers match between the Product and ProductModel tables.*/

 
USE AdventureWorks ;
GO
SELECT DISTINCT Name
FROM Production.Product p 
WHERE EXISTS
	(SELECT *
	FROM Production.ProductModel pm 
	WHERE p.ProductModelID = pm.ProductModelID
	AND pm.Name = 'Long-sleeve logo jersey') ;
GO

-- OR

USE AdventureWorks ;
GO
SELECT DISTINCT Name
FROM Production.Product
WHERE ProductModelID IN
	(SELECT ProductModelID 
	FROM Production.ProductModel
	WHERE Name = 'Long-sleeve logo jersey') ;
GO

 

/*The following example uses IN in a correlated, or repeating, subquery. This is a query that depends on the outer query for its values. The query is executed repeatedly, one time for each row that may be selected by the outer query. This query retrieves one instance of the first and last name of each employee for which the bonus in the SalesPerson table is 5000.00 and for which the employee identification numbers match in the Employee and SalesPerson tables.*/

 
USE AdventureWorks ;
GO
SELECT DISTINCT c.LastName, c.FirstName 
FROM Person.Contact c JOIN HumanResources.Employee e
ON e.ContactID = c.ContactID WHERE 5000.00 IN
	(SELECT Bonus
	FROM Sales.SalesPerson sp
	WHERE e.EmployeeID = sp.SalesPersonID) ;
GO

 

/*The previous subquery in this statement cannot be evaluated independently of the outer query. It requires a value for Employee.EmployeeID, but this value changes as the SQL Server Database Engine examines different rows in Employee.

A correlated subquery can also be used in the HAVING clause of an outer query. This example finds the product models for which the maximum list price is more than twice the average for the model.*/

 
USE AdventureWorks
GO
SELECT p1.ProductModelID
FROM Production.Product p1
GROUP BY p1.ProductModelID
HAVING MAX(p1.ListPrice) >= ALL
	(SELECT 2 * AVG(p2.ListPrice)
	FROM Production.Product p2
	WHERE p1.ProductModelID = p2.ProductModelID) ;
GO

 

--This example uses two correlated subqueries to find the names of employees who have sold a particular product.

 
USE AdventureWorks ;
GO
SELECT DISTINCT c.LastName, c.FirstName 
FROM Person.Contact c JOIN HumanResources.Employee e
ON e.ContactID = c.ContactID WHERE EmployeeID IN 
	(SELECT SalesPersonID 
	FROM Sales.SalesOrderHeader
	WHERE SalesOrderID IN 
	(SELECT SalesOrderID 
	FROM Sales.SalesOrderDetail
	WHERE ProductID IN 
		(SELECT ProductID 
		FROM Production.Product p 
		WHERE ProductNumber = 'BK-M68B-42'))) ;
GO

 

--F. Using GROUP BY
--The following example finds the total of each sales order in the database.

 
USE AdventureWorks ;
GO
SELECT SalesOrderID, SUM(LineTotal) AS SubTotal
FROM Sales.SalesOrderDetail sod
GROUP BY SalesOrderID
ORDER BY SalesOrderID ;
GO

 

--Because of the GROUP BY clause, only one row containing the sum of all sales is returned for each sales order.

--G. Using GROUP BY with multiple groups
--The following example finds the average price and the sum of year-to-date sales, grouped by product ID and special offer ID.

 
Use AdventureWorks
SELECT ProductID, SpecialOfferID, AVG(UnitPrice) AS 'Average Price', 
    SUM(LineTotal) AS SubTotal
FROM Sales.SalesOrderDetail
GROUP BY ProductID, SpecialOfferID
ORDER BY ProductID
GO

 

--Using GROUP BY and WHERE
--The following example puts the results 
--into groups after retrieving only the rows 
--with list prices greater than $1000.

USE AdventureWorks;
GO
SELECT ProductModelID, AVG(ListPrice) AS 'Average List Price'
FROM Production.Product
WHERE ListPrice > $1000
GROUP BY ProductModelID
ORDER BY ProductModelID ;
GO

--The following example finds the average price of each type of product and orders the results by average price.

 
USE AdventureWorks ;
GO
SELECT ProductID, AVG(UnitPrice) AS 'Average Price'
FROM Sales.SalesOrderDetail
WHERE OrderQty > 10
GROUP BY ProductID
ORDER BY AVG(UnitPrice) ;
GO

--The following example finds the average price of each type of product and orders the results by average price.

 
USE AdventureWorks ;
GO
SELECT ProductID, AVG(UnitPrice) AS 'Average Price'
FROM Sales.SalesOrderDetail
WHERE OrderQty > 10
GROUP BY ProductID
ORDER BY AVG(UnitPrice) ;
GO

--The following example finds the average price of each type of product and orders the results by average price.

 
USE AdventureWorks ;
GO
SELECT ProductID, AVG(UnitPrice) AS 'Average Price'
FROM Sales.SalesOrderDetail
WHERE OrderQty > 10
GROUP BY ProductID
ORDER BY AVG(UnitPrice) ;
GO

--The following example finds the average price of each type of product and orders the results by average price.

 
USE AdventureWorks ;
GO
SELECT ProductID, AVG(UnitPrice) AS 'Average Price'
FROM Sales.SalesOrderDetail
WHERE OrderQty > 10
GROUP BY ProductID
ORDER BY AVG(UnitPrice) ;
GO


--This topic provides examples of using the SELECT statement.

--A. Using SELECT to retrieve rows and columns
/*The following example shows three code examples. This first code example returns all rows (no WHERE clause is specified) and all columns (using the *) from the Product table in the AdventureWorks database.*/

 
USE AdventureWorks ;
GO
SELECT *
FROM Production.Product
ORDER BY Name ASC ;

-- Alternate way.
USE AdventureWorks ;
GO
SELECT p.*
FROM Production.Product p
ORDER BY Name ASC ;
GO

/*This example returns all rows (no WHERE clause is specified), and only a subset of the columns (Name, ProductNumber, ListPrice) from the Product table in the AdventureWorks database. Additionally, a column heading is added.*/

 
USE AdventureWorks ;
GO
SELECT Name, ProductNumber, ListPrice AS Price
FROM Production.Product 
ORDER BY Name ASC ;
GO

 

--This example returns only the rows for Product that have a product line of R and that have days to manufacture that is less than 4.

 
USE AdventureWorks ;
GO
SELECT Name, ProductNumber, ListPrice AS Price
FROM Production.Product 
WHERE ProductLine = 'R' 
AND DaysToManufacture < 4
ORDER BY Name ASC ;
GO

 

--B. Using SELECT with column headings and calculations
/*The following examples return all rows from the Product table. The first example returns total sales and the discounts for each product. In the second example, the total revenue is calculated for each product.*/

 
USE AdventureWorks ;
GO
SELECT p.Name AS ProductName, 
NonDiscountSales = (OrderQty * UnitPrice),
Discounts = ((OrderQty * UnitPrice) * UnitPriceDiscount)
FROM Production.Product p 
INNER JOIN Sales.SalesOrderDetail sod
ON p.ProductID = sod.ProductID 
ORDER BY ProductName DESC ;
GO

 

--This is the query that calculates the revenue for each product in each sales order.

 
USE AdventureWorks ;
GO
SELECT 'Total income is', ((OrderQty * UnitPrice) * (1.0 - UnitPriceDiscount)), ' for ',
p.Name AS ProductName 
FROM Production.Product p 
INNER JOIN Sales.SalesOrderDetail sod
ON p.ProductID = sod.ProductID 
ORDER BY ProductName ASC ;
GO

 

--C. Using DISTINCT with SELECT
--The following example uses DISTINCT to prevent the retrieval of duplicate titles.

 
USE AdventureWorks ;
GO
SELECT DISTINCT Title
FROM HumanResources.Employee
ORDER BY Title ;
GO

 

--D. Creating tables with SELECT INTO
/*The following first example creates a temporary table named #Bicycles in tempdb. To use this table, always refer to it with the exact name that is shown. This includes the number sign (#).*/

 
USE tempdb ;
IF OBJECT_ID (N'#Bicycles',N'U') IS NOT NULL
DROP TABLE #Bicycles ;
GO
USE AdventureWorks;
GO
SET NOCOUNT ON

SELECT * 
INTO #Bicycles
FROM Production.Product
WHERE ProductNumber LIKE 'BK%'

SET NOCOUNT OFF

SELECT name 
FROM tempdb..sysobjects 
WHERE name LIKE '#Bicycles%' ;
GO

 
/*
--Here is the result set. 

 
name                          
------------------------------
#Bicycles_____________________
 
*/

--This second example creates the permanent table NewProducts.

 
USE AdventureWorks ;
GO
IF OBJECT_ID ('dbo.NewProducts', 'U') IS NOT NULL
DROP TABLE dbo.NewProducts ;
GO
ALTER DATABASE AdventureWorks SET RECOVERY BULK_LOGGED ;
GO

SELECT * INTO dbo.NewProducts
FROM Production.Product
WHERE ListPrice > $25 
AND ListPrice < $100

SELECT name 
FROM sysobjects 
WHERE name LIKE 'New%'

USE master ;
GO

ALTER DATABASE AdventureWorks SET RECOVERY FULL ;
GO

 

Here is the result set. 

 
name                          
------------------------------
NewProducts                   
(1 row(s) affected)
 

--E. Using correlated subqueries
/*The following example shows queries that are semantically equivalent and illustrates the difference between using the EXISTS keyword and the IN keyword. Both are examples of a valid subquery that retrieves one instance of each product name for which the product model is a long sleeve logo jersey, and the ProductModelID numbers match between the Product and ProductModel tables.*/

 
USE AdventureWorks ;
GO
SELECT DISTINCT Name
FROM Production.Product p 
WHERE EXISTS
	(SELECT *
	FROM Production.ProductModel pm 
	WHERE p.ProductModelID = pm.ProductModelID
	AND pm.Name = 'Long-sleeve logo jersey') ;
GO

-- OR

USE AdventureWorks ;
GO
SELECT DISTINCT Name
FROM Production.Product
WHERE ProductModelID IN
	(SELECT ProductModelID 
	FROM Production.ProductModel
	WHERE Name = 'Long-sleeve logo jersey') ;
GO

 

/*The following example uses IN in a correlated, or repeating, subquery. This is a query that depends on the outer query for its values. The query is executed repeatedly, one time for each row that may be selected by the outer query. This query retrieves one instance of the first and last name of each employee for which the bonus in the SalesPerson table is 5000.00 and for which the employee identification numbers match in the Employee and SalesPerson tables. */

 
USE AdventureWorks ;
GO
SELECT DISTINCT c.LastName, c.FirstName 
FROM Person.Contact c JOIN HumanResources.Employee e
ON e.ContactID = c.ContactID WHERE 5000.00 IN
	(SELECT Bonus
	FROM Sales.SalesPerson sp
	WHERE e.EmployeeID = sp.SalesPersonID) ;
GO

 

/*The previous subquery in this statement cannot be evaluated independently of the outer query. It requires a value for Employee.EmployeeID, but this value changes as the SQL Server Database Engine examines different rows in Employee.

A correlated subquery can also be used in the HAVING clause of an outer query. This example finds the product models for which the maximum list price is more than twice the average for the model.*/

 
USE AdventureWorks
GO
SELECT p1.ProductModelID
FROM Production.Product p1
GROUP BY p1.ProductModelID
HAVING MAX(p1.ListPrice) >= ALL
	(SELECT 2 * AVG(p2.ListPrice)
	FROM Production.Product p2
	WHERE p1.ProductModelID = p2.ProductModelID) ;
GO

 

--This example uses two correlated subqueries to find the names of employees who have sold a particular product.

 
USE AdventureWorks ;
GO
SELECT DISTINCT c.LastName, c.FirstName 
FROM Person.Contact c JOIN HumanResources.Employee e
ON e.ContactID = c.ContactID WHERE EmployeeID IN 
	(SELECT SalesPersonID 
	FROM Sales.SalesOrderHeader
	WHERE SalesOrderID IN 
		(SELECT SalesOrderID 
		FROM Sales.SalesOrderDetail
		WHERE ProductID IN 
			(SELECT ProductID 
			FROM Production.Product p 
			WHERE ProductNumber = 'BK-M68B-42'))) ;
GO

 

--F. Using GROUP BY
--The following example finds the total of each sales order in the database.

 
USE AdventureWorks ;
GO
SELECT SalesOrderID, SUM(LineTotal) AS SubTotal
FROM Sales.SalesOrderDetail sod
GROUP BY SalesOrderID
ORDER BY SalesOrderID ;
GO

 

--Because of the GROUP BY clause, only one row containing the sum of all sales is returned for each sales order.

--G. Using GROUP BY with multiple groups
--The following example finds the average price and the sum of year-to-date sales, grouped by product ID and special offer ID.

 
Use AdventureWorks
SELECT ProductID, SpecialOfferID, AVG(UnitPrice) AS 'Average Price', 
    SUM(LineTotal) AS SubTotal
FROM Sales.SalesOrderDetail
GROUP BY ProductID, SpecialOfferID
ORDER BY ProductID
GO

 

--H. Using GROUP BY and WHERE
--The following example puts the results into groups after retrieving only the rows with list prices greater than $1000.

 
USE AdventureWorks;
GO
SELECT ProductModelID, AVG(ListPrice) AS 'Average List Price'
FROM Production.Product
WHERE ListPrice > $1000
GROUP BY ProductModelID
ORDER BY ProductModelID ;
GO

 

--I. Using GROUP BY with an expression
--The following example groups by an expression. You can group by an expression if the expression does not include aggregate functions.

 
USE AdventureWorks ;
GO
SELECT AVG(OrderQty) AS 'Average Quantity', 
NonDiscountSales = (OrderQty * UnitPrice)
FROM Sales.SalesOrderDetail sod
GROUP BY (OrderQty * UnitPrice)
ORDER BY (OrderQty * UnitPrice) DESC ;
GO

 

--J. Using GROUP BY with ORDER BY
--The following example finds the average price of each type of product and orders the results by average price.

 
USE AdventureWorks ;
GO
SELECT ProductID, AVG(UnitPrice) AS 'Average Price'
FROM Sales.SalesOrderDetail
WHERE OrderQty > 10
GROUP BY ProductID
ORDER BY AVG(UnitPrice) ;
GO

 

--K. Using the HAVING clause
/*The first example that follows shows a HAVING clause with an aggregate function. It groups the rows in the SalesOrderDetail table by product ID and eliminates products whose average order quantities are five or less. */
USE AdventureWorks ;
GO
SELECT ProductID 
FROM Sales.SalesOrderDetail
GROUP BY ProductID
HAVING AVG(OrderQty) > 5
ORDER BY ProductID ;
GO

 
 USE AdventureWorks ;
GO
SELECT ProductID 
FROM Sales.SalesOrderDetail
WHERE UnitPrice < 25.00
GROUP BY ProductID
HAVING AVG(OrderQty) > 5
ORDER BY ProductID ;
GO

USE AdventureWorks ;
GO
SELECT ProductID, AVG(OrderQty) AS AverageQuantity, SUM(LineTotal) AS Total
FROM Sales.SalesOrderDetail
GROUP BY ProductID
HAVING SUM(LineTotal) > $1000000.00
AND AVG(OrderQty) < 3 ;
GO

USE AdventureWorks ;
GO
SELECT ProductID, Total = SUM(LineTotal)
FROM Sales.SalesOrderDetail
GROUP BY ProductID
HAVING SUM(LineTotal) > $2000000.00 ;
GO




 


