CREATE TABLE dbo.mytable 
( 
	low 	int,
	high 	int,
	myavg 	AS 	(low + high)/2 
) ;

CREATE TABLE dbo.mylogintable
(
	date_in 		datetime,
	user_id 		int, 
	myuser_name 	AS 	USER_NAME()
) ;

--Sparse columns are ordinary columns that have an optimized storage for null values. 
--Sparse columns reduce the space requirements for null values at the cost of more overhead to retrieve nonnull values
CREATE TABLE dbo.T1
(
	c1	int 		PRIMARY KEY,
    	c2	varchar(50) 	SPARSE 		NULL 
) ;

CREATE TABLE new_employees
(
 	id_num 	int 		IDENTITY(1,1),
 	fname 	varchar (20),
 	minit 	char(1),
 	lname 	varchar(30)
);

INSERT new_employees 
	(fname, minit, lname)
VALUES
	('Karin', 'F', 'Josephs');

INSERT new_employees
	(fname, minit, lname)
VALUES
	('Pirkko', 'O', 'Koskitalo');

