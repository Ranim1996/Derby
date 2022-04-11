CREATE PROCEDURE [dbo].[DeleteUser]
	@userID nvarchar(128)
AS
begin
	set nocount on;
	delete from [User]
	where Id = @userID
end