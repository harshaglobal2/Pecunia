/* a stored procedure is a collection of 
Transact SQL statements
The commands placed in stored procedure
 are directly accessible
by sql server 
if it is on same 
machine it is called local procedure else on different
machine called remote procedure
A stored procedure can have maximum of 2,100 parameters
*/

--simple stored procedure
--this stored procedure returns all authors
--(first and last names ) their titles and their
--publishers from a four table join
--procedure without parameters 
--example 1
use pubs
CREATE PROCEDURE AU_INFO_ALL_1 AS SELECT AU_LNAME,AU_FNAME,TITLE,PUB_NAME
FROM AUTHORS A INNER JOIN TITLEAUTHOR TA ON A.AU_ID =TA.AU_ID INNER JOIN  TITLES T 
ON T.TITLE_ID =TA.TITLE_ID INNER JOIN publishers P 
ON T.PUB_ID =P.PUB_ID 
GO
--TO EXECUTE THE STORED PROCEDURE
EXECUTE AU_INFO_ALL_1
--OR EXEC
--AU_INFO_ALL IF THE PROCEDURE IS THE FIRST
-- STATEMENT IN THE BATCH

------------------------------------------------------------------------------------

--example 2 procedure with parameters
CREATE PROCEDURE AU_INFO_ALL_2
 @lastname varchar(40),
@firstname varchar(20)
  AS SELECT AU_LNAME,AU_FNAME,TITLE,PUB_NAME
FROM AUTHORS A INNER JOIN TITLEAUTHOR TA ON A.AU_ID =TA.AU_ID INNER JOIN  TITLES T 
ON T.TITLE_ID =TA.TITLE_ID INNER JOIN publishers P 
ON T.PUB_ID =P.PUB_ID  
WHERE AU_FNAME=@FIRSTNAME
AND AU_LNAME=@LASTNAME 
GO
--TO EXECUTE THE STORED PROCEDURE
EXECUTE AU_INFO_ALL_2 'DULL','ANN'
--OR EXECUTE IN THIS WAY
EXECUTE AU_INFO_ALL_2 @LASTNAME='DULL',@FIRSTNAME='ANN'
--OR EXECUTE IN THIS WAY
EXECUTE AU_INFO_ALL_2 @FIRSTNAME='ANN',@LASTNAME='DULL'
--OR EXECUTE IN THIS WAY
EXEC AU_INFO_ALL_2 @FIRSTNAME='ANN',@LASTNAME='DULL'
--IF THE PROCEDURE IS THE FIRST STATEMENT IN THE BATCH

--AUTH_INFO_ALL_2 'DULL' 'ANN'
----------------------------------------------------------------------------------
--EXAMPLE 3 STORED PROCEDURE WITH WILDCARD PARAMETERS
CREATE PROCEDURE AU_INFO_ALL_3
--CODE CHANGED HERE FOR WILDCARD
 @lastname varchar(30)='D%',
@firstname varchar(18)='%'
  AS SELECT AU_LNAME,AU_FNAME,TITLE,PUB_NAME
FROM AUTHORS A INNER JOIN TITLEAUTHOR TA ON A.AU_ID =TA.AU_ID INNER JOIN  TITLES T 
ON T.TITLE_ID =TA.TITLE_ID INNER JOIN publishers P 
ON T.PUB_ID =P.PUB_ID  
--CODE CHANGED HERE FOR WILDCARD
WHERE AU_FNAME LIKE @FIRSTNAME
AND AU_LNAME LIKE @LASTNAME 
GO
EXECUTE AU_INFO_ALL_3 @FIRSTNAME='A%'
--OR EXECUTE IN THIS WAY
EXECUTE AU_INFO_ALL_3 'H%','S%'
------------------------------------------------------------------------------------------
--EXAMPLE 4 USING OUTPUT PARAMETER 
--OUTPUT PARAMETER -TO ACCESS A VALUE SET DURING THE PROCEDURE EXECUTION 
CREATE PROCEDURE TITLES_SUM 
@TITLE VARCHAR(40) ='%' ,
@SUM MONEY OUTPUT
AS
SELECT 'TITLE NAME'=TITLE
FROM TITLES
WHERE TITLE LIKE @TITLE
SELECT @SUM=SUM(PRICE)
FROM TITLES WHERE TITLE LIKE @TITLE
GO

--NOTE:THE PARAMETER NAME AND VARIABLE NAME DO NOT HAVE TO MATCH HOWEVER THE DATA TYPE AND PARAMETER
--POSITIONING MUST MATCH

