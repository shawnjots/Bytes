Create Procedure [dbo].[DeleteByManagerId]
(
    @employeeID int
)
as
begin
    Delete from Manager where employeeID=@employeeID
End