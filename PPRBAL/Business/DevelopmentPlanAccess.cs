using FPDAL.Data;
using PPRBAL.Interface;
using PPRDAL.Data;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Razor.Parser;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PPRBAL.Business
{
    public class DevelopmentPlanAccess : IDevelopmentPlan
    {
        DevelopmentPlanData data = new DevelopmentPlanData();
        public DevelopmentPlanModel GetAllActivity(string ProjectID)
        {
            int returnResult = 0;
            DevelopmentPlanModel response = new DevelopmentPlanModel();
            DevelopmentPlanModelList list = new DevelopmentPlanModelList();
            List<DevelopmentPlanModelList> responseList = new List<DevelopmentPlanModelList>();
            DataSet ds = data.SelectAll(ProjectID, out returnResult);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            list = new DevelopmentPlanModelList();
                            list.PlanID = Convert.ToInt32(row["PlanId"]);
                            list.Progress = Convert.ToInt32(row["TotalProgress"]);
                            list.SelectedProgress = Convert.ToInt32(row["SelectedProgress"]);
                            if (list.Progress != 0 && list.SelectedProgress != 0)
                            {
                                list.ProgressPercentage = Convert.ToInt32(Convert.ToDecimal(list.SelectedProgress) / Convert.ToDecimal(list.Progress) * 100) + 1;
                            }
                            else
                            {
                                list.ProgressPercentage = 0;
                            }

                            //list.ProgressPercentage= Convert.ToInt32(row["Progress"]);
                            list.Activity = Convert.ToString(row["ActivityName"]);
                            list.Nature = Convert.ToString(row["Nature"]);
                            if (Convert.ToInt32(row["id"]) == 12 && Convert.ToString(row["ActivityName"])== "Further modifications/ improvement (if required) activity 4 onwards repeated" && (!string.IsNullOrEmpty(row["Nature"].ToString()))  && (row["Nature"].ToString()== "Individual"))
                            {
                                list.FurtherModification4 = "1";
                                response.FurtherModification4 = list.FurtherModification4;
                            }
                            if (Convert.ToInt32(row["id"]) == 12 && Convert.ToString(row["ActivityName"]) == "Further modifications/ improvement (if required) activity 4 onwards repeated" && (!string.IsNullOrEmpty(row["Nature"].ToString())) && (row["Nature"].ToString() == "Team"))
                            {
                                list.FurtherModification4 = "2";
                                response.FurtherModification4 = list.FurtherModification4;
                            }
                            if (Convert.ToInt32(row["id"]) == 14 && Convert.ToString(row["ActivityName"]) == "Further modification / improvement (if required) activity 10 onwards repeated" && (!string.IsNullOrEmpty(row["Nature"].ToString())) && (row["Nature"].ToString() == "Individual"))
                            {
                                list.FurtherModification10 = "1";
                                response.FurtherModification10 = list.FurtherModification10;
                            }
                            if (Convert.ToInt32(row["id"]) == 14 && Convert.ToString(row["ActivityName"]) == "Further modification / improvement (if required) activity 10 onwards repeated" && (!string.IsNullOrEmpty(row["Nature"].ToString())) && (row["Nature"].ToString() == "Team"))
                            {
                                list.FurtherModification10 = "2";
                                response.FurtherModification10 = list.FurtherModification10;
                            }
                            if (Convert.ToInt32(row["id"]) == 16 && Convert.ToString(row["ActivityName"]) == "Application for Patent /Design Application (If required) as per discretion of HOD R&D" && (!string.IsNullOrEmpty(row["Nature"].ToString())) && (row["Nature"].ToString() == "Individual"))
                            {
                                list.ApplicationforPatent = "1";
                                response.ApplicationforPatent = list.ApplicationforPatent;
                            }
                            if (Convert.ToInt32(row["id"]) == 16 && Convert.ToString(row["ActivityName"]) == "Application for Patent /Design Application (If required) as per discretion of HOD R&D" && (!string.IsNullOrEmpty(row["Nature"].ToString())) && (row["Nature"].ToString() == "Team"))
                            {
                                list.ApplicationforPatent = "2";
                                response.ApplicationforPatent = list.ApplicationforPatent;
                            }
                            if (Convert.ToInt32(row["id"]) == 22 && Convert.ToString(row["ActivityName"]) == "Need of Involvement of Customer in development" && (!string.IsNullOrEmpty(row["Nature"].ToString())) && (row["Nature"].ToString() == "Individual"))
                            {
                                list.NeedOfDevelopment = "1";
                                response.NeedOfDevelopment = list.NeedOfDevelopment;
                            }
                            if (Convert.ToInt32(row["id"]) == 22 && Convert.ToString(row["ActivityName"]) == "Need of Involvement of Customer in development" && (!string.IsNullOrEmpty(row["Nature"].ToString())) && (row["Nature"].ToString() == "Team"))
                            {
                                list.NeedOfDevelopment = "2";
                                response.NeedOfDevelopment = list.NeedOfDevelopment;
                            }
                            //list.FurtherModification10 = Convert.ToString(row["Nature"]);
                            list.ResourcesReq = Convert.ToString(row["ResourcesReq"]);
                            list.Responsibility = Convert.ToString(row["Responsibility"]);

                            if (row["AssignedDate"] is DBNull || string.IsNullOrEmpty(row["AssignedDate"].ToString()))
                            {

                            }
                            else
                            {
                                DateTime tempdate = Convert.ToDateTime(row["AssignedDate"]);
                                string date = tempdate.ToString("yyyy-MM-dd");
                                list.AssignedDate = date;
                            }

                            if (row["TargetDate"] is DBNull || string.IsNullOrEmpty(row["TargetDate"].ToString()))
                            {

                            }
                            else
                            {
                                DateTime tempdate1 = Convert.ToDateTime(row["TargetDate"]);
                                string date1 = tempdate1.ToString("yyyy-MM-dd");
                                list.TargetDate = date1;
                            }

                            list.ApprovingAuthority = Convert.ToString(row["ApprovingAuthority"]);

                            if (row["CompletionDate"] is DBNull || string.IsNullOrEmpty(row["CompletionDate"].ToString()))
                            {

                            }
                            else
                            {
                                DateTime tempdate2 = Convert.ToDateTime(row["CompletionDate"]);
                                string date2 = tempdate2.ToString("yyyy-MM-dd");
                                list.CompletionDate = date2;
                            }

                            list.Remarks = Convert.ToString(row["Remark"]);
                            list.Aging = Convert.ToInt32(row["Aging"]) > 0 ? Convert.ToInt32(row["Aging"]) : 0;
                            list.SubActivity = Convert.ToString(row["SubActivityName"]);
                            list.ActivityId = Convert.ToInt32(row["Id"]);
                            if (list.ActivityId == 8)
                            {
                                response.DesignValidation_DocumentName = Convert.ToString(row["DocumentName"]);
                                response.DesignValidation_DOCUMENTSPATH = Convert.ToString(row["DocumentPath"]);
                            }
                            list.SubActivityPageName = Convert.ToString(row["SubActivityPageName"]);
                            string marks = Convert.ToString(row["MarkAsActivityComplete"]);
                            if (marks == "" || marks == null)
                            {
                                list.ActivityMarkAsComplete = false;
                            }

                            else
                            {
                                list.ActivityMarkAsComplete = Convert.ToBoolean(row["MarkAsActivityComplete"]);
                            }
                            if (list.ActivityMarkAsComplete == true)
                            {
                                list.ProgressPercentage = 101;
                            }
                            responseList.Add(list);
                            response._ActivityList = responseList;
                        }
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        response.AllSelectedProgress = Convert.ToInt32(ds.Tables[1].Rows[0]["AllSelectedProgress"]);
                        response.ActivityCount = Convert.ToInt32(ds.Tables[1].Rows[0]["ActivityCount"]);
                        response.AllActitvity = Convert.ToInt32(ds.Tables[1].Rows[0]["AllSelectedActivityProgress"]);
                        response.AllSelectedActivityProgress = Convert.ToInt32(ds.Tables[1].Rows[0]["CompleteSelectedActivity"]);
                        if (response.AllActitvity != 0)
                        //if (response.ActivityCount != 0  && response.AllSelectedProgress != 0 && response.AllActitvity != 0 && response.AllSelectedActivityProgress != 0)
                        {
                            //response.AllProgressPercentage = Convert.ToInt32(Convert.ToDecimal(response.AllSelectedProgress) / Convert.ToDecimal(response.AllProgress) * 100);
                            response.AllProgressPercentage = Convert.ToInt32(Convert.ToDecimal(response.AllSelectedProgress + response.AllSelectedActivityProgress) / Convert.ToDecimal(response.ActivityCount) * 100);
                        }
                        else
                        {
                            response.AllProgressPercentage = 0;
                        }
                        response.ProjectID = Convert.ToInt32(ds.Tables[1].Rows[0]["ID"]);
                        response.ProjectNO = Convert.ToString(ds.Tables[1].Rows[0]["ProjectNumber"]);
                        response.ProjectTitle = Convert.ToString(ds.Tables[1].Rows[0]["ProjectTitle"]);
                        response.OpeningDate = Convert.ToString(ds.Tables[1].Rows[0]["OpeningDate"]);
                        response.Coordinator = Convert.ToString(ds.Tables[1].Rows[0]["Coordinator"]);
                        response.ProductRefNo = Convert.ToString(ds.Tables[1].Rows[0]["Product_Ref_No"]);
                        response.Status = Convert.ToString(ds.Tables[1].Rows[0]["Status"]);
                    }
                    response._ResponsibilityList = UtilityAccess.RespList(ds.Tables[2], 1);
                    response._AuthorityList = UtilityAccess.AuthorityList(ds.Tables[3], 1);
                }
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "GetAllActivity");
                returnResult = -1;
                return null;
            }
            return response;
        }

        public DesignDataSheetModel GetData(string ProjectID, string PlanID)
        {
            int returnResult = 0;
            DesignDataSheetModel response = new DesignDataSheetModel();
            DataSet ds = data.GetData(ProjectID, PlanID, out returnResult);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    response.ProjectNO = Convert.ToString(ds.Tables[1].Rows[0]["ProjectNumber"]);
                    response.ProjectID = Convert.ToInt32(ds.Tables[1].Rows[0]["ID"]);
                    response.ProjectTitle = Convert.ToString(ds.Tables[1].Rows[0]["ProjectTitle"]);
                    response.Coordinator = Convert.ToString(ds.Tables[1].Rows[0]["Coordinator"]);
                    //response.ProductRefNo = Convert.ToString(ds.Tables[1].Rows[0]["Product_Ref_No"]);
                    response.PPR_Status = Convert.ToString(ds.Tables[1].Rows[0]["Status"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.ProjectID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProjectID"]);
                        response.PlanID = Convert.ToInt32(ds.Tables[0].Rows[0]["PlanID"]);

                        response.Functional_Performar_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["Functional_Performar_Requirement"]);
                        response.ProductRefNo = Convert.ToString(ds.Tables[0].Rows[0]["ProductRefNo"]);

                        response.StaticStrength = Convert.ToString(ds.Tables[0].Rows[0]["StaticStrength"]);
                        response.DynamicStrength = Convert.ToString(ds.Tables[0].Rows[0]["DynamicStrength"]);
                        response.corrosionResistance = Convert.ToString(ds.Tables[0].Rows[0]["corrosionResistance"]);
                        response.Other = Convert.ToString(ds.Tables[0].Rows[0]["Other"]);
                        response.Static_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["Static_Unit"]);
                        response.Dyanmic_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["Dyanmic_Unit"]);
                        response.Corrosion_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["Corrosion_Unit"]);
                        response.Other_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["Other_Unit"]);

                        response.MaterialSpecific = Convert.ToString(ds.Tables[0].Rows[0]["MaterialSpecific"]);
                        response.ProcessSpecific = Convert.ToString(ds.Tables[0].Rows[0]["ProcessSpecific"]);
                        response.MaterialSpecific_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["MaterialSpecific_Unit"]);
                        response.ProcessSpecific_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["ProcessSpecific_Unit"]);

                        response.Statutory_Regulatory_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["Statutory_Regulatory_Requirement"]);
                        response.SPECIAL_ENVIRONMENT_CONDITIONS = Convert.ToString(ds.Tables[0].Rows[0]["SPECIAL_ENVIRONMENT_CONDITIONS"]);
                        response.Packaging = Convert.ToString(ds.Tables[0].Rows[0]["Packaging"]);
                        response.StickerLabels = Convert.ToString(ds.Tables[0].Rows[0]["StickerLabels"]);
                        response.UserInstruction = Convert.ToString(ds.Tables[0].Rows[0]["UserInstruction"]);

                        response.Packaging_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["Packaging_Unit"]);
                        response.StickerLabels_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["StickerLabels_Unit"]);
                        response.UserInstruction_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["UserInstruction_Unit"]);
                        response.INFORMATION_EARLIER_PROJECTS = Convert.ToString(ds.Tables[0].Rows[0]["INFORMATION_EARLIER_PROJECTS"]);
                        response.CUSTOMER_IN_DEVELOPMENT = Convert.ToString(ds.Tables[0].Rows[0]["CUSTOMER_IN_DEVELOPMENT"]);
                        response.Benchmarking_Criteria = Convert.ToString(ds.Tables[0].Rows[0]["Benchmarking_Criteria"]);

                        
                       
                    }
                   
                    response._UnitList = UtilityAccess.UnitList(ds.Tables[2], 1);
                }
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "GetData");
                returnResult = -1;
                return null;
            }
            return response;
        }

        public DesignDataSheetModel AddOrEdit_DesignInputDataSheet(DesignDataSheetModel model)
        {
            Int32 returnResult = 0;
            DesignDataSheetModel response = new DesignDataSheetModel();
            try
            {
                DataSet ds = data.DesignInputDataSheet(model, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddOrEdit_DesignInputDataSheet");
                returnResult = -1;
                return null;
            }
        }

        public DevelopmentPlanModel AddOrEdit(DevelopmentPlanModel model)
        {
            DataTable AddNewTableData = new DataTable();
            int returnResult = 0;
            DevelopmentPlanModel response = new DevelopmentPlanModel();
            try
            {
                AddNewTableData = AddNewTableData1(model);
                returnResult = data.AddOrEdit(model, AddNewTableData, out returnResult);
                response.ProjectID = model.ProjectID;
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }

        }
        public static DataTable AddNewTableData1(DevelopmentPlanModel models)
        {
            DataTable dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow.Columns.Add("ProjectID", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("ActivityId", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Nature", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Nature1", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Nature2", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Nature3", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Nature4", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("ResourcesReq", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Responsibility", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("AssignedDate", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("TargetDate", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("ApprovingAuthority", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("CompletionDate", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Remark", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Aging", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Createdby", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("MarkAsActivityComplete", typeof(System.Boolean));
            dtSetupSeriesRow.Columns.Add("DocumentPath", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("DocumentName", typeof(System.String));
            try
            {
                if (models._ActivityList != null && models._ActivityList.Count > 0)
                {
                    foreach (var item in models._ActivityList)
                    {
                        DataRow dtRow = dtSetupSeriesRow.NewRow();
                        dtRow["ProjectID"] = models.ProjectID;
                        dtRow["ActivityId"] = item.ActivityId;
                        dtRow["Nature"] = item.Nature;
                        if (item.ActivityId == 12)
                        {
                            dtRow["Nature1"] = models.FurtherModification4 ?? null;
                        }
                        if(item.ActivityId == 14)
                        {
                            dtRow["Nature2"] = models.FurtherModification10 ?? null;
                        }
                        if (item.ActivityId == 16)
                        {
                            dtRow["Nature3"] = models.ApplicationforPatent ?? null;
                        }
                        if (item.ActivityId == 22)
                        {
                            dtRow["Nature4"] = models.NeedOfDevelopment ?? null;
                        }
                        //dtRow["Nature"] = models.FurtherModification4 ?? null;
                        dtRow["ResourcesReq"] = item.ResourcesReq ?? null;
                        dtRow["Responsibility"] = item.Responsibility ?? null;
                        dtRow["AssignedDate"] = item.AssignedDate ?? null;
                        dtRow["TargetDate"] = item.TargetDate ?? null;
                        dtRow["ApprovingAuthority"] = item.ApprovingAuthority ?? null;
                        dtRow["CompletionDate"] = item.CompletionDate ?? null;
                        dtRow["Remark"] = item.Remarks ?? null;
                        dtRow["Aging"] = item.Aging ?? 0;
                        dtRow["MarkAsActivityComplete"] = item.ActivityMarkAsComplete;
                        if (item.ActivityId == 8)
                        {
                            dtRow["DocumentPath"] = models.DesignValidation_DOCUMENTSPATH;
                            dtRow["DocumentName"] = models.DesignValidation_DocumentName;
                        }

                        dtSetupSeriesRow.Rows.Add(dtRow);
                    }
                }
                return dtSetupSeriesRow;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddNewTableData1");
                return null;
            }
        }
        public DevelopmentPlanModel GetAllDesignDevelopmentPlan(DevelopmentPlanModel model)
        {
            int returnResult = 0;
            DevelopmentPlanModel response = new DevelopmentPlanModel();
            List<DevelopmentPlanModel> responseList = new List<DevelopmentPlanModel>();
            DataSet ds = data.SelectAllDesignDevelopmentPlanById(model, out returnResult);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new DevelopmentPlanModel();
                            //response.ActivityId = Convert.ToInt32(row["ActivityID"]);
                            //response.Activity = Convert.ToString(row["ActivityName"]);
                            //response.Nature = Convert.ToString(row["Nature"]);
                            //response.ResourcesReq = Convert.ToString(row["ResourcesReq"]);
                            //response.Responsibility = Convert.ToString(row["Responsibility"] ?? 0);
                            //response.AssignedDate = Convert.ToString(row["AssignedDate"]);
                            //response.TargetDate = Convert.ToString(row["TargetDate"]);
                            //response.ApprovingAuthority = Convert.ToString(row["ApprovingAuthority"]);
                            //response.CompletionDate = Convert.ToString(row["CompletionDate"]);
                            //response.Remarks = Convert.ToString(row["Remark"]);
                            //response.Aging = Convert.ToInt32(row["Aging"]);
                            //responseList.Add(response);
                            //response._ActivityList = responseList;
                        }
                    }
                    //response._NatureList = UtilityAccess.RenderList(ds.Tables[1], 1);
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "GetAllDesignDevelopmentPlan");
                returnResult = -1;
                return null;
            }

        }

        #region DesignReview
        public DesignReviewModel AddOrEdit_DesignReviewDataSheet(DesignReviewModel model)
        {
            DesignReviewModel response = new DesignReviewModel();
            Int32 returnResult = 0;
            try
            {
                DataSet ds = data.DesignReviewDataSheet(model, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddOrEdit_DesignReviewDataSheet");
                returnResult = -1;
                return null;
            }
        }
        public DesignReviewModel GetDesignReviewData(string ProjectID, string PlanID)
        {
            int returnResult = 0;
            DesignReviewModel response = new DesignReviewModel();
            DataSet ds = data.GetDesignReviewData(ProjectID, PlanID, out returnResult);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    response.ProjectNO = Convert.ToString(ds.Tables[1].Rows[0]["ProjectNumber"]);
                    response.ProjectID = Convert.ToInt32(ds.Tables[1].Rows[0]["ID"]);
                    response.ProjectDate = Convert.ToString(ds.Tables[1].Rows[0]["ProjectDate"]);
                    response.PPR_Status = Convert.ToString(ds.Tables[1].Rows[0]["Status"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.ProjectID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProjectID"]);
                        response.PlanID = Convert.ToInt32(ds.Tables[0].Rows[0]["PlanID"]);

                        response.AVAILABILITYOFMATERIALSPROPOSED_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["AVAILABILITYOFMATERIALSPROPOSED_STATUS"]);
                        response.AVAILABILITYOFMATERIALSPROPOSED_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["AVAILABILITYOFMATERIALSPROPOSED_REMARKS"]);
                        response.WORKABILITYOFDESIGNASPERFUNCTIONALPERFORMANCEREQUIREMENTS_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["WORKABILITYOFDESIGNASPERFUNCTIONALPERFORMANCEREQUIREMENTS_STATUS"]);
                        response.WORKABILITYOFDESIGNASPERFUNCTIONALPERFORMANCEREQUIREMENTS_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["WORKABILITYOFDESIGNASPERFUNCTIONALPERFORMANCEREQUIREMENTS_REMARKS"]);
                        response.FEASIBILITYOFMANUFACTURINGINCLUDINGTOOLMAKING_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["FEASIBILITYOFMANUFACTURINGINCLUDINGTOOLMAKING_STATUS"]);
                        response.FEASIBILITYOFMANUFACTURINGINCLUDINGTOOLMAKING_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["FEASIBILITYOFMANUFACTURINGINCLUDINGTOOLMAKING_REMARKS"]);
                        response.PROBABILITYOFMEETINGTHETESTRESULTS_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["PROBABILITYOFMEETINGTHETESTRESULTS_STATUS"]);
                        response.PROBABILITYOFMEETINGTHETESTRESULTS_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["PROBABILITYOFMEETINGTHETESTRESULTS_REMARKS"]);
                        response.PROBABILITYOFMEETINGCONSTRUCTIONAL_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["PROBABILITYOFMEETINGCONSTRUCTIONAL_REMARKS"]);
                        response.PROBABILITYOFMEETINGCONSTRUCTIONAL_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["PROBABILITYOFMEETINGCONSTRUCTIONAL_STATUS"]);
                        response.PROBABILITYOFMEETINGSTATUTORYREGULATORYREQUIREMENTS_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["PROBABILITYOFMEETINGSTATUTORYREGULATORYREQUIREMENTS_STATUS"]);
                        response.PROBABILITYOFMEETINGSTATUTORYREGULATORYREQUIREMENTS_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["PROBABILITYOFMEETINGSTATUTORYREGULATORYREQUIREMENTS_REMARKS"]);
                        response.EASEOFPACKAGINGAVAILABILITY_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["EASEOFPACKAGINGAVAILABILITY_STATUS"]);
                        response.EASEOFPACKAGINGAVAILABILITY_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["EASEOFPACKAGINGAVAILABILITY_REMARKS"]);
                        response.EASEOFINSTALLATIONBYUSER_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["EASEOFINSTALLATIONBYUSER_STATUS"]);
                        response.EASEOFINSTALLATIONBYUSER_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["EASEOFINSTALLATIONBYUSER_REMARKS"]);
                        response.FTOSEARCHINCOORDINATIONWITHKARAMIPRTEAM_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["FTOSEARCHINCOORDINATIONWITHKARAMIPRTEAM_STATUS"]);
                        response.FTOSEARCHINCOORDINATIONWITHKARAMIPRTEAM_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["FTOSEARCHINCOORDINATIONWITHKARAMIPRTEAM_REMARKS"]);
                        response.AVAILABILITYOFMANPOWER_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["AVAILABILITYOFMANPOWER_STATUS"]);

                        response.AVAILABILITYOFMANPOWER_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["AVAILABILITYOFMANPOWER_REMARKS"]);
                        response.AVAILABILITYOFMACHINERY_STATUS = Convert.ToBoolean(ds.Tables[0].Rows[0]["AVAILABILITYOFOFMACHINERY_STATUS"]);
                        response.AVAILABILITYOFMACHINERY_REMARKS = Convert.ToString(ds.Tables[0].Rows[0]["AVAILABILITYOFMACHINERY_REMARKS"]);
                        response.Remarks = Convert.ToString(ds.Tables[0].Rows[0]["Remarks"]);
                        response.DesignReview_DocumentName = Convert.ToString(ds.Tables[0].Rows[0]["DocumentName"]);
                        response.DesignReview_DOCUMENTSPATH = Convert.ToString(ds.Tables[0].Rows[0]["DocumentPath"]);

                    }
                    //response._NatureList = UtilityAccess.RenderList(ds.Tables[1], 1);
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "GetDesignReviewData");
                returnResult = -1;
                return null;
            }
        }

        #endregion
        #region QualityPlan
        public QualityPlanModel AddOrEdit_QualityPlanDataSheet(QualityPlanModel model)
        {
            QualityPlanModel response = new QualityPlanModel();
            Int32 returnResult = 0;
            try
            {
                DataSet ds = data.QualityPlanDataSheet(model, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddOrEdit_QualityPlanDataSheet");
                returnResult = -1;
                return null;
            }
        }
        public QualityPlanModel GetQualityPlanData(string ProjectID, string PlanID)
        {
            int returnResult = 0;
            QualityPlanModel response = new QualityPlanModel();
            DocDetails docdetails = new DocDetails();
            List<DocDetails> docdetailsList = new List<DocDetails>();
            List<QualityPlanModel> responseList = new List<QualityPlanModel>();
            DataSet ds = data.GetQualityPlanData(ProjectID, PlanID, out returnResult);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.ProjectID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                        response.ProjectNO = Convert.ToString(ds.Tables[0].Rows[0]["ProjectNumber"]);
                        response.ProjectTitle = Convert.ToString(ds.Tables[0].Rows[0]["ProjectTitle"]);
                        response.ProjectDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["OpeningDate"]);
                        response.Coordinator = Convert.ToString(ds.Tables[0].Rows[0]["Coordinator"]);
                        response.PPR_Status = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        response.ProjectID = Convert.ToInt32(ds.Tables[1].Rows[0]["ProjectID"]);
                        response.PlanID = Convert.ToInt32(ds.Tables[1].Rows[0]["PlanID"]);
                        response.WORKINSTRUCTIONS_STATUS = Convert.ToBoolean(ds.Tables[1].Rows[0]["WORKINSTRUCTIONS_STATUS"]);
                        response.WORKINSTRUCTIONS_DOCUMENTSPATH = Convert.ToString(ds.Tables[1].Rows[0]["WORKINSTRUCTIONS_DOCUMENTS"]);
                        response.WORKINSTRUCTIONS_REMARKS = Convert.ToString(ds.Tables[1].Rows[0]["WORKINSTRUCTIONS_REMARKS"]);
                        response.WORKINSTRUCTIONS_DocumentName = Convert.ToString(ds.Tables[1].Rows[0]["WORKINSTRUCTIONSDocumentName"]);

                        response.INSPECTIONCRITERION_STATUS = Convert.ToBoolean(ds.Tables[1].Rows[0]["INSPECTIONCRITERION_STATUS"]);
                        response.INSPECTIONCRITERION_DOCUMENTSPATH = Convert.ToString(ds.Tables[1].Rows[0]["INSPECTIONCRITERION_DOCUMENTS"]);
                        response.INSPECTIONCRITERION_REMARKS = Convert.ToString(ds.Tables[1].Rows[0]["INSPECTIONCRITERION_REMARKS"]);
                        response.INSPECTIONCRITERION_DocumentName = Convert.ToString(ds.Tables[1].Rows[0]["INSPECTIONCRITERIONDocumentName"]);

                        response.TESTINGPLAN_STATUS = Convert.ToBoolean(ds.Tables[1].Rows[0]["TESTINGPLAN_STATUS"]);
                        response.TESTINGPLAN_DOCUMENTSPATH = Convert.ToString(ds.Tables[1].Rows[0]["TESTINGPLAN_DOCUMENTS"]);
                        response.TESTINGPLAN_REMARKS = Convert.ToString(ds.Tables[1].Rows[0]["TESTINGPLAN_REMARKS"]);
                        response.TESTINGPLAN_DocumentName = Convert.ToString(ds.Tables[1].Rows[0]["TESTINGPLANDocumentName"]);

                        response.TechnicalDataSheet_STATUS = Convert.ToBoolean(ds.Tables[1].Rows[0]["TechnicalDataSheet_STATUS"]);
                        response.TechnicalDataSheet_DOCUMENTSPATH = Convert.ToString(ds.Tables[1].Rows[0]["TechnicalDataSheet_DOCUMENTS"]);
                        response.TechnicalDataSheet_REMARKS = Convert.ToString(ds.Tables[1].Rows[0]["TechnicalDataSheet_REMARKS"]);
                        response.TechnicalDataSheet_DocumentName = Convert.ToString(ds.Tables[1].Rows[0]["TechnicalDataSheetDocumentName"]);

                        response.TechnicalDrawings_STATUS = Convert.ToBoolean(ds.Tables[1].Rows[0]["TechnicalDrawings_STATUS"]);
                        response.TechnicalDrawings_DOCUMENTSPATH = Convert.ToString(ds.Tables[1].Rows[0]["TechnicalDrawings_DOCUMENTS"]);
                        response.TechnicalDrawings_DocumentName = Convert.ToString(ds.Tables[1].Rows[0]["TechnicalDrawings_DocumentName"]);
                        //foreach (string path in response.TechnicalDrawings_DOCUMENTSPATH.Split(','))
                        //{
                        //    //foreach (string name in response.TechnicalDrawings_DocumentName.Split(','))
                        //    //{
                        //    docdetails = new DocDetails();
                        //    if (!String.IsNullOrEmpty(path))
                        //    {
                        //        docdetails.DocTitle = path.Substring(path.Length);
                        //        docdetails.DocPath = path;
                        //        docdetailsList.Add(docdetails);
                        //    }


                        //    //}
                        //}
                        // Split the document paths and names into arrays
                        string[] paths = response.TechnicalDrawings_DOCUMENTSPATH.Split(',');
                        string[] names = response.TechnicalDrawings_DocumentName.Split(',');

                        // Initialize the docdetailsList if not already done
                        if (docdetailsList == null)
                        {
                            docdetailsList = new List<DocDetails>();
                        }

                        for (int i = 0; i < paths.Length; i++)
                        {
                            string path = paths[i];
                            string name = i < names.Length ? names[i] : string.Empty;

                            if (!String.IsNullOrEmpty(path))
                            {
                                docdetails = new DocDetails
                                {
                                    DocTitle = name, // Use the document name as the title
                                    DocPath = path
                                };
                                docdetailsList.Add(docdetails);
                            }
                        }
                        response.TechnicalDrawings_REMARKS = Convert.ToString(ds.Tables[1].Rows[0]["TechnicalDrawings_REMARKS"]);
                        response.TechnicalFile_STATUS = Convert.ToBoolean(ds.Tables[1].Rows[0]["TechnicalFile_STATUS"]);
                        response.TechnicalFile_DOCUMENTSPATH = Convert.ToString(ds.Tables[1].Rows[0]["TechnicalFile_DOCUMENTS"]);
                        response.TechnicalFile_REMARKS = Convert.ToString(ds.Tables[1].Rows[0]["TechnicalFile_REMARKS"]);
                        response.TechnicalFile_DocumentName = Convert.ToString(ds.Tables[1].Rows[0]["TechnicalFile_DocumentName"]);
                        response.UserInstruction_STATUS = Convert.ToBoolean(ds.Tables[1].Rows[0]["UserInstruction_STATUS"]);
                        response.UserInstruction_DOCUMENTSPATH = Convert.ToString(ds.Tables[1].Rows[0]["UserInstruction_DOCUMENTS"]);
                        response.UserInstruction_REMARKS = Convert.ToString(ds.Tables[1].Rows[0]["UserInstruction_REMARKS"]);
                        response.UserInstruction_DocumentName = Convert.ToString(ds.Tables[1].Rows[0]["UserInstruction_DocumentName"]);
                    }
                }
                response._DocDetailsList = docdetailsList; ;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "GetQualityPlanData");
                returnResult = -1;
                return null;
            }

        }
        #endregion

        #region DesignVerification
        public DesignVerificationModel AddOrEdit_DesignVerification(DesignVerificationModel model)
        {
            DesignVerificationModel response = new DesignVerificationModel();
            Int32 returnResult = 0;
            try
            {
                DataSet ds = data.DesignVerification(model, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddOrEdit_DesignVerification");
                returnResult = -1;
                return null;
            }
        }
        public DesignVerificationModel GetDesignVerificationData(string ProjectID, string PlanID)
        {
            int returnResult = 0;
            DesignVerificationModel response = new DesignVerificationModel();
            DataSet ds = data.GetDesignVerificationData(ProjectID, PlanID, out returnResult);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.ProjectID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProjectID"]);
                        response.PlanID = Convert.ToInt32(ds.Tables[0].Rows[0]["PlanID"]);
                        response.VerficationID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);

                        response.Functional_Performar_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["Functional_Performar_Requirement"]);
                        response.Functional_Performar_Observation = Convert.ToString(ds.Tables[0].Rows[0]["Functional_Performar_Observation"]);
                        response.Functional_Performar_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["Functional_Performar_Remarks"]);
                        response.Static_Strengh_Req = Convert.ToString(ds.Tables[0].Rows[0]["Static_Strengh_Req"]);
                        response.Static_Strengh_Observation = Convert.ToString(ds.Tables[0].Rows[0]["Static_Strengh_Observation"]);
                        response.Static_Strengh_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["Static_Strengh_Remarks"]);
                        response.Dynamic_Strengh_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["Dynamic_Strengh_Requirement"]);
                        response.Dynamic_Strengh_Observation = Convert.ToString(ds.Tables[0].Rows[0]["Dynamic_Strengh_Observation"]);
                        response.Dynamic_Strengh_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["Dynamic_Strengh_Remarks"]);
                        response.corrosion_Resistance_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["corrosion_Resistance_Requirement"]);
                        response.corrosion_Resistance_Observation = Convert.ToString(ds.Tables[0].Rows[0]["corrosion_Resistance_Observation"]);
                        response.corrosion_Resistance_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["corrosion_Resistance_Remarks"]);
                        response.Other_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["Other_Requirement"]);
                        response.Other_Observation = Convert.ToString(ds.Tables[0].Rows[0]["Other_Observation"]);
                        response.Other_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["Other_Remarks"]);
                        response.MaterialSpecific_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["MaterialSpecific_Requirement"]);
                        response.MaterialSpecific_Observation = Convert.ToString(ds.Tables[0].Rows[0]["MaterialSpecific_Observation"]);
                        response.MaterialSpecific_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["MaterialSpecific_Remarks"]);
                        response.ProcessSpecific_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["ProcessSpecific_Requirement"]);
                        response.ProcessSpecific_Observation = Convert.ToString(ds.Tables[0].Rows[0]["ProcessSpecific_Observation"]);
                        response.ProcessSpecific_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["ProcessSpecific_Remarks"]);
                        response.Statutory_Regulatory_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["Statutory_Regulatory_Requirement"]);
                        response.Statutory_Regulatory_Observation = Convert.ToString(ds.Tables[0].Rows[0]["Statutory_Regulatory_Observation"]);
                        response.Statutory_Regulatory_Remark = Convert.ToString(ds.Tables[0].Rows[0]["Statutory_Regulatory_Remark"]);
                        response.SPECIAL_ENVIRONMENT_CONDITIONS_Req = Convert.ToString(ds.Tables[0].Rows[0]["SPECIAL_ENVIRONMENT_CONDITIONS_Req"]);
                        response.SPECIAL_ENVIRONMENT_CONDITIONS_Observation = Convert.ToString(ds.Tables[0].Rows[0]["SPECIAL_ENVIRONMENT_CONDITIONS_Observation"]);
                        response.SPECIAL_ENVIRONMENT_CONDITIONS_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["SPECIAL_ENVIRONMENT_CONDITIONS_Remarks"]);
                        response.Packaging_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["Packaging_Requirement"]);
                        response.Packaging_Observation = Convert.ToString(ds.Tables[0].Rows[0]["Packaging_Observation"]);
                        response.Packaging_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["Packaging_Remarks"]);
                        response.StickerLabel_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["StickerLabel_Requirement"]);
                        response.StickerLabel_Observation = Convert.ToString(ds.Tables[0].Rows[0]["StickerLabel_Observation"]);
                        response.StickerLabel_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["StickerLabel_Remarks"]);
                        response.UserInstruction_Requirement = Convert.ToString(ds.Tables[0].Rows[0]["UserInstruction_Requirement"]);
                        response.UserInstruction_Observation = Convert.ToString(ds.Tables[0].Rows[0]["UserInstruction_Observation"]);
                        response.UserInstruction_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["UserInstruction_Remarks"]);
                        response.INFORMATION_EARLIER_PROJECTS_REQ = Convert.ToString(ds.Tables[0].Rows[0]["INFORMATION_EARLIER_PROJECTS_REQ"]);
                        response.INFORMATION_EARLIER_PROJECTS_Observation = Convert.ToString(ds.Tables[0].Rows[0]["INFORMATION_EARLIER_PROJECTS_Observation"]);
                        response.INFORMATION_EARLIER_PROJECTS_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["INFORMATION_EARLIER_PROJECTS_Remarks"]);
                        response.CUSTOMER_IN_DEVELOPMENT_REQ = Convert.ToString(ds.Tables[0].Rows[0]["CUSTOMER_IN_DEVELOPMENT_REQ"]);
                        response.CUSTOMER_IN_DEVELOPMENT_Observation = Convert.ToString(ds.Tables[0].Rows[0]["CUSTOMER_IN_DEVELOPMENT_Observation"]);
                        response.CUSTOMER_IN_DEVELOPMENT_Remarks = Convert.ToString(ds.Tables[0].Rows[0]["CUSTOMER_IN_DEVELOPMENT_Remarks"]);
                        response.Static_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["Static_Unit"]);
                        response.Dyanmic_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["Dyanmic_Unit"]);
                        response.Corrosion_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["Corrosion_Unit"]);
                        response.Other_Unit = Convert.ToInt32(ds.Tables[0].Rows[0]["Other_Unit"]);
                        response.DesignVerification_DocumentName = Convert.ToString(ds.Tables[0].Rows[0]["DocumentName"]);
                        response.DesignVerification_DOCUMENTSPATH = Convert.ToString(ds.Tables[0].Rows[0]["DocumentPath"]);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        response.ProjectNO = Convert.ToString(ds.Tables[1].Rows[0]["ProjectNumber"]);
                        response.ProjectID = Convert.ToInt32(ds.Tables[1].Rows[0]["ID"]);
                        response.ProjectTitle = Convert.ToString(ds.Tables[1].Rows[0]["ProjectTitle"]);
                        response.Coordinator = Convert.ToString(ds.Tables[1].Rows[0]["Coordinator"]);
                        response.ProductRefNo = Convert.ToString(ds.Tables[1].Rows[0]["Product_Ref_No"]);
                        response.ProjectDate = Convert.ToString(ds.Tables[1].Rows[0]["ProjectDate"]);
                        response.PPR_Status = Convert.ToString(ds.Tables[1].Rows[0]["Status"]);
                    }

                    response._UnitList = UtilityAccess.UnitList(ds.Tables[2], 1);
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "GetDesignVerificationData");
                returnResult = -1;
                return null;
            }

        }

        #endregion

        #region DesignValidation
        public DesignValidationModel GetDesignValidationData(string ProjectID, string PlanID)
        {
            int returnResult = 0;
            DesignValidationModel response = new DesignValidationModel();
            DataSet ds = data.GetDesignValidationData(ProjectID, PlanID, out returnResult);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.ProjectID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                        response.ProjectNO = Convert.ToString(ds.Tables[0].Rows[0]["ProjectNumber"]);
                        response.ProjectDate = Convert.ToString(ds.Tables[0].Rows[0]["OpeningDate"]);
                        response.PPR_Status = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {

                        response.ProjectID = Convert.ToInt32(ds.Tables[1].Rows[0]["ProjectID"]);
                        response.PlanID = Convert.ToInt32(ds.Tables[1].Rows[0]["PlanID"]);
                        response.FEEDBACKRECEIVED = Convert.ToString(ds.Tables[1].Rows[0]["FeedBackReceived"]);
                        response.IMPROVEMENTSREQUIRED = Convert.ToString(ds.Tables[1].Rows[0]["IMPROVEMENTSREQUIRED"]);
                        response.ACTIONPLAN = Convert.ToString(ds.Tables[1].Rows[0]["ACTIONPLAN"]);
                        response.TARGETDATE = Convert.ToString(ds.Tables[1].Rows[0]["TARGETDATE"]);
                        response.SampleSentToKTC = Convert.ToBoolean(ds.Tables[1].Rows[0]["SampleSentToKTC"]);
                        //response.DateOfSampleSent = Convert.ToString(ds.Tables[1].Rows[0]["DateOfSampleSent"]);
                        string datenull = Convert.ToString(ds.Tables[1].Rows[0]["DateOfSampleSent"]);
                        if (!String.IsNullOrEmpty(datenull))
                        {
                            DateTime tempDate1 = Convert.ToDateTime(ds.Tables[1].Rows[0]["DateOfSampleSent"]);
                            response.DateOfSampleSent = tempDate1.ToString("yyyy-MM-dd");
                        }
                        response.Reason = Convert.ToString(ds.Tables[1].Rows[0]["Reason"]);
                        response.RESPONSIBILITY = Convert.ToString(ds.Tables[1].Rows[0]["RESPONSIBILITY"]);
                        response.SAMPLESRESUBMITTEDON = Convert.ToString(ds.Tables[1].Rows[0]["SAMPLESRESUBMITTEDON"]);
                        response.FINALFEEDBACK = Convert.ToString(ds.Tables[1].Rows[0]["FINALFEEDBACK"]);
                        response.REMARKS = Convert.ToString(ds.Tables[1].Rows[0]["REMARKS"]);
                        response.DesignValidation_DOCUMENTSPATH = Convert.ToString(ds.Tables[1].Rows[0]["DocumentPath"]);
                        response.DesignValidation_DocumentName = Convert.ToString(ds.Tables[1].Rows[0]["DocumentName"]);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "GetDesignValidationData");
                returnResult = -1;
                return null;
            }

        }
        public DesignValidationModel AddOrEdit_DesignValidationDataSheet(DesignValidationModel model)
        {
            Int32 returnResult = 0;
            DesignValidationModel response = new DesignValidationModel();
            try
            {
                DataSet ds = data.DesignValidationInputDataSheet(model, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddOrEdit_DesignValidationDataSheet");
                returnResult = -1;
                return null;
            }
        }

        #endregion

        #region CHECKLISTFORINDUSTRIALISATION
        public IndustrialisationModel_New GetIndustrialisationData_New(string ProjectID, string PlanID)
        {
            int returnResult = 0;
            IndustrialisationModel_New response = new IndustrialisationModel_New();
           
            DataSet ds = data.GetIndustrialisationData(ProjectID, PlanID, out returnResult);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.ProjectID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProjectID"]);
                        response.PlanID = Convert.ToInt32(ds.Tables[0].Rows[0]["PlanID"]);
                         
                        response.ItemPicture = Convert.ToString(ds.Tables[0].Rows[0]["ItemPicture"]);
                        response.ProductCategory = Convert.ToString(ds.Tables[0].Rows[0]["ProductCategory"]);
                        response.TDS = Convert.ToString(ds.Tables[0].Rows[0]["TDS"]);
                        response.ManualInstruction = Convert.ToString(ds.Tables[0].Rows[0]["ManualInstruction"]);
                        response.Certification = Convert.ToString(ds.Tables[0].Rows[0]["Certification"]);
                        response.ItemCode = Convert.ToString(ds.Tables[0].Rows[0]["ItemCode"]);
                        response.ApplicableStandard = Convert.ToString(ds.Tables[0].Rows[0]["ApplicableStandard"]);
                        response.QUALITYPLAN_DOCUMENTSPATH = Convert.ToString(ds.Tables[0].Rows[0]["DocumentPath"]);
                        response.CustomerName = Convert.ToString(ds.Tables[0].Rows[0]["CustomerName"]);
                        response.BOMCreationStatus = Convert.ToString(ds.Tables[0].Rows[0]["BOMCreationStatus"]);
                        response.SafetyStockCreationStatus = Convert.ToString(ds.Tables[0].Rows[0]["SafetyStockCreationStatus"]);
                        response.Sample = Convert.ToString(ds.Tables[0].Rows[0]["Sample"]);
                        response.Packaging = Convert.ToString(ds.Tables[0].Rows[0]["Packaging"]);
                        response.WorkInstructions = Convert.ToString(ds.Tables[0].Rows[0]["WorkInstructions"]);
                        response.InspectionCriterion = Convert.ToString(ds.Tables[0].Rows[0]["InspectionCriterion"]);
                        response.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                        string datenull = Convert.ToString(ds.Tables[0].Rows[0]["INDUSTRIALISATIONDate"]);
                        if (!String.IsNullOrEmpty(datenull))
                        {
                            DateTime tempDate1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["INDUSTRIALISATIONDate"]);
                            response.INDUSTRIALISATIONDate = tempDate1.ToString("yyyy-MM-dd");
                        }
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        response.ProjectNO = Convert.ToString(ds.Tables[1].Rows[0]["ProjectNumber"]);
                        response.PPR_Status = Convert.ToString(ds.Tables[1].Rows[0]["Status"]);
                        response.ProductCategory = Convert.ToString(ds.Tables[1].Rows[0]["Product_Category"]);
                    } 
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "GetIndustrialisationData");
                returnResult = -1;
                return null;
            }

        }
        public IndustrialisationModel GetIndustrialisationData(string ProjectID, string PlanID)
        {
            int returnResult = 0;
            IndustrialisationModel response = new IndustrialisationModel();
            DETAILOfCOMPONENTSModel detailsResponse = new DETAILOfCOMPONENTSModel();
            List<DETAILOfCOMPONENTSModel> detailsResponseList = new List<DETAILOfCOMPONENTSModel>();
            List<DETAILOfCOMPONENTSModel> responseList = new List<DETAILOfCOMPONENTSModel>();
            DataSet ds = data.GetIndustrialisationData(ProjectID, PlanID, out returnResult);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.ProjectID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProjectID"]);
                        response.PlanID = Convert.ToInt32(ds.Tables[0].Rows[0]["PlanID"]);

                        response.ADDITIONALMACHINESREQUIRED = Convert.ToString(ds.Tables[0].Rows[0]["ADDITIONALMACHINESREQUIRED"]);
                        response.JIGFIXTURESTOOLSNew = Convert.ToString(ds.Tables[0].Rows[0]["JIG_FIXTURES_TOOLSNew"]);
                        response.MODIFICATIONINOLD = Convert.ToString(ds.Tables[0].Rows[0]["MODIFICATIONINOLD"]);
                        response.ADDITIONALTESTEQUIPMENTREQUIRED = Convert.ToString(ds.Tables[0].Rows[0]["ADDITIONALTESTEQUIPMENTREQUIRED"]);
                        response.CHANGEINISODOCUMENT = Convert.ToString(ds.Tables[0].Rows[0]["CHANGEINISODOCUMENT"]);
                        response.UPDATIONINERPSYSTEMS = Convert.ToString(ds.Tables[0].Rows[0]["UPDATIONINERPSYSTEMS"]);
                        response.PLANNINGOFCOMPONENTDEVELOPMENT = Convert.ToString(ds.Tables[0].Rows[0]["PLANNINGOFCOMPONENTDEVELOPMENT"]);
                        response.QUALITYPLAN = Convert.ToString(ds.Tables[0].Rows[0]["QUALITYPLAN"]);
                        response.QUALITYPLAN_DOCUMENTSPATH = Convert.ToString(ds.Tables[0].Rows[0]["DocumentPath"]);
                        string datenull = Convert.ToString(ds.Tables[0].Rows[0]["INDUSTRIALISATIONDate"]);
                        if (!String.IsNullOrEmpty(datenull))
                        {
                            DateTime tempDate1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["INDUSTRIALISATIONDate"]);
                            response.INDUSTRIALISATIONDate = tempDate1.ToString("yyyy-MM-dd");
                        }
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        response.ProjectNO = Convert.ToString(ds.Tables[2].Rows[0]["ProjectNumber"]);
                        response.PPR_Status = Convert.ToString(ds.Tables[2].Rows[0]["Status"]);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[1].Rows)
                        {
                            detailsResponse = new DETAILOfCOMPONENTSModel();
                            detailsResponse.DetailsID = Convert.ToInt32(row["Id"]);
                            detailsResponse.IndustrilisationID = Convert.ToInt32(row["CheckListForIndustrialisiton"]);
                            detailsResponse.DRGNO = Convert.ToString(row["DRGNO"]);
                            detailsResponse.Title = Convert.ToString(row["Title"]);
                            detailsResponse.Quantity = Convert.ToString(row["Quantity"]);
                            detailsResponse.ComponentStatus = Convert.ToString(row["COMPONENTSStatus"]);
                            detailsResponse.Inhouse = Convert.ToString(row["InHouse"]);
                            detailsResponse.Outside = Convert.ToString(row["Outside"] ?? null);
                            detailsResponse.ToolingStatus = Convert.ToString(row["ToolingStatus"]);
                            detailsResponseList.Add(detailsResponse);
                        }
                    }
                    response._detailofcomponent = detailsResponseList;
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "GetIndustrialisationData");
                returnResult = -1;
                return null;
            }

        }
        public IndustrialisationModel AddOrEdit_InduatrilisationDataSheet(IndustrialisationModel model)
        {
            DataTable AddNewTableData = new DataTable();
            int returnResult = 0;
            IndustrialisationModel response = new IndustrialisationModel();
            try
            {
                AddNewTableData = AddNewTableData2(model);
                returnResult = data.InduatrilisationInputDataSheet(model, AddNewTableData, out returnResult);
                response.ProjectID = model.ProjectID;
                response.ReturnCode = returnResult; response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddOrEdit_InduatrilisationDataSheet");
                returnResult = -1;
                return null;
            }

        }
        public IndustrialisationModel_New AddOrEdit_InduatrilisationDataSheet_New(IndustrialisationModel_New model)
        {
           
            int returnResult = 0;
            IndustrialisationModel_New response = new IndustrialisationModel_New();
            try
            { 
                returnResult = data.InduatrilisationInputDataSheet_New(model, out returnResult);
                response.ProjectID = model.ProjectID;
                response.ReturnCode = returnResult; response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddOrEdit_InduatrilisationDataSheet");
                returnResult = -1;
                return null;
            }

        }
        public static DataTable AddNewTableData2(IndustrialisationModel models)
        {

            DataTable dtSetupSeriesRow = new DataTable();

            dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow.Columns.Add("DRGNO", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("TITLE", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Quantity", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("COMPONENTSStatus", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("InHouse", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Outside", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("ToolingStatus", typeof(System.String));
            try
            {
                if (models._detailofcomponent != null && models._detailofcomponent.Count > 0)
                {
                    foreach (var item in models._detailofcomponent)
                    {
                        //models.ProjectID = item.ProjectID;
                        DataRow dtRow = dtSetupSeriesRow.NewRow();
                        dtRow["DRGNO"] = item.DRGNO ?? null;
                        dtRow["TITLE"] = item.Title ?? null;
                        dtRow["Quantity"] = item.Quantity ?? null;
                        dtRow["COMPONENTSStatus"] = item.ComponentStatus ?? null;
                        dtRow["InHouse"] = item.Inhouse ?? null;
                        dtRow["Outside"] = item.Outside ?? null;
                        dtRow["ToolingStatus"] = item.ToolingStatus ?? null;
                        dtSetupSeriesRow.Rows.Add(dtRow);
                    }
                }
                return dtSetupSeriesRow;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddNewTableData2");
                return null;
            }

        }
        #endregion
    }
}
