CREATE PROCEDURE [dbo].[GetRequestsByUserId]
    @userId nvarchar(128)
AS
    set nocount on

    select Id, Title, Description
    from [Request]
    where UserId = @userId

    return 0