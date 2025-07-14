using FPDAL.Data;
using Infotech.ClassLibrary;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRDAL.Data
{
    public class DashboardData : ConnectionObjects
    {
        public DataSet GetAllUserLevelData(DashBoardModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                new SqlParameter("@EmployeeID",model.UserID??""),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Sp_PPRGetUserLevelData", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DashboardData", "GetAllUserLevelData");
                return null;
            }
            finally
            {
            }
        }
    }
}
