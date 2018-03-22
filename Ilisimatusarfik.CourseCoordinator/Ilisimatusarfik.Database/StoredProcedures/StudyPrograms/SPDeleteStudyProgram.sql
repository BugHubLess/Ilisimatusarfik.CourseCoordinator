CREATE PROCEDURE [dbo].[SPDeleteStudyProgram]
	@studyId int
AS
	DELETE FROM StudyPrograms
	WHERE StudyProgramID = @studyId
RETURN 0
