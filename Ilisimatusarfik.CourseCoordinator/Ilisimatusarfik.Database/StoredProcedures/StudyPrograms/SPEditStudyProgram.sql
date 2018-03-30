CREATE PROCEDURE [dbo].[SPEditStudyProgram]
	@studyId int,
	@languageId int,
	@name NVARCHAR(MAX),
	@description NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ROWS INT;
	UPDATE StudyProgramsTranslations
	SET LanguageID = @languageId, Name = @name, Description = @description
	WHERE StudyProgramID = @studyId
	SET @ROWS = @@ROWCOUNT;
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ROWS;
