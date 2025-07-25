USE [PPR]
GO
/****** Object:  StoredProcedure [dbo].[PPR_UserLogin]    Script Date: 03-Mar-23 5:25:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[PPR_UserLogin]
(@UserId varchar(50)
)
as 
begin
	
	if @UserId in ('Admin','Admin123@gmail.com')
	begin
		Select UserId, UserName, CompanyId, Email, Mobileno, Password,
		CreatedBy, CreateDate, UpdatedBy, UpdatedDate,UserType from LoginMaster
		Where UserName=@UserId or Email=@UserId
	end
	else
	begin
		select Sr#No as UserId,NAME as UserName,CompanyID as CompanyId,[Email ID] as Email,
		[MOBILE NUMBER] as Mobileno,Password,NAME as CreatedBy,GETDATE() as CreateDate,
		NAME as UpdatedBy,GETDATE() as UpdatedDate,2 as UserType from [MasterDatabase].dbo.[Master_Requestor]
		where DepartmentID in (9,37) and EMPLOYEE_ID=@UserId
	end
end




SET ANSI_NULLS ON
