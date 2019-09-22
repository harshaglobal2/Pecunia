CREATE TABLE Category
(
CategoryID INT PRIMARY KEY,
CategoryName VARCHAR(20)
)

CREATE TABLE Product
(
ProductID INT PRIMARY KEY,
ProductName VARCHAR(30),
UnitPrice   MONEY,
Quantity INT,
CategoryID INT FOREIGN KEY REFERENCES Category(CategoryID)
)

CREATE PROC usp_InsertCategory
(
          @CatID	INT,
          @CatName	VARCHAR(20)
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
                              RAISERROR('Category ID already exists', 1, 1)                    END
                    ELSE                    BEGIN
                              INSERT INTO Category
                              (CategoryID, CategoryName)
                              VALUES
                              (@CatID, @CatName)
                    END
          END	
END
EXEC usp_InsertCategory 1, 'Bike'