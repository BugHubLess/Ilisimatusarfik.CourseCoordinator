/**
 Adds a study program to the database
 Precondition: locale must exist
*/
CREATE PROCEDURE [dbo].[SPAddStudyProgram]
	@locale NVARCHAR(50),
	@name NVARCHAR(MAX),
	@description NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ID INT;
	IF EXISTS (SELECT * FROM Languages WHERE Locale = @locale)
	BEGIN
		INSERT StudyPrograms DEFAULT VALUES
		SET @ID = CAST(SCOPE_IDENTITY() AS INT);
		INSERT INTO StudyProgramsTranslations (StudyProgramID, LanguageID, Name, Description)
		SELECT @ID, LanguageID, @name, @description FROM Languages WHERE Locale = @locale
	END
	ELSE BEGIN
		SET @ID = 0
	END
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ID
