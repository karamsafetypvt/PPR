
create or alter Procedure [dbo].[Proc_DesignDataSheet]
(
@ProjectID bigint,
@PlanID int,
@ProjectTitle Nvarchar(100),
@ProjectNO Nvarchar(100),
@Coordinator Nvarchar(100),
@ProductRefNo Nvarchar(100),
@Functional_Performar_Requirement Nvarchar(500),
@StaticStrength bit,
@DynamicStrength bit,
@corrosionResistance bit,
@Other bit,
@MaterialSpecific bit,
@ProcessSpecific bit,
@Statutory_Regulatory_Requirement Nvarchar(500),
@SPECIAL_ENVIRONMENT_CONDITIONS Nvarchar(500),
@Packaging bit,
@StickerLabels bit,
@UserInstruction bit,
@INFORMATION_EARLIER_PROJECTS  Nvarchar(500),
@CUSTOMER_IN_DEVELOPMENT  Nvarchar(500),
--@CreatedDate datetime,
--@UpdatedDate datetime,
@CreatedBy nvarchar(20),
@UpdatedBy nvarchar(20),
@Status Nvarchar(10), 
@OpCode int,
@returnResult int output
)
as 
begin 
if @OpCode=1
		--if(@ProjectID=0)
		begin 
		INSERT INTO [dbo].[DesignInputDataSheet]
           ([ProjectID] ,[ProjectNO] ,[ProjectTitle] ,[Coordinator] ,[ProductRefNo] ,[Functional_Performar_Requirement]
           ,[StaticStrength] ,[DynamicStrength] ,[corrosionResistance] ,[Other] ,[MaterialSpecific] ,[ProcessSpecific]
		   ,[Statutory_Regulatory_Requirement] ,[SPECIAL_ENVIRONMENT_CONDITIONS] ,[Packaging] ,[StickerLabels]  
		   ,[UserInstruction] ,[INFORMATION_EARLIER_PROJECTS],[CUSTOMER_IN_DEVELOPMENT] ,[CreatedDate] ,[UpdatedDate]
           ,[UpdatedBy] ,[CreatedBy] ,[Status])

		Values
			(@ProjectID,@ProjectNO,@ProjectTitle,@Coordinator,@ProductRefNo,@Functional_Performar_Requirement
			,@StaticStrength,@DynamicStrength,@corrosionResistance,@Other,@MaterialSpecific,@ProcessSpecific
			,@Statutory_Regulatory_Requirement,@SPECIAL_ENVIRONMENT_CONDITIONS,@Packaging,@StickerLabels,
			@UserInstruction,@INFORMATION_EARLIER_PROJECTS,@CUSTOMER_IN_DEVELOPMENT,GETDATE(),GETDATE()
			,@CreatedBy,@UpdatedBy,@Status)
		Set @returnResult=11
		end
		--else
		--begin 
		--Update Product_Master Set 
		--ProjectTitle=@ProjectTitle,ProjectNumber=@ProjectNO,Coordinator=@Coordinator,Product_Category=@ProductCategory,
		--Product_Ref_No=@ProductRefNo,ProductDescription=@ProductDescription,
		--CompanyId=@CompanyName,OpeningDate=@OpeningDate,ClosingDate=@ClosingDate,UpdateDate=GetDate(),
		--UpdateddBy=@CreatedBy,Status=@Status where  ID=@ProjectID
		--Set @returnResult=12
		--end
 end