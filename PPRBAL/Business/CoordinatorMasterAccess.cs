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
    public class CoordinatorMasterAccess : ICoordinatorMaster
    {
        CoordinatorMasterData PPCdata = new CoordinatorMasterData();
        public CoordinatorMasterModel GetCoordinatorMasterData(CoordinatorMasterModel model)
            {
            CoordinatorMasterModel response = new CoordinatorMasterModel();
            List<CoordinatorMasterModel> responseList = new List<CoordinatorMasterModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new CoordinatorMasterModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.Name = Convert.ToString(row["Name"]);
                            response.Discription = Convert.ToString(row["Description"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                       
                    }
                }
                response._StatusList = UtilityAccess.StatusListCategory();
                response._CoordinatorMasterModelList=responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "CoordinatorMasterAccess", "GetCoordinatorMasterData");
                return null;
            }

        }
        public CoordinatorMasterModel AddOrEdit(CoordinatorMasterModel model)
        {
            Int32 returnResult = 0;
            CoordinatorMasterModel response = new CoordinatorMasterModel();
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
                ApplicationLogger.LogError(ex, "CoordinatorMasterAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public CoordinatorMasterModel GetCoordinatorMasterDataById(CoordinatorMasterModel model)
        {
            Int32 returnResult = 0;

            CoordinatorMasterModel response = new CoordinatorMasterModel();
            List<CoordinatorMasterModel> responseList = new List<CoordinatorMasterModel>();
            try
            {
                DataSet ds = PPCdata.GetCoordinatorMasterDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new CoordinatorMasterModel();
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
                ApplicationLogger.LogError(ex, "CoordinatorMasterAccess", "GetCoordinatorMasterDataById");
                returnResult = -1;
                return null;
            }
        }
    }
}

