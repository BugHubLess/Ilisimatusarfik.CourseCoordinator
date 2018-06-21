ALTER TABLE [dbo].[Lectures]
	ADD CONSTRAINT [fk_lectures_courses]
	FOREIGN KEY (CourseID)
	REFERENCES [Courses] (CourseID)
	ON DELETE CASCADE
