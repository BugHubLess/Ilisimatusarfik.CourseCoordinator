CREATE TABLE [dbo].[Classrooms]
(
	[ClassroomID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Capacity] INT NULL, 
    [Location] NVARCHAR(MAX) NULL
)
