CREATE TABLE tbl_Employee 
( 
	Employee_Name varchar(25), 
      	Region varchar(50), 
      	Department varchar(40), 
      	sal int 
)
INSERT into tbl_Employee( 
                              Employee_Name, 
                              Region, 
                              Department, 
                              sal 
                        ) 

VALUES 
('Shujaat', 'North America', 'Information Technology', 9999), 
('Andrew', 'Asia Pacific', 'Information Technology',  5555), 
('Maria', 'North America', 'Human Resources', 4444), 
('Stephen', 'Middle East & Africa', 'Information Technology', 8888), 
('Stephen', 'Middle East & Africa', 'Human Resources', 8888)


SELECT Region, Department, avg(sal) Average_Salary 
from tbl_Employee 
Group BY 
      GROUPING SETS 
      ( 
            (Region, Department), 
            (Region), 
            (Department) , 
            ()          
      )

/*
SELECT Region, Department, avg(sal) Average_Salary 
from tbl_Employee 
Group BY 
Region, Department 
UNION 
SELECT Region, NULL, avg(sal) Average_Salary 
from tbl_Employee 
Group BY Region 
UNION 
SELECT NULL, Department, avg(sal) Average_Salary 
from tbl_Employee 
Group BY Department 
UNION 
SELECT NULL, NULL, avg(sal) Average_Salary 
from tbl_Employee*/

--CUBE subclause for grouping
--This is used to return the power n to 2 for n elements.

SELECT Region, Department, avg(sal) Average_Salary 
from tbl_Employee 
Group BY 
      CUBE (Region, Department)


--ROLLUP subclause for grouping
--This is used to return n+1 grouping sets for n elements in a hierarchy scenario.

SELECT Region, Department, avg(sal) Average_Salary 
from tbl_Employee 
Group BY 
      ROLLUP (Region, Department)
