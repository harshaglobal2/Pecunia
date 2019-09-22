--The uniqueidentifier data type does not automatically generate new IDs for inserted rows the way the IDENTITY property does. To get new uniqueidentifier values, a table must have a DEFAULT clause specifying the NEWID function, or INSERT statements must use the NEWID function:
/*The uniqueidentifier data type stores
 16-byte binary values that operate as
  globally unique identifiers (GUIDs).
   A GUID is a unique binary number; no other computer in the world will generate a duplicate of that GUID value. The main use for a GUID is for assigning an identifier that must be unique in a network that has many computers at many sites.
 
A GUID value for a uniqueidentifier column is usually obtained: 
•In a Transact-SQL statement, batch, or script by calling the NEWID function.

 •In application code by calling an application API function
  or method that returns a GUID.*/
 
CREATE TABLE MyUniqueTable
(
	UniqueColumn	UNIQUEIDENTIFIER		DEFAULT NEWID(),
   	Characters      	VARCHAR(10) 
)
GO

INSERT INTO MyUniqueTable(Characters)
VALUES ('abc')
INSERT INTO MyUniqueTable VALUES (NEWID(), 'def')
GO
select * from MyUniqueTable
