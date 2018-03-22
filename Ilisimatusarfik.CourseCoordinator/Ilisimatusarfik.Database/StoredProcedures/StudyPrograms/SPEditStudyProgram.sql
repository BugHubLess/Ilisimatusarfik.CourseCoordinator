CREATE PROCEDURE [dbo].[SPEditStudyProgram]
	@studyId int,
	@languageId int,
	@name nvarchar,
	@description nvarchar
AS
BEGIN TRANSACTION
BEGIN TRY
	UPDATE StudyProgramsTranslations
	SET LanguageID = @languageId, Name = @name, Description = @description
	WHERE StudyProgramID = @studyId
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN 0
