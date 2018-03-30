CREATE PROCEDURE [dbo].[SPUpdateOrAddStatusTranslation]
	@statusId INT,
	@culture NVARCHAR(MAX),
	@name NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	UPDATE ST
	SET Name = @name
	FROM StatusTranslations ST
	INNER JOIN Languages L
	ON ST.LanguageID = L.LanguageID
	WHERE ST.StatusID = @statusId AND L.Culture = @culture

	IF @@ROWCOUNT = 0
	INSERT INTO StatusTranslations (StatusID, LanguageID, Name)
	SELECT @statusId, LanguageID, @name FROM Languages WHERE Culture = @culture
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @@ROWCOUNT  -- returns the number of rows affected
