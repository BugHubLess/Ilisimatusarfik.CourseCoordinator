ALTER TABLE [dbo].[LectureStatusTranslations]
	ADD CONSTRAINT [fk_lectureStatustranslations_status]
	FOREIGN KEY (LectureStatusID)
	REFERENCES [LectureStatus] ([LectureStatusID])
	ON DELETE CASCADE
