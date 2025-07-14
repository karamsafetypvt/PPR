using FPDAL.Data;
using Infotech.ClassLibrary;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRDAL.Data
{
    public class DevelopmentPlanData : ConnectionObjects
    {
        public DataSet SelectAll(string ProjectID, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                           new SqlParameter("@ProjectID",ProjectID) ,
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetAllActivity", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "SelectAll");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }

        public DataSet SelectAllDesignDevelopmentPlanById(DevelopmentPlanModel model, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                           new SqlParameter("@ProjectID",model.ProjectID) ,
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.SelectAllDesignDevelopmentPlanById", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "SelectAllDesignDevelopmentPlanById");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        public int AddOrEdit(DevelopmentPlanModel model, DataTable dt, out Int32 ReturnResult)
        {
            try {
                DataTable dt1 = new DataTable();
                ReturnResult = 0;
                dt.TableName = "tblItem";
                DataSet myDataSet = new DataSet("myDataSet");
                myDataSet.Tables.Add(dt);
                string constr = ConfigurationManager.ConnectionStrings["DBPPR"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("dbo.Sp_AddOrEditDesignDevelopmentplan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProjectID", model.ProjectID));
                cmd.Parameters.Add("@activitydata", SqlDbType.Xml).Value = (myDataSet == null ? null : myDataSet.GetXml());
                da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
                int result = Convert.ToInt32(dt1.Rows[0]["returnResult"]);
                return result;
            }
            catch(Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "AddOrEdit");
                ReturnResult = -1;
                return 0;
            }
            
        }

        public DataSet DesignInputDataSheet(DesignDataSheetModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                            new SqlParameter("@OpCode",11),
                                            new SqlParameter("@ProjectID",model.ProjectID),
                                            new SqlParameter("@PlanID",model.PlanID),
                                            new SqlParameter("@ProjectNO",model.ProjectNO??string.Empty),
                                            new SqlParameter("@ProjectTitle",model.ProjectTitle??string.Empty),
                                            new SqlParameter("@Coordinator",model.Coordinator),
                                            new SqlParameter("@ProductRefNo",model.ProductRefNo),
                                            new SqlParameter("@Functional_Performar_Requirement",model.Functional_Performar_Requirement),
                                            new SqlParameter("@StaticStrength",model.StaticStrength),
                                            new SqlParameter("@DynamicStrength",model.DynamicStrength),
                                            new SqlParameter("@corrosionResistance",model.corrosionResistance),
                                             new SqlParameter("@Other",model.Other),
                                            new SqlParameter("@Static_Unit",model.Static_Unit),
                                            new SqlParameter("@Dynamic_Unit",model.Dyanmic_Unit),
                                            new SqlParameter("@corrosion_Unit",model.Corrosion_Unit),
                                            new SqlParameter("@Other_Unit",model.Other_Unit),

                                            new SqlParameter("@MaterialSpecific_Unit",model.MaterialSpecific_Unit),
                                            new SqlParameter("@MaterialSpecific",model.MaterialSpecific),
                                            new SqlParameter("@ProcessSpecific",model.ProcessSpecific),
                                            new SqlParameter("@ProcessSpecific_Unit",model.ProcessSpecific_Unit),
                                            new SqlParameter("@Statutory_Regulatory_Requirement",model.Statutory_Regulatory_Requirement),
                                            new SqlParameter("@SPECIAL_ENVIRONMENT_CONDITIONS",model.SPECIAL_ENVIRONMENT_CONDITIONS),

                                            new SqlParameter("@Packaging_Unit",model.Packaging_Unit),
                                            new SqlParameter("@StickerLabels_Unit",model.StickerLabels_Unit),
                                            new SqlParameter("@UserInstruction_Unit",model.UserInstruction_Unit),
                                            new SqlParameter("@Packaging",model.Packaging),
                                            new SqlParameter("@StickerLabels",model.StickerLabels),
                                            new SqlParameter("@UserInstruction",model.UserInstruction),
                                            

                                            new SqlParameter("@INFORMATION_EARLIER_PROJECTS",model.INFORMATION_EARLIER_PROJECTS),
                                            new SqlParameter("@CUSTOMER_IN_DEVELOPMENT",model.CUSTOMER_IN_DEVELOPMENT),
                                            //new SqlParameter("@CreatedDate",model.CreatedDate),
                                            //new SqlParameter("@UpdatedDate",model.UpdatedDate),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@UpdatedBy",model.UpdatedBy),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                            new SqlParameter("@Benchmarking_Criteria",model.Benchmarking_Criteria),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_DesignDataSheet", parameters);
                ReturnResult = Convert.ToInt32(parameters[33].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "DesignInputDataSheet");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }


        public DataSet GetData(string ProjectID, string PlanID, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                           new SqlParameter("@ProjectID",ProjectID) ,
                                           new SqlParameter("@PlanID",PlanID)
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetDataDesignDataSheet", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "GetData");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        #region DesignReview
        public DataSet DesignReviewDataSheet(DesignReviewModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                            new SqlParameter("@OpCode",11),
                                            new SqlParameter("@ProjectID",model.ProjectID),
                                            new SqlParameter("@PlanID",model.PlanID),
                                            new SqlParameter("@AVAILABILITYOFMATERIALSPROPOSED_STATUS",model.AVAILABILITYOFMATERIALSPROPOSED_STATUS),
                                            new SqlParameter("@AVAILABILITYOFMATERIALSPROPOSED_REMARKS",model.AVAILABILITYOFMATERIALSPROPOSED_REMARKS??string.Empty),
                                            new SqlParameter("@WORKABILITYOFDESIGNASPERFUNCTIONALPERFORMANCEREQUIREMENTS_STATUS",
                                                  model.WORKABILITYOFDESIGNASPERFUNCTIONALPERFORMANCEREQUIREMENTS_STATUS),
                                            new SqlParameter("@WORKABILITYOFDESIGNASPERFUNCTIONALPERFORMANCEREQUIREMENTS_REMARKS",model.WORKABILITYOFDESIGNASPERFUNCTIONALPERFORMANCEREQUIREMENTS_REMARKS),
                                            new SqlParameter("@FEASIBILITYOFMANUFACTURINGINCLUDINGTOOLMAKING_STATUS",model.FEASIBILITYOFMANUFACTURINGINCLUDINGTOOLMAKING_STATUS),
                                            new SqlParameter("@FEASIBILITYOFMANUFACTURINGINCLUDINGTOOLMAKING_REMARKS",model.FEASIBILITYOFMANUFACTURINGINCLUDINGTOOLMAKING_REMARKS),
                                            new SqlParameter("@PROBABILITYOFMEETINGTHETESTRESULTS_STATUS",model.PROBABILITYOFMEETINGTHETESTRESULTS_STATUS),
                                            new SqlParameter("@PROBABILITYOFMEETINGTHETESTRESULTS_REMARKS",model.PROBABILITYOFMEETINGCONSTRUCTIONAL_REMARKS),
                                            new SqlParameter("@PROBABILITYOFMEETINGCONSTRUCTIONAL_STATUS",model.PROBABILITYOFMEETINGCONSTRUCTIONAL_STATUS),
                                            new SqlParameter("@PROBABILITYOFMEETINGCONSTRUCTIONAL_REMARKS",model.PROBABILITYOFMEETINGCONSTRUCTIONAL_REMARKS),
                                            new SqlParameter("@PROBABILITYOFMEETINGSTATUTORYREGULATORYREQUIREMENTS_STATUS",model.PROBABILITYOFMEETINGSTATUTORYREGULATORYREQUIREMENTS_STATUS),
                                            new SqlParameter("@PROBABILITYOFMEETINGSTATUTORYREGULATORYREQUIREMENTS_REMARKS",model.PROBABILITYOFMEETINGSTATUTORYREGULATORYREQUIREMENTS_REMARKS),
                                            new SqlParameter("@EASEOFPACKAGINGAVAILABILITY_STATUS",model.EASEOFPACKAGINGAVAILABILITY_STATUS),
                                            new SqlParameter("@EASEOFPACKAGINGAVAILABILITY_REMARKS",model.EASEOFPACKAGINGAVAILABILITY_REMARKS),
                                            new SqlParameter("@EASEOFINSTALLATIONBYUSER_STATUS",model.EASEOFINSTALLATIONBYUSER_STATUS),
                                            new SqlParameter("@EASEOFINSTALLATIONBYUSER_REMARKS",model.EASEOFINSTALLATIONBYUSER_REMARKS),
                                            new SqlParameter("@FTOSEARCHINCOORDINATIONWITHKARAMIPRTEAM_STATUS",model.FTOSEARCHINCOORDINATIONWITHKARAMIPRTEAM_STATUS),
                                            new SqlParameter("@FTOSEARCHINCOORDINATIONWITHKARAMIPRTEAM_REMARKS",model.FTOSEARCHINCOORDINATIONWITHKARAMIPRTEAM_REMARKS),
                                            new SqlParameter("@AVAILABILITYOFMANPOWER_STATUS",model.AVAILABILITYOFMANPOWER_STATUS),
                                            new SqlParameter("@AVAILABILITYOFMANPOWER_REMARKS",model.AVAILABILITYOFMANPOWER_REMARKS),
                            new SqlParameter("@AVAILABILITYOFMACHINERY_STATUS",model.AVAILABILITYOFMACHINERY_STATUS),
                                            new SqlParameter ("@AVAILABILITYOFMACHINERY_REMARKS",model.AVAILABILITYOFMACHINERY_REMARKS),
                                            new SqlParameter ("@REMARKS",model.Remarks),
                                            new SqlParameter ("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@DocumentPath",model.DesignReview_DOCUMENTSPATH),
                                            new SqlParameter("@DocumentName",model.DesignReview_DocumentName),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_DesignReviewDataSheet", parameters);
                ReturnResult = Convert.ToInt32(parameters[30].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "DesignReviewDataSheet");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        public DataSet GetDesignReviewData(string ProjectID, string PlanID, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                           new SqlParameter("@ProjectID",ProjectID) ,
                                           new SqlParameter("@PlanID",PlanID)
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo_GetDesignReviewDataSheet", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "GetDesignReviewData");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        #endregion

        #region QualityPlan
        public DataSet QualityPlanDataSheet(QualityPlanModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                            new SqlParameter("@OpCode",11),
                                            new SqlParameter("@ProjectID",model.ProjectID),
                                            new SqlParameter("@PlanID",model.PlanID),
                                            new SqlParameter("@WORKINSTRUCTIONS_STATUS",model.WORKINSTRUCTIONS_STATUS),
                                            new SqlParameter("@WORKINSTRUCTIONS_DOCUMENTS",model.WORKINSTRUCTIONS_DOCUMENTSPATH??string.Empty),
                                            new SqlParameter("@WORKINSTRUCTIONS_REMARKS",model.WORKINSTRUCTIONS_REMARKS),
                                            new SqlParameter("@WORKINSTRUCTIONS_DocumentName",model.WORKINSTRUCTIONS_DocumentName),
                                            
                                            new SqlParameter("@INSPECTIONCRITERION_STATUS",model.INSPECTIONCRITERION_STATUS),
                                            new SqlParameter("@INSPECTIONCRITERION_DOCUMENTS",model.INSPECTIONCRITERION_DOCUMENTSPATH),
                                            new SqlParameter("@INSPECTIONCRITERION_REMARKS",model.INSPECTIONCRITERION_REMARKS),
                                            new SqlParameter("@INSPECTIONCRITERION_DocumentName",model.INSPECTIONCRITERION_DocumentName),
                                            
                                            new SqlParameter("@TESTINGPLAN_STATUS",model.TESTINGPLAN_STATUS),
                                            new SqlParameter("@TESTINGPLAN_DOCUMENTS",model.TESTINGPLAN_DOCUMENTSPATH),
                                            new SqlParameter("@TESTINGPLAN_REMARKS",model.TESTINGPLAN_REMARKS),
                                            new SqlParameter("@TESTINGPLAN_DocumentName",model.TESTINGPLAN_DocumentName),
                                            
                                            new SqlParameter("@TechnicalDataSheet_STATUS",model.TechnicalDataSheet_STATUS),
                                            new SqlParameter("@TechnicalDataSheet_DOCUMENTS",model.TechnicalDataSheet_DOCUMENTSPATH),
                                            new SqlParameter("@TechnicalDataSheet_REMARKS",model.TechnicalDataSheet_REMARKS),
                                             new SqlParameter("@TechnicalDataSheet_DocumentName",model.TechnicalDataSheet_DocumentName),
                                            
                                            new SqlParameter("@TechnicalDrawings_STATUS",model.TechnicalDrawings_STATUS),
                                            new SqlParameter("@TechnicalDrawings_DOCUMENTS",model.TechnicalDrawings_DOCUMENTSPATH),
                                            new SqlParameter("@TechnicalDrawings_REMARKS",model.TechnicalDrawings_REMARKS),
                                            new SqlParameter("@TechnicalDrawings_DocumentName",model.TechnicalDrawings_DocumentName),
                                            
                                            new SqlParameter("@TechnicalFile_STATUS",model.TechnicalFile_STATUS),
                                            new SqlParameter("@TechnicalFile_DOCUMENTS",model.TechnicalFile_DOCUMENTSPATH),
                                            new SqlParameter("@TechnicalFile_REMARKS",model.TechnicalFile_REMARKS),
                                            new SqlParameter("@TechnicalFile_DocumentName",model.TechnicalFile_DocumentName),
                                            
                                            new SqlParameter("@UserInstruction_STATUS",model.UserInstruction_STATUS),
                                            new SqlParameter("@UserInstruction_DOCUMENTS",model.UserInstruction_DOCUMENTSPATH),
                                            new SqlParameter ("@UserInstruction_REMARKS",model.UserInstruction_REMARKS),
                                            new SqlParameter("@UserInstruction_DocumentName",model.UserInstruction_DocumentName),
                                            new SqlParameter ("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_QualityPlanInsertDataSheet", parameters);
                ReturnResult = Convert.ToInt32(parameters[33].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "QualityPlanDataSheet");
                ReturnResult = -1;
                return myDataSet;
            }
            finally

            {
            }
        }
        public DataSet GetQualityPlanData(string ProjectID, string PlanID, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                           new SqlParameter("@ProjectID",ProjectID) ,
                                           new SqlParameter("@PlanID",PlanID)
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetDataQualityPlanDataSheet", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "GetQualityPlanData");
                ReturnResult = -1;
                return myDataSet;
            }
            finally

            {
            }
        }

        #endregion

        #region DesignVerification
        public DataSet DesignVerification(DesignVerificationModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                            new SqlParameter("@OpCode",11),
                                            new SqlParameter("@ProjectID",model.ProjectID),
                                            new SqlParameter("@PlanID",model.PlanID),
                                            new SqlParameter("@Functional_Performar_Requirement",model.Functional_Performar_Requirement),
                                            new SqlParameter("@Functional_Performar_Observation",model.Functional_Performar_Observation),
                                            new SqlParameter("@Functional_Performar_Remarks",model.Functional_Performar_Remarks),
                                            new SqlParameter("@Static_Strengh_Req",model.Static_Strengh_Req),
                                            new SqlParameter("@Static_Strengh_Observation",model.Static_Strengh_Observation),
                                            new SqlParameter("@Static_Strengh_Remarks",model.Static_Strengh_Remarks),
                                            new SqlParameter("@Dynamic_Strengh_Requirement",model.Dynamic_Strengh_Requirement),
                                            new SqlParameter("@Dynamic_Strengh_Observation",model.Dynamic_Strengh_Observation),
                                            new SqlParameter("@Dynamic_Strengh_Remarks",model.Dynamic_Strengh_Remarks),
                                            new SqlParameter("@corrosion_Resistance_Requirement",model.corrosion_Resistance_Requirement),
                                            new SqlParameter("@corrosion_Resistance_Observation",model.corrosion_Resistance_Observation),
                                            new SqlParameter("@corrosion_Resistance_Remarks",model.corrosion_Resistance_Remarks),
                                            new SqlParameter("@Other_Requirement",model.Other_Requirement),
                                            new SqlParameter("@Other_Observation",model.Other_Observation),
                                            new SqlParameter("@Other_Remarks",model.Other_Remarks),
                                            new SqlParameter("@MaterialSpecific_Requirement",model.MaterialSpecific_Requirement),
                                            new SqlParameter("@MaterialSpecific_Observation",model.MaterialSpecific_Observation),
                                            new SqlParameter("@MaterialSpecific_Remarks",model.MaterialSpecific_Remarks),
                                            new SqlParameter("@ProcessSpecific_Requirement",model.ProcessSpecific_Requirement),
                                            new SqlParameter("@ProcessSpecific_Observation",model.ProcessSpecific_Observation),
                                            new SqlParameter("@ProcessSpecific_Remarks",model.ProcessSpecific_Remarks),
                                            new SqlParameter("@Statutory_Regulatory_Requirement",model.Statutory_Regulatory_Requirement),
                                            new SqlParameter("@Statutory_Regulatory_Observation",model.Statutory_Regulatory_Observation),
                                            new SqlParameter("@Statutory_Regulatory_Remark",model.Statutory_Regulatory_Remark),
                                            new SqlParameter("@SPECIAL_ENVIRONMENT_CONDITIONS_Req",model.SPECIAL_ENVIRONMENT_CONDITIONS_Req),
                                            new SqlParameter("@SPECIAL_ENVIRONMENT_CONDITIONS_Observation",model.SPECIAL_ENVIRONMENT_CONDITIONS_Observation),
                                            new SqlParameter("@SPECIAL_ENVIRONMENT_CONDITIONS_Remarks",model.SPECIAL_ENVIRONMENT_CONDITIONS_Remarks),
                                            new SqlParameter("@Packaging_Requirement",model.Packaging_Requirement),
                                            new SqlParameter("@Packaging_Observation",model.Packaging_Observation),
                                            new SqlParameter("@Packaging_Remarks",model.Packaging_Remarks),
                                            new SqlParameter("@StickerLabel_Requirement",model.StickerLabel_Requirement),
                                            new SqlParameter("@StickerLabel_Observation",model.StickerLabel_Observation),
                                            new SqlParameter("@StickerLabel_Remarks",model.StickerLabel_Remarks),
                                            new SqlParameter("@UserInstruction_Requirement",model.UserInstruction_Requirement),
                                            new SqlParameter("@UserInstruction_Observation",model.UserInstruction_Observation),
                                            new SqlParameter("@UserInstruction_Remarks",model.UserInstruction_Remarks),
                                            new SqlParameter("@INFORMATION_EARLIER_PROJECTS_REQ",model.INFORMATION_EARLIER_PROJECTS_REQ),
                                            new SqlParameter("@INFORMATION_EARLIER_PROJECTS_Observation",model.INFORMATION_EARLIER_PROJECTS_Observation),
                                            new SqlParameter("@INFORMATION_EARLIER_PROJECTS_Remarks",model.INFORMATION_EARLIER_PROJECTS_Remarks),
                                            new SqlParameter("@CUSTOMER_IN_DEVELOPMENT_REQ",model.CUSTOMER_IN_DEVELOPMENT_REQ),
                                            new SqlParameter("@CUSTOMER_IN_DEVELOPMENT_Observation",model.CUSTOMER_IN_DEVELOPMENT_Observation),
                                            new SqlParameter("@CUSTOMER_IN_DEVELOPMENT_Remarks",model.CUSTOMER_IN_DEVELOPMENT_Remarks),
                                            new SqlParameter ("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@Static_Unit",model.Static_Unit),
                                            new SqlParameter("@Dyanmic_Unit",model.Dyanmic_Unit),
                                            new SqlParameter("@Corrosion_Unit",model.Corrosion_Unit),
                                            new SqlParameter("@Other_Unit",model.Other_Unit),
                                            new SqlParameter("@DocumentPath",model.DesignVerification_DOCUMENTSPATH),
                                            new SqlParameter("@DocumentName",model.DesignVerification_DocumentName),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_DesignVerification", parameters);
                ReturnResult = Convert.ToInt32(parameters[53].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "DesignVerification");
                ReturnResult = -1;
                return myDataSet;
            }
            finally

            {
            }
        }
        public DataSet GetDesignVerificationData(string ProjectID, string PlanID, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                           new SqlParameter("@ProjectID",ProjectID) ,
                                           new SqlParameter("@PlanID",PlanID)
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetDesignVerificationData", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "GetDesignVerificationData");
                ReturnResult = -1;
                return myDataSet;
            }
            finally

            {
            }
        }
        #endregion

        #region DesignValidation
        public DataSet DesignValidationInputDataSheet(DesignValidationModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                            new SqlParameter("@OpCode",11),
                                            new SqlParameter("@ProjectID",model.ProjectID),
                                            new SqlParameter("@PlanID",model.PlanID),
                                            new SqlParameter("@FEEDBACKRECEIVED",model.FEEDBACKRECEIVED),
                                            new SqlParameter("@SampleSentToKTC",model.SampleSentToKTC),
                                            new SqlParameter("@DateOfSampleSent",model.DateOfSampleSent),
                                            new SqlParameter("@Reason",model.Reason),
                                            new SqlParameter("@IMPROVEMENTSREQUIRED",model.IMPROVEMENTSREQUIRED),
                                            new SqlParameter("@ACTIONPLAN",model.ACTIONPLAN),
                                            new SqlParameter("@TARGETDATE",model.TARGETDATE),
                                            new SqlParameter("@RESPONSIBILITY",model.RESPONSIBILITY),
                                            new SqlParameter("@SAMPLESRESUBMITTEDON",model.SAMPLESRESUBMITTEDON),
                                            new SqlParameter("@FINALFEEDBACK",model.FINALFEEDBACK),
                                            new SqlParameter("@REMARKS",model.REMARKS),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@DocumentPath",model.DesignValidation_DOCUMENTSPATH),
                                            new SqlParameter("@DocumentName",model.DesignValidation_DocumentName),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_DesignValidationDataSheet", parameters);
                ReturnResult = Convert.ToInt32(parameters[18].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "DesignValidationInputDataSheet");
                ReturnResult = -1;
                return myDataSet;
            }
            finally

            {
            }
        }
        public DataSet GetDesignValidationData(string ProjectID, string PlanID, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                           new SqlParameter("@ProjectID",ProjectID) ,
                                           new SqlParameter("@PlanID",PlanID)
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetDesignValidationDataSheet", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "GetDesignValidationData");
                ReturnResult = -1;
                return myDataSet;
            }
            finally

            {
            }
        }
        #endregion

        #region Induatrilisation 
        public int InduatrilisationInputDataSheet(IndustrialisationModel model, DataTable dt, out Int32 ReturnResult)
        {
            try {
                DataTable dt1 = new DataTable();
                ReturnResult = 0;
                dt.TableName = "tblItem";
                DataSet myDataSet = new DataSet("myDataSet");
                myDataSet.Tables.Add(dt);
                string constr = ConfigurationManager.ConnectionStrings["DBPPR"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("dbo.Sp_AddOrEditInduatrilisationplan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProjectID", model.ProjectID));
                cmd.Parameters.Add(new SqlParameter("@PlanID", model.PlanID));
                cmd.Parameters.Add(new SqlParameter("@ADDITIONALMACHINESREQUIRED", model.ADDITIONALMACHINESREQUIRED));
                cmd.Parameters.Add(new SqlParameter("@JIGFIXTURESTOOLSNew", model.JIGFIXTURESTOOLSNew));
                cmd.Parameters.Add(new SqlParameter("@MODIFICATIONINOLD", model.MODIFICATIONINOLD));
                cmd.Parameters.Add(new SqlParameter("@ADDITIONALTESTEQUIPMENTREQUIRED", model.ADDITIONALTESTEQUIPMENTREQUIRED));
                cmd.Parameters.Add(new SqlParameter("@CHANGEINISODOCUMENT", model.CHANGEINISODOCUMENT));
                cmd.Parameters.Add(new SqlParameter("@UPDATIONINERPSYSTEMS", model.UPDATIONINERPSYSTEMS));
                cmd.Parameters.Add(new SqlParameter("@PLANNINGOFCOMPONENTDEVELOPMENT", model.PLANNINGOFCOMPONENTDEVELOPMENT));
                cmd.Parameters.Add(new SqlParameter("@QUALITYPLAN", model.QUALITYPLAN));
                cmd.Parameters.Add(new SqlParameter("@INDUSTRIALISATIONDate", model.INDUSTRIALISATIONDate ?? null));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", model.CreatedBy));
                cmd.Parameters.Add(new SqlParameter("@DocumentPath", model.QUALITYPLAN_DOCUMENTSPATH));
                cmd.Parameters.Add(new SqlParameter("@OpCode", 11));
                cmd.Parameters.Add("@activitydata", SqlDbType.Xml).Value = (myDataSet == null ? null : myDataSet.GetXml());
                da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
                int result = Convert.ToInt32(dt1.Rows[0]["returnResult"]);
                return result;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "InduatrilisationInputDataSheet");
                ReturnResult = -1;
                return 0;
            }
            
        }

        public int InduatrilisationInputDataSheet_New(IndustrialisationModel_New model, out Int32 ReturnResult)
        {
            try
            {
                DataTable dt1 = new DataTable();
                ReturnResult = 0;
                 
                DataSet myDataSet = new DataSet("myDataSet");
                 
                string constr = ConfigurationManager.ConnectionStrings["DBPPR"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("dbo.Sp_AddOrEditInduatrilisationplan_New", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProjectID", model.ProjectID));
                cmd.Parameters.Add(new SqlParameter("@PlanID", model.PlanID));
                cmd.Parameters.Add(new SqlParameter("@ProductCategory", model.ProductCategory));
                cmd.Parameters.Add(new SqlParameter("@ItemPicture", model.ItemPicture));
                cmd.Parameters.Add(new SqlParameter("@TDS", model.TDS));
                cmd.Parameters.Add(new SqlParameter("@ManualInstruction", model.ManualInstruction));
                cmd.Parameters.Add(new SqlParameter("@Certification", model.Certification));
                cmd.Parameters.Add(new SqlParameter("@ItemCode", model.ItemCode));
                cmd.Parameters.Add(new SqlParameter("@ApplicableStandard", model.ApplicableStandard));
                cmd.Parameters.Add(new SqlParameter("@CustomerName", model.CustomerName));
                cmd.Parameters.Add(new SqlParameter("@BOMCreationStatus", model.BOMCreationStatus));
                cmd.Parameters.Add(new SqlParameter("@SafetyStockCreationStatus", model.SafetyStockCreationStatus));
                cmd.Parameters.Add(new SqlParameter("@Sample", model.Sample));
                cmd.Parameters.Add(new SqlParameter("@Packaging", model.Packaging));
                cmd.Parameters.Add(new SqlParameter("@WorkInstructions", model.WorkInstructions));
                cmd.Parameters.Add(new SqlParameter("@InspectionCriterion", model.InspectionCriterion));
                cmd.Parameters.Add(new SqlParameter("@INDUSTRIALISATIONDate", model.INDUSTRIALISATIONDate ?? null));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", model.CreatedBy));
                cmd.Parameters.Add(new SqlParameter("@DocumentPath", model.QUALITYPLAN_DOCUMENTSPATH));
                cmd.Parameters.Add(new SqlParameter("@Remark", model.Remark));
                cmd.Parameters.Add(new SqlParameter("@OpCode", 11));

                da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
                int result = Convert.ToInt32(dt1.Rows[0]["returnResult"]);
                return result;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "InduatrilisationInputDataSheet_New");
                ReturnResult = -1;
                return 0;
            }

        }

        public DataSet GetIndustrialisationData(string ProjectID, string PlanID, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                           new SqlParameter("@ProjectID",ProjectID) ,
                                           new SqlParameter("@PlanID",PlanID)
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_GetIndustrialisationDataSheet", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanData", "GetIndustrialisationData");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        #endregion
    }
}
