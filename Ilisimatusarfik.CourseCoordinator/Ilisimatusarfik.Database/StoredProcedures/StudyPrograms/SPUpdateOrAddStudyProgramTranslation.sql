﻿CREATE PROCEDURE [dbo].[SPUpdateOrAddStudyProgramTranslation]
	@studyProgramId INT,
	@locale NVARCHAR(50),
	@name NVARCHAR(MAX),
	@description NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ROWS INT;
	UPDATE SPT
	SET Name = @name, Description = @description
	FROM StudyProgramsTranslations SPT
	INNER JOIN Languages L
	ON SPT.LanguageID = L.LanguageID
	WHERE SPT.StudyProgramID = @studyProgramId AND L.Locale = @locale

	SET @ROWS = @@ROWCOUNT;

	IF @ROWS = 0
	BEGIN
		INSERT INTO StudyProgramsTranslations (StudyProgramID, LanguageID, Name, Description)
		SELECT @studyProgramId, LanguageID, @name, @description FROM Languages WHERE Locale = @locale
		SET @ROWS = @@ROWCOUNT;
	END
COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ROWS  -- returns the number of rows affected