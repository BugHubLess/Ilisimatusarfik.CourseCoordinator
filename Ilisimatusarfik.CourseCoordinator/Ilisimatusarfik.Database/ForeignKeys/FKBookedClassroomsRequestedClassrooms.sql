ALTER TABLE [dbo].[BookedClassrooms]
	ADD CONSTRAINT [fk_bookedClassrooms_requestedClassrooms]
	FOREIGN KEY (RequestedClassroomID)
	REFERENCES [RequestedClassrooms] (RequestedClassroomID)
	ON DELETE CASCADE
