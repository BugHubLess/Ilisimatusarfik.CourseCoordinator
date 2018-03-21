ALTER TABLE [dbo].[StudyProgramsTranslations]
	ADD CONSTRAINT [fk_studyprogramstranslations_languages]
	FOREIGN KEY (LanguageID)
	REFERENCES [Languages] (LanguageID)
