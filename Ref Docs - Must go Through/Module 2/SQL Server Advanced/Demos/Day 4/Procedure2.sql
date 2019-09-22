CREATE PROC usp_InsertProduct
(
          @ProdID	INT,
          @ProdName VARCHAR(20),
          @Price MONEY,
          @Qty INT,
          @CatID INT
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
                              RAISERROR('Product ID already exists', 1, 1)                    END
                    ELSE                    BEGIN
                              IF EXISTS (SELECT CategoryName FROM Category WHERE CategoryID = @CatID OR @CatID IS NULL)
                              BEGIN
                                        IF (@Price <= 0 OR @Qty <=0)
                                        BEGIN
                                                  RAISERROR('Unit Price or Quantity cannot be negative or zero', 1, 1)
                                        END
                                        ELSE
                                        BEGIN
                                                  INSERT INTO Product
                                                  (ProductID, ProductName, UnitPrice, Quantity, CategoryID)
                                                  VALUES
                                                  (@ProdID, @ProdName, @Price, @Qty, @CatID)
                                        END
                              END
                              ELSE                              BEGIN
                                        RAISERROR('Category ID does not exists', 1, 1)
                              END
                    END
          END	
END

EXEC usp_InsertProduct 101, 'Cover', 200, 4, 1