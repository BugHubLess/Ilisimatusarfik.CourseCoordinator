/*
Edit/update a course
*/
CREATE PROCEDURE [dbo].[SPEditCourse]
	@locale NVARCHAR(50),
	@startDate DateTimeOffset(7),
	@endDate DateTimeOffset(7),
	@ECTS INT,
	@name NVARCHAR(MAX),
	@description NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	UPDATE C

	SET C.StartDate = @startDate,
	C.EndDate = @endDate,
	C.ECTS = @ECTS,
	C.Name = @name,
	C.Description = @description

	FROM (
		SELECT * FROM
		Courses CS
		INNER JOIN CourseTranslations CT
		ON
		CS.CourseID = CT.CourseID
		RIGHT JOIN Languages L
		ON
		CT.LanguageID = L.LanguageID
	) AS C
	
	WHERE C.Locale = @locale

COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @@ROWCOUNT
