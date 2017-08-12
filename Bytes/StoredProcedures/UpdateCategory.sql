Create Procedure [dbo].[UpdateCategory]
(
    @categoryID int,
    @categoryName nvarchar(50)
)
as
begin
    Update Category
    Set categoryName=@categoryName
    Where categoryID=@categoryID
End 