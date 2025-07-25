USE [PPR]
GO
/****** Object:  StoredProcedure [dbo].[GetAllActivity]    Script Date: 03-Mar-23 3:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[GetAllActivity]
(
@ProjectID int
)
as
begin
  if (select COUNT(1) from [dbo].[DesignDevelopmentplan] where ProjectID=@ProjectID)>0
  begin
       select dp.Id as PlanId,dp.ActivityID as Id,am.ActivityName,am.Status,am.ResourcesReq,
	   am.Responsibility,am.ApprovingAuthority,
	   --am.Nature
	   (select Nature_Name from Nature_Master as nm where nm.Id=am.Nature) as Nature
	   ,SubActivityName,REPLACE (SubActivityName, ' ', '' ) AS SubActivityPageName,
	   CONVERT(varchar(20),dp.AssignedDate,103) as AssignedDate,
	   CONVERT(varchar(20),dp.TargetDate,103) as TargetDate,
	   CONVERT(varchar(20),dp.CompletionDate,103) as CompletionDate,
	   Remark,Aging
	   from DesignDevelopmentplan as dp
	   inner join ActivityMaster as am on am.Id=dp.ActivityID
	   left join [dbo].[SubActivityMaster] as sm on sm.ID=am.[SubActivityID]
	   where ProjectID=@ProjectID
	   order by id asc

	   Select ID, ProjectTitle,ProjectNumber,Coordinator,Product_Ref_No,OpeningDate from Product_Master 
		where ID=@ProjectID
  end
  else
  begin
		Select 0 as PlanId ,am.Id,ActivityName,am.Status,ResourcesReq,[Responsibility],[ApprovingAuthority],
		(select Nature_Name from Nature_Master as nm where nm.Id=am.Nature) as Nature,
		SubActivityName,REPLACE (SubActivityName, ' ', '' ) AS SubActivityPageName,
		'' as AssignedDate,'' as TargetDate,'' as CompletionDate,'' as Remark,0 as Aging
		from ActivityMaster as am
		left join [dbo].[SubActivityMaster] as sm on sm.ID=am.[SubActivityID]  --where am.Status='Active'
		order by am.id asc

		Select ID, ProjectTitle,ProjectNumber,Coordinator,Product_Ref_No,OpeningDate from Product_Master 
		where ID=@ProjectID 
	end
end