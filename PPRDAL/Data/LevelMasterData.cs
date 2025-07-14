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
    public class LevelMasterData : ConnectionObjects
    {
        
        public DataSet SelectAll(LevelMasteranDesignMasterModel model, out Int32 ReturnResult,string PPR_For)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                          new SqlParameter("@Dept",PPR_For??string.Empty),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetAllUsersDataForLevel", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "LevelMasterData", "SelectAll");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet SelectAllDevelopmentSheetLevel(LevelMasteranDesignMasterModel model, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetAllDevelopmentSheetLevel", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "LevelMasterData", "SelectAllDevelopmentSheetLevel");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet AddOrEdit(LevelMasteranDesignMasterModel model, DataTable dt, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Level1",model.PPRLevel1Ids??string.Empty),
                                            new SqlParameter("@Level2",model.PPRLevel2Ids??string.Empty),
                                            new SqlParameter("@Level3",model.PPRLevel3Ids??string.Empty),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Sp_AddOrEditUserLevel", parameters);
                ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "LevelMasterData", "AddOrEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet AddEditDevelopmentsheetLevels(LevelMasteranDesignMasterModel model, DataTable dt, out Int32 ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Level1",model.Developmentsheet1Ids??string.Empty),
                                            new SqlParameter("@Level2",model.Developmentsheet2Ids??string.Empty),
                                            new SqlParameter("@Level3",model.Developmentsheet3Ids??string.Empty),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_IPD_PPRsheetLevel", parameters);
                ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "LevelMasterData", "AddEditDevelopmentsheetLevels");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
    }
}
