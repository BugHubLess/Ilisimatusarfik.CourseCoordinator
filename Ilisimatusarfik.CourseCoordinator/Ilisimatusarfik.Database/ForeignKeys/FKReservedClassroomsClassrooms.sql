ALTER TABLE [dbo].[ReservedClassrooms]
	ADD CONSTRAINT [fk_reservedClassrooms_classrooms]
	FOREIGN KEY (ClassroomID)
	REFERENCES [Classrooms] (ClassroomID)
	ON DELETE CASCADE
