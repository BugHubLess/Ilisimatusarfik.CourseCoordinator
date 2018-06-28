ALTER TABLE [dbo].[ReservedClassrooms]
	ADD CONSTRAINT [fk_reservedClassrooms_lectures]
	FOREIGN KEY (LectureID)
	REFERENCES [Lectures] (LectureID)
	ON DELETE CASCADE