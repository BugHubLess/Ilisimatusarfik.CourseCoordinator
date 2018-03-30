ALTER TABLE [dbo].[StatusTranslations]
	ADD CONSTRAINT [fk_statustranslations_languages]
	FOREIGN KEY (LanguageID)
	REFERENCES [Languages] (LanguageID)
	ON DELETE CASCADE
