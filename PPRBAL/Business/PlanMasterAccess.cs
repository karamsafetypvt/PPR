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
    public class PlanMasterAccess : IPlanMaster
    {
        PlanMasterData PPCdata = new PlanMasterData();
        public PlanMasterModel GetPlanMasterData(PlanMasterModel model)
            {
            PlanMasterModel response = new PlanMasterModel();
            List<PlanMasterModel> responseList = new List<PlanMasterModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new PlanMasterModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.Name = Convert.ToString(row["Name"]);
                            response.Discription = Convert.ToString(row["Description"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                       
                    }
                }
                response._StatusList = UtilityAccess.StatusListCategory();
                response._PlanMasterModelList=responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "PlanMasterAccess", "GetPlanMasterData");
                return null;
            }

        }
        public PlanMasterModel AddOrEdit(PlanMasterModel model)
        {
            Int32 returnResult = 0;
            PlanMasterModel response = new PlanMasterModel();
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
                ApplicationLogger.LogError(ex, "PlanMasterAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public PlanMasterModel GetPlanMasterDataById(PlanMasterModel model)
        {
            Int32 returnResult = 0;

            PlanMasterModel response = new PlanMasterModel();
            List<PlanMasterModel> responseList = new List<PlanMasterModel>();
            try
            {
                DataSet ds = PPCdata.GetPlanMasterDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new PlanMasterModel();
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
                ApplicationLogger.LogError(ex, "PlanMasterAccess", "GetPlanMasterDataById");
                returnResult = -1;
                return null;
            }
        }
    }
}

