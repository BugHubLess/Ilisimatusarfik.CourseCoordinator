/*
Edit/update a course
*/
CREATE PROCEDURE [dbo].[SPEditCourse]
	@courseId INT,
	@locale NVARCHAR(50),
	@startDate DateTimeOffset(7),
	@endDate DateTimeOffset(7),
	@ECTS INT,
	@name NVARCHAR(MAX),
	@description NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ROWS INT;
	UPDATE Courses

	SET StartDate = @startDate,
	EndDate = @endDate,
	ECTS = @ECTS

	WHERE CourseID = @courseId;

	UPDATE CT

	SET CT.Name = @name,
	CT.Description = @description,
	CT.LanguageID = L.LanguageID

	FROM CourseTranslations CT
	INNER JOIN Languages L
	ON CT.LanguageID = L.LanguageID

	WHERE CT.CourseID = @courseId

	SET @ROWS = @@ROWCOUNT;

COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ROWS
