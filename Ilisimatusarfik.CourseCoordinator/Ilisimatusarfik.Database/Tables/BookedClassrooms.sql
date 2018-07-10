CREATE TABLE [dbo].[BookedClassrooms]
(
	[RequestedClassroomID] INT NOT NULL PRIMARY KEY, 
    [ApprovedBy] INT NULL, 
    [BookingDate] DATETIMEOFFSET NOT NULL
)
