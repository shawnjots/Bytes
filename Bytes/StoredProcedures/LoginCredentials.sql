USE [Bytes]
GO
/****** Object:  StoredProcedure [dbo].[LoginCredentials]    Script Date: 8/16/2017 21:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[LoginCredentials]  
(

	@username nvarchar(50),
    @password nvarchar(50))

as
Select SalesPerson.employeeID, Manager.employeeID from SalesPerson, Manager where(SalesPerson.username = @username AND SalesPerson.password = @password AND Manager.username = @username AND Manager.password = @password)
