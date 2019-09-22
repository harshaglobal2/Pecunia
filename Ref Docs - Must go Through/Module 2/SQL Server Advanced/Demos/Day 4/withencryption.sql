/*Use the WITH ENCRYPTION option
The WITH ENCRYPTION clause hides the text of
 a stored procedure from users.
  This example creates an encrypted procedure, 
  uses the sp_helptext system stored procedure to 
  get information on that encrypted procedure,
   and then attempts to get information on that
    procedure directly from the syscomments table.*/
IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'encrypt_this' AND type = 'P')
   DROP PROCEDURE encrypt_this
GO
USE Northwind
GO
CREATE PROCEDURE encrypt_this
WITH ENCRYPTION
AS
SELECT * 
FROM  Customers
GO

EXEC sp_helptext encrypt_this

