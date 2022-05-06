CREATE PROCEDURE [dbo].[DeleteEvent]
	@eventId int,
	@userId nvarchar(128)
AS
begin
	set nocount on;
	delete from [Event]
	where Id = @eventId AND UserId = @userId
end
