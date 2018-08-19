/**
	This returns all status for that locale even if they don't have any translations.
	The translation name will just be empty - but the ID will be set!
**/
CREATE PROCEDURE [dbo].[SPGetLectureStatusTranslations]
	@locale nvarchar(50)
AS
	SELECT S.LectureStatusID, ST.Status FROM
	((SELECT LanguageID, Locale FROM Languages) AS L
	CROSS JOIN							-- Gets all combinations of Language X Status tuples
	(SELECT LectureStatusID FROM LectureStatus) AS S)
	LEFT JOIN LectureStatusTranslations ST		-- Then we join the above table to ST by constricting that status and language should match
	ON
		S.LectureStatusID = ST.LectureStatusID AND
		L.LanguageID = ST.LanguageID
	WHERE L.Locale = @locale
RETURN 0
