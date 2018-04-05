CREATE PROCEDURE [dbo].[SPGetSemesterCoursesByStudyProgram]
	@studyProgramId INT,
	@locale NVARCHAR(50)
AS
	SELECT SPC.Semester, SPC.CourseID, CT.Name, CT.Description, C.StartDate, C.EndDate, C.ECTS FROM
	((SELECT LanguageID, Locale FROM Languages) AS L
	CROSS JOIN
	(SELECT StudyProgramID, CourseID, Semester FROM StudyProgramCourses) AS SPC)
	LEFT JOIN CourseTranslations CT
	ON
		SPC.CourseID = CT.CourseID AND
		L.LanguageID = CT.LanguageID
	LEFT JOIN Courses C
	ON
		SPC.CourseID = C.CourseID
	WHERE L.Locale = @locale AND SPC.StudyProgramID = @studyProgramId
RETURN 0
