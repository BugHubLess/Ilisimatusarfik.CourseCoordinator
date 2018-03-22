ALTER TABLE [dbo].[CourseManagers]
	ADD CONSTRAINT [EmployeeID]
	FOREIGN KEY (EmployeeID)
	REFERENCES [Employees] (EmployeeID)
