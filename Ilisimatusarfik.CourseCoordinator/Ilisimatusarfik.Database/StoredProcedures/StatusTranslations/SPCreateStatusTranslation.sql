﻿CREATE PROCEDURE [dbo].[SPCreateStatusTranslation]
	@culture nvarchar,
	@name nvarchar
AS
BEGIN TRANSACTION
BEGIN TRY
	INSERT Status DEFAULT VALUES -- This will set SCOPE_IDENTITY
	INSERT INTO StatusTranslations (StatusID, LanguageID, Name)
	SELECT SCOPE_IDENTITY(), LanguageID, @name FROM Languages WHERE Culture = @culture
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN SCOPE_IDENTITY()
