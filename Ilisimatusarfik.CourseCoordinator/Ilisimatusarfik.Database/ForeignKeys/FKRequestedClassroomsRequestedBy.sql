ALTER TABLE [dbo].[RequestedClassrooms]
	ADD CONSTRAINT [fk_requestedClassrooms_requestedBy]
	FOREIGN KEY (RequestedBy)
	REFERENCES [Employees] (EmployeeID)
	ON DELETE SET NULL
