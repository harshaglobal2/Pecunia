use AdventureWorks
CREATE TABLE dbo.Resumes
(
  	CandidateID 	INT 	IDENTITY PRIMARY KEY,
   	CandidateResume	XML
);
 
INSERT INTO Resumes (CandidateResume)
 
SELECT Resume
 
FROM HumanResources.JobCandidate;
  
SELECT * FROM Resumes where CandidateID=1;

DECLARE @resume XML;
SELECT @resume = CandidateResume
FROM dbo.Resumes
WHERE CandidateID = 1;

 
SELECT @resume AS Resume; 

