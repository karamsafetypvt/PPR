
create or alter   Procedure [dbo].[Proc_DesignVerification]
(
@ProjectID bigint,
@PlanID int
,@Functional_Performar_Requirement nvarchar(100)
,@Functional_Performar_Observation  nvarchar(100)
,@Functional_Performar_Remarks nvarchar(max)
,@Static_Strengh_Req nvarchar(100)
,@Static_Strengh_Observation nvarchar(100)
,@Static_Strengh_Remarks nvarchar(max)
,@Dynamic_Strengh_Requirement nvarchar(100)
,@Dynamic_Strengh_Observation nvarchar(100)
,@Dynamic_Strengh_Remarks nvarchar(max)
,@corrosion_Resistance_Requirement nvarchar(100)
,@corrosion_Resistance_Observation nvarchar(100)
,@corrosion_Resistance_Remarks nvarchar(max)
,@Other_Requirement nvarchar(100)
,@Other_Observation nvarchar(100)
,@Other_Remarks nvarchar(max)
,@MaterialSpecific_Requirement nvarchar(100)
,@MaterialSpecific_Observation nvarchar(100)
,@MaterialSpecific_Remarks nvarchar(max)
,@ProcessSpecific_Requirement nvarchar(100)
,@ProcessSpecific_Observation nvarchar(100)
,@ProcessSpecific_Remarks nvarchar(max)
,@Statutory_Regulatory_Requirement nvarchar(100)
,@Statutory_Regulatory_Observation nvarchar(100)
,@Statutory_Regulatory_Remark nvarchar(max)
,@SPECIAL_ENVIRONMENT_CONDITIONS_Req nvarchar(100)
,@SPECIAL_ENVIRONMENT_CONDITIONS_Observation nvarchar(100)
,@SPECIAL_ENVIRONMENT_CONDITIONS_Remarks nvarchar(max)
,@Packaging_Requirement nvarchar(100)
,@Packaging_Observation nvarchar(100)
,@Packaging_Remarks nvarchar(max)
,@StickerLabel_Requirement nvarchar(100)
,@StickerLabel_Observation nvarchar(100)
,@StickerLabel_Remarks nvarchar(max)
,@UserInstruction_Requirement nvarchar(100)
,@UserInstruction_Observation nvarchar(100)
,@UserInstruction_Remarks nvarchar(max)
,@INFORMATION_EARLIER_PROJECTS_REQ nvarchar(100)
,@INFORMATION_EARLIER_PROJECTS_Observation nvarchar(100)
,@INFORMATION_EARLIER_PROJECTS_Remarks nvarchar(max)
,@CUSTOMER_IN_DEVELOPMENT_REQ nvarchar(100)
,@CUSTOMER_IN_DEVELOPMENT_Observation nvarchar(100)
,@CUSTOMER_IN_DEVELOPMENT_Remarks nvarchar(100),
@CreatedBy nvarchar(20),
@Status Nvarchar(10), 
@OpCode int,
@returnResult int output
)
as 
begin 
if @OpCode=11
		if(select COUNT(1) from [dbo].[DesignVerification] where ProjectID=@ProjectID and PlanID=@PlanID)<=0
		begin 
		INSERT INTO [dbo].[DesignVerification]
          ([ProjectID],[PlanID],[Functional_Performar_Requirement],[Functional_Performar_Observation]
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
			[CUSTOMER_IN_DEVELOPMENT_Remarks],[CreatedDate],[CreatedBy])

		Values
			(@ProjectID,@PlanID,@Functional_Performar_Requirement,@Functional_Performar_Observation,
			@Functional_Performar_Remarks,@Static_Strengh_Req,@Static_Strengh_Observation
			,@Static_Strengh_Remarks,@Dynamic_Strengh_Requirement,@Dynamic_Strengh_Observation,
			@Dynamic_Strengh_Remarks,@corrosion_Resistance_Requirement,@corrosion_Resistance_Observation,
			@corrosion_Resistance_Remarks,@Other_Requirement,@Other_Observation,@Other_Remarks,
			@MaterialSpecific_Requirement,@MaterialSpecific_Observation,@MaterialSpecific_Remarks,
			@ProcessSpecific_Requirement,@ProcessSpecific_Observation,@ProcessSpecific_Remarks,
			@Statutory_Regulatory_Requirement,@Statutory_Regulatory_Observation,@Statutory_Regulatory_Remark
			,@SPECIAL_ENVIRONMENT_CONDITIONS_Req,@SPECIAL_ENVIRONMENT_CONDITIONS_Observation,
			@SPECIAL_ENVIRONMENT_CONDITIONS_Remarks,@Packaging_Requirement,
			@Packaging_Observation,@Packaging_Remarks,@StickerLabel_Requirement,@StickerLabel_Observation,
			@StickerLabel_Remarks,@UserInstruction_Requirement,@UserInstruction_Observation,
			@UserInstruction_Remarks,@INFORMATION_EARLIER_PROJECTS_REQ,@INFORMATION_EARLIER_PROJECTS_Observation,
			@INFORMATION_EARLIER_PROJECTS_Remarks,@CUSTOMER_IN_DEVELOPMENT_REQ,@CUSTOMER_IN_DEVELOPMENT_Observation,
			@CUSTOMER_IN_DEVELOPMENT_Remarks,GETDATE()
			,@CreatedBy)
		    Set @returnResult=11
		end
		else
		begin 
			update [dbo].[DesignVerification] set [ProjectID]=@ProjectID,[PlanID]=@PlanID
			,[Functional_Performar_Requirement]=@Functional_Performar_Requirement,
			[Functional_Performar_Observation]=@Functional_Performar_Observation
           ,[Functional_Performar_Remarks]=@Functional_Performar_Remarks,
		   [Static_Strengh_Req]=@Static_Strengh_Req,[Static_Strengh_Observation]=@Static_Strengh_Observation
           ,[Static_Strengh_Remarks]=@Static_Strengh_Remarks,[Dynamic_Strengh_Requirement]=@Dynamic_Strengh_Requirement
		   ,[Dynamic_Strengh_Observation]=@Dynamic_Strengh_Observation
           ,[Dynamic_Strengh_Remarks]=@Dynamic_Strengh_Remarks
		   ,[corrosion_Resistance_Requirement]=@corrosion_Resistance_Requirement,
		   [corrosion_Resistance_Observation]=@corrosion_Resistance_Observation
           ,[corrosion_Resistance_Remarks]=@corrosion_Resistance_Remarks,[Other_Requirement]=@Other_Requirement
		   ,[Other_Observation]=@Other_Observation,[Other_Remarks]=@Other_Remarks
           ,[MaterialSpecific_Requirement]=@MaterialSpecific_Requirement
		   ,[MaterialSpecific_Observation]=@MaterialSpecific_Observation,[MaterialSpecific_Remarks]=@MaterialSpecific_Remarks
           ,[ProcessSpecific_Requirement]=@ProcessSpecific_Requirement,
		   [ProcessSpecific_Observation]=@ProcessSpecific_Observation,[ProcessSpecific_Remarks]=@ProcessSpecific_Remarks
           ,[Statutory_Regulatory_Requirement]=@Statutory_Regulatory_Requirement
		   ,[Statutory_Regulatory_Observation]=@Statutory_Regulatory_Observation,
			[Statutory_Regulatory_Remark]=@Statutory_Regulatory_Remark
		   ,[SPECIAL_ENVIRONMENT_CONDITIONS_Req]=@SPECIAL_ENVIRONMENT_CONDITIONS_Req,
			[SPECIAL_ENVIRONMENT_CONDITIONS_Observation]=@SPECIAL_ENVIRONMENT_CONDITIONS_Observation,
			[SPECIAL_ENVIRONMENT_CONDITIONS_Remarks]=@SPECIAL_ENVIRONMENT_CONDITIONS_Remarks,
		   [Packaging_Requirement]=@Packaging_Requirement
           ,[Packaging_Observation]=@Packaging_Observation,
		   [Packaging_Remarks]=@Packaging_Remarks
		   ,[StickerLabel_Requirement]=@StickerLabel_Requirement,
		   [StickerLabel_Observation]=@StickerLabel_Observation
           ,[StickerLabel_Remarks]=@StickerLabel_Remarks,
		   [UserInstruction_Requirement]=@UserInstruction_Requirement
		   ,[UserInstruction_Observation]=@UserInstruction_Observation
           ,[UserInstruction_Remarks]=@UserInstruction_Remarks,
			[INFORMATION_EARLIER_PROJECTS_REQ]=@INFORMATION_EARLIER_PROJECTS_REQ,
			[INFORMATION_EARLIER_PROJECTS_Observation]=@INFORMATION_EARLIER_PROJECTS_Observation,
			[INFORMATION_EARLIER_PROJECTS_Remarks]=@INFORMATION_EARLIER_PROJECTS_Remarks
		   ,[CUSTOMER_IN_DEVELOPMENT_REQ]=@CUSTOMER_IN_DEVELOPMENT_REQ,
			[CUSTOMER_IN_DEVELOPMENT_Observation]=@CUSTOMER_IN_DEVELOPMENT_Observation,
			[CUSTOMER_IN_DEVELOPMENT_Remarks]=@CUSTOMER_IN_DEVELOPMENT_Remarks,
           [UpdatedDate]=GETDATE(),[UpdatedBy]=@CreatedBy
			where ProjectID=@ProjectID and PlanID=@PlanID 
		    Set @returnResult=12
		end

 end