using FPDAL.Data;
using PPRBAL.Interface;
using PPRDAL.Data;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Business
{
    public class ActivityMasterAccess: IActivityMaster
    {
        ActitvityMasterData activity = new ActitvityMasterData();
        public ActivityMasterModel GetActivityCommonData()
        {
            ActivityMasterModel response = new ActivityMasterModel();
            try
            {
                DataSet ds = activity.GetActivityCommonData();
                if (ds != null && ds.Tables.Count > 0)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response._SubActivityList = UtilityAccess.RenderList(ds.Tables[0],2);
                    }
                    if(ds.Tables[1].Rows.Count > 0)
                    {
                        response._NatureList = UtilityAccess.RenderList(ds.Tables[1], 2);
                    }
                    response._StatusList = UtilityAccess.StatusListValTextNew(1);
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ActivityMasterAccess", "GetActivityCommonData");
                return response;
            }
        }
        public ActivityMasterModel GetAllActivityData()
        {
            ActivityMasterModel response = new ActivityMasterModel();
            List<ActivityMasterModel> responseList = new List<ActivityMasterModel>();
            DataSet ds = activity.SelectAllActivityData();
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new ActivityMasterModel();
                            response.ActivityID = Convert.ToInt32(row["Id"]);
                            response.ActivityName = Convert.ToString(row["ActivityName"]);
                            response.SubActivity = Convert.ToString(row["SubActivityName"]);
                            response.Nature = Convert.ToString(row["Nature_Name"]);
                            response.ResourceReq = Convert.ToString(row["ResourcesReq"] ?? null);
                            response.Responsibility = Convert.ToString(row["Responsibility"]);
                            response.ApprovingAuthority = Convert.ToString(row["ApprovingAuthority"]);
                            response.CreatedDate = Convert.ToString(row["CreatedDate"]);
                            response.CreatedBy = Convert.ToString(row["CreatedBy"]);
                            response.UpdatedDate = Convert.ToString(row["UpdatedDate"]);
                            response.UpdatedBy = Convert.ToString(row["UpdatedBy"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                            response._ActivityMasterModelList = responseList;
                        }
                    }
                }
                return response;
            }
            catch(Exception ex)
            {
                ApplicationLogger.LogError(ex, "ActivityMasterAccess", "GetAllActivityData");
                return response;
            }
            
        }
        public ActivityMasterModel AddOrEdit(ActivityMasterModel model)
        {
            ActivityMasterModel response = new ActivityMasterModel();
            Int32 returnResult = 0;
            response.ReturnCode = 0;
            response.ReturnMessage = MsgResponse.Message(returnResult);
            try
            {
                DataSet ds = activity.AddorEdit(model, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ActivityMasterAccess", "AddOrEdit");
                return response;
            }
        }
        public ActivityMasterModel GetActivityMasterDatabyId(int ActivityID)
        {
            ActivityMasterModel response = new ActivityMasterModel();
            DataSet ds = activity.GetActivityMasterDatabyId(ActivityID);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new ActivityMasterModel();
                            response.ActivityID = Convert.ToInt32(row["Id"]);
                            response.ActivityName = Convert.ToString(row["ActivityName"]);
                            response.ApprovingAuthority = Convert.ToString(row["ApprovingAuthority"]);
                            response.SubActivity = Convert.ToString(row["SubActivityID"]);
                            response.ResourceReq = Convert.ToString(row["ResourcesReq"] ?? 0);
                            response.Responsibility = Convert.ToString(row["Responsibility"]);
                            response.Status = Convert.ToString(row["Status"]);
                            response.Nature = Convert.ToString(row["Nature"]);
                            response.SequenceNo = Convert.ToInt32(row["Serialno"]);
                        }
                    }
                    if (ds != null && ds.Tables.Count > 0)
                    {

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            response._SubActivityList = UtilityAccess.RenderList(ds.Tables[1], 2);
                        }
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            response._NatureList = UtilityAccess.RenderList(ds.Tables[2], 2);
                        }
                    }
                    response._StatusList = UtilityAccess.StatusListValTextNew(1);
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ActivityMasterAccess", "GetActivityMasterDatabyId");
                return response;
            }
        }
        public ActivityMasterModel DeleteActivityMaster(int ActivityID)
        {
            Int32 returnResult = 0;
            ActivityMasterModel response = new ActivityMasterModel();
            DataSet ds = activity.DeleteActivityMaster(ActivityID, out returnResult);
            try
            {
                
                if (ds != null && ds.Tables.Count > 0)
                {
                }
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ActivityMasterAccess", "DeleteActivityMaster");
                return response;
            }
        }
    }
}
