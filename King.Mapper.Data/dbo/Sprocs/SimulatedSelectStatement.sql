CREATE PROCEDURE [dbo].[SimulatedSelectStatement]
	@TestInt int = NULL
	, @TestBigInt bigint = NULL
	, @TestBit bit = NULL
	, @TestDecimal decimal(16,16) = NULL
	, @TestMoney money = NULL
	, @TestFloat float = NULL
	, @TestDate date = NULL
	, @TestDateTime2 datetime2 = NULL
	, @TestDateTime datetime = NULL
	, @TestChar char = NULL
	, @TestText text = NULL
	, @TestNChar nchar = NULL
	, @TestNText ntext = NULL
	, @TestBinary binary(64) = NULL
	, @TestImage image = NULL
	, @TestGuid uniqueidentifier = NULL
AS
BEGIN

	SELECT @TestInt AS 'Identifier'
		, @TestBigInt AS 'BigInt'
		, @TestBit AS 'Bit'
		, @TestDecimal AS 'Decimal'
		, @TestMoney AS 'Money'
		, @TestFloat AS 'Float'
		, @TestDate AS 'Date'
		, @TestDateTime2 AS 'DateTime2'
		, @TestDateTime AS 'DateTime'
		, @TestChar AS 'Char'
		, @TestText AS 'Text'
		, @TestNChar AS 'NChar'
		, @TestNText AS 'NText'
		, @TestBinary AS 'Binary'
		, @TestImage AS 'Image'
		, @TestGuid AS 'Unique'

END