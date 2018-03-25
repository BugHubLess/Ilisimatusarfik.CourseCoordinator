CREATE PROCEDURE [dbo].[SPGetLanguage]
	@culture nvarchar(50)
AS
	SELECT LanguageID, Culture, DisplayName
	FROM Languages
	WHERE Culture = @culture
RETURN 0
