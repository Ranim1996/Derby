CREATE PROCEDURE [dbo].[UpdateRequest]
	@requestId int,
	@userId nvarchar(128),
	@requestTitle nvarchar(128),
	@requestDescription nvarchar(128)
AS
begin
	set nocount on;
	update [Request]
	set Title = @requestTitle, Description = @requestDescription
	where Id = @requestId and UserID = @userId
end