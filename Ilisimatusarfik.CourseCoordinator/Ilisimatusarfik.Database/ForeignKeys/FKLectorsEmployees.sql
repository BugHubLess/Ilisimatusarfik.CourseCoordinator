ALTER TABLE [dbo].[Lectors]
	ADD CONSTRAINT [fk_lectors_employees]
	FOREIGN KEY (EmployeeID)
	REFERENCES [Employees] (EmployeeID)
