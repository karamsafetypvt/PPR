using FPDAL.Data;
using Infotech.ClassLibrary;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PPRDAL.Data
{
    public class  ReportData : ConnectionObjects
    {

        public DataSet GetPPRReport( ReportModel model, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;

            SqlParameter[] parameters ={
                                           new SqlParameter("@ProjectID",model.ProjectID),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_GetDesignDevelopmentDataForExcel", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ReportData", "GetPPRReport");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        public DataSet GetDevelopmentSheetReport(ReportModel model, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;

            SqlParameter[] parameters ={
                                           //new SqlParameter("@ProjectID",model.ProjectID),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_GetDevelopmentSheetDataForExcel", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ReportData", "GetDevelopmentSheetReport");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
    }
}

