ALTER TABLE [dbo].[RoomStatusTranslations]
	ADD CONSTRAINT [fk_roomStatusTranslations_languages]
	FOREIGN KEY (LanguageID)
	REFERENCES [Languages] (LanguageID)
	ON DELETE CASCADE
