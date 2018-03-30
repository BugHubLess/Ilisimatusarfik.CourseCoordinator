CREATE PROCEDURE [dbo].[SPGetStatusTranslations]
	@statusId int,
	@languageId int
AS
	SELECT StatusID, Name
	FROM StatusTranslations
	WHERE LanguageID = @languageId
RETURN 0
