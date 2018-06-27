CREATE TABLE [dbo].[Lectures]
(
	[LectureID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CourseID] INT NOT NULL, 
    [StatusID] INT NOT NULL, 
    [Start] DATETIMEOFFSET NOT NULL, 
    [Duration] INT NOT NULL 
)
