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
    public class ResponsibilityMasterAccess : IResponsibilityMaster
    {
        ResponsibilityMasterData PPCdata = new ResponsibilityMasterData();
        public ResponsibilityMasterModel GetResponsibilityMasterData(ResponsibilityMasterModel model)
        {
            ResponsibilityMasterModel response = new ResponsibilityMasterModel();
            List<ResponsibilityMasterModel> responseList = new List<ResponsibilityMasterModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new ResponsibilityMasterModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.Name = Convert.ToString(row["Name"]);
                            response.Discription = Convert.ToString(row["Description"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }

                    }
                }
                response._StatusList = UtilityAccess.StatusListCategory();
                response._ResponsibilityMasterModelList = responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ResponsibilityMasterAccess", "GetPlanMasterData");
                return null;
            }

        }
        public ResponsibilityMasterModel AddOrEdit(ResponsibilityMasterModel model)
        {
            Int32 returnResult = 0;
            ResponsibilityMasterModel response = new ResponsibilityMasterModel();
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
                ApplicationLogger.LogError(ex, "ResponsibilityMasterAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public ResponsibilityMasterModel GetResponsibilityMasterDataById(ResponsibilityMasterModel model)
        {
            Int32 returnResult = 0;

            ResponsibilityMasterModel response = new ResponsibilityMasterModel();
            List<ResponsibilityMasterModel> responseList = new List<ResponsibilityMasterModel>();
            try
            {
                DataSet ds = PPCdata.GetResponsibilityMasterDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new ResponsibilityMasterModel();
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
                ApplicationLogger.LogError(ex, "ResponsibilityMasterAccess", "GetResponsibilityMasterDataById");
                returnResult = -1;
                return null;
            }
        }
    }
}

