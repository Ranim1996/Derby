CREATE PROCEDURE [dbo].[OfferHelp]
	@userId nvarchar(128),
	@requestId int
AS
begin
	set nocount on;
	insert into [UserRequest](UserId, RequestId)
    VALUES ( @userId, @requestId)
end
