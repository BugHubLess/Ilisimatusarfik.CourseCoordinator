﻿CREATE PROCEDURE [dbo].[SPDeleteStatusTranslations]
	@statusId int
AS
BEGIN TRANSACTION
BEGIN TRY
	DELETE FROM Status
	WHERE StatusID = @statusId
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN 0