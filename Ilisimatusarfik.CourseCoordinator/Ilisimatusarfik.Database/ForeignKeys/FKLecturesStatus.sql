ALTER TABLE [dbo].[Lectures]
	ADD CONSTRAINT [fk_lectures_lectureStatus]
	FOREIGN KEY (StatusID)
	REFERENCES [LectureStatus] ([LectureStatusID])
