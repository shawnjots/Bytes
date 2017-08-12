Create Procedure [dbo].[UpdateProduct]
(
    @productID int,
    @productName nvarchar(50),
    @buyingPrice decimal,
    @sellingPrice decimal,
    @purchaseDate datetime,
    @expiryDate datetime,
    @description nvarchar(MAX)
)
as
begin
    Update Product
    set productName=@productName,
    buyingPrice=@buyingPrice,
    sellingPrice=@sellingPrice,
    purchaseDate=@purchaseDate,
    expiryDate=@expiryDate,
    description=@description
    where productID=@productID
End