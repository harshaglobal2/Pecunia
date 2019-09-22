declare @myDoc xml
set @myDoc = 	'<Root>
			<ProductDescription ProductID="1" ProductName="Road Bike">
				<Features>
  					<Warranty>1 year parts and labor</Warranty>
	  				<Maintenance>3 year parts and labor extended maintenance is available</Maintenance>
				</Features>
			</ProductDescription>
		</Root>'
SELECT @myDoc.query('/Root/ProductDescription/Features')

--Use AdventureWorks
use AdventureWorks

SELECT CatalogDescription.query('
declare namespace PD = "http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription";
<Product ProductModelID="{ /PD:ProductDescription[1]/@ProductModelID }" />
') as Result
FROM Production.ProductModel
where CatalogDescription.exist('
declare namespace PD="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription";
declare namespace wm="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelWarrAndMain";
     /PD:ProductDescription/PD:Features/wm:Warranty ') = 1
     
 






DECLARE @myDoc xml
DECLARE @ProdID int
SET @myDoc = '<Root>
<ProductDescription ProductID="1" ProductName="Road Bike">
<Features>
  <Warranty>1 year parts and labor</Warranty>
  <Maintenance>3 year parts and labor extended maintenance is available</Maintenance>
</Features>
</ProductDescription>
</Root>'

SET @ProdID =  @myDoc.value('(/Root/ProductDescription/@ProductID)[1]', 'int' )
SELECT @ProdID
    
    
    SELECT CatalogDescription.value('           
    declare namespace PD="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription";           
       (/PD:ProductDescription/@ProductModelID)[1]', 'int') AS Result           
FROM Production.ProductModel           
WHERE CatalogDescription IS NOT NULL           
ORDER BY Result desc        


--In the following example, there is an XML document that
-- has a <Root> top-level element and three <row> child elements. 
--The query uses the nodes() method to set separate context nodes, one for each <row> element. The nodes() method returns a rowset with three rows. Each row has a logical copy of the original XML, with each context node identifying a different <row> element in the original document.

--The query then returns the context node from each row: 








