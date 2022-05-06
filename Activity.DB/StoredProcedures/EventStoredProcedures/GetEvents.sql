CREATE PROCEDURE [dbo].[GetEvents]
AS
    set nocount on

    select Id, UserId, Title, Description, [Where], [When]
    from [Event]

    return 0
