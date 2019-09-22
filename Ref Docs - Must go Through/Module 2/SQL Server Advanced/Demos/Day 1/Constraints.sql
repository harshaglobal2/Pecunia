/* ************************** jobs table ************************** */
CREATE TABLE jobs
(
   	job_id  	smallint		IDENTITY(1,1)	PRIMARY KEY CLUSTERED,
   	job_desc    	varchar(50)     	NOT NULL	DEFAULT 'New Position - title not formalized yet',
   	min_lvl 	tinyint 		NOT NULL	CHECK (min_lvl >= 10),
   	max_lvl 	tinyint 		NOT NULL	CHECK (max_lvl <= 250)
)

/* ************************* employee table ************************* */
CREATE TABLE employee 
(
   	emp_id  	int
      		CONSTRAINT PK_emp_id PRIMARY KEY NONCLUSTERED
      		CONSTRAINT CK_emp_id CHECK (emp_id LIKE 
         			'[A-Z][A-Z][A-Z][1-9][0-9][0-9][0-9][0-9][FM]' or
         			emp_id LIKE '[A-Z]-[A-Z][1-9][0-9][0-9][0-9][0-9][FM]'),
      		/* Each employee ID consists of three characters that 
      		represent the employee's initials, followed by a five 
      		digit number ranging from 10000 through 99999 and then the 
      		employee's gender (M or F). A (hyphen) - is acceptable 
      		for the middle initial. */
   	fname   	varchar(20)	NOT NULL,
   	minit   	char(1) 		NULL,
   	lname   	varchar(30)     	NOT NULL,
   	job_id  	smallint        	NOT NULL	DEFAULT 1
      	/* Entry job_id for new hires. */
      	REFERENCES jobs(job_id),
   	job_lvl 	tinyint		DEFAULT 10,
      	/* Entry job_lvl for new hires. */
   	pub_id  	char(4) 		NOT NULL	DEFAULT ('9952')
      	REFERENCES publishers(pub_id),
      	/* By default, the Parent Company Publisher is the company
      	to whom each employee reports. */
   	hire_date	datetime		NOT NULL	DEFAULT (getdate())
      	/* By default, the current system date is entered. */
)

/* ***************** publishers table ******************** */
CREATE TABLE publishers
(
   	pub_id	char(4)		NOT NULL 
         		CONSTRAINT UPKCL_pubind PRIMARY KEY CLUSTERED
         		CHECK (pub_id IN ('1389', '0736', '0877', '1622', '1756')
            			OR pub_id LIKE '99[0-9][0-9]'),
   	pub_name	varchar(40)	NULL,
   	city         	varchar(20)     	NULL,
   	state      	char(2) 		NULL,
   	country      	varchar(30)     	NULL	DEFAULT('USA')
)

--------------------------------------------
--Primary Key as column constraint

create table client_master
(
	client_no 	varchar(6) 	Primary Key,
	address2 	varchar(30),
	bal_due 	int
);

--Primary Key as table constraint
create table client_master1 
(
	client_no 	varchar(6),
	address2 	varchar(30),
	bal_due 	int, 
	Primary Key(client_no)
);

--Unique at column level
create table UniqueConst
(
	Name 	nvarchar(100) 	NOT NULL	UNIQUE 
)

CREATE TABLE Persons
(
	P_Id 	int 		NOT NULL 	PRIMARY KEY,
	LastName 	varchar(255) 	NOT NULL,
	FirstName varchar(255),
	Address 	varchar(255),
 	City 	varchar(255)
)
 
CREATE TABLE Orders
(
	O_Id 	int 		NOT NULL 	PRIMARY KEY,
 	OrderNo 	int 		NOT NULL,
 	P_Id 	int 		FOREIGN KEY REFERENCES Persons(P_Id)
 )
 
--or

ALTER TABLE Orders
ADD FOREIGN KEY (P_Id)
REFERENCES Persons(P_Id)
 
ALTER TABLE Orders
ADD CONSTRAINT fk_PerOrders
FOREIGN KEY (P_Id)
REFERENCES Persons(P_Id)