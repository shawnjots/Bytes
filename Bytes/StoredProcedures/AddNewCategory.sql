Create Procedure [dbo].[AddNewCategory]
(
    @categoryName nvarchar(50)
)
as
begin
    Insert into Category values(@categoryName)
End