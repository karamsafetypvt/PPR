using FPDAL.Data;
using PPRBAL.Interface;
using PPRDAL.Data;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PPRBAL.Business
{
    public class ProductProcessReportAccess : IProductProjectReport
    {
        ProductProjectReportData pprdata = new ProductProjectReportData();
        public ProductProjectReportModel GetProductProjectReportData(ProductProjectReportModel model, string UserType)
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
                            response.ImagePath = Convert.ToString(row["ImagePath"]);
                            response.PPR_For = Convert.ToString(row["PPR_For"]);
                            responseList.Add(response);
                            response._ProductProjectReportList = responseList;
                        }
                    }
                    response._SearchbyStatusList = UtilityAccess.StatusListValcreateN(2);
                    response._StatusList = UtilityAccess.ApprovalStatusList(2);
                    //response.ReturnCode = 12;
                    //response.ReturnMessage = Response.Message(returnResult);
                    //response.ContactModel = Model;
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProcessReportAccess", "GetProductProjectReportData");
                returnResult = -1;
                return null;
            }

        }
        public ProductProjectReportModel AddOrEdit(ProductProjectReportModel model)
        {
            Int32 returnResult = 0;
            ProductProjectReportModel response = new ProductProjectReportModel();
            response.ReturnCode = 0;
            response.ReturnMessage = MsgResponse.Message(0);
            try
            {
                DataSet ds = pprdata.AddorEdit(model, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProcessReportAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public ProductProjectReportModel GetProductProjectReportDataById(int ProjectID)
        {
            Int32 returnResult = 0;
            ProductProjectReportModel response = new ProductProjectReportModel();
            List<ProductProjectReportModel> responseList = new List<ProductProjectReportModel>();
            try
            {
                DataSet ds = pprdata.GetProductProjectReportDataById(ProjectID, out returnResult);
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
                            string datenull = Convert.ToString(row["OpeningDate"]);
                            if (!String.IsNullOrEmpty(datenull))
                            {
                                DateTime tempDate1 = Convert.ToDateTime(row["OpeningDate"]);
                                response.OpeningDate = tempDate1.ToString("yyyy-MM-dd");
                            }

                            string datenull1 = Convert.ToString(row["ClosingDate"]);
                            if (!String.IsNullOrEmpty(datenull1))
                            {
                                DateTime tempDate2 = Convert.ToDateTime(row["ClosingDate"]);
                                response.ClosingDate = tempDate2.ToString("yyyy-MM-dd");
                            }

                            response.Status = Convert.ToString(row["Status"]);
                            response.ImagePath = Convert.ToString(row["ImagePath"]);
                            response.ImageName = Convert.ToString(row["ImageName"]);
                            //response.WithPPR = Convert.ToBoolean(row["WithPPR"]);
                            //response.WithDevelopmentSheet = Convert.ToBoolean(row["WithDevelopmentSheet"]);
                            responseList.Add(response);
                        }

                    }
                    response._StatusList = UtilityAccess.StatusListValcreate(1);
                    if(ds.Tables[2].Rows.Count > 0) 
                    {
                        response._ProductCategoryList = UtilityAccess.RenderList(ds.Tables[2],1);
                    }
                    else {
                        response._ProductCategoryList = UtilityAccess.DRPBlankList();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        response._CoordinatorList = UtilityAccess.RenderList(ds.Tables[1], 2);
                    }else
                    {
                        response._CoordinatorList = UtilityAccess.DRPBlankList();
                    }
                }
                response._ProductProjectReportList = responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProcessReportAccess", "GetProductProjectReportDataById");
                returnResult = -1;
                return response;
            }
        }
        public ProductProjectReportModel DeleteProductProjectReport(int ProjectID)
        {
            Int32 returnResult = 0;
            ProductProjectReportModel response = new ProductProjectReportModel();
            response.ReturnCode = 0;
            response.ReturnMessage = MsgResponse.Message(0);
            try
            {
                DataSet ds = pprdata.DeleteProductProjectReport(ProjectID, out returnResult);
                if (returnResult > 0)
                {
                    response.ReturnCode = returnResult;
                    response.ReturnMessage = MsgResponse.Message(returnResult);
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProcessReportAccess", "DeleteProductProjectReport");
                returnResult = -1;
                return null;
            }
        }
        public ProductProjectReportModel ChangeProductStatus(int ProjectID, ProductProjectReportModel model)
        {
            Int32 returnResult = 0;
            ProductProjectReportModel response = new ProductProjectReportModel();
            string _Forwardsubject = "Forward PPR Report";
            string _Adminsubject = "PPR Report Apporved";
            string _body = "Dear PPR Team, <br/><br/> Your request for PPR (";
            string _body1 = ") report approval request for the next level has been successfully approved.";
            string _Previoussubject = "Rejection of PPR Report Approval for Next Level";
            
            string _Previousbody = ") report approval at the next level has been rejected because " + model.Remark+ ". <br/><br/><br/> Thanks";
            string Email,PPRNo;
            response.ReturnCode = 0;
            response.ReturnMessage = MsgResponse.Message(0);
            try
            {
                DataSet ds = pprdata.ChangeProductStatus(model, ProjectID, out returnResult);
                if (returnResult > 0 && String.IsNullOrEmpty(model.Remark))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                PPRNo = Convert.ToString(row["PPRNo"]);
                                Email = Convert.ToString(row["email"]);
                                if (returnResult == 29)
                                { 
                                    Int32 RetVal = UtilityAccess.SendEmail("PPR Team", Email, _Forwardsubject, "Dear PPR Team, <br/><br/> This email regarding the approval of the PPR (" + PPRNo+ ") report for the next level is sent to you. <br/><br/><br/> Thanks");
                                }
                                else if (returnResult == 31)
                                { 
                                    Int32 retval = UtilityAccess.SendEmail("PPR Team", Email, _Adminsubject, "Dear PPR Team, <br/><br/> The request for the approval of your PPR (" + PPRNo + ") report has been approved. <br/><br/><br/> Thanks");
                                }
                            }
                        }
                    }

                }
                else
                {
                    Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    PPRNo = ds.Tables[0].Rows[0]["PPRNo"].ToString(); 
                    Int32 RetVal = UtilityAccess.SendEmail("PPR Team", Email, _Previoussubject, _body+PPRNo+ _Previousbody);
                }
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProcessReportAccess", "ChangeProductStatus");
                returnResult = -1;
                return null;
            }
        }
        public ProductProjectReportModel GetProjectCommondata()
        {
            ProductProjectReportModel response = new ProductProjectReportModel();
            DataSet ds = pprdata.GetProjectCommondata();
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response._CoordinatorList = UtilityAccess.RenderList(ds.Tables[0], 1);
                    }
                    else
                    {
                        response._CoordinatorList = UtilityAccess.DRPBlankList();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        response._ProductCategoryList = UtilityAccess.RenderList(ds.Tables[1], 1);
                    }
                    else
                    {
                        response._ProductCategoryList = UtilityAccess.DRPBlankList();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        response.MaxProjectNO = ds.Tables[2].Rows[0]["MaxProjectNumber"].ToString();
                        response.ProjectNO = UtilityAccess.AutoGenerateProjectNumber(response.MaxProjectNO);
                    }
                    response._StatusList = UtilityAccess.StatusListValcreate(2);
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProcessReportAccess", "ChangeProductStatus");
                return null;
            }
            
        }
        public ProductProjectReportModel GetProjectNumber()
        {
            ProductProjectReportModel response = new ProductProjectReportModel();
            DataSet ds = pprdata.GetMaxProjectNumber();
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.MaxProjectNO = ds.Tables[0].Rows[0]["MaxProjectNumber"].ToString();

                    }

                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProcessReportAccess", "GetProjectNumber");
                return null;
            }
        }
        #region DevelopmentSheet
        public DevelopmentSheetModel GetDevelopmentSheetImprovisation(int ProjectID, int ActivityID)
        {
            Int32 returnResult = 0;
            DevelopmentSheetModel response = new DevelopmentSheetModel();
            DevelopmentSheetComponent developmentresponse = new DevelopmentSheetComponent();
            List<DevelopmentSheetComponent> developmentresponseList = new List<DevelopmentSheetComponent>();
            try
            {
                DataSet ds = pprdata.GetDevelopmentSheetImprovisationDataById(ProjectID, ActivityID, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new DevelopmentSheetModel();
                            response.ProjectID = Convert.ToInt32(row["Id"]);
                            //response.SerialNo = Convert.ToInt32(row["Id"]);
                            response.RefNo = Convert.ToString(row["Product_Ref_No"]);
                            response.NewProductDescription = Convert.ToString(row["ProductDescription"]);
                            response.PPRNo = Convert.ToString(row["ProjectNumber"] ?? 0);
                            response.Status = Convert.ToString(row["Status"] ?? 0);

                        }
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row1 in ds.Tables[1].Rows)
                        {
                            developmentresponse = new DevelopmentSheetComponent();
                            developmentresponse.Statusofcurrentactionsunderplan = Convert.ToString(row1["Statusofcurrentactionsunderplan"] ?? null);
                            developmentresponse.Customer = Convert.ToString(row1["Customer"] ?? null);
                            developmentresponse.Resp = Convert.ToString(row1["Resp"] ?? null);
                            if (row1["TargetDate"].ToString() != "")
                            {
                                DateTime tempDate1 = Convert.ToDateTime(row1["TargetDate"]);
                                developmentresponse.TargetDate = tempDate1.ToString("yyyy-MM-dd");
                            }


                            if (row1["RevisedDate"].ToString() != "")
                            {
                                DateTime tempDate2 = Convert.ToDateTime(row1["RevisedDate"]);
                                developmentresponse.RevisedDate = tempDate2.ToString("yyyy-MM-dd");
                            }

                            if (row1["CompletionDate"].ToString() != "")
                            {
                                DateTime tempDate3 = Convert.ToDateTime(row1["CompletionDate"]);
                                developmentresponse.CompletionDate = tempDate3.ToString("yyyy-MM-dd");
                            }

                            developmentresponse.CertificationStatus = Convert.ToString(row1["CertificationStatus"]);
                            developmentresponse.Sampletobesentfortrial = Convert.ToString(row1["Sampletobesentfortrial"]);
                            developmentresponse.ItemcreationBOMRouting = Convert.ToString(row1["ItemcreationBOMRouting"]);
                            developmentresponse.TranslationStatus = Convert.ToString(row1["TranslationStatus"]);
                            developmentresponse.Remarks = Convert.ToString(row1["Reamark"] ?? null);
                            developmentresponse.MarkAsComplete = Convert.ToBoolean(row1["MarkAsComplete"]);
                            developmentresponse._CertificationStatusList = UtilityAccess.CertificationStatusList(2);
                            developmentresponse._TranslationStatusList = UtilityAccess.TransactionStatusList(2);
                            developmentresponse._ItemcreationBOMRoutingList = UtilityAccess.TransactionStatusList(2);
                            developmentresponse._SampletobesentfortrialList = UtilityAccess.StatusList(2);
                            developmentresponseList.Add(developmentresponse);
                        }
                    }
                    if(ds.Tables[2].Rows.Count>0)
                    {
                        response._CustomerList = UtilityAccess.CustomerList(ds.Tables[2], 1);
                    }
                    else {
                        response._CustomerList = UtilityAccess.DRPBlankList();
                    }
                    
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        response._underplanList = UtilityAccess.underplanList(ds.Tables[3], 1);
                    }
                    else {
                        response._underplanList = UtilityAccess.DRPBlankList();
                    }
                    
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        response._RespList = UtilityAccess.RespList(ds.Tables[4], 1);
                    }
                    else {
                        response._RespList = UtilityAccess.DRPBlankList();
                    }
                    
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        response._CertificationStatusList = UtilityAccess.CertificationStatusList_DDL(ds.Tables[5], 1);
                    }
                    else {
                        response._CertificationStatusList = UtilityAccess.DRPBlankList();
                    }
                    
                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        response._TranslationStatusList = UtilityAccess.TransactionStatusList_ddl(ds.Tables[6], 1);
                    }
                    else {
                        response._TranslationStatusList = UtilityAccess.DRPBlankList();
                    }
                    
                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        response._ItemcreationBOMRoutingList = UtilityAccess.TransactionStatusList_ddl(ds.Tables[6], 1);
                    }
                    else {
                        response._ItemcreationBOMRoutingList = UtilityAccess.DRPBlankList();
                    }
                    response._SampletobesentfortrialList = UtilityAccess.StatusList(2);

                }
                response._developmentSheetComponent = developmentresponseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProcessReportAccess", "GetDevelopmentSheetImprovisation");
                returnResult = -1;
                return null;
            }
        }

        public DevelopmentSheetModel AddADevelopmentSheetImprovisation(DevelopmentSheetModel model)
        {
            DataTable AddNewTableData = new DataTable();
            int returnResult = 0;

            DevelopmentSheetModel response = new DevelopmentSheetModel();
            try
            {
                AddNewTableData = AddNewTableData2(model);
                returnResult = pprdata.AddorEditDevelopmentSheetImprovisation(model, AddNewTableData, out returnResult);
                response.ProjectID = model.ProjectID;
                response.ReturnCode = returnResult; response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProcessReportAccess", "AddADevelopmentSheetImprovisation");
                returnResult = -1;
                return null;
            }

        }
        public static DataTable AddNewTableData2(DevelopmentSheetModel models)
        {
            DataTable dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow.Columns.Add("Statusofcurrentactionsunderplan", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Customer", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Resp", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("TargetDate", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("RevisedDate", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("CompletionDate", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("CertificationStatus", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Sampletobesentfortrial", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("ItemcreationBOMRouting", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("TranslationStatus", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Reamark", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Createby", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("MarkAsComplete", typeof(System.Boolean));
            try
            {
                if (models._developmentSheetComponent != null && models._developmentSheetComponent.Count > 0)
                {
                    foreach (var item in models._developmentSheetComponent)
                    {
                        //models.ProjectID = item.ProjectID;
                        DataRow dtRow = dtSetupSeriesRow.NewRow();
                        dtRow["Statusofcurrentactionsunderplan"] = item.Statusofcurrentactionsunderplan ?? "0";
                        dtRow["Customer"] = item.Customer ?? "0";
                        dtRow["Resp"] = item.Resp ?? "0";
                        dtRow["TargetDate"] = item.TargetDate;

                        //dtRow["TargetDate"] = item.TargetDate !=string.Empty?DateTime.Parse(item.TargetDate) : new DateTime(1900, 1, 1);
                        dtRow["RevisedDate"] = item.RevisedDate;
                        dtRow["CompletionDate"] = item.CompletionDate;
                        dtRow["CertificationStatus"] = item.CertificationStatus ?? "0";
                        dtRow["Sampletobesentfortrial"] = item.Sampletobesentfortrial ?? "0";
                        dtRow["ItemcreationBOMRouting"] = item.ItemcreationBOMRouting ?? "0";
                        dtRow["TranslationStatus"] = item.TranslationStatus ?? "0";
                        dtRow["Reamark"] = item.Remarks ?? null;
                        dtRow["CreateBy"] = models.CreatedBy ?? null;
                        dtRow["MarkAsComplete"] = item.MarkAsComplete;
                        dtSetupSeriesRow.Rows.Add(dtRow);
                    }
                }
                return dtSetupSeriesRow;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProcessReportAccess", "AddNewTableData2");
                return dtSetupSeriesRow;
            }
            finally
            {
            }
        }
        #endregion
    }
}
