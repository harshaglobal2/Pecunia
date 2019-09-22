--Create Table Statement to create Default Constraint
 
--a.       Column Level
 
USE AdventureWorks2008
GO

CREATE TABLE Customer
(
 	CustomerID 	INT 		CONSTRAINT pk_customer_cid PRIMARY KEY,
 	CustomerName 	VARCHAR(30),
 	CustomerAddress 	VARCHAR(50) 	CONSTRAINT df_customer_Add DEFAULT 'UNKNOWN'
 );
GO
 

--b.      Table Level : Not applicable for Default Constraint
 
--2)      Alter Table Statement to Add Default Constraint
 
ALTER TABLE Customer
ADD CONSTRAINT df_customer_Add DEFAULT 'UNKNOWN' FOR CustomerAddress
GO 

--3)      Alter Table to Drop Default Constraint
 
ALTER TABLE Customer
DROP CONSTRAINT df_customer_Add
GO 
