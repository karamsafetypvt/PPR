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
    public class UnitMasterAccess : IUnitMaster
    {
        UnitMasterData PPCdata = new UnitMasterData();
        public UnitMasterModel GetUnitMasterData(UnitMasterModel model)
            {
            UnitMasterModel response = new UnitMasterModel();
            List<UnitMasterModel> responseList = new List<UnitMasterModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new UnitMasterModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.Name = Convert.ToString(row["Name"]);
                            response.Discription = Convert.ToString(row["Description"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                    }
                }
                
                response._UnitMasterModelList=responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UnitMasterAccess", "GetUnitMasterData");
                return null;
            }

        }
        public UnitMasterModel AddOrEdit(UnitMasterModel model)
        {
            Int32 returnResult = 0;
            UnitMasterModel response = new UnitMasterModel();
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
                ApplicationLogger.LogError(ex, "UnitMasterAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public UnitMasterModel GetUnitMasterDataById(UnitMasterModel model)
        {
            Int32 returnResult = 0;

            UnitMasterModel response = new UnitMasterModel();
            List<UnitMasterModel> responseList = new List<UnitMasterModel>();
            try
            {
                DataSet ds = PPCdata.GetUnitMasterDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new UnitMasterModel();
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
                ApplicationLogger.LogError(ex, "UnitMasterAccess", "GetUnitMasterDataById");
                returnResult = -1;
                return null;
            }
        }
    }
}

