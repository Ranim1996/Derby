CREATE TABLE [dbo].[Request]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL,
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Request_User] FOREIGN KEY (UserId) REFERENCES [User](Id), 
)