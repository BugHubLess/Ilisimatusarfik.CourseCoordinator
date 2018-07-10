CREATE TABLE [dbo].[RoomStatusTranslations]
(
	[RoomStatusID] INT NOT NULL , 
    [LanguageID] INT NOT NULL, 
    [RoomStatus] NVARCHAR(MAX) NULL, 
    PRIMARY KEY ([RoomStatusID], [LanguageID])
)
