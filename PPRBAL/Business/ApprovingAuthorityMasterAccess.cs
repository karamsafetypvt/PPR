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
    public class ApprovingAuthorityMasterAccess : IApprovingAuthorityMaster
    {
        ApprovingAuthorityMasterData PPCdata = new ApprovingAuthorityMasterData();
        public ApprovingAuthorityMasterModel GetAuthorityMasterData(ApprovingAuthorityMasterModel model)
            {
            ApprovingAuthorityMasterModel response = new ApprovingAuthorityMasterModel();
            List<ApprovingAuthorityMasterModel> responseList = new List<ApprovingAuthorityMasterModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new ApprovingAuthorityMasterModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.Name = Convert.ToString(row["Name"]);
                            response.Discription = Convert.ToString(row["Description"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                       
                    }
                }
                response._StatusList = UtilityAccess.StatusListCategory();
                response._ApprovingAuthorityMasterModelList=responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ApprovingAuthorityMasterAccess", "GetAuthorityMasterData");
                return null;
            }

        }
        public ApprovingAuthorityMasterModel AddOrEdit(ApprovingAuthorityMasterModel model)
        {
            Int32 returnResult = 0;
            ApprovingAuthorityMasterModel response = new ApprovingAuthorityMasterModel();
            response.ReturnCode = 0;
            response.ReturnMessage = MsgResponse.Message(0);
            try
            {
                DataSet ds = PPCdata.AddorEdit(model, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ApprovingAuthorityMasterAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public ApprovingAuthorityMasterModel GetAuthorityMasterDataById(ApprovingAuthorityMasterModel model)
        {
            Int32 returnResult = 0;

            ApprovingAuthorityMasterModel response = new ApprovingAuthorityMasterModel();
            List<ApprovingAuthorityMasterModel> responseList = new List<ApprovingAuthorityMasterModel>();
            try
            {
                DataSet ds = PPCdata.GetApprovingAuthorityMasterDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new ApprovingAuthorityMasterModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.Name = Convert.ToString(row["Name"]);
                            response.Discription = Convert.ToString(row["Description"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                    }
                    response._StatusList = UtilityAccess.StatusListCategory(); ;
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ApprovingAuthorityMasterAccess", "GetAuthorityMasterDataById");
                returnResult = -1;
                return null;
            }
        }
    }
}

