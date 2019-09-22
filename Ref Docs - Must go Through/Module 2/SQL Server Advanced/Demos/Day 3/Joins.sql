--Joins
--Left outer join
--all records from left table and
-- corresponding matching records from right

SELECT  	categoryname, description, productname, productid
FROM 	CATEGORIES  
	LEFT OUTER JOIN 
	PRODUCTS  
	ON PRODUCTS.categoryid = CATEGORIES.categoryid
GO

/*change to right outer join reversed   Every row  from the right table is retrieved with corresponding match from the left table. */
--Full Outer Join
--FULL OUTER JOIN, which includes all rows
-- from both tables, regardless of whether 
--or not the other table has a matching value.

--Cross join
/*A cross join that does not have a WHERE clause produces the Cartesian product of the tables involved in the join. The size of a Cartesian product result set is the number of rows in the first table multiplied by the number of rows in the second table. */

SELECT  	categoryname, description, productname, productid
FROM 	CATEGORIES 
	CROSS JOIN 
	PRODUCTS  
ORDER BY CategoryName

USE AdventureWorks;
GO
SELECT DISTINCT 	pv1.ProductID, pv1.VendorID
FROM 	Purchasing.ProductVendor pv1
	INNER JOIN
	Purchasing.ProductVendor pv2
	ON pv1.ProductID = pv2.ProductID
    	AND pv1.VendorID <> pv2.VendorID
ORDER BY pv1.ProductID


/*USE AdventureWorks;
GO
SELECT 	p.SalesPersonID, t.Name AS Territory
FROM 	Sales.SalesPerson p
	CROSS JOIN 
	Sales.SalesTerritory t
ORDER BY p.SalesPersonID;
 

/*The result set contains 170 rows (SalesPerson has 17 rows and SalesTerritory has 10; 17 multiplied by 10 equals 170).
However, if a WHERE clause is added, the cross join behaves 
as an inner join. For example, the following 
Transact-SQL queries produce the same result set.

*/

USE AdventureWorks;
GO
SELECT 	p.SalesPersonID, t.Name AS Territory
FROM 	Sales.SalesPerson p
	INNER JOIN 
	Sales.SalesTerritory t
	ON p.TerritoryID = t.TerritoryID
ORDER BY p.SalesPersonID;