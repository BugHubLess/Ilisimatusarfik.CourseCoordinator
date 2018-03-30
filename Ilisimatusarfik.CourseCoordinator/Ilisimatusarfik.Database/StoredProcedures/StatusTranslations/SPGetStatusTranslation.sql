CREATE PROCEDURE [dbo].[SPGetStatusTranslation]
	@statusId int,
	@languageId int
AS
	SELECT StatusID, Name
	FROM StatusTranslations
	WHERE StatusID = @statusId AND LanguageID = @languageId
RETURN 0
