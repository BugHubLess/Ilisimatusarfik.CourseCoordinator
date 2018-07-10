CREATE PROCEDURE [dbo].[SPUpdateOrAddLectureStatusTranslation]
	@lectureStatusId INT,
	@locale NVARCHAR(50),
	@name NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ROWS INT;
	UPDATE ST
	SET LectureStatus = @name
	FROM LectureStatusTranslations ST
	INNER JOIN Languages L
	ON ST.LanguageID = L.LanguageID
	WHERE ST.LectureStatusID = @lectureStatusId AND L.Locale = @locale

	SET @ROWS = @@ROWCOUNT;

	IF @ROWS = 0
	BEGIN
		INSERT INTO LectureStatusTranslations (LectureStatusID, LanguageID, LectureStatus)
		SELECT @lectureStatusId, LanguageID, @name FROM Languages WHERE Locale = @locale
		SET @ROWS = @@ROWCOUNT;
	END

COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ROWS  -- returns the number of rows affected
