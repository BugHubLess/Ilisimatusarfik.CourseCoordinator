﻿CREATE TABLE [dbo].[StudyProgramsTranslations]
(
	[StudyProgramID] INT NOT NULL, 
    [LanguageID] INT NOT NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_StudyProgramsTranslations] PRIMARY KEY ([LanguageID], [StudyProgramID]) 
)