DECLARE
@TOTALCOST MONEY
EXECUTE TITLES_SUM 'THE %' ,@TOTALCOST OUTPUT
IF @TOTALCOST < 200
BEGIN
PRINT ' ' 
PRINT 'ALL OF THESE TITLES CAN BE PURCHASED FOR LESS THAN $200'
END
ELSE
SELECT 'THE TOTAL COST OF THESE TITLES IS $' + RTRIM (CAST (@TOTALCOST AS VARCHAR(20)))

-------------------------------------------------------------------------------------------
--EXAMPLE 5 -OUTPUT CURSOR PARAMETER
--OUTPUT CURSOR PARAMETERS ARE USED
-- TO PASS A CURSOR THAT IS LOCAL TO A STORED PROCEDURE BACK TO THE CALLING BATCH ,STTORED PROCEDURE OR TRIGGER
CREATE PROCEDURE TITLES_CURSOR 
@TITLES_CURSOR CURSOR VARYING OUTPUT AS 
SET @TITLES_CURSOR =CURSOR
FORWARD_ONLY STATIC FOR SELECT * FROM TITLES
OPEN @TITLES_CURSOR
GO
--NEXT EXECUTE A BATCH THAT DECLARES A LOCAL CURSOR variable ,executes the procedure to
--assign the cursor to the local variable and then fetches the rows from the cursor

declare 
@MYCURSOR CURSOR
EXEC TITLES_CURSOR 
@TITLES_CURSOR=@MYCURSOR OUTPUT 
WHILE (@@FETCH_STATUS = 0)
BEGIN
  FETCH NEXT FROM @MYCURSOR
END
CLOSE @MYCURSOR
DEALLOCATE @MYCURSOR
GO

-------------------------------------------------------------------------------------
--EXAMPLE 6--PROCEDURE WITH RECOMPILE OPTION
--THE WITH RECOMPILE CLAUSE IS HELPFUL WHEN THE PARAMETERS SUPPLIED TO THE PROCEDURE
---WILL NOT BE TYPICAL AND WHEN A NEW EXECUTION PLAN SHOULD NOT BE CACHED OR STORED 
----IN MEMORY
CREATE PROCEDURE TITLES_BY_AUTHOR 
@LNAME_PATTERN VARCHAR (30) ='%' WITH RECOMPILE
AS
SELECT RTRIM(AU_FNAME) + ' ' + RTRIM(AU_LNAME) AS 'AUTHORS FULL NAME' ,TITLE AS 
TITLE
FROM AUTHORS A INNER JOIN TITLEAUTHOR TA 
ON A.AU_ID=TA.AU_ID INNER JOIN TITLES T 
ON TA.TITLE_ID =T.TITLE_ID 
WHERE AU_LNAME LIKE @LNAME_PATTERN
GO
EXECUTE TITLES_BY_AUTHOR  @LNAME_PATTERN ='RINGER'
----------------------------------------------------------------------------------
--EXAMPLE 7-STORED PROCEDURE WITH ENCRYPTION 
--:-CLAUSE OBFUSCATES THE TEXT OF
---STORED PROCEDURE -THIS EXAMPLE USES
-- SP_HELPTEXT TO GET INFORMATION ON THE 
--OBFUSCATED PROCEDURE 
/*The WITH ENCRYPTION option prevents the definition of the
 stored procedure from being returned
*/
CREATE PROCEDURE ENCRYPT_THIS WITH ENCRYPTION 
AS SELECT * FROM AUTHORS
GO
EXEC SP_HELPTEXT ENCRYPT_THIS

--SELECT THE IDENTIFICATION NUMBER AND TEXT OF OBFUSCATED STORED PROCEDURE CONTENTS
SELECT C.ID ,C.TEXT FROM SYSCOMMENTS C INNER JOIN SYSOBJECTS O ON C.ID =O.ID
WHERE O.NAME ='ENCRYPT_THIS'

