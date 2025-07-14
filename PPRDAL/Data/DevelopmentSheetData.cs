using FPDAL.Data;
using Infotech.ClassLibrary;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRDAL.Data
{
    public class DevelopmentSheetData : ConnectionObjects
    {

        public DataSet SelectAll(ProductProjectReportModel model, out Int32 ReturnResult, string UserType)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;

            SqlParameter[] parameters ={
                                           new SqlParameter("@UserType",UserType),
                                           new SqlParameter("@ProjectNumber",model.SearchbyProjectNo??""),
                                           new SqlParameter("@Status",model.SearchbyStatus??""),
                                           new SqlParameter("@Date",model.SearchbyDate??"")
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetAllDevelopmentSheetReport", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentSheetData", "SelectAll");
                //ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }

        #region DevelopmentSheet
        
        public DataSet ChangeDevelopmentSheetStatus(ProductProjectReportModel model, int ProjectID, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                            new SqlParameter("@ID",ProjectID),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@LoginUser",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                             new SqlParameter("@Remark",model.Remark),
                                             new SqlParameter("@Type",model.ProductDescription)

                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_DSForwardforApproval", parameters);
                ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentSheetData", "ChangeDevelopmentSheetStatus");
                ReturnResult = -1;
                return myDataSet;
            }
            finally

            {
            }
        }
        #endregion
    }
}

