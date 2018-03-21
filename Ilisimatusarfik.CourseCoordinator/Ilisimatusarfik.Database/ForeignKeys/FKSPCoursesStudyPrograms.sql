ALTER TABLE [dbo].[StudyProgramCourses]
	ADD CONSTRAINT [fk_studyprogramcourses_studyprogram]
	FOREIGN KEY (StudyProgramID)
	REFERENCES [StudyPrograms] (StudyProgramID)
