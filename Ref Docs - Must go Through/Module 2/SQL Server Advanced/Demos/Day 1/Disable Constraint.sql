CREATE TABLE cnst_example 
(
	id INT NOT NULL,
    	name VARCHAR(10) NOT NULL,
    	salary MONEY NOT NULL
    	CONSTRAINT salary_cap CHECK (salary < 100000)
);

-- Disable the constraint.
ALTER TABLE cnst_example NOCHECK CONSTRAINT salary_cap;

-- Reenable the constraint.
ALTER TABLE cnst_example WITH CHECK CHECK CONSTRAINT salary_cap;
