CREATE NONCLUSTERED INDEX FIBillOfMaterialsWithEndDate
    ON Production.BillOfMaterials (ComponentID, StartDate)
    WHERE EndDate IS NOT NULL ;
GO

USE AdventureWorks;
GO

SELECT ProductAssemblyID, ComponentID, StartDate 
FROM Production.BillOfMaterials
WHERE EndDate IS NOT NULL 
    AND ComponentID = 5 
    AND StartDate > '01/01/2008' ;
GO

select * from Production.BillOfMaterials