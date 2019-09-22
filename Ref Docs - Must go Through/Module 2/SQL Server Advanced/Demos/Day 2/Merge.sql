CREATE TABLE StudentDetails1
(
	StudentID INTEGER PRIMARY KEY,
 	StudentName VARCHAR(15)
 )
 GO
 
INSERT INTO StudentDetails
 VALUES(1,'SMITH')
 INSERT INTO StudentDetails
 VALUES(2,'ALLEN')
 INSERT INTO StudentDetails
 VALUES(3,'JONES')
 INSERT INTO StudentDetails
 VALUES(4,'MARTIN')
 INSERT INTO StudentDetails
 VALUES(5,'JAMES')
 GO 

--StudentTotalMarks:
CREATE TABLE StudentTotalMarks1
 (
 	StudentID INTEGER REFERENCES StudentDetails,
 	StudentMarks INTEGER
 )
 GO
 
INSERT INTO StudentTotalMarks
 VALUES(1,230)
 INSERT INTO StudentTotalMarks
 VALUES(2,255)
 INSERT INTO StudentTotalMarks
 VALUES(3,200)
 GO 

--In our example we will consider three main conditions while we merge this two tables.
-- 1.Delete the records whose marks are more than 250.
 --2.Update marks and add 25 to each as internals if records exist.
 --3.Insert the records if record does not exists.

MERGE StudentTotalMarks AS stm
 USING (SELECT StudentID,StudentName FROM StudentDetails) AS sd
 ON stm.StudentID = sd.StudentID
 WHEN MATCHED AND stm.StudentMarks > 250 THEN DELETE
 WHEN MATCHED THEN UPDATE SET stm.StudentMarks = stm.StudentMarks + 25
 WHEN NOT MATCHED THEN
 INSERT(StudentID,StudentMarks)
 VALUES(sd.StudentID,25);
 GO 
 
 --There are two very important points to remember while using MERGE statement.
-- Semicolon is mandatory after the merge statement.
 --When there is a MATCH clause used along with some condition, it has to be specified first amongst all other WHEN MATCH clause.

select * from StudentTotalMarks order by StudentID 