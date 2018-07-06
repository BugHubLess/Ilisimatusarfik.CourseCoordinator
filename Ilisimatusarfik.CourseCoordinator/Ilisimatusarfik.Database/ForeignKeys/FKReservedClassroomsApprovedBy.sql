ALTER TABLE [dbo].[ReservedClassrooms]
	ADD CONSTRAINT [fk_reservedClassrooms_approvedBy]
	FOREIGN KEY (ApprovedBy)
	REFERENCES [Employees] (EmployeeID)
	ON DELETE NO ACTION