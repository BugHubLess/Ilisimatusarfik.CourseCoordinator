ALTER TABLE [dbo].[LectureStatusTranslations]
	ADD CONSTRAINT [fk_lectureStatustranslations_lectureStatus]
	FOREIGN KEY (LectureStatusID)
	REFERENCES [LectureStatus] ([LectureStatusID])
	ON DELETE CASCADE
