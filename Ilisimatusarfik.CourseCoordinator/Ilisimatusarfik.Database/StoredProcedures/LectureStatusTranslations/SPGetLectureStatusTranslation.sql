/**
	This return status for that locale even if it doesn't have any translation.
	The translation name will just be empty.
**/
CREATE PROCEDURE [dbo].[SPGetLectureStatusTranslation]
	@lectureStatusId int,
	@locale nvarchar(50)
AS
	SELECT S.LectureStatusID, ST.Status FROM
	((SELECT LanguageID, Locale FROM Languages) AS L
	CROSS JOIN
	(SELECT LectureStatusID FROM LectureStatus) AS S)
	LEFT JOIN LectureStatusTranslations ST
	ON
		S.LectureStatusID = ST.LectureStatusID AND
		L.LanguageID = ST.LanguageID
	WHERE L.Locale = @locale AND S.LectureStatusID = @lectureStatusId
RETURN 0
