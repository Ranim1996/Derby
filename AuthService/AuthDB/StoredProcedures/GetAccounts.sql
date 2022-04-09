CREATE PROCEDURE [dbo].[GetAccounts]
AS
    set nocount on

    select Id, FirstName, LastName, EmailAddress 
    from [Account]

    return 0