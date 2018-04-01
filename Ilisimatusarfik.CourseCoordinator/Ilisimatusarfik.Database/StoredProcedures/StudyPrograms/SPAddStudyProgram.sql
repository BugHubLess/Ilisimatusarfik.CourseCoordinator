CREATE PROCEDURE [dbo].[SPAddStudyProgram]
	@languageId int,
	@name NVARCHAR(MAX),
	@description NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ID INT;
	INSERT StudyPrograms DEFAULT VALUES
	SET @ID = SCOPE_IDENTITY();
	INSERT INTO StudyProgramsTranslations (StudyProgramID, LanguageID, Name, Description)
	VALUES (@ID, @languageId, @name, @description)
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ID
