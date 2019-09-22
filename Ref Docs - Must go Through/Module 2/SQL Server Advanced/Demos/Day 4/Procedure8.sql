CREATE PROC usp_DisplayProductCategoryWise
(
	@CatID	INT
)
AS
BEGIN
	IF EXISTS (SELECT CategoryName FROM Category WHERE CategoryID = @CatID)
	BEGIN
		SELECT ProductID, ProductName, UnitPrice, Quantity
		FROM Product
		WHERE CategoryID = @CatID
	END
	ELSE
	BEGIN
		RAISERROR('Category ID does not exists', 1, 1)
	END
END

EXEC usp_DisplayProductCategoryWise 1