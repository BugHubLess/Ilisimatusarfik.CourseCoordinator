CREATE PROCEDURE [dbo].[SPGetAllLanguages]
AS
	SELECT LanguageID, Culture, DisplayName
	FROM Languages
RETURN 0