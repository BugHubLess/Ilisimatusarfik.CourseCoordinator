ALTER TABLE [dbo].[RequestedClassrooms]
	ADD CONSTRAINT [fk_requestedClassrooms_roomStatus]
	FOREIGN KEY (RoomStatusID)
	REFERENCES [RoomStatus] (RoomStatusID)
	ON DELETE CASCADE
