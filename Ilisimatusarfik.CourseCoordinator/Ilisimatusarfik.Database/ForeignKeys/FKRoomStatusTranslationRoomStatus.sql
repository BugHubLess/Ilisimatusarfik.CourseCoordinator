ALTER TABLE [dbo].[RoomStatusTranslations]
	ADD CONSTRAINT [fk_roomStatusTranslations_roomStatus]
	FOREIGN KEY (RoomStatusID)
	REFERENCES [RoomStatus] (RoomStatusID)
	ON DELETE CASCADE
