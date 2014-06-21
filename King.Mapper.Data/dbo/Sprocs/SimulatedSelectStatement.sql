CREATE PROCEDURE [dbo].[SimulatedSelectStatement]
	@TestInt int = NULL
AS
BEGIN

	SELECT @TestInt AS 'Identifier'

END