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
