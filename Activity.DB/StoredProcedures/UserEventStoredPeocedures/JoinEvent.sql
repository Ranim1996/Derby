CREATE PROCEDURE [dbo].[JoinEvent]
	@userId nvarchar(128),
	@eventId int
AS
begin
	set nocount on;
	insert into [UserEvent](UserId, EventId)
    VALUES ( @userId, @eventId)
end
