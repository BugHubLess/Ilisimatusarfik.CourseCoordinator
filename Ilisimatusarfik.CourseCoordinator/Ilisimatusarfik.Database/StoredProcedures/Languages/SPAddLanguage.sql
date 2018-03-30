/**
 Creates a language and returns the ID of the newly created language
*/
CREATE PROCEDURE [dbo].[SPAddLanguage]
	@locale NVARCHAR(50),
	@displayname NVARCHAR(50)
AS
	INSERT INTO Languages (Locale, DisplayName)
	VALUES (@locale, @displayname)
RETURN SCOPE_IDENTITY()