CREATE TABLE EmployeeOrg
(
   	OrgNode 		hierarchyid 	PRIMARY KEY CLUSTERED,
   	OrgLevel 		AS 		OrgNode.GetLevel(),
   	EmployeeID 	int 		UNIQUE NOT NULL,
   	EmpName 		varchar(20) 	NOT NULL,
   	Title 		varchar(20) 	NULL
) ;
GO

CREATE UNIQUE INDEX EmployeeOrgNc1 
ON EmployeeOrg(OrgLevel, OrgNode) ;
GO

CREATE UNIQUE INDEX EmployeeOrgNc1 
ON EmployeeOrg(OrgLevel, OrgNode) ;
GO

INSERT EmployeeOrg (OrgNode, EmployeeID, EmpName, Title)
VALUES (hierarchyid::GetRoot(), 6, 'David', 'Marketing Manager') ;
GO

SELECT OrgNode.ToString() AS Text_OrgNode, 
OrgNode, OrgLevel, EmployeeID, EmpName, Title 
FROM EmployeeOrg ;

DECLARE @Manager hierarchyid 
SELECT @Manager = hierarchyid::GetRoot()
FROM HumanResources.EmployeeOrg ;

INSERT HumanResources.EmployeeOrg (OrgNode, EmployeeID, EmpName, Title)
VALUES
(@Manager.GetDescendant(NULL, NULL), 46, 'Sariya', 'Marketing Specialist') ; 

--Sariya reports to David. To insert Sariya's node, you must create an appropriate OrgNode value of data type hierarchyid. The following code creates a variable of data type hierarchyid and populates it with the root OrgNode value of the table. Then uses that variable with the GetDescendant() method to insert row that is a subordinate node. GetDescendant takes two arguments. Review the following options for the argument values:

--If parent is NULL, GetDescendant returns NULL.

--If parent is not NULL, and both child1 and child2 are NULL, GetDescendant returns a child of parent.

--If parent and child1 are not NULL, and child2 is NULL, GetDescendant returns a child of parent greater than child1.

--If parent and child2 are not NULL and child1 is NULL, GetDescendant returns a child of parent less than child2.

--If parent, child1, and child2 are all not NULL, GetDescendant returns a child of parent greater than child1 and less than child2.

--The following code uses the (NULL, NULL) arguments of the root parent because there are not yet any rows in the table except the root. Execute the following code to insert Sariya:


DECLARE @Manager hierarchyid 
SELECT @Manager = hierarchyid::GetRoot()
FROM EmployeeOrg ;

INSERT EmployeeOrg (OrgNode, EmployeeID, EmpName, Title)
VALUES
(@Manager.GetDescendant(NULL, NULL), 46, 'Sariya', 'Marketing Specialist') ; 
SELECT OrgNode.ToString() AS Text_OrgNode, 
OrgNode, OrgLevel, EmployeeID, EmpName, Title 
FROM EmployeeOrg ;

--Querying

DECLARE @CurrentEmployee hierarchyid

SELECT @CurrentEmployee = OrgNode
FROM EmployeeOrg
WHERE EmployeeID = 46 ;

SELECT *
FROM EmployeeOrg
WHERE OrgNode.IsDescendantOf(@CurrentEmployee ) = 1 ;

--GetAncestor
DECLARE @CurrentEmployee hierarchyid

SELECT @CurrentEmployee = OrgNode
FROM EmployeeOrg
WHERE EmployeeID = 6 ;

SELECT OrgNode.ToString() AS Text_OrgNode, *
FROM EmployeeOrg
WHERE OrgNode.GetAncestor(1) = @CurrentEmployee


--Use the GetLevel method to find how many levels down each row is in the hierarchy. 
SELECT OrgNode.ToString() AS Text_OrgNode, 
OrgNode.GetLevel() AS EmpLevel, *
FROM EmployeeOrg ;
GO

--Use the GetRoot method to find the root node in the hierarchy.

SELECT OrgNode.ToString() AS Text_OrgNode, *
FROM EmployeeOrg
WHERE OrgNode = hierarchyid::GetRoot() ;
GO
