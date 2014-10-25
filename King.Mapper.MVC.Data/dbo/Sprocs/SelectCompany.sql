CREATE PROCEDURE [dbo].[SelectCompany]
	@Id int = NULL
AS
BEGIN

	SELECT Id
		, Name
	FROM [dbo].[Company] WITH(NOLOCK)
	WHERE Id = @Id
		AND DeletedOn IS NULL;

END