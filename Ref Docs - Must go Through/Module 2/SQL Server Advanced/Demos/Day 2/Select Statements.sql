USE Northwind;

SELECT *
FROM Products
ORDER BY ProductName ASC;

-- Alternate way.
SELECT p.*
FROM Products AS p
ORDER BY ProductName ASC;
GO

SELECT DISTINCT City
FROM Employees
ORDER BY CITY;
GO

