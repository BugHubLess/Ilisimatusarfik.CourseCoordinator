ALTER TABLE [dbo].[Lectures]
	ADD CONSTRAINT [fk_lectures_classrooms]
	FOREIGN KEY (ClassroomID)
	REFERENCES [Classrooms] (ClassroomID)
