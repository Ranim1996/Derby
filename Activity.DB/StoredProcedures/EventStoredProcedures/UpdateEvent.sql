CREATE PROCEDURE [dbo].[UpdateEvent]
	@eventId int,
	@eventTitle nvarchar(128),
	@eventDescription nvarchar(128),
	@eventDate DateTime,
	@eventLocation nvarchar(128)
AS
begin
	set nocount on;
	update [Event]
	set Title = @eventTitle, Description = @eventDescription, [Where] = @eventLocation, [When] = @eventDate
	where Id = @eventId
end
