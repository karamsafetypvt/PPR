 
alter   Procedure [dbo].[Proc_GetDesignVerificationData]
(
@ProjectID bigint,
@PlanID int
)
as 
begin 
		select [ID],[ProjectID],[PlanID],[Functional_Performar_Requirement],[Functional_Performar_Observation]
           ,[Functional_Performar_Remarks],[Static_Strengh_Req],[Static_Strengh_Observation]
           ,[Static_Strengh_Remarks],[Dynamic_Strengh_Requirement],[Dynamic_Strengh_Observation]
           ,[Dynamic_Strengh_Remarks],[corrosion_Resistance_Requirement],[corrosion_Resistance_Observation]
           ,[corrosion_Resistance_Remarks],[Other_Requirement],[Other_Observation],[Other_Remarks]
           ,[MaterialSpecific_Requirement],[MaterialSpecific_Observation],[MaterialSpecific_Remarks]
           ,[ProcessSpecific_Requirement],[ProcessSpecific_Observation],[ProcessSpecific_Remarks]
           ,[Statutory_Regulatory_Requirement],[Statutory_Regulatory_Observation],[Statutory_Regulatory_Remark]
		   ,[SPECIAL_ENVIRONMENT_CONDITIONS_Req],[SPECIAL_ENVIRONMENT_CONDITIONS_Observation],
		   [SPECIAL_ENVIRONMENT_CONDITIONS_Remarks],[Packaging_Requirement]
           ,[Packaging_Observation],[Packaging_Remarks],[StickerLabel_Requirement],[StickerLabel_Observation]
           ,[StickerLabel_Remarks],[UserInstruction_Requirement],[UserInstruction_Observation]
           ,[UserInstruction_Remarks],[INFORMATION_EARLIER_PROJECTS_REQ],[INFORMATION_EARLIER_PROJECTS_Observation],
		   [INFORMATION_EARLIER_PROJECTS_Remarks],[CUSTOMER_IN_DEVELOPMENT_REQ],[CUSTOMER_IN_DEVELOPMENT_Observation],
			[CUSTOMER_IN_DEVELOPMENT_Remarks] from  [dbo].[DesignVerification]
		   where ProjectID=@ProjectID and PlanID=@PlanID

		select ProjectNumber,ProjectTitle,Coordinator,Product_Ref_No,
		convert(varchar(20),OpeningDate,103) as ProjectDate
		from Product_Master where ID=@ProjectID

 end