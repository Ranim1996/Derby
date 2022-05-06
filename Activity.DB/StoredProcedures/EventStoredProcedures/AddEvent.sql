CREATE PROCEDURE [dbo].[AddEvent]
	@userId nvarchar(128),
	@eventTitle nvarchar(128),
	@eventDescription nvarchar(128),
	@eventDate DateTime,
	@eventLocation nvarchar(128)
AS
begin
	set nocount on;
	insert into [Event](UserId, Title, Description, [When], [Where])
    VALUES ( @userId, @eventTitle, @eventDescription, @eventDate, @eventLocation)
end