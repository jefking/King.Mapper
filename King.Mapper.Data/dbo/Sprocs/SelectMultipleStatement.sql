CREATE PROCEDURE [dbo].[SelectMultipleStatement]
AS
BEGIN

		SELECT 0 AS 'Identifier'
	UNION
		SELECT 1 AS 'Identifier'
	UNION
		SELECT 2 AS 'Identifier'
	UNION
		SELECT 3 AS 'Identifier'
	UNION
		SELECT 4 AS 'Identifier'
	UNION
		SELECT 5 AS 'Identifier'

END