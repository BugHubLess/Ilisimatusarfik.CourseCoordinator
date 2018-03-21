CREATE TABLE [dbo].[Languages]
(
	[LanguageID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Culture] NVARCHAR(50) NOT NULL, 
    [DisplayName] NVARCHAR(50) NOT NULL
)
