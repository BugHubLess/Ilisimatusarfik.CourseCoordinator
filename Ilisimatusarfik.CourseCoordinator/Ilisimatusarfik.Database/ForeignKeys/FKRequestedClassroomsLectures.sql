ALTER TABLE [dbo].[RequestedClassrooms]
	ADD CONSTRAINT [fk_requestedClassrooms_lectures]
	FOREIGN KEY (LectureID)
	REFERENCES [Lectures] (LectureID)
	ON DELETE CASCADE