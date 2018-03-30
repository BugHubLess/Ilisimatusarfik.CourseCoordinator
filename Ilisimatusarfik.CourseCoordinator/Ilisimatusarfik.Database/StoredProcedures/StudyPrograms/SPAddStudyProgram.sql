CREATE PROCEDURE [dbo].[SPAddStudyProgram]
	@languageId int,
	@name nvarchar,
	@description nvarchar
AS
BEGIN TRANSACTION
BEGIN TRY
	INSERT StudyPrograms DEFAULT VALUES
	INSERT INTO StudyProgramsTranslations (StudyProgramID, LanguageID, Name, Description)
	VALUES (SCOPE_IDENTITY(), @languageId, @name, @description)
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN SCOPE_IDENTITY()
