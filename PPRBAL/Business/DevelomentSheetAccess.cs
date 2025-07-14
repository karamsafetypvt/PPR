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
    public class DevelomentSheetAccess : IDevelopmentSheet
    {
        DevelopmentSheetData pprdata = new DevelopmentSheetData();
        public ProductProjectReportModel GetDevelopmentSheetReportData(ProductProjectReportModel model, string UserType)
        {
            int returnResult = 0;
            ProductProjectReportModel response = new ProductProjectReportModel();
            //response.ReturnCode = 0;
            //response.ReturnMessage = Response.Message(0);
            List<ProductProjectReportModel> responseList = new List<ProductProjectReportModel>();
            DataSet ds = pprdata.SelectAll(model, out returnResult, UserType);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new ProductProjectReportModel();
                            response.ProjectID = Convert.ToInt32(row["Id"]);
                            response.ProjectTitle = Convert.ToString(row["ProjectTitle"]);
                            response.ProjectNO = Convert.ToString(row["ProjectNumber"]);
                            response.Coordinator = Convert.ToString(row["Coordinator"]);
                            response.ProductCategory = Convert.ToString(row["Product_Category"] ?? 0);
                            response.ProductRefNo = Convert.ToString(row["Product_Ref_No"]);
                            response.ProductDescription = Convert.ToString(row["ProductDescription"]);
                            response.CompanyName = Convert.ToInt32(row["CompanyId"]);
                            response.OpeningDate = Convert.ToString(row["OpeningDate"]);
                            response.ClosingDate = Convert.ToString(row["ClosingDate"]);
                            response.CreatedDate = Convert.ToDateTime(row["CreateDate"]);
                            response.UpdatedDate = Convert.ToDateTime(row["UpdateDate"] ?? "");
                            response.CreatedBy = Convert.ToString(row["CreatedBy"]);
                            response.UpdatedBy = Convert.ToString(row["UpdateddBy"]);
                            response.Status = Convert.ToString(row["Status"]);
                            response.ApprovalStatus = Convert.ToInt32(row["ApprovalStatus"]);
                            responseList.Add(response);
                            response._ProductProjectReportList = responseList;
                        }
                    }
                    response._SearchbyStatusList = UtilityAccess.StatusListValcreate(2);
                    //response.ReturnCode = 12;
                    //response.ReturnMessage = Response.Message(returnResult);
                    //response.ContactModel = Model;
                }
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelomentSheetAccess", "GetDevelopmentSheetReportData");
                returnResult = -1;
                return null;
            }
            return response;
        }
        #region DevelopmentSheet
        public ProductProjectReportModel ChangeDevelopmentSheetStatus(int ProjectID, ProductProjectReportModel model)
        {
            Int32 returnResult = 0;
            ProductProjectReportModel response = new ProductProjectReportModel();
            string _Forwardsubject = "Forward PPR Report";
            string _Adminsubject = "PPR Report Apporved";
            string _Previoussubject = "PPR Report Re-assigned";
            string _body = "You received this email for PPR report approve for next level.";
            string Email;
            response.ReturnCode = 0;
            response.ReturnMessage = MsgResponse.Message(0);
            try
            {
                DataSet ds = pprdata.ChangeDevelopmentSheetStatus(model, ProjectID, out returnResult);
                if (returnResult > 0 && String.IsNullOrEmpty(model.Remark))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                if (returnResult == 29)
                                {
                                    //Email = Convert.ToString("dimpal.tech1@gmail.com");
                                    //Int32 RetVal = UtilityAccess.SendEmail("PPR Team", Email, _Forwardsubject, _body);
                                }
                                else if (returnResult == 31)
                                {
                                    //Email = Convert.ToString("dimpal.tech1@gmail.com");
                                    ////Email = Convert.ToString(row["email"]);
                                    //Int32 retval = UtilityAccess.SendEmail("PPR Team", Email, _Adminsubject, "You received this email for PPR report approve from the level 3 user.");
                                }
                            }
                        }
                    }

                }
                else
                {
                    //Email = Convert.ToString("dimpal.tech1@gmail.com");
                    ////Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    //Int32 RetVal = UtilityAccess.SendEmail("PPR Team", Email, _Previoussubject, _body);
                }
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }   
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelomentSheetAccess", "ChangeDevelopmentSheetStatus");
                return response;
            }
        }

        #endregion
    }
}
