CREATE PROC usp_SearchProduct
(
	@ProdID	INT
)
AS
BEGIN
	IF EXISTS (SELECT ProductName FROM Product WHERE ProductID = @ProdID)
	BEGIN
		SELECT ProductID, ProductName, UnitPrice, Quantity, CategoryName
		FROM Product INNER JOIN Category
		ON Product.CategoryID = Category.CategoryID
		WHERE ProductID = @ProdID
	END
	ELSE
	BEGIN
		RAISERROR('Product ID does not exists', 1,1)
	END
END

EXEC usp_SearchProduct 101