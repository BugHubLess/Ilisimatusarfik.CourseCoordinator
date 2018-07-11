CREATE TABLE [dbo].[RoomStatusTranslations]
(
	[RoomStatusID] INT NOT NULL , 
    [LanguageID] INT NOT NULL, 
    [Status] NVARCHAR(MAX) NULL, 
    PRIMARY KEY ([RoomStatusID], [LanguageID])
)
