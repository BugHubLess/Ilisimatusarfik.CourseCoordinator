CREATE PROCEDURE [dbo].[SPDeleteLanguage]
	@languageId int
AS
	DELETE FROM Languages
	WHERE LanguageID = @languageId
RETURN 0
