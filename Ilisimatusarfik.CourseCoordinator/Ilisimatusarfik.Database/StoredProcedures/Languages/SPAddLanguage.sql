/**
 Creates a language and returns the ID of the newly created language
*/
CREATE PROCEDURE [dbo].[SPAddLanguage]
	@locale NVARCHAR(50),
	@displayname NVARCHAR(50)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ID INT;
	INSERT INTO Languages (Locale, DisplayName)
	VALUES (@locale, @displayname)
	SET @ID = SCOPE_IDENTITY();
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ID
