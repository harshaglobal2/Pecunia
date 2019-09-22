DECLARE @startdate datetime, @adddays int;
SET @startdate = 'January 10, 1900 12:00 AM';
SET @adddays = 5;
SET NOCOUNT OFF;
SELECT @startdate + 1.25 AS 'Start Date', 
   @startdate + @adddays AS 'Add Date';
DECLARE @addvalue int;
SET @addvalue = 15;
SELECT '125127' + @addvalue;



SELECT 38 / 5 AS Integer, 38 % 5 AS Remainder ;

