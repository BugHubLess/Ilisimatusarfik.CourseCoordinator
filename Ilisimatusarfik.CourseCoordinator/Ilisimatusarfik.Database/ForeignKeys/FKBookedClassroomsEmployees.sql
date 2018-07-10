ALTER TABLE [dbo].[BookedClassrooms]
	ADD CONSTRAINT [fk_bookedClassrooms_employees]
	FOREIGN KEY (ApprovedBy)
	REFERENCES [Employees] (EmployeeID)
	ON DELETE SET NULL
