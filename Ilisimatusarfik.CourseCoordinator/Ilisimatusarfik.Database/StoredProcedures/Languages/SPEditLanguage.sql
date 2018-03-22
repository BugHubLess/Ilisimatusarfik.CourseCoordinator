CREATE PROCEDURE [dbo].[SPEditLanguage]
	@languageId int,
	@culture nvarchar,
	@displayName nvarchar
AS
	UPDATE Languages
	SET Culture = @culture, DisplayName = @displayName
	WHERE LanguageID = @languageId
RETURN 0
