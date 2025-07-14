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
    public class ProductProjectCategoryAccess : IProductProjectCategory
    {
        ProductProjectCategoryData PPCdata = new ProductProjectCategoryData();
        public ProductProjectCategoryModel GetProductProjectCategoryData(ProductProjectCategoryModel model)
        {
            ProductProjectCategoryModel response = new ProductProjectCategoryModel();
            List<ProductProjectCategoryModel> responseList = new List<ProductProjectCategoryModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new ProductProjectCategoryModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.Name = Convert.ToString(row["Name"]);
                            response.Discription = Convert.ToString(row["Discription"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                       
                    }
                }
                response._StatusList = UtilityAccess.StatusListCategory();
                response._ProductProjectCategoryList=responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectCategoryAccess", "GetProductProjectCategoryData");
               
                return null;
            }

        }
        public ProductProjectCategoryModel AddOrEdit(ProductProjectCategoryModel model)
        {
            Int32 returnResult = 0;
            ProductProjectCategoryModel response = new ProductProjectCategoryModel();
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
                ApplicationLogger.LogError(ex, "ProductProjectCategoryAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public ProductProjectCategoryModel GetProductProjectCategoryDataById(ProductProjectCategoryModel model)
        {
            Int32 returnResult = 0;

            ProductProjectCategoryModel response = new ProductProjectCategoryModel();
            List<ProductProjectCategoryModel> responseList = new List<ProductProjectCategoryModel>();
            try
            {
                DataSet ds = PPCdata.GetProductProjectReportDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new ProductProjectCategoryModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.Name = Convert.ToString(row["Name"]);
                            response.Discription = Convert.ToString(row["Discription"]);
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
                ApplicationLogger.LogError(ex, "ProductProjectCategoryAccess", "GetProductProjectCategoryData");
                returnResult = -1;
                return null;
            }
        }
    }
}

