CREATE PROCEDURE [dbo].[SPDeleteStudyProgram]
	@studyId int
AS
	DECLARE @ROWS INT;
	DELETE FROM StudyPrograms
	WHERE StudyProgramID = @studyId
	SET @ROWS = @@ROWCOUNT;
RETURN @ROWS
