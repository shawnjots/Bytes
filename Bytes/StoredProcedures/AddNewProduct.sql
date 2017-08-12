Create procedure [dbo].[AddNewProduct]
(
	@productName nvarchar(50),
    @buyingPrice money,
    @sellingPrice money,
    @purchaseDate datetime,
    @expiryDate datetime,
    @description nvarchar(MAX)
)
as
begin
    Insert into Product values(@productName, @buyingPrice, @sellingPrice, 
	@purchaseDate, @expiryDate, @description)
End