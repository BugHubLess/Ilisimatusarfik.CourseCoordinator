/**
	Assigns a course to a study program in a semester
*/
CREATE PROCEDURE [dbo].[SPAssignOrUpdateCourseToStudyProgramSemester]
	@courseId INT,
	@studyProgramId INT,
	@semester INT
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ROWS INT;

	UPDATE StudyProgramCourses
	SET StudyProgramID = @studyProgramId,
	CourseID = @courseId,
	Semester = @semester

	WHERE StudyProgramID = @studyProgramId
	AND CourseID = @courseId

	SET @ROWS = @@ROWCOUNT

	IF @ROWS = 0
	BEGIN
		INSERT INTO StudyProgramCourses (StudyProgramID, CourseID, Semester)
		VALUES (@studyProgramId, @courseId, @semester)
		SET @ROWS = @@ROWCOUNT;
	END
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ROWS  -- returns the number of rows affected
