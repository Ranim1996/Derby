CREATE TABLE [dbo].[UserEvent]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EventId] INT NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [FK_UserEvent_Event] FOREIGN KEY (EventId) REFERENCES [Event](Id), 
    CONSTRAINT [FK_UserEvent_User] FOREIGN KEY (UserId) REFERENCES [User](Id)
)
