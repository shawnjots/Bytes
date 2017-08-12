Create Procedure [dbo].[DeleteCategoryById]
(
    @categoryID int
)
as
begin
    Delete from Category where categoryID=@categoryID
End