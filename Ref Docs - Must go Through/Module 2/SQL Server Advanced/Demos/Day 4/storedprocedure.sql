CREATE PROCEDURE titles_sum @@TITLE varchar(40) = '%',
 @@SUM money OUTPUT
AS
SELECT 'Title Name' = title
FROM titles 
WHERE title LIKE @@TITLE 
SELECT @@SUM = SUM(price)
FROM titles
WHERE title LIKE @@TITLE
GO
---
/*The WITH RECOMPILE clause is helpful when the parameters supplied to the procedure will not be typical, and when a new execution plan should not be cached or stored in memory.
USE pubs
IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'titles_by_author' AND type = 'P')
   DROP PROCEDURE titles_by_author
GO
CREATE PROCEDURE titles_by_author @@LNAME_PATTERN varchar(30) = '%'
WITH RECOMPILE
AS
SELECT RTRIM(au_fname) + ' ' + RTRIM(au_lname) AS 'Authors full name',
   title AS Title
FROM authors a INNER JOIN titleauthor ta 
   ON a.au_id = ta.au_id INNER JOIN titles t
   ON ta.title_id = t.title_id
WHERE au_lname LIKE @@LNAME_PATTERN
GO
. Use the WITH ENCRYPTION option
The WITH ENCRYPTION clause hides the text of a stored procedure from users. This example creates an encrypted procedure, uses the sp_helptext system stored procedure to get information on that encrypted procedure, and then attempts to get information on that procedure directly from the syscomments table.
IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'encrypt_this' AND type = 'P')
   DROP PROCEDURE encrypt_this
GO
USE pubs
GO
CREATE PROCEDURE encrypt_this
WITH ENCRYPTION
AS
SELECT * 
FROM authors
GO

EXEC sp_helptext encrypt_this
*/
