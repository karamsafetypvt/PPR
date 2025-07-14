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
    public class CustomerMasterAccess: ICustomerMaster
    {
        CustomerMasterData PPCdata = new CustomerMasterData();
        public CustomerMasterModel GetCustomerMasterData(CustomerMasterModel model)
            {
            CustomerMasterModel response = new CustomerMasterModel();
            List<CustomerMasterModel> responseList = new List<CustomerMasterModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new CustomerMasterModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.Name = Convert.ToString(row["Name"]);
                            response.Discription = Convert.ToString(row["Description"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                       
                    }
                }
                response._StatusList = UtilityAccess.StatusListCategory();
                response._CustomerMasterModelList=responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "CustomerMasterAccess", "GetCustomerMasterData");
                return null;
            }

        }
        public CustomerMasterModel AddOrEdit(CustomerMasterModel model)
        {
            Int32 returnResult = 0;
            CustomerMasterModel response = new CustomerMasterModel();
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
                ApplicationLogger.LogError(ex, "CustomerMasterAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public CustomerMasterModel GetCustomerMasterDataById(CustomerMasterModel model)
        {
            Int32 returnResult = 0;

            CustomerMasterModel response = new CustomerMasterModel();
            List<CustomerMasterModel> responseList = new List<CustomerMasterModel>();
            try
            {
                DataSet ds = PPCdata.GetCustomerMasterDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new CustomerMasterModel();
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
                ApplicationLogger.LogError(ex, "CustomerMasterAccess", "GetCustomerMasterDataById");
                returnResult = -1;
                return null;
            }
        }
    }
}

