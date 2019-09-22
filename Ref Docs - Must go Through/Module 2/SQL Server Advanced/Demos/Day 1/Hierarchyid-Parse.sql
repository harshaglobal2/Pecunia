DECLARE @StringValue AS nvarchar(4000), @hierarchyidValue AS hierarchyid
SET @StringValue = '/1/1/3/'
SET @hierarchyidValue = 0x5ADE

SELECT hierarchyid::Parse(@StringValue) AS hierarchyidRepresentation,
 @hierarchyidValue.ToString() AS StringRepresentation ;
GO
