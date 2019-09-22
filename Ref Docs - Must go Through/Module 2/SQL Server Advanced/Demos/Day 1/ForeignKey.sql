--Create Table Statement  to create Foreign Key
 
--a.       Column Level
 
USE AdventureWorks2008
GO
CREATE TABLE ProductSales
(
 	SalesID		INT 	CONSTRAINT pk_productSales_sid PRIMARY KEY,
 	ProductID 		INT 	CONSTRAINT fk_productSales_pid FOREIGN KEY REFERENCES Products(ProductID),
 	SalesPerson 	VARCHAR(25)
);
 
GO
 
--b.      Table Level
 
CREATE TABLE ProductSales
(
	SalesID INT,
 	ProductID INT,
 	SalesPerson VARCHAR(25)
 	CONSTRAINT pk_productSales_sid PRIMARY KEY(SalesID),
 	CONSTRAINT fk_productSales_pid FOREIGN KEY(ProductID)REFERENCES Products(ProductID)
);
GO 

--1)      Alter Table Statement to create Foreign Key
 
ALTER TABLE ProductSales
ADD CONSTRAINT fk_productSales_pid 
FOREIGN KEY(ProductID)REFERENCES Products(ProductID)
GO 

--2)    Alter Table Statement to Drop Foreign Key
 
ALTER TABLE ProductSales
DROP CONSTRAINT fk_productSales_pid;
GO 
