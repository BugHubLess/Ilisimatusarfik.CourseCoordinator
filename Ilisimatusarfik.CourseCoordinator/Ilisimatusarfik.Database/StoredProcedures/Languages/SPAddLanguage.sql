/**
 Creates a language and returns the ID of the newly created language
*/
CREATE PROCEDURE [dbo].[SPAddLanguage]
	@culture NVARCHAR(50),
	@displayname NVARCHAR(50)
AS
	INSERT INTO Languages (Culture, DisplayName)
	VALUES (@culture, @displayname)
RETURN SCOPE_IDENTITY()