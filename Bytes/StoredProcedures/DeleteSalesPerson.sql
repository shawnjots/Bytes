Create Procedure [dbo].[DeleteSalesPersonById]
(
    @employeeID int
)
as
begin
    Delete from SalesPerson where employeeID=@employeeID
End