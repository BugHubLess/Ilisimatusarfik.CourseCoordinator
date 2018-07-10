CREATE TABLE [dbo].[LectureStatusTranslations]
(
	[LectureStatusID] INT NOT NULL, 
    [LanguageID] INT NOT NULL, 
    [LectureStatus] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_LectureStatusTranslations] PRIMARY KEY ([LanguageID], [LectureStatusID]) 
)
