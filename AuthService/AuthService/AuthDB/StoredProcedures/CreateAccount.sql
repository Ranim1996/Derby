CREATE PROCEDURE [dbo].[CreateAccount]
	@userId nvarchar(128),
	@userFirstName nvarchar(128),
	@userLastName nvarchar(128),
	@userEmail nvarchar(128)
AS
begin
	set nocount on;
	insert into [Account](Id, FirstName, LastName, EmailAddress)
    VALUES ( @userId, @userFirstName, @userLastName, @userEmail)
end