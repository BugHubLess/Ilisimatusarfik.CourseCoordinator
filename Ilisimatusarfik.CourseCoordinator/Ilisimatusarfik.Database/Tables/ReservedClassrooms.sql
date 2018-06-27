CREATE TABLE [dbo].[ReservedClassrooms]
(
	[LectureID] INT NOT NULL , 
    [ClassroomID] INT NOT NULL, 
    [ReservedBy] INT NULL, 
    [BookingDate] DATETIMEOFFSET NOT NULL, 
    [ApprovedBy] INT NULL, 
    [Approved] BIT NOT NULL, 
    CONSTRAINT [PK_ReservedClassrooms] PRIMARY KEY ([LectureID], [ClassroomID])
)
