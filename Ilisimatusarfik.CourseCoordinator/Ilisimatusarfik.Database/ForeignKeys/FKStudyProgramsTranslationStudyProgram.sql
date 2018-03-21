ALTER TABLE [dbo].[StudyProgramsTranslations]
	ADD CONSTRAINT [fk_studyprogramstranslation_studyprograms]
	FOREIGN KEY (StudyProgramID)
	REFERENCES [StudyPrograms] (StudyProgramID)
