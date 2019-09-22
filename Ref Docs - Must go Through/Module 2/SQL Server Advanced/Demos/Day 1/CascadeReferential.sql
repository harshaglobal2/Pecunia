CREATE TABLE EmpMaster
(
	EmpId INT PRIMARY KEY,
	EmpName VARCHAR(25)
); 

CREATE TABLE EmpDetails
(
	EmpId INT FOREIGN KEY REFERENCES EmpMaster(EmpId) 
	ON DELETE CASCADE,
	DeptId INT  PRIMARY KEY,
	DeptName VARCHAR(20)
);

insert into EmpMaster(EmpId,EmpName) values(1,'Kim')
insert into EmpMaster(EmpId,EmpName) values(2,'Sam')
insert into  EmpMaster(EmpId,EmpName) values(3,'John')

insert into EmpDetails(EmpId ,DeptId ,DeptName ) values(1,101,'AAA')
insert into EmpDetails(EmpId ,DeptId ,DeptName ) values(2,101,'AAA')
insert into EmpDetails(EmpId ,DeptId ,DeptName ) values(3,103,'CCC')

delete from EmpMaster where EmpId=3

select * from EmpDetails where EmpId=3
