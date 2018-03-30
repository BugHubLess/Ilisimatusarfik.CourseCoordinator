﻿CREATE PROCEDURE [dbo].[SPCreateStatusTranslation]
	@languageId int,
	@name nvarchar
AS
BEGIN TRANSACTION
BEGIN TRY
	INSERT Status DEFAULT VALUES
	INSERT INTO StatusTranslations (StatusID, LanguageID, Name)
	VALUES (@@IDENTITY, @languageId, @name)
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @@IDENTITY
