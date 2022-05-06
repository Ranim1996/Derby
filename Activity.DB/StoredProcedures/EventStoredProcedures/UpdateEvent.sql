CREATE PROCEDURE [dbo].[UpdateEvent]
	@eventId int,
	@userId nvarchar(128),
	@eventTitle nvarchar(128),
	@eventDescription nvarchar(128),
	@eventDate DateTime,
	@eventLocation nvarchar(128)
AS
begin
	set nocount on;
	update [Event]
	set Title = @eventTitle, Description = @eventDescription, [Where] = @eventLocation, [When] = @eventDate
	where Id = @eventId and UserID = @userId
end
