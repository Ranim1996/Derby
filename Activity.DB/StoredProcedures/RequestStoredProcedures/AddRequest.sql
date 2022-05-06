CREATE PROCEDURE [dbo].[AddRequest]
	@userId nvarchar(128),
	@requestTitle nvarchar(128),
	@requestDescription nvarchar(128)
AS
begin
	set nocount on;
	insert into [Request](UserId, Title, Description)
    VALUES ( @userId, @requestTitle, @requestDescription)
end