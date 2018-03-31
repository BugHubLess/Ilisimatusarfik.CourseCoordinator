/**
	This return status for that locale even if it doesn't have any translation.
	The translation name will just be empty.
**/
CREATE PROCEDURE [dbo].[SPGetStatusTranslation]
	@statusId int,
	@locale nvarchar(50)
AS
	SELECT S.StatusID, ST.Name FROM
	((SELECT LanguageID, Locale FROM Languages) AS L
	CROSS JOIN
	(SELECT StatusID FROM Status) AS S)
	LEFT JOIN StatusTranslations ST
	ON
		S.StatusID = ST.StatusID AND
		L.LanguageID = ST.LanguageID
	WHERE L.Locale = @locale AND S.StatusID = @statusId
RETURN 0
