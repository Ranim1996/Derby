CREATE PROCEDURE [dbo].[GetEventsByLocation]
    @location nvarchar(50)
AS
    set nocount on

    select Id, Title, Description, [Where], [When]
    from [Event]
    where [Where] = @location

return 0
