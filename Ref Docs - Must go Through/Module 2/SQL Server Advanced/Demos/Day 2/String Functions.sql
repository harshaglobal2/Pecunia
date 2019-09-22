USE AdventureWorks;
GO

SELECT FirstName, REVERSE(FirstName) AS Reverse
FROM Person.Contact
WHERE ContactID < 5
ORDER BY FirstName;
GO

--The following example shows the SOUNDEX
-- function and the related DIFFERENCE function.
-- In the first example, the standard SOUNDEX values are
-- returned for all consonants.
-- Returning the SOUNDEX for Smith and Smythe
-- returns the same SOUNDEX result because all vowels,
-- the letter y, doubled letters, and the letter h, are not included.
-- Using SOUNDEX

SELECT SOUNDEX ('Smith'), SOUNDEX ('Smythe');

SELECT REPLACE('abcdefghicde','cde','xxx');

use Northwind;
SELECT LastName, SUBSTRING(FirstName, 1, 1)
 AS Initial FROM Employees WHERE LastName like 'S%' 

SELECT LEN(CompanyName) AS Length,CompanyName,city 
FROM Suppliers
WHERE Country ='USA'

--The following example finds the position at 
--which the pattern ensure starts in a
-- specific row of the DocumentSummary
-- column in the Document table.

USE AdventureWorks;
SELECT PATINDEX('%ensure%',DocumentSummary)
FROM Production.Document
WHERE DocumentID = 3;
GO

 --Char
USE AdventureWorks;
SELECT FirstName + ' ' + LastName,
 + CHAR(13)  + EmailAddress + CHAR(13) 
+ Phone FROM Person.Contact
WHERE ContactID = 1;

select CHAR(13) + firstname from Person.Contact
GO

--space
--The following example trims the last names and concatenates a comma, two spaces, and the first names of people listed in the Contact table in AdventureWorks.

USE AdventureWorks;
GO
SELECT RTRIM(LastName) + ',' + SPACE(2) +  LTRIM(FirstName)
FROM Person.Contact
ORDER BY LastName, FirstName;
GO

SELECT LEFT('abcdefg',2)
GO



SELECT RTRIM('Removes trailing spaces.   ');
DECLARE @string_to_trim varchar(60);
SET @string_to_trim = 'Four spaces are after the period in this sentence.    ';

SELECT @string_to_trim + ' Next string.';

SELECT RTRIM(@string_to_trim) + ' Next string.';
GO

DECLARE @string_to_trim varchar(60);
SET @string_to_trim = '     Five spaces are at the beginning of this
   string.';
SELECT 'Here is the string without the leading spaces: ' + 
   LTRIM(@string_to_trim);
GO

SELECT x = SUBSTRING('abcdef', 2, 3);

----- Use CAST
USE AdventureWorks2012;
GO
SELECT SUBSTRING(Name, 1, 30) AS ProductName, ListPrice
FROM Production.Product
WHERE CAST(ListPrice AS int) LIKE '3%';
GO

-- Use CONVERT.
USE AdventureWorks2012;
GO
SELECT SUBSTRING(Name, 1, 30) AS ProductName, ListPrice
FROM Production.Product
WHERE CONVERT(int, ListPrice) LIKE '3%';
GO

SELECT CAST(10.3496847 AS money);

USE AdventureWorks2012;
GO
SELECT CAST(ROUND(SalesYTD/CommissionPCT, 0) AS int) AS Computed
FROM Sales.SalesPerson 
WHERE CommissionPCT != 0;
GO
