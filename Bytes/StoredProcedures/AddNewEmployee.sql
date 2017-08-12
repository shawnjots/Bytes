Create procedure [dbo].[AddNewEmployee]
(
    @username nvarchar(50),
    @password nvarchar(50),
    @firstName nvarchar(50),
    @lastName nvarchar(50),
    @phoneNumber nvarchar(50)
)
as
begin
    Insert into Employee values(@username, @password, 
    @firstName, @lastName, @phoneNumber)
End