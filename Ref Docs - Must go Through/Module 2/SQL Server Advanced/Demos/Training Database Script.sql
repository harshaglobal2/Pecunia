

Use Training 
create table Desig_master(
Design_Code numeric(3) Primary Key,
Design_Name Varchar(30) unique);



insert into desig_master values(101,'HOD');
insert into desig_master values(102,'Professor');
insert into desig_master values(103,'Reader');
insert into desig_master values(104,'Sr. Lecturer');
insert into desig_master values(105,'Lecturer');
insert into desig_master values(106,'Director');



Create Table Department_master(
Dept_code numeric(2) Primary Key,
Dept_Name varchar(30) unique);




insert into department_master values(10,'Computer Science');
insert into department_master values(20,'Electricals');
insert into department_master values(30,'Electronics');
insert into department_master values(40,'Mechanics');
insert into department_master values(50,'Robotics');


Create Table Student_master(
Stud_Code numeric(6) primary key,
Stud_Name varchar(30) not null,
Dept_Code numeric(2) references department_master(dept_code),
Stud_Dob datetime,
Address varchar(30));


insert into Student_master values(1001,'Amit',10,'11-Jan-80','chennai');
insert into Student_master values(1002,'Ravi',10,'1-Nov-81','New Delhi');
insert into Student_master values(1003,'Ajay',20,'13-Jan-82',null);
insert into Student_master values(1004,'Raj',30,'14-Jan-79','Mumbai');
insert into Student_master values(1005,'Arvind',40,'15-Jan-83','Bangalore');
insert into Student_master values(1006,'Rahul',50,'16-Jan-81','Delhi');
insert into Student_master values(1007,'Mehul',20,'17-Jan-82',	null);
insert into Student_master values(1008,'Dev',10,'11-Mar-81',	null);
insert into Student_master values(1009,'Vijay',30,'19-Jan-80',	null);
insert into Student_master values(1010,'Rajat',40,'20-Jan-80','Bangalore');
insert into Student_master values(1011,'Sunder',50,'21-Jan-80',	null);
insert into Student_master values(1012,'Rajesh', 30,'22-Jan-80',null);
insert into Student_master values(1013,'Anil',	20,'23-Jan-80',	'Chennai');
insert into Student_master values(1014,'Sunil',	10,'15-Feb-85',	null);
insert into Student_master values(1015,'Kapil',	40,'18-Mar-81',	null);
insert into Student_master values(1016,'Ashok',	40,'26-Nov-80',	null);
insert into Student_master values(1017,'Ramesh',30,'27-Dec-80',	null);
insert into Student_master values(1018,'Amit Raj',50,'28-Sep-80','New Delhi');
insert into Student_master values(1019,'Ravi Raj',50,'29-May-81','New Delhi');
insert into Student_master values(1020,'Amrit',	10,'11-Nov-80',	null);
insert into Student_master values(1021,'Sumit',	20,'1-Jan-80','Chennai');




Create table Student_Marks(
Stud_Code numeric(6) references student_master(Stud_code),
Stud_Year int  not null,
Subject1 numeric(3),
Subject2 numeric(3),
Subject3 numeric(3));



insert into Student_marks values(1001,	2007,	55,	45,78);
insert into Student_marks values(1002,	2007,	66,	74,88);
insert into Student_marks values(1003,	2007,	87,	54,65);
insert into Student_marks values(1004,	2007,	65,	64,90);
insert into Student_marks values(1005,	2007,	78,	88,65);
insert into Student_marks values(1006,	2007,	65,	86,54);
insert into Student_marks values(1007,	2007,	67,	79,49);
insert into Student_marks values(1008,	2007,	72,	55,55);
insert into Student_marks values(1009,	2007,	71,	59,58);
insert into Student_marks values(1010,	2007,	68,	44,92);
insert into Student_marks values(1011,	2007,	89,	96,78);
insert into Student_marks values(1012,	2007,	78,	56,55);
insert into Student_marks values(1013,	2007,	75,	58,65);
insert into Student_marks values(1014,	2007,	73,	74,65);
insert into Student_marks values(1015,	2007,	66,	45,74);
insert into Student_marks values(1016,	2007,	68,	78,74);
insert into Student_marks values(1017,	2007,	69,	44,52);
insert into Student_marks values(1018,	2007,	null,	78,56);
insert into Student_marks values(1019,	2007,	78,	58,74);
insert into Student_marks values(1020,	2007,	45,	null,65);
insert into Student_marks values(1021,	2007,	null,	79,78);


