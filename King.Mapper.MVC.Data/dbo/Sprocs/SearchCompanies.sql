CREATE PROCEDURE [dbo].[SearchCompanies]
	@NameLike nvarchar(50) = NULL
AS
BEGIN

	SELECT  Id
		, Name
	FROM [dbo].[Company] WITH(NOLOCK)
	WHERE Name LIKE '%' + @NameLike + '%'
		AND DeletedOn IS NULL;
END