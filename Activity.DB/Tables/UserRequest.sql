CREATE TABLE [dbo].[UserRequest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RequestId] INT NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [FK_UserRequest_Request] FOREIGN KEY (RequestId) REFERENCES [Request](Id), 
    CONSTRAINT [FK_UserRequest_User] FOREIGN KEY (UserId) REFERENCES [User](Id)
)
