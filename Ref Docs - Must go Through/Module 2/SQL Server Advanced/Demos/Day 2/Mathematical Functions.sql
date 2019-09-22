SELECT CEILING(12.9273);

SELECT FLOOR(12.9273);

SELECT RAND(), RAND(3);

SELECT LOG(1.75) AS 'base-e'
    ,LOG10(1.75) AS 'base-10'
    ,LOG(1.75)/LOG(2) AS 'base-2'; 
GO

SELECT PI()
GO

SELECT POWER(2.0, -100.0);
GO

DECLARE @myvalue float;
SET @myvalue = 1.00;
WHILE @myvalue < 10.00
   BEGIN
      SELECT SQRT(@myvalue);
      SET @myvalue = @myvalue + 1
   END;
GO
