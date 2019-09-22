CREATE PROC usp_DeleteProduct
(
          @ProdID	INT
)
ASBEGIN
          IF(@ProdID IS NULL OR @ProdID < 0)
          BEGIN
                    RAISERROR('Product ID cannot be null or negative', 1, 1)
          END
          ELSE
          BEGIN
                    IF EXISTS (SELECT ProductName FROM Product WHERE ProductID = @ProdID)
                    BEGIN
                              DELETE FROM Product WHERE ProductID = @ProdID
                     END
                     ELSE                    BEGIN
                              RAISERROR('Product ID does not exists', 1, 1)
                    END
          END	
END
