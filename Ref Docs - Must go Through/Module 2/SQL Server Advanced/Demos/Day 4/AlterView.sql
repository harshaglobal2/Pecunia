USE AdventureWorks ;
GO

CREATE VIEW HumanResources.EmployeeHireDate
AS
SELECT c.FirstName, c.LastName, e.HireDate
FROM HumanResources.Employee AS e JOIN Person.Contact AS c
ON e.ContactID = c.ContactID ;
GO


/*The view must be changed to include only the employees that were hired before
 1997. If ALTER VIEW is not used, but instead the view is dropped
  and re-created, the previously used GRANT statement and 
  any other statements that deal with permissions pertaining
   to this view must be re-entered.
	 */

ALTER VIEW HumanResources.EmployeeHireDate
AS
SELECT c.FirstName, c.LastName, e.HireDate
FROM HumanResources.Employee AS e JOIN Person.Contact AS c
ON e.ContactID = c.ContactID
WHERE HireDate < CONVERT(DATETIME,'19980101',101) ;
GO

select * from HumanResources.EmployeeHireDate
