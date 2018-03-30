CREATE PROCEDURE [dbo].[SPUpdateOrAddStatusTranslation]
	@statusId INT,
	@locale NVARCHAR(50),
	@name NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ROWS INT;
	UPDATE ST
	SET Name = @name
	FROM StatusTranslations ST
	INNER JOIN Languages L
	ON ST.LanguageID = L.LanguageID
	WHERE ST.StatusID = @statusId AND L.Locale = @locale

	SET @ROWS = @@ROWCOUNT;

	IF @ROWS = 0
	BEGIN
		INSERT INTO StatusTranslations (StatusID, LanguageID, Name)
		SELECT @statusId, LanguageID, @name FROM Languages WHERE Locale = @locale
		SET @ROWS = @@ROWCOUNT;
	END

COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ROWS  -- returns the number of rows affected
