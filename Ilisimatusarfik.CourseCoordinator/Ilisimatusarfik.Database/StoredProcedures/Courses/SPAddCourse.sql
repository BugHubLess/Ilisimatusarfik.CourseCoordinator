/**
 Creates a course and returns the ID of the newly created course
*/
CREATE PROCEDURE [dbo].[SPAddCourse]
	@locale NVARCHAR(50),
	@startDate DateTimeOffset(7),
	@endDate DateTimeOffset(7),
	@ECTS INT,
	@name NVARCHAR(MAX),
	@description NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ID INT;
	INSERT INTO Courses (StartDate, EndDate, ECTS)-- This will set SCOPE_IDENTITY
	VALUES (@startDate, @endDate, @ECTS)
	SET @ID = SCOPE_IDENTITY();
	INSERT INTO CourseTranslations(CourseID, LanguageID, Name, Description)
	SELECT @ID, LanguageID, @name, @description FROM Languages WHERE Locale = @locale
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ID
