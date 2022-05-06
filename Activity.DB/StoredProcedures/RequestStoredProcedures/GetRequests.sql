CREATE PROCEDURE [dbo].[GetRequests]
AS
    set nocount on

    select Id, UserId, Title, Description
    from [Request]

    return 0