CREATE TABLE [dbo].[RequestedClassrooms]
(
    [RequestedClassroomID] INT NOT NULL, 
	[LectureID] INT NOT NULL , 
    [ClassroomID] INT NOT NULL, 
    [RequestedBy] INT NULL, 
    [RequestedBookingDate] DATETIMEOFFSET NOT NULL, 
	[RoomStatusID] INT NOT NULL, 
    [Reason] NVARCHAR(MAX) NULL, 
    CONSTRAINT [UC_RequestedClassrooms] UNIQUE ([LectureID], [ClassroomID]),
    CONSTRAINT [PK_RequestedClassrooms] PRIMARY KEY ([RequestedClassroomID])
)
