USE [PPR]
GO
/****** Object:  StoredProcedure [dbo].[Proc_DesignValidationDataSheet]    Script Date: 14-Mar-23 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   Procedure [dbo].[Proc_DesignValidationDataSheet]
(
@ProjectID bigint,
@PlanID int,
@FEEDBACKRECEIVED bit,
@IMPROVEMENTSREQUIRED bit,
@ACTIONPLAN bit,
@TARGETDATE bit,
@RESPONSIBILITY bit,
@SAMPLESRESUBMITTEDON bit,
@FINALFEEDBACK bit,
@REMARKS bit,
@CreatedBy nvarchar(100),
@Status int,
@SampleSentToKTC bit,
@DateOfSampleSent datetime,
@Reason nvarchar(max),
@OpCode int,
@returnResult int output
)
as 
begin 
if @OpCode=11
        if(select COUNT(1) from [dbo].[DesignValidation] where ProjectID=@ProjectID and PlanID=@PlanID)<=0
        begin 
           INSERT INTO [dbo].[DesignValidation]
           ([ProjectID],[PlanID],FeedBackReceived ,IMPROVEMENTSREQUIRED ,ACTIONPLAN ,TARGETDATE ,RESPONSIBILITY
           ,SAMPLESRESUBMITTEDON ,FINALFEEDBACK ,REMARKS ,[CreatedBy],CreatedDate ,[Status],SampleSentToKTC,DateOfSampleSent,Reason)
           Values
            (@ProjectID,@PlanID,@FEEDBACKRECEIVED,@IMPROVEMENTSREQUIRED,@ACTIONPLAN,@TARGETDATE,@RESPONSIBILITY
            ,@SAMPLESRESUBMITTEDON,@FINALFEEDBACK,@REMARKS,@CreatedBy,GETDATE(),1,@SampleSentToKTC,@DateOfSampleSent,@Reason)
            Set @returnResult=11
        end
        else
        begin 
			update [dbo].[DesignValidation] set FeedBackReceived=@FeedBackReceived ,
			IMPROVEMENTSREQUIRED=@IMPROVEMENTSREQUIRED ,
			ACTIONPLAN=@ACTIONPLAN ,TARGETDATE=@TARGETDATE
			,RESPONSIBILITY=@RESPONSIBILITY,SAMPLESRESUBMITTEDON=@SAMPLESRESUBMITTEDON ,
			FINALFEEDBACK=@FINALFEEDBACK,
			REMARKS=@REMARKS ,[UpdatedBy]=@CreatedBy,UpdatedDate=GETDATE(),[Status]=1,
			SampleSentToKTC=@SampleSentToKTC,DateOfSampleSent=@DateOfSampleSent,Reason=@Reason
			where ProjectID=@ProjectID and PlanID=@PlanID 
            Set @returnResult=12
        end
end