CREATE PROCEDURE [dbo].[GetUsers]
AS
    set nocount on

    select Id, FirstName, LastName, EmailAddress, CreatedDate 
    from [User]

    return 0