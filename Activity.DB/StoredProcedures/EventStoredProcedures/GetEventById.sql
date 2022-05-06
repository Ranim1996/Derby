CREATE PROCEDURE [dbo].[GetEventById]
    @eventId nvarchar(128)
AS
    set nocount on

    select Id, Title, Description, [Where], [When]
    from [Event]
    where Id = @eventId

return 0