-------------------------------------------------------------------------------------
--EXAMPLE 8 EXECUTE A STORED PROCEDURE THAT OVERRIDES THE DEFAULT VALUE OF A PARAMETER
---WITH AN EXPLICIT VALUE
CREATE PROC SHOWIND2 
@TABLE VARCHAR(30) ='TITLES'
AS
SELECT TABLE_NAME =SYSOBJECTS.NAME,
INDEX_NAME =SYSINDEXES.NAME,INDEX_ID =INDID
FROM SYSINDEXES INNER JOIN SYSOBJECTS ON SYSOBJECTS.ID=SYSINDEXES.ID WHERE SYSOBJECTS.NAME
=@TABLE
EXECUTE SHOWIND2 AUTHORS
--OR
--IF WE DON'T SPECIFY IT WILL USE THE DEFAULT TABLE TITLES
EXECUTE SHOWIND2 
------------------------------------------------------------------------------------
--EXAMPLE 9
--STORED PROCEDURE USING A PARAMETER DEFAULT OF NULL
CREATE PROC SHOWIND3 
@TABLE VARCHAR(30) =NULL
AS 
IF @TABLE IS NULL
PRINT 'GIVE A TABLE NAME'
ELSE
SELECT TABLE_NAME=SYSOBJECTS.NAME,INDEX_NAME =SYSINDEXES.NAME,INDEX_ID=INDID FROM 
SYSINDEXES INNER JOIN SYSOBJECTS
ON SYSOBJECTS.ID =SYSINDEXES.ID 
WHERE SYSOBJECTS.NAME =@TABLE

EXECUTE SHOWIND3
--OR 
EXECUTE SHOWIND3 'TITLES'

-----------------------------------------------------------------------------------------------------
--EXAMPLE 10 
--ALTER PROCEDURE COMMAND 
CREATE PROCEDURE O_AUTH AS SELECT AU_FNAME,AU_LNAME,ADDRESS,CITY FROM AUTHORS
WHERE CITY='OAKLAND' AND STATE ='CA' ORDER BY AU_LNAME,AU_FNAME
GO
--PRESS F5
ALTER PROCEDURE O_AUTH WITH ENCRYPTION AS SELECT AU_FNAME,AU_LNAME,ADDRESS,CITY FROM AUTHORS
WHERE CITY='OAKLAND' AND STATE ='CA' ORDER BY AU_LNAME,AU_FNAME
GO
--PRESS F5
SELECT O.ID,C.TEXT FROM SYSOBJECTS O INNER JOIN SYSCOMMENTS C ON O.ID =C.ID WHERE 
O.TYPE ='P' AND O.NAME='O_AUTH'
-------------------------------------------------------------------------------------------------------------
--TO DROP A PROCEDURE
DROP PROCEDURE O_AUTH
GO
-------------------------------------------------------------------------------
--example 11(extra)
CREATE PROCEDURE get_sales_for_title
@title varchar(80),   -- This is the input parameter.
@ytd_sales int OUTPUT -- This is the output parameter.
AS  

-- Get the sales for the specified title and 
-- assign it to the output parameter.
SELECT @ytd_sales = ytd_sales
FROM titles
WHERE title = @title

RETURN
GO 
select * from titles 
exec get_sales_for_title 
@title='But Is It User Friendly?',@ytd_sales=8780
--------------------------------------------------------------------------------------
--EXAMPLE 12 
--Handling Error Messages with stored procedure
--@@error contains error number of last executed statement
--raiseerror returns user defined or system error message 
CREATE PROCEDURE U_GERR AS SELECT ERROR_NUMBER() AS ERRONUMBER,
ERROR_SEVERITY() AS ERRORSEVERITY,
ERROR_STATE() AS ERRORSTATE,
ERROR_PROCEDURE()AS ERRORPROCEDURE,
ERROR_LINE() AS ERRORLINE,
ERROR_MESSAGE() AS ERRORMESSAGE

--CALLING PROCEDURE USING TRY CATCH BLOCK
BEGIN TRY
SELECT 1/0
END TRY
BEGIN CATCH
EXECUTE U_GERR
END CATCH

--example 13
--create a temporary table
use vaishali
create table #config_out(name_c varchar(50),minval int,
maxval int,configval int,runval int)
insert #config_out exec sp_configure
select * from  #config_out
--EXTENDED STORED PROCEDURES
EXEC XP_FIXEDDRIVES
-----------------------------------
declare @exists int

exec xp_fileexist 'c:\test.file', @exists output

print @exists
-------------------------------------------------------
exec xp_dirtree 'D:\EXPROC'

-------------------------------------------------
--The first parameter, hdoc, is an integer handle that is used to identify the
-- XML document to SQL Server. The second parameter, xmltext, is the actual XML
-- document that SQL Server should tell the MSXML2 library to parse,
-- and the third option is a set of OPENXML XPath namespaces that can be used
-- to format the resultant XML document.


declare @id int

declare @xml varchar(500)

set @xml = '<people><person name="John Doe" age="30"/></people>'

exec sp_xml_preparedocument @id output, @xml

select * from OpenXML(@id, '/people/person')

with(name varchar(50) '@name')

exec sp_xml_removedocument @id

