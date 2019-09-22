CREATE VIEW authors_CA AS
    ( 
        SELECT * FROM Authors WHERE state='CA'
    )

/*(If you now issue the following command: 
UPDATE authors_CA SET state='NJ'
then all the records visible in the view are updated with a differente State value, and therefore would disappear from the view itself.
This is perfectly legal, but can create subtle programming errors. You can avoid this problem by adding the WITH CHECK OPTION predicate when you create the view: */

CREATE VIEW authors_CA AS
    ( 
        SELECT * FROM Authors WHERE state='CA'
    )
    WITH CHECK OPTION

/*Now any insert or update operation that makes a record disappear from the view raises a trappable runtime error. */
