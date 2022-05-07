CREATE PROCEDURE [dbo].[UpdateRequest]
	@requestId int,
	@requestTitle nvarchar(128),
	@requestDescription nvarchar(128)
AS
begin
	set nocount on;
	update [Request]
	set Title = @requestTitle, Description = @requestDescription
	where Id = @requestId
end