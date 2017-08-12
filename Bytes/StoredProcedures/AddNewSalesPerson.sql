Create procedure [dbo].[AddNewSalesPerson]
(
    @username nvarchar(50),
    @password nvarchar(50),
    @firstName nvarchar(50),
    @lastName nvarchar(50),
    @phoneNumber nvarchar(50)
)
as
begin
    Insert into SalesPerson values(@username, @password, 
    @firstName, @lastName, @phoneNumber)
End