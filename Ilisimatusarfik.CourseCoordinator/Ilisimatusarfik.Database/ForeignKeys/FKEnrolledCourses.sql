ALTER TABLE [dbo].[Enrolled]
	ADD CONSTRAINT [fk_enrolled_courses]
	FOREIGN KEY (CourseID)
	REFERENCES [Courses] (CourseID)
