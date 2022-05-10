CREATE PROCEDURE [dbo].[GetResponses]
    @requestId int
AS
    set nocount on

    select r.RequestId, u.FirstName, u.LastName
    from [UserRequest] r
    inner join [User] u on r.UserId = u.Id
    where RequestId = @requestId

return 0
