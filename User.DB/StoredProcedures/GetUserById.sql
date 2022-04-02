CREATE PROCEDURE [dbo].[GetUserById]
    @userId nvarchar(128)
AS
    set nocount on

    select Id, FirstName, LastName, EmailAddress, CreatedDate 
    from [User]
    where Id = @userId

    return 0