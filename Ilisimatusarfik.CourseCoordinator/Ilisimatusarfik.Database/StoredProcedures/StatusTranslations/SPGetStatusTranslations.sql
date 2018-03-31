/**
	This returns all status for that locale even if they don't have any translations.
	The translation name will just be empty - but the ID will be set!
**/
CREATE PROCEDURE [dbo].[SPGetStatusTranslations]
	@locale nvarchar(50)
AS
	SELECT S.StatusID, ST.Name FROM
	((SELECT LanguageID, Locale FROM Languages) AS L
	CROSS JOIN							-- Gets all combinations of Language X Status tuples
	(SELECT StatusID FROM Status) AS S)
	LEFT JOIN StatusTranslations ST		-- Then we join the above table to ST by constricting that status and language should match
	ON
		S.StatusID = ST.StatusID AND
		L.LanguageID = ST.LanguageID
	WHERE L.Locale = @locale
RETURN 0
