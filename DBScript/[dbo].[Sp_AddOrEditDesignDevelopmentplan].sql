USE [PPR]
GO
/****** Object:  StoredProcedure [dbo].[Sp_AddOrEditDesignDevelopmentplan]    Script Date: 03-Mar-23 3:31:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[Sp_AddOrEditDesignDevelopmentplan]
(
@ProjectID bigint,
@activitydata xml=null
)
as
--if @call_name='Save_ItemInfo' goto Save_ItemInfo
begin
		Select t.value('ProjectID[1]','bigint')as ProjectID,
		t.value('ActivityId[1]','bigint')as ActivityId,
		t.value('Nature[1]','varchar(50)')as Nature,
		t.value('ResourcesReq[1]','nvarchar(100)')as ResourcesReq,
		t.value('Responsibility[1]','nvarchar(100)')as Responsibility,
		t.value('AssignedDate[1]','datetime')as AssignedDate,
		t.value('TargetDate[1]','datetime')as TargetDate,
		t.value('ApprovingAuthority[1]','nvarchar(100)')as ApprovingAuthority,
		t.value('CompletionDate[1]','datetime')as CompletionDate,
		t.value('Remark[1]','nvarchar(max)')as Remark,
		t.value('Aging[1]','int')as Aging,
		t.value('Createdby[1]','nvarchar(100)')as Createdby
		into #Tbl1
		from @activitydata.nodes('/myDataSet/tblItem')as template(t)

		Delete From DesignDevelopmentplan where ProjectID=@ProjectID

		insert into DesignDevelopmentplan(
		ProjectID,
		ActivityID,
		Nature,
		ResourcesReq,
		Responsibility,
		AssignedDate,
		TargetDate,
		ApprovingAuthority,
		CompletionDate,
		Remark,
		Aging,
		Createdby,
		CreateDate,
		Status
		)
		Select ProjectID,
		ActivityID,
		Nature,
		ResourcesReq,
		Responsibility,
		AssignedDate,
		TargetDate,
		ApprovingAuthority,
		CompletionDate,
		Remark,
		Aging,
		Createdby,
		GetDate(),1
		from #Tbl1
		drop table #Tbl1
		end
		