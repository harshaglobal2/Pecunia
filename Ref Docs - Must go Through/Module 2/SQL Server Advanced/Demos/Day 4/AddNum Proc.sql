CREATE PROC addnum
 @FirstNumber int = 5,
   @SecondNumber int,
 @Answer varchar(30) OUTPUT as

   Declare @sum int
   Set @sum = @FirstNumber + @SecondNumber
   Set @Answer = 'The answer is ' + convert(varchar,@sum)
   Return @sum