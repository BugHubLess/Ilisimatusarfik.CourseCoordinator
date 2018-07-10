CREATE TABLE [dbo].[LectureStatusTranslations]
(
	[LectureStatusID] INT NOT NULL, 
    [LanguageID] INT NOT NULL, 
    [LectureStatus] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_StatusTranslations] PRIMARY KEY ([LanguageID], [LectureStatusID]) 
)
