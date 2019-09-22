--Create an alias Data Type
--Creating an alias type based on the varchar data type
CREATE TYPE SSN
FROM varchar(11) NOT NULL ;

--Drop alias Data Type
DROP TYPE ssn ;

CREATE TYPE CountryCode 
FROM char(2) NULL
 
 