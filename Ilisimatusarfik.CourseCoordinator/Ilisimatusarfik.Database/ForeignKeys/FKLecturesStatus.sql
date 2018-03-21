ALTER TABLE [dbo].[Lectures]
	ADD CONSTRAINT [fk_lectures_status]
	FOREIGN KEY (StatusID)
	REFERENCES [Status] (StatusID)
