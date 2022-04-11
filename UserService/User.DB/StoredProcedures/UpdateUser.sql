CREATE PROCEDURE [dbo].[UpdateUser]
	@userId nvarchar(128),
	@userFirstName nvarchar(128),
	@userLastName nvarchar(128),
	@userEmail nvarchar(128)
AS
begin
	set nocount on;
	update [User]
	set FirstName = @userFirstName, LastName = @userLastName, EmailAddress = @userEmail
	where Id = @userId
end