Create Table Staff_Master(
Staff_Code numeric(8) primary key,
Staff_Name varchar(30) not null,
Des_Code numeric(3) references desig_Master(Design_Code),
Dept_Code numeric(2) references department_master(dept_code),
Staff_dob datetime,
Hiredate  datetime,
Mgr_code numeric(8),
Salary numeric(10,2),
Address varchar(20));



insert into Staff_master values(100001,'Arvind',102,10,'15-Jan-80','15-Jan-03',100006,2000,'chennai');
insert into Staff_master values(100002,'Shyam',102,20,'18-Feb-80','17-Feb-02',100007,12000,'chennai');
insert into Staff_master values(100003,'Mohan',102,10,'23-Mar-80','19-Jan-02',100006,12000,'chennai');
insert into Staff_master values(100004,'Anil',102,20,'22-Apr-77','11-Mar-01',100006,12000,'chennai');
insert into Staff_master values(100005,'John',106,10,'22-May-76','21-Jan-01',100007,32000,'chennai');
insert into Staff_master values(100006,'Allen',103,10,'22-Jan-80','23-Apr-01',100005,42000,'chennai');
insert into Staff_master values(100007,'Smith',103,20,'19-Jul-73','12-Mar-02',100005,62000,'chennai');
insert into Staff_master values(100008,'Ravi raj',102,10,'17-Jun-80','11-Jan-03',100006,12000,'chennai');
insert into Staff_master values(100009,'Rahul',102,10,'16-Jan-78','11-Dec-03',100006,22000,'chennai');
insert into Staff_master values(100010,'Ram',103,10,'17-Jan-79','17-Jan-02',100007,32000,'chennai');



Create Table Book_Master(
Book_code numeric(10) primary key,
Book_name varchar(30) not null,
pub_year int,
Author varchar(30) not null,
book_category  varchar(10) );


select * from book_Master
insert into Book_Master values(10000001,'Let Us C++',2000,'Y.P Karnitkar','Comp Sc');

insert into Book_Master values(10000002,'Mastering VC++',2005,'P.J Allen','Comp Sc');

insert into Book_Master values(10000003,'JAVA Complet Reference',2004,'H. Schild','Comp Sc');

insert into Book_Master values(10000004,'J2EE Complet Reference',2000,'H. Schild','Comp Sc');

insert into Book_Master values(10000005,'Relational DBMS',2000,'B. C Desai','Comp Sc');

insert into Book_Master values(10000006,'Let Us C',2000,'Y.P Karnitkar','Comp Sc');

insert into Book_Master values(10000007,'Intoduction To Algorithams',2001,'Cormen','Comp Sc');

insert into Book_Master values(10000008,'Computer Networks',2000,'Millan','Tanenbaum');

insert into Book_Master values(10000009,'Introduction to O/S',2001,'Millan','Comp Sc');


Create Table Book_Transaction(
Book_code numeric(10) references Book_master(Book_code),
Stud_code numeric(6) references student_master(stud_code),
Staff_code numeric(8) references staff_master(staff_code),
Issue_date  datetime not null,
Exp_Return_date  datetime not null,
Actual_Return_date  datetime);

insert into book_transaction values (10000001,1012,NULL, '2009-07-02', '2009-07-09',NULL)

insert into book_transaction values (10000002,1010,NULL, '2009-07-01', '2009-07-08',NULL)

insert into book_transaction values (10000005,1009,NULL, '2009-06-30', '2009-07-06',NULL)

insert into book_transaction values (10000006,1012,NULL, '2009-06-13', '2009-06-20',NULL)

insert into book_transaction values (10000004,NULL,100001,'2009-07-02','2009-07-09',NULL)


insert into book_transaction values (10000003,NULL,100004,'2009-05-14','2009-05-21',NULL)


insert into book_transaction values (10000007,NULL,100005,'2009-05-21','2009-05-28',NULL)



insert into book_transaction values (10000008,NULL,100006,'2009-05-21','2009-05-28','2009-05-28')

insert into book_transaction values (10000009,1008,NULL, '2009-06-30', '2009-07-06','2009-07-09')




 
