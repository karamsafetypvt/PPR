using FPDAL.Data;
using Infotech.ClassLibrary;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PPRDAL.Data
{
    public class ProductProjectReportData : ConnectionObjects
    {

        public DataSet SelectAll(ProductProjectReportModel model, out Int32 ReturnResult, string UserType)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;

            SqlParameter[] parameters ={
                                           new SqlParameter("@Mode",41),
                                           new SqlParameter("@UserType",UserType),
                                           new SqlParameter("@ProjectNumber",model.SearchbyProjectNo??""),
                                           new SqlParameter("@Status",model.SearchbyStatus??""),
                                           new SqlParameter("@Date",model.SearchbyDate??""),
                                           new SqlParameter("@PPR_For",model.PPR_For),
                                           new SqlParameter("@ApprovalStatus",model.Status),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetAllProductProjectReport", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectReportData", "SelectAll");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        public DataSet AddorEdit(ProductProjectReportModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                            new SqlParameter("@ProjectID",model.ProjectID),
                                            new SqlParameter("@ProjectTitle",model.ProjectTitle??string.Empty),
                                            new SqlParameter("@ProjectNO",model.ProjectNO??string.Empty),
                                            new SqlParameter("@Coordinator",model.Coordinator),
                                            new SqlParameter("@ProductCategory",model.ProductCategory),
                                            new SqlParameter("@ProductRefNo",model.ProductRefNo),
                                            new SqlParameter("@ProductDescription",model.ProductDescription),
                                            new SqlParameter("@CompanyName",model.CompanyName),
                                            new SqlParameter("@OpeningDate",model.OpeningDate),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@ClosingDate",model.ClosingDate),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@ImageName",model.ImageName),
                                            new SqlParameter("@ImagePath",model.ImagePath),
                                            new SqlParameter("@PPR_For",model.PPR_For),
                                            //new SqlParameter("@WithPPR",model.WithPPR),
                                            //new SqlParameter("@WithDevelopmentSheet",model.WithDevelopmentSheet),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_AddOrEditProduct", parameters);
                ReturnResult = Convert.ToInt32(parameters[15].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectReportData", "AddorEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetProductProjectReportDataById(int ProjectID, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                            new SqlParameter("@ProjectID",ProjectID),
                                            //new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_GetProductProjectReportById", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectReportData", "GetProductProjectReportDataById");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }

        public DataSet GetProjectCommondata()
        {
            DataSet myDataSet = null;
            
            SqlParameter[] parameters ={

                                            //new SqlParameter("@ProjectID",ProjectID),
                                            //new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_GetProjectCommondata", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectReportData", "GetProjectCommondata");
                //ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        public DataSet DeleteProductProjectReport(int ProjectID, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                            new SqlParameter("@ID",ProjectID),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_DeleteProductProjectReport", parameters);
                ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectReportData", "GetProductProjectReportDataById");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        public DataSet ChangeProductStatus(ProductProjectReportModel model, int ProjectID, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                            new SqlParameter("@ID",ProjectID),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@LoginUser",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                             new SqlParameter("@Remark",model.Remark),
                                             new SqlParameter("@Type",model.ProductDescription),
                                             new SqlParameter("@PPR_For",model.PPR_For),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_ForwardforApproval", parameters);
                ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectReportData", "ChangeProductStatus");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        public DataSet GetMaxProjectNumber()
        {
            DataSet myDataSet = null;

            SqlParameter[] parameters ={
                                           new SqlParameter("@Mode",42),
                                           new SqlParameter("@UserType",""),
                                           new SqlParameter("@ProjectNumber",""),
                                           new SqlParameter("@Status",""),
                                           new SqlParameter("@Date","")
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetAllProductProjectReport", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectReportData", "GetMaxProjectNumber");

                return null;
            }
            finally

            {
            }
        }
        #region DevelopmentSheet
        public DataSet GetDevelopmentSheetImprovisationDataById(int ProjectID, int ActivityID, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                            new SqlParameter("@ProjectID",ProjectID),
                                            new SqlParameter("@ActivityID",ActivityID),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_GetDevelopmentSheetImprovisationDataById", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectReportData", "GetDevelopmentSheetImprovisationDataById");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }

        public int AddorEditDevelopmentSheetImprovisation(DevelopmentSheetModel model, DataTable dt, out Int32 ReturnResult)
        {
            try
            {
                DataTable dt1 = new DataTable();
                ReturnResult = 0;
                dt.TableName = "tblItem";
                DataSet myDataSet = new DataSet("myDataSet");
                myDataSet.Tables.Add(dt);
                string constr = ConfigurationManager.ConnectionStrings["DBPPR"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("dbo.Sp_AddOrEditDevelopmentSheetImprovisation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProjectID", model.ProjectID));
                cmd.Parameters.Add(new SqlParameter("@PlanID", model.PlanID));
                cmd.Parameters.Add(new SqlParameter("@ActivityID", model.ActivityID));
                cmd.Parameters.Add("@activitydata", SqlDbType.Xml).Value = (myDataSet == null ? null : myDataSet.GetXml());
                da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
                int result = Convert.ToInt32(dt1.Rows[0]["returnResult"]);
                return result;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectReportData", "AddorEditDevelopmentSheetImprovisation");
                ReturnResult = -1;
                return 0;
            }

        }
        #endregion
    }
}

