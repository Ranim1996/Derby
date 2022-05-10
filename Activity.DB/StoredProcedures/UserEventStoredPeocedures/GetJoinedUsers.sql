CREATE PROCEDURE [dbo].[GetJoinedUsers]
    @eventId int
AS
    set nocount on

    select e.EventId, u.FirstName, u.LastName
    from [UserEvent] e
    inner join [User] u on e.UserId = u.Id
    where EventId = @eventId

return 0