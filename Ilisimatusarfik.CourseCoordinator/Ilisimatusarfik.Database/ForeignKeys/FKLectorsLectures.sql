ALTER TABLE [dbo].[Lectors]
	ADD CONSTRAINT [fk_lectors_lectures]
	FOREIGN KEY (LectureID)
	REFERENCES [Lectures] (LectureID)
