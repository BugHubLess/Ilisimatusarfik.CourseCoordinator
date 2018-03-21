ALTER TABLE [dbo].[CourseTranslations]
	ADD CONSTRAINT [fk_coursetranslations_languages]
	FOREIGN KEY (LanguageID)
	REFERENCES [Languages] (LanguageID)
