CREATE PROCEDURE [dbo].[DeleteRequest]
	@requestId int,
	@userId nvarchar(128)
AS
begin
	set nocount on;
	delete from [Request]
	where Id = @requestId AND UserId = @userId
end