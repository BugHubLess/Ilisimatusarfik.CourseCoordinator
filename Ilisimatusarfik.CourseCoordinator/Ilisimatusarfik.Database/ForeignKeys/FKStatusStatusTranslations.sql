ALTER TABLE [dbo].[StatusTranslations]
	ADD CONSTRAINT [fk_statustranslations_status]
	FOREIGN KEY (StatusID)
	REFERENCES [Status] (StatusID)
