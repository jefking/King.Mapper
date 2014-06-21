CREATE PROCEDURE [dbo].[SimulatedInsertStatement]
	@TestInt int = NULL
AS
BEGIN

	CREATE TABLE #Simulation
	(
		primaryKey INT NOT NULL,
	)

	INSERT INTO #Simulation
	(
		primaryKey
	)
	VALUES
	(
		@TestInt
	)

END