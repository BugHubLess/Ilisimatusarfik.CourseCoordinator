/**
 Creates or updates a course and assigns it to a study program.
 Precondition: locale must exist
*/
CREATE PROCEDURE [dbo].[SPAddOrUpdateCourseToStudyProgram]
	@studyProgramId INT,
	@locale NVARCHAR(50),
	@courseId INT,
	@startDate DateTimeOffset(7),
	@endDate DateTimeOffset(7),
	@name NVARCHAR(MAX),
	@description NVARCHAR(MAX),
	@ects INT,
	@semester INT
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @RESULT INT;
	IF NOT EXISTS (SELECT CourseID FROM Courses WHERE Courses.CourseID = @courseId)
	BEGIN
		IF EXISTS (SELECT * FROM Languages WHERE Locale = @locale)
		BEGIN
			DECLARE @CID INT;
			SET @CID = 0;
			INSERT Courses (StartDate, EndDate, ECTS)
			VALUES (@startDate, @endDate, @ects)

			SET @CID = SCOPE_IDENTITY();

			INSERT INTO CourseTranslations (CourseID, LanguageID, Name, Description)
			SELECT @CID, LanguageID, @name, @description FROM Languages WHERE Locale = @locale

			INSERT StudyProgramCourses (StudyProgramID, CourseID, Semester)
			VALUES (@studyProgramId, @CID, @semester)

			SET @RESULT = @CID;
		END
	END
	ELSE
	BEGIN
		DECLARE @ROWS INT;
		UPDATE Courses
		SET StartDate = @startDate, EndDate = @endDate, ECTS = @ects
		WHERE CourseID = @courseId

		UPDATE CT
		SET CT.Name = @name, CT.Description = @description
		FROM CourseTranslations CT
		INNER JOIN Languages L
		ON CT.LanguageID = L.LanguageID
		WHERE CT.CourseID = @courseId AND L.Locale = @locale

		INSERT INTO StudyProgramCourses (StudyProgramID, CourseID, Semester)
		VALUES (@studyProgramId, @courseId, @semester)

		SET @ROWS = @@ROWCOUNT;

		SET @RESULT = @ROWS;
	END
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @RESULT
