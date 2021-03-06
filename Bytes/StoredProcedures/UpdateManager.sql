Create Procedure [dbo].[UpdateManager]
(
    @employeeID int,
    @username nvarchar(50),
    @password nvarchar(50),
    @firstName nvarchar(50),
    @lastName nvarchar(50),
    @phoneNumber nvarchar(50)
)
as
begin
    Update Manager 
    set username=@username,
    password=@password,
    firstName=@firstName,
    lastName=@lastName,
    phoneNumber=@phoneNumber
    where employeeID=@employeeID
End