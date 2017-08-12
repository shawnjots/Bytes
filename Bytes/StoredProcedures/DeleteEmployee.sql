Create Procedure [dbo].[DeleteEmployeeById]
(
    @employeeID int
)
as
begin
    Delete from Employee where employeeID=@employeeID
End