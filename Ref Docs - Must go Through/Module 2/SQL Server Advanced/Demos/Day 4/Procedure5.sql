CREATE PROC usp_DeleteCategory
(
          @CatID	INT
)
ASBEGIN
          IF(@CatID IS NULL OR @CatID < 0)
          BEGIN
                    RAISERROR('Category ID cannot be null or negative', 1, 1)
          END
          ELSE
          BEGIN
                    IF EXISTS (SELECT CategoryID FROM Category WHERE CategoryID = @CatID)
                    BEGIN
                              DELETE FROM Category WHERE CategoryID = @CatID                    END
                    ELSE                    BEGIN
                              RAISERROR('Category ID not exists', 1, 1)
                    END
          END	
END
