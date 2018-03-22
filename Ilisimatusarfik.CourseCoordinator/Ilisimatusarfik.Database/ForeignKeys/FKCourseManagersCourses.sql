ALTER TABLE [dbo].[CourseManagers]
	ADD CONSTRAINT [fk_coursemanagers_courses]
	FOREIGN KEY (CourseID)
	REFERENCES [Courses] (CourseID)
