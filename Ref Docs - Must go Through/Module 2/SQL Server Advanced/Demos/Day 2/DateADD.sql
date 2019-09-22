DECLARE @datetime2 datetime2 = '2007-01-01 13:10:10.1111111'
SELECT '1 millisecond' ,DATEADD(millisecond,1,@datetime2)
UNION ALL
SELECT '2 milliseconds', DATEADD(millisecond,2,@datetime2)
UNION ALL
SELECT '1 microsecond', DATEADD(microsecond,1,@datetime2)
UNION ALL
SELECT '2 microseconds', DATEADD(microsecond,2,@datetime2)
UNION ALL
SELECT '49 nanoseconds', DATEADD(nanosecond,49,@datetime2)
UNION ALL
SELECT '50 nanoseconds', DATEADD(nanosecond,50,@datetime2)
UNION ALL
SELECT '150 nanoseconds', DATEADD(nanosecond,150,@datetime2);

SELECT DATEADD(month, 1, SYSDATETIME());

SELECT SYSUTCDATETIME()

SELECT DATENAME(YEAR,GETDATE())
SELECT DATEPART(YEAR,GETDATE())
SELECT DATENAME(MONTH,GETDATE())
SELECT DATEPART(MONTH,GETDATE())

USE AdventureWorks;
GO
SELECT SalesOrderID
    ,OrderDate 
    ,DATEADD(day,2,OrderDate) AS PromisedShipDate
FROM Sales.SalesOrderHeader
SELECT SYSDATETIMEOFFSET()

