declare @XmlTab table
(
  	XMLCol xml
)

insert into @XmlTab values('<EmpID>1</EmpID><EmpName>vaishali</EmpName>');
select * from @XmlTab
--second example

CREATE TABLE dbo.Invoices 
(
	InvoiceID 		int, 
 	SalesDate 		datetime, 
 	CustomerID 	int, 
	ItemList 		xml
) 

--- implicily cast string values---
DECLARE @itemString nvarchar(2000) 
SET @itemString = 	'<Items> 
 			<Item ProductID="2" Quantity="3"/> 
			<Item ProductID="4" Quantity="1"/> 
		</Items>' 
DECLARE @itemDoc xml 
SET @itemDoc = @itemString 
INSERT INTO dbo.Invoices 
VALUES 
(1, GetDate(), 2, @itemDoc) 

-- check the data
select * from dbo.invoices

-- example 2
-- constant string expression--- 
INSERT INTO dbo.Invoices 
VALUES 
(2, GetDate(), 2, 	'<Items> 
  			<Item ProductID="2" Quantity="3"/> 
			<Item ProductID="4" Quantity="1"/> 
		</Items>') 

-- check the data
select * from dbo.invoices

--performing manipulations
CREATE TABLE T (i int, x xml)
go

INSERT INTO T VALUES
(1,	'<Root>
		<ProductDescription ProductID="1" ProductName="Road Bike">
			<Features>
  			<Warranty>1 year parts and labor</Warranty>
  			<Maintenance>3 year parts and labor extended maintenance is available</Maintenance>
			</Features>
		</ProductDescription>
	</Root>'
)
go

-- verify the contents before delete
SELECT x.query(' //ProductDescription/Features')
FROM T

-- delete the second feature
UPDATE T
SET x.modify('delete /Root/ProductDescription/Features/*[2]')

-- verify the deletion
SELECT x.query(' //ProductDescription/Features')
FROM T

