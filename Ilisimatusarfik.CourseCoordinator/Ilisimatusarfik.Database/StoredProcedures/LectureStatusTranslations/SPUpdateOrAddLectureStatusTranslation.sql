CREATE PROCEDURE [dbo].[SPUpdateOrAddLectureStatusTranslation]
	@lectureStatusId INT,
	@locale NVARCHAR(50),
	@status NVARCHAR(MAX)
AS
BEGIN TRANSACTION
BEGIN TRY
	DECLARE @ROWS INT;
	UPDATE ST
	SET Status = @status
	FROM LectureStatusTranslations ST
	INNER JOIN Languages L
	ON ST.LanguageID = L.LanguageID
	WHERE ST.LectureStatusID = @lectureStatusId AND L.Locale = @locale

	SET @ROWS = @@ROWCOUNT;

	IF @ROWS = 0
	BEGIN
		INSERT INTO LectureStatusTranslations (LectureStatusID, LanguageID, Status)
		SELECT @lectureStatusId, LanguageID, @status FROM Languages WHERE Locale = @locale
		SET @ROWS = @@ROWCOUNT;
	END

COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
RETURN @ROWS  -- returns the number of rows affected
