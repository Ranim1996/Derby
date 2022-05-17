CREATE TABLE [dbo].[Event]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [When] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [Where] NVARCHAR(50) NOT NULL
)
