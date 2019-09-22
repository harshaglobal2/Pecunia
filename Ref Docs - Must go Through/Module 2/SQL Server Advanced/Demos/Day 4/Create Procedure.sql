--'Step 1 create a procedure
-------------------------------------------
CREATE PROC addnum
 	@FirstNumber int = 5,
   	@SecondNumber int,
 	@Answer varchar(30) OUTPUT 
AS
   	Declare @sum int
   	Set @sum = @FirstNumber + @SecondNumber
   	Set @Answer = 'The answer is ' + convert(varchar,@sum)
   	Return @sum
------------------------------------------------------------

/*The first thing to remember is that the parameter name must start with an @ symbol. The name can’t have spaces, and there are some characters that are not allowed. If you just stick with alpha-numeric characters and underscores in your parameter names you won’t have any problems naming parameters.
Second, the data type of the parameter and possibly the size must be stated. For example, the size of a parameter of type VARCHAR must be specified. Third, if you wish to access a return value from the parameter, the OUTPUT keyword must be used. In the example create proc statement, three parameters are defined, two are integers. One of the parameters, @Answer, is an OUTPUT parameter and will be used to pass a value back to the caller. 
Parameters can be given a default value. The @FirstNumber parameter has a default value of 5. */
--------------------------------------------------
--'2Step 2
--------------------------------------------------
Call the stored procedure
Declare @a int, @b int, @c varchar(30)
Select @a = 1, @b = 2
Exec addnum @a, @b, @c OUTPUT
Select @c
-------------------------------

--Passing Parameters to procedure
CREATE PROCEDURE pass_params 
	@param0 int=NULL,   -- Defaults to NULL
	@param1 int=1,      -- Defaults to 1
	@param2 int=2       -- Defaults to 2
AS
	SELECT @param0, @param1, @param2
GO

EXEC pass_params          -- PASS NOTHING - ALL Defaults
(null)    1    2

EXEC pass_params 0, 10, 20    -- PASS ALL, IN ORDER
0    10    20

EXEC pass_params @param2=200, @param1=NULL    
-- Explicitly identify last two params (out of order)
(null)    (null)    200

EXEC pass_params 0, DEFAULT, 20
-- Let param1 default. Others by position.
0    1    20


================================================
--Example of Output Parameter

USE pubs
GO
IF EXISTS(SELECT name FROM sysobjects
      WHERE name = 'titles_sum' AND type = 'P')
   	DROP PROCEDURE titles_sum
GO
USE pubs
GO

CREATE PROCEDURE titles_sum 
	@@TITLE varchar(40) = '%', 
	@@SUM money OUTPUT
AS
	SELECT 'Title Name' = title
	FROM titles 
	WHERE title LIKE @@TITLE 
	
	SELECT @@SUM = SUM(price)
	FROM titles
	WHERE title LIKE @@TITLE
GO

----------------------------------------------
--The parameter name and variable name do not have to match; however, the data type and parameter positioning must match (unless @@SUM = variable is used). 

DECLARE @@TOTALCOST money
EXECUTE titles_sum 'The%', @@TOTALCOST OUTPUT
IF @@TOTALCOST < 200 
BEGIN
   PRINT ' '
   PRINT 'All of these titles can be purchased for less than $200.'
END
ELSE
   SELECT 'The total cost of these titles is $' 
         + RTRIM(CAST(@@TOTALCOST AS varchar(20)))

--------------------------------------------------------------------------

CREATE PROC au_info 
	@lastname varchar(40), 
	@firstname varchar(20) 
AS 
	SELECT au_lname, au_fname, title, pub_name
	FROM authors INNER JOIN titleauthor ON authors.au_id = titleauthor.au_id
   	JOIN titles ON titleauthor.title_id = titles.title_id
   	JOIN publishers ON titles.pub_id = publishers.pub_id
	WHERE au_fname = @firstname
	AND au_lname = @lastname
GO

----------------------------------------------------------------
EXECUTE au_info Ringer, Anne

--------------------------------------------------------------------
CREATE PROC pub_info2 
	@pubname varchar(40) = 'Algodata Infosystems'
AS 
	SELECT au_lname, au_fname, pub_name
	FROM authors a INNER JOIN titleauthor ta ON a.au_id = ta.au_id
	JOIN titles t ON ta.title_id = t.title_id
   	JOIN publishers p ON t.pub_id = p.pub_id
	WHERE @pubname = p.pub_name
-----------------------------------------------------------------
--Execute pub_info2 with no parameter specified:

EXECUTE pub_info2
-----------------------------------------------------

CREATE PROC showind2 
	@table varchar(30) = 'titles'
AS 
	SELECT TABLE_NAME = sysobjects.name,
	INDEX_NAME = sysindexes.name, INDEX_ID = indid
	FROM sysindexes INNER JOIN sysobjects ON sysobjects.id = sysindexes.id
	WHERE sysobjects.name = @table

--The column headings (for example, TABLE_NAME) make the results more readable. Here is what the stored procedure shows for the authors table:

EXECUTE showind2 authors

---------------------------------------------------
CREATE PROC showind3 
	@table varchar(30) = NULL
AS 
	IF @table IS NULL
   		PRINT 'Give a table name'
	ELSE
	   	SELECT TABLE_NAME = sysobjects.name,
   		INDEX_NAME = sysindexes.name, INDEX_ID = indid
   		FROM sysindexes INNER JOIN sysobjects
   		ON sysobjects.id = sysindexes.id
   		WHERE sysobjects.name = @table


-------------------------------------------------------------------------

