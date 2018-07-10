ALTER TABLE [dbo].[RequestedClassrooms]
	ADD CONSTRAINT [fk_requestedClassrooms_classrooms]
	FOREIGN KEY (ClassroomID)
	REFERENCES [Classrooms] (ClassroomID)
	ON DELETE CASCADE
