﻿CREATE PROCEDURE [dbo].[SPCreateLectureStatusTranslation]
	@locale NVARCHAR(50),
	@status NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ID INT;
		INSERT LectureStatus DEFAULT VALUES -- This will set SCOPE_IDENTITY
		INSERT INTO LectureStatusTranslations (LectureStatusID, LanguageID, Status)
		SELECT @ID, LanguageID, @status FROM Languages WHERE Locale = @locale
		SET @ID = SCOPE_IDENTITY();
		COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ID
