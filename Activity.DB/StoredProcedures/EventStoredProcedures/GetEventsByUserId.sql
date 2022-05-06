CREATE PROCEDURE [dbo].[GetEventsByUserId]
    @userId nvarchar(128)
AS
    set nocount on

    select Id, Title, Description, [Where], [When]
    from [Event]
    where UserId = @userId

    return 0