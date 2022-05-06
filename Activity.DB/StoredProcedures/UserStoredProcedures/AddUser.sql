CREATE PROCEDURE [dbo].[AddUser]
	@userId nvarchar(128),
	@userFirstName nvarchar(128),
	@userLastName nvarchar(128)
AS
begin
	set nocount on;
	insert into [User](Id, FirstName, LastName)
    VALUES ( @userId, @userFirstName, @userLastName)
end