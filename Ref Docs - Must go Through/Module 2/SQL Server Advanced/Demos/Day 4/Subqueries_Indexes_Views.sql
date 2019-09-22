use AdventureWorks
/* SELECT statement built using a subquery. */
SELECT Name
FROM AdventureWorks.Production.Product
WHERE ListPrice =
    (SELECT ListPrice
     FROM AdventureWorks.Production.Product
     WHERE Name = 'Chainring Bolts' )

/* SELECT statement built using a join that returns the same result set. */
SELECT Prd1. Name
FROM AdventureWorks.Production.Product AS Prd1
     JOIN AdventureWorks.Production.Product AS Prd2
       ON (Prd1.ListPrice = Prd2.ListPrice)
WHERE Prd2. Name = 'Chainring Bolts'

/*Comparison operators that introduce a subquery can be modified by the keywords ALL or ANY. SOME is an ISO standard equivalent for ANY.

Subqueries introduced with a modified comparison operator return a list of zero or more values and can include a GROUP BY or HAVING clause.
 These subqueries can be restated with EXISTS. 
Using the > comparison operator as an example, >ALL means greater than every value. In other words, it means greater than the maximum value.
  For example, >ALL (1, 2, 3) means greater than 3. 
  >ANY means greater than at least one value, that is, greater
    than the minimum. So >ANY (1, 2, 3) means greater than 1.
    
For a row in a subquery with >ALL to satisfy the condition specified in the 
outer query, the value in the column introducing the subquery must
 be greater than each value in the list of values returned by the subquery.

Similarly, >ANY means that for a row to satisfy the condition 
specified in the outer query, the value in the column that introduces
 the subquery must be greater than at least one of the values in the list
  of values returned by the subquery.

The following query provides an example of a subquery introduced 
with a comparison operator modified by ANY.
 It finds the products whose list prices are greater 
 than or equal to the maximum list price of any product subcategory.

*/
USE AdventureWorks;
GO
SELECT Name
FROM Production.Product
WHERE ListPrice >= ALL
    	(SELECT MAX (ListPrice)
     	FROM Production.Product
     	GROUP BY ProductSubcategoryID)
 

/*For each Product subcategory, the inner query finds the maximum list price. The outer query looks at all of these values and determines which  individual product's list prices are greater than or equal to any  product subcategory's maximum list price. If ANY is changed to ALL, the query will return only those products whose list price is greater than or equal to all the list prices returned in the inner query.

If the subquery does not return any values, the entire query fails to return any values.

The =ANY operator is equivalent to IN. For example, to find the names of all the wheel products that  Adventure Works Cycles makes, you can use either IN or =ANY.
*/
--Using =ANY

USE AdventureWorks;
GO
SELECT Name
FROM Production.Product
WHERE ProductSubcategoryID =ANY
    	(SELECT ProductSubcategoryID
     	FROM Production.ProductSubcategory
     	WHERE Name = 'Wheels')

--Using IN
USE AdventureWorks;
GO
SELECT Name
FROM Production.Product
WHERE ProductSubcategoryID IN
    	(SELECT ProductSubcategoryID
     	FROM Production.ProductSubcategory
     	WHERE Name = 'Wheels')
