Declare @variant1 sql_variant, @variant2 sql_variant
Declare @variant3 sql_variant, @variant4 sql_variant
Declare @MyInt as integer, @MyDatetime as Datetime
Declare @MyMoney as Money, @MyBit as bit
Set @MyInt = 37
Set @MyDatetime = '11/8/12'
Set @MyMoney = $37.23
Set @MyBit = 1
Select 	@variant1 = @MyInt,
	@variant2 = @MyDatetime ,
	@variant3 = @MyMoney,
	@variant4 = @MyBit


Select 	@variant1 as [Int Variant],
	@variant2 as [Datetime Variant],
	@variant3 as [Money Variant],
	@variant4 as [Bit Variant]