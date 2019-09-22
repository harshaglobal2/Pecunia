CREATE PROC usp_DisplayAllProducts
AS
BEGIN
          SELECT p.ProductID, p.ProductName, p.UnitPrice, p.Quantity, c.CategoryName
          FROM Product  p INNER JOIN Category c
          ON p.CategoryID = c.CategoryID
END

EXEC usp_DisplayAllProducts WITH RESULT SETS
((PID INT,
PName VARCHAR(30),
Price MONEY,
Quantity INT,
Category VARCHAR(20)))