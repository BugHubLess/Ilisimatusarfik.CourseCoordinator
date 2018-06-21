ALTER TABLE [dbo].[CourseTranslations]
	ADD CONSTRAINT [fk_coursetranslations_courses]
	FOREIGN KEY (CourseID)
	REFERENCES [Courses] (CourseID)
	ON DELETE CASCADE