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
using System.Text;
using System.Threading.Tasks;

namespace PPRDAL.Data
{
    public class ResponsibilityMasterData : ConnectionObjects
    {
        public DataSet SelectAll(ResponsibilityMasterModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                            new SqlParameter("@RespoID",model.Id),
                                            new SqlParameter("@RespoName",model.Name??string.Empty),
                                            new SqlParameter("@RespoDescription",model.Discription??string.Empty),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_RespoMaster_Sp", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ResponsibilityMasterData", "SelectAll");
                return null;
            }
            finally

            {
            }
        }
        public DataSet AddorEdit(ResponsibilityMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                             new SqlParameter("@Mode",11),
                                            new SqlParameter("@RespoID",model.Id),
                                            new SqlParameter("@RespoName",model.Name??string.Empty),
                                            new SqlParameter("@RespoDescription",model.Discription??string.Empty),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_RespoMaster_Sp", parameters);
                ReturnResult = Convert.ToInt32(parameters[6].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ResponsibilityMasterData", "AddorEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetResponsibilityMasterDataById(ResponsibilityMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                             new SqlParameter("@Mode",31),
                                             new SqlParameter("@RespoID",model.Id),
                                            new SqlParameter("@RespoName",model.Name??string.Empty),
                                            new SqlParameter("@RespoDescription",model.Discription??string.Empty),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                            //new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_RespoMaster_Sp", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ResponsibilityMasterData", "GetProductProjectReportDataById");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
    }
}
