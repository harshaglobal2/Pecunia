CREATE TABLE test_defaults
(
	keycol	smallint,
   	process_id smallint 	DEFAULT @@SPID,   --Preferred default definition
   	date_ins   	datetime 	DEFAULT getdate(),   --Preferred default definition
   	mathcol      smallint 	DEFAULT 10 * 2,   --Preferred default definition
   	char1      	char(3),
   	char2      	char(3) 	DEFAULT 'xyz' --Preferred default definition
)
GO

/* Illustration only, use DEFAULT definitions instead.*/
CREATE DEFAULT abc_const AS 'abc'
GO

sp_bindefault abc_const, 'test_defaults.char1'
GO

INSERT INTO test_defaults(keycol) VALUES (1)
GO

SELECT * FROM test_defaults
GO

--Rule
CREATE RULE id_chk AS @id BETWEEN 0 and 10000
GO

CREATE TABLE cust_sample
(
   	cust_id		int	PRIMARY KEY,
   	cust_name		char(50),
   	cust_address	char(50),
   	cust_credit_limit   	money
)
GO

sp_bindrule id_chk, 'cust_sample.cust_id'
GO
