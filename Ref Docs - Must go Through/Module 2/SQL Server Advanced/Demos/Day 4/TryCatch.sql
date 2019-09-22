CREATE PROCEDURE usp_GetErrorInfo
AS
    SELECT 
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() as ErrorState,
        ERROR_PROCEDURE() as ErrorProcedure,
        ERROR_LINE() as ErrorLine,
        ERROR_MESSAGE() as ErrorMessage;
GO

BEGIN TRY
    -- Generate divide-by-zero error.
    SELECT 1/0;
END TRY
BEGIN CATCH
    -- Execute the error retrieval routine.
    EXECUTE usp_GetErrorInfo;
END CATCH;
GO


/*
For example, the following code example shows 
a SELECT statement that causes a syntax error.
 If this code is executed in the SQL Server Management
  Studio Query Editor, execution will not start because
   the batch fails to compile. 
   The error will be returned to the Query Editor
    and will not get caught by TRY…CATCH.

*/
USE AdventureWorks;
GO

BEGIN TRY
    -- This PRINT statement will not run because the batch
    -- does not begin execution.
    PRINT N'Starting execution';

    -- This SELECT statement contains a syntax error that
    -- stops the batch from compiling successfully.
    SELECT ** FROM HumanResources.Employee;
END TRY
BEGIN CATCH
    SELECT 
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO
