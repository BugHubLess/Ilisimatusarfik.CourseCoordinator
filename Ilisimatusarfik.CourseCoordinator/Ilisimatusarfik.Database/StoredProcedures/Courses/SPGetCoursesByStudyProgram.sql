CREATE PROCEDURE [dbo].[SPGetCoursesByStudyProgram]
	@studyProgramId INT,
	@locale NVARCHAR(50)
AS
	SELECT SP.StudyProgramID, SPT.Name, SPT.Description FROM
	((SELECT LanguageID, Locale FROM Languages) AS L
	CROSS JOIN
	(SELECT StudyProgramID FROM StudyPrograms) AS SP)
	LEFT JOIN StudyProgramsTranslations SPT
	ON
		SP.StudyProgramID = SPT.StudyProgramID AND
		L.LanguageID = SPT.LanguageID
	WHERE L.Locale = @locale AND SP.StudyProgramID = @studyProgramId
RETURN 0
