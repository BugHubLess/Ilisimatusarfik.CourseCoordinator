CREATE PROCEDURE [dbo].[SPUpdateOrAddStatusTranslation]
	@statusId int,
	@languageId int,
	@name nvarchar
AS
BEGIN TRANSACTION
BEGIN TRY
	UPDATE StatusTranslations
	SET Name = @name
	WHERE StatusID = @statusId AND LanguageID = @languageId

	IF @@ROWCOUNT = 0
	INSERT INTO StatusTranslations (StatusID, LanguageID, Name)
	VALUES (@statusId, @languageId, @name)
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN 0
