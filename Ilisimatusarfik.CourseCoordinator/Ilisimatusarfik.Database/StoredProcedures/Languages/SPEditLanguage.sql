﻿CREATE PROCEDURE [dbo].[SPEditLanguage]
	@languageId int,
	@locale NVARCHAR(50),
	@displayName NVARCHAR(50)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ROWS INT;
	UPDATE Languages
	SET Locale = @locale, DisplayName = @displayName
	WHERE LanguageID = @languageId
	SET @ROWS = @@ROWCOUNT;
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ROWS
