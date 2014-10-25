CREATE PROCEDURE [dbo].[SaveCompany]
	@Id int = NULL,
	@Name nvarchar(50) = NULL,
	@Delete bit = 0
AS
BEGIN

	MERGE dbo.Company AS target
		USING
		(
			SELECT
				@Id
				, @Name
		) AS source (Id, Name)
		ON
		(
			target.Id = source.Id
		)
	WHEN MATCHED THEN 
		UPDATE SET
			Name = source.Name
			, LastModifiedOn = GETUTCDATE()
			, DeletedOn = CASE @Delete WHEN 1 THEN GETUTCDATE() ELSE NULL END
	WHEN NOT MATCHED THEN
		INSERT
		(
			Name
		)
		VALUES
		(
			source.Name
		);

END