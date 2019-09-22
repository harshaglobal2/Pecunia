CREATE TABLE doc_exc ( column_a INT) 
GO

ALTER TABLE doc_exc
ADD column_b VARCHAR(20) NULL 
CONSTRAINT exb_unique UNIQUE
GO

EXEC sp_help doc_exc
GO

DROP TABLE doc_exc
GO

CREATE TABLE doc_exd ( column_a INT) 
GO

INSERT INTO doc_exd VALUES (-1)
GO

ALTER TABLE doc_exd WITH NOCHECK 
ADD CONSTRAINT exd_check CHECK (column_a > 1)
GO

EXEC sp_help doc_exd
GO

DROP TABLE doc_exd
GO


CREATE TABLE doc_exe ( column_a INT CONSTRAINT column_a_un UNIQUE) 
GO

ALTER TABLE doc_exe ADD 
/* Add a PRIMARY KEY identity column. */ 
column_b INT IDENTITY
CONSTRAINT column_b_pk PRIMARY KEY, 
/* Add a column referencing another column in the same table. */ 
column_c INT NULL  
CONSTRAINT column_c_fk 
REFERENCES doc_exe(column_a),
/* Add a column with a constraint to enforce that   */ 
/* nonnull data is in a valid phone number format.  */
column_d VARCHAR(16) NULL 
CONSTRAINT column_d_chk
CHECK 
(column_d IS NULL OR 
column_d LIKE "[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]" OR
column_d LIKE
"([0-9][0-9][0-9]) [0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]"),



CREATE TABLE cnst_example 
(
	id INT NOT NULL,
	name VARCHAR(10) NOT NULL,
 	salary MONEY NOT NULL
    	CONSTRAINT salary_cap CHECK (salary < 100000)
)

-- Valid inserts
INSERT INTO cnst_example VALUES (1,'Joe Brown',65000)
INSERT INTO cnst_example VALUES (2,'Mary Smith',75000)

-- This insert violates the constraint.
INSERT INTO cnst_example VALUES (3,'Pat Jones',105000)

-- Disable the constraint and try again.
ALTER TABLE cnst_example NOCHECK CONSTRAINT salary_cap

INSERT INTO cnst_example VALUES (3,'Pat Jones',105000)

-- Reenable the constraint and try another insert, will fail.
ALTER TABLE cnst_example CHECK CONSTRAINT salary_cap

INSERT INTO cnst_example VALUES (4,'Eric James',110000)
