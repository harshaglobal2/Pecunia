/*The first example creates a table with an identity column and a geometry column GeomCol1. A third column renders the geometry column into its Open Geospatial Consortium (OGC) Well-Known Text (WKT) representation, and uses the STAsText() method. Two rows are then inserted: one row contains a LineString instance of geometry, and one row contains a Polygon instance.*/

CREATE TABLE SpatialTable 
( 
	id 		int 	IDENTITY (1,1),
    	GeomCol1 	geometry, 
    	GeomCol2 	AS 	GeomCol1.STAsText() 
);
GO

INSERT INTO SpatialTable (GeomCol1)
VALUES (geometry::STGeomFromText('LINESTRING (100 100, 20 180, 180 180)', 0));

INSERT INTO SpatialTable (GeomCol1)
VALUES (geometry::STGeomFromText('POLYGON ((0 0, 150 0, 150 150, 0 150, 0 0))', 0));
GO


DECLARE @geom1 geometry;
DECLARE @geom2 geometry;
DECLARE @result geometry;

SELECT @geom1 = GeomCol1 FROM SpatialTable WHERE id = 1;
SELECT @geom2 = GeomCol1 FROM SpatialTable WHERE id = 2;
SELECT @result = @geom1.STIntersection(@geom2);
SELECT @result.STAsText();


--geography

CREATE TABLE SpatialTable 
( 
	id 	int 	IDENTITY (1,1),
    	GeogCol1 	geography, 
    	GeogCol2 	AS 	GeogCol1.STAsText() 
);
GO

INSERT INTO SpatialTable (GeogCol1)
VALUES (geography::STGeomFromText('LINESTRING(-122.360 47.656, -122.343 47.656)', 4326));

INSERT INTO SpatialTable (GeogCol1)
VALUES (geography::STGeomFromText('POLYGON((-122.358 47.653, -122.348 47.649, -122.348 47.658, -122.358 47.658, -122.358 47.653))', 4326));
GO


DECLARE @geog1 geography;
DECLARE @geog2 geography;
DECLARE @result geography;

SELECT @geog1 = GeogCol1 FROM SpatialTable WHERE id = 1;
SELECT @geog2 = GeogCol1 FROM SpatialTable WHERE id = 2;
SELECT @result = @geog1.STIntersection(@geog2);
SELECT @result.STAsText();





USE AdventureWorks ;
GO
CREATE TABLE HumanResources.EmployeeOrg
(
   	OrgNode 		hierarchyid 	PRIMARY KEY CLUSTERED,
   	OrgLevel 		AS 		OrgNode.GetLevel(),
   	EmployeeID 	int 		UNIQUE NOT NULL,
   	EmpName 		varchar(20) 	NOT NULL,
   	Title 		varchar(20) 	NULL
) ;
GO

