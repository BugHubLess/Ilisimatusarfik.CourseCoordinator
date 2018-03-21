ALTER TABLE [dbo].[StudentRollRegistries]
	ADD CONSTRAINT [fk_studentrollregistries_students]
	FOREIGN KEY (StudentID)
	REFERENCES [Students] (StudentID)
