Create Procedure [dbo].[DeleteProductById]
(
    @productID int
)
as
begin
    Delete from Product where productID=@productID
End