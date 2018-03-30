CREATE PROCEDURE [dbo].[SPEditLanguage]
	@languageId int,
	@locale NVARCHAR(50),
	@displayName NVARCHAR(50)
AS
	DECLARE @ROWS INT;
	UPDATE Languages
	SET Locale = @locale, DisplayName = @displayName
	WHERE LanguageID = @languageId
	SET @ROWS = @@ROWCOUNT;
RETURN @ROWS