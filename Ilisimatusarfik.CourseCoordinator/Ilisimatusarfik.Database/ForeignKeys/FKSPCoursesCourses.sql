ALTER TABLE [dbo].[StudyProgramCourses]
	ADD CONSTRAINT [fk_studyprogramcourses_courses]
	FOREIGN KEY (CourseID)
	REFERENCES [Courses] (CourseID)
