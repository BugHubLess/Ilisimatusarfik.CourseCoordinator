ALTER TABLE [dbo].[ReservedClassrooms]
	ADD CONSTRAINT [fk_reservedClassrooms_reservedBy]
	FOREIGN KEY (ReservedBy)
	REFERENCES [Employees] (EmployeeID)
	ON DELETE SET NULL
