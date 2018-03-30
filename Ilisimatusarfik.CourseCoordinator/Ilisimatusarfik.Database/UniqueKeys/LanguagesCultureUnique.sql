ALTER TABLE [dbo].[Languages]
	ADD CONSTRAINT [uc_culture]
	UNIQUE ([Locale])
