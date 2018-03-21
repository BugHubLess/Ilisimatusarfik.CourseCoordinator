ALTER TABLE [dbo].[Enrolled]
	ADD CONSTRAINT [fk_enrolled_students]
	FOREIGN KEY (StudentID)
	REFERENCES [Students] (StudentID)
