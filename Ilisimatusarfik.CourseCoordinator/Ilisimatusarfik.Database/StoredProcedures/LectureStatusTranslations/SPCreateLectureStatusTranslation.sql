/**
 Creates a lecture status
 Precondition: locale must exist
*/
CREATE PROCEDURE [dbo].[SPCreateLectureStatusTranslation]
	@locale NVARCHAR(50),
	@status NVARCHAR(MAX)
AS
BEGIN TRANSACTION
	SET XACT_ABORT ON
	BEGIN
		BEGIN TRY
			DECLARE @ID INT

			IF EXISTS (SELECT * FROM Languages WHERE Locale = @locale)
			BEGIN
				INSERT LectureStatus DEFAULT VALUES -- This will set SCOPE_IDENTITY
				SET @ID = SCOPE_IDENTITY()

				INSERT INTO LectureStatusTranslations (LectureStatusID, LanguageID, Status)
				SELECT @ID, LanguageID, @status FROM Languages WHERE Locale = @locale
			END
			ELSE BEGIN
				SET @ID = 0
			END

			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END
RETURN @ID