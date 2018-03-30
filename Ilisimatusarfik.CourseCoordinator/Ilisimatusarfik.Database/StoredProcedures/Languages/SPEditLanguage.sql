CREATE PROCEDURE [dbo].[SPEditLanguage]
	@languageId int,
	@culture NVARCHAR(50),
	@displayName NVARCHAR(50)
AS
	DECLARE @ROWS INT;
	UPDATE Languages
	SET Culture = @culture, DisplayName = @displayName
	WHERE LanguageID = @languageId
	SET @ROWS = @@ROWCOUNT;
RETURN @ROWS