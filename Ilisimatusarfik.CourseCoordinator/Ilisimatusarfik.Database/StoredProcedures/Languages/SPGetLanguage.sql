CREATE PROCEDURE [dbo].[SPGetLanguage]
	@locale nvarchar(50)
AS
	SELECT LanguageID, Locale, DisplayName
	FROM Languages
	WHERE Locale = @locale
RETURN 0
