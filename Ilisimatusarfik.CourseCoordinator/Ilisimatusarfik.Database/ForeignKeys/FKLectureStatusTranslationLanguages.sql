ALTER TABLE [dbo].[LectureStatusTranslations]
	ADD CONSTRAINT [fk_lectureStatustranslations_languages]
	FOREIGN KEY (LanguageID)
	REFERENCES [Languages] (LanguageID)
	ON DELETE CASCADE
