CREATE TABLE myTable1
( 
	ID INT Identity(1,1),  
	Name VARCHAR(20)
) 

 /* Now Create a Stored Procedure with the OUTPUT  parameter */
  
CREATE PROCEDURE my_sp
(	@name VARCHAR(20), 
     	@id_out INT OUTPUT
)
AS 
BEGIN 
     INSERT INTO myTable1 VALUES (@name) 
     SELECT  @id_out = Scope_Identity ()
END
GO

declare @id int
exec my_sp 'vaishali' ,@id out 
select @id as inserted_id

