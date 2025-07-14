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
    public class CoordinatorMasterData : ConnectionObjects
    {
        public DataSet SelectAll(CoordinatorMasterModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                            new SqlParameter("@CoordinatorID",model.Id),
                                            new SqlParameter("@CoordinatorName",model.Name??string.Empty),
                                            new SqlParameter("@CoordinatorDescription",model.Discription??string.Empty),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_CoordinatorMaster_Sp", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "CoordinatorMasterData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public DataSet AddorEdit(CoordinatorMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                             new SqlParameter("@Mode",11),
                                            new SqlParameter("@CoordinatorID",model.Id),
                                            new SqlParameter("@CoordinatorName",model.Name??string.Empty),
                                            new SqlParameter("@CoordinatorDescription",model.Discription??string.Empty),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_CoordinatorMaster_Sp", parameters);
                ReturnResult = Convert.ToInt32(parameters[6].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "CoordinatorMasterData", "AddorEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetCoordinatorMasterDataById(CoordinatorMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                             new SqlParameter("@Mode",31),
                                             new SqlParameter("@CoordinatorID",model.Id),
                                            new SqlParameter("@CoordinatorName",model.Name??string.Empty),
                                            new SqlParameter("@CoordinatorDescription",model.Discription??string.Empty),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                            //new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.PPR_CoordinatorMaster_Sp", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "CoordinatorMasterData", "GetCoordinatorMasterDataById");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
    }
}
