CREATE TABLE [dbo].[Event]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL,
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [When] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [Where] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Event_User] FOREIGN KEY (UserId) REFERENCES [User](Id), 
)