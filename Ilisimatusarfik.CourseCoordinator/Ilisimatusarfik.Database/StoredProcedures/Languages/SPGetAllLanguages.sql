CREATE PROCEDURE [dbo].[SPGetAllLanguages]
AS
	SELECT LanguageID, Locale, DisplayName
	FROM Languages
RETURN 0