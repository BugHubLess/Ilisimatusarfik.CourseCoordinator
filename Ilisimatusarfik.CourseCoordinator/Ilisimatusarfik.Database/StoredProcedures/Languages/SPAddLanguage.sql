/**
 Creates a language and returns the ID of the newly created language
*/
CREATE PROCEDURE [dbo].[SPAddLanguage]
	@culture nvarchar,
	@displayname nvarchar
AS
	INSERT INTO Languages (Culture, DisplayName)
	VALUES (@culture, @displayname)
RETURN @@IDENTITY
