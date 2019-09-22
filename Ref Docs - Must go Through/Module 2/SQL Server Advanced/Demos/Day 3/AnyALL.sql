/*Using the > comparison operator as an example, >ALL means greater than every value. In other words, it means greater than the maximum value.
For example, >ALL (1, 2, 3) means greater than 3.
	 >ANY means greater than at least one value, that is, greater than the minimum.
	   So >ANY (1, 2, 3) means greater than 1.
	   */
/*. It finds the products whose list prices are greater than or equal to the maximum list price of any product subcategory.*/

Use AdventureWorks

SELECT Name
FROM Production.Product
WHERE ListPrice >= ANY
    	(SELECT MAX (ListPrice)
     	FROM Production.Product
     	GROUP BY ProductSubcategoryID) ;
	 
/*For each Product subcategory, the inner query finds the maximum list price. The outer query looks at all of these values and determines which individual product's list prices are greater than or equal to any product subcategory's maximum list price. If ANY is changed to ALL, the query will return only those products whose list price is greater than or equal to all the list prices returned in the inner query.*/
 /*
 The =ANY operator is equivalent to IN. For example, to find the names of all the wheel products that Adventure Works Cycles makes, you can use either IN or =ANY.*/

SELECT Name
FROM Production.Product
WHERE ProductSubcategoryID =ANY
    	(SELECT ProductSubcategoryID
     	FROM Production.ProductSubcategory
     	WHERE Name = 'Wheels') ;

--Using IN
GO
SELECT Name
FROM Production.Product
WHERE ProductSubcategoryID IN
    	(SELECT ProductSubcategoryID
     	FROM Production.ProductSubcategory
     	WHERE Name = 'Wheels') ;
