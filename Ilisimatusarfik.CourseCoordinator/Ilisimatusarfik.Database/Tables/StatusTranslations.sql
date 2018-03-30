CREATE TABLE [dbo].[StatusTranslations]
(
	[StatusID] INT NOT NULL, 
    [LanguageID] INT NOT NULL, 
    [Name] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_StatusTranslations] PRIMARY KEY ([LanguageID], [StatusID]) 
)
