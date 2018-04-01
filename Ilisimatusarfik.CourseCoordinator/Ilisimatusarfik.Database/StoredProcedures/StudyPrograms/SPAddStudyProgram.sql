﻿CREATE PROCEDURE [dbo].[SPAddStudyProgram]
	@locale NVARCHAR(50),
	@name NVARCHAR(MAX),
	@description NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ID INT;
	INSERT StudyPrograms DEFAULT VALUES
	SET @ID = SCOPE_IDENTITY();
	INSERT INTO StudyProgramsTranslations (StudyProgramID, LanguageID, Name, Description)
	SELECT @ID, LanguageID, @name, @description FROM Languages WHERE Locale = @locale
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ID
