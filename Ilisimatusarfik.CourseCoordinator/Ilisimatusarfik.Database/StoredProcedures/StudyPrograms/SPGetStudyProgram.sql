CREATE PROCEDURE [dbo].[SPGetStudyProgram]
	@studyProgramId INT,
	@locale NVARCHAR(50)
AS
	SELECT S.StudyProgramID, SP.Name, SP.Description
	FROM
	((SELECT LanguageID, Locale FROM Languages) AS L
	CROSS JOIN
	(SELECT StudyProgramID FROM StudyPrograms) AS S)
	LEFT JOIN StudyProgramsTranslations SP
	ON
		S.StudyProgramID = SP.StudyProgramID AND
		L.LanguageID = SP.LanguageID
	WHERE L.Locale = @locale AND S.StudyProgramID = @studyProgramId
RETURN 0
