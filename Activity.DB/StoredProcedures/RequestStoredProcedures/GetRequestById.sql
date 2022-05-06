CREATE PROCEDURE [dbo].[GetRequestById]
    @requestId nvarchar(128)
AS
    set nocount on

    select Id, Title, Description
    from [Request]
    where Id = @requestId

return 0