ALTER TABLE [dbo].[StudentRollRegistries]
	ADD CONSTRAINT [fk_studentrollregistries_lectures]
	FOREIGN KEY (LectureID)
	REFERENCES [Lectures] (LectureID)
