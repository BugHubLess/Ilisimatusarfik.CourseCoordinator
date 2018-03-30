CREATE PROCEDURE [dbo].[SPEditLanguage]
	@languageId int,
	@culture NVARCHAR(50),
	@displayName NVARCHAR(50)
AS
	UPDATE Languages
	SET Culture = @culture, DisplayName = @displayName
	WHERE LanguageID = @languageId
RETURN 0