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
    public class ActitvityMasterData : ConnectionObjects
    {

        public DataSet GetActivityCommonData()
        {
            ActivityMasterModel model = new ActivityMasterModel();
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                           new SqlParameter("@Mode",1),
                                           new SqlParameter("@ActivityID",model.ActivityID),
                                            new SqlParameter("@ActivityName",model.ActivityName??string.Empty),
                                            new SqlParameter("@SubActivity",model.SubActivity??string.Empty),
                                            new SqlParameter("@Status",model.Status??string.Empty),
                                            new SqlParameter("@Nature",model.Nature),
                                            new SqlParameter("@ResourceReq",model.ResourceReq),
                                            new SqlParameter("@Responsibility",model.Responsibility),
                                            new SqlParameter("@ApprovingAuthority",model.ApprovingAuthority),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                             new SqlParameter("@SequenceNo",model.SequenceNo),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetActivityMasterData", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ActitvityMasterData", "GetActivityCommonData");
                return null;
            }
            finally
            {
            }
        }
        public DataSet SelectAllActivityData()
        {
            ActivityMasterModel model = new ActivityMasterModel();
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                           new SqlParameter("@Mode",2),
                                           new SqlParameter("@ActivityID",model.ActivityID),
                                            new SqlParameter("@ActivityName",model.ActivityName??string.Empty),
                                            new SqlParameter("@SubActivity",model.SubActivity??string.Empty),
                                            new SqlParameter("@Status",model.Status??string.Empty),
                                            new SqlParameter("@Nature",model.Nature),
                                            new SqlParameter("@ResourceReq",model.ResourceReq),
                                            new SqlParameter("@Responsibility",model.Responsibility),
                                            new SqlParameter("@ApprovingAuthority",model.ApprovingAuthority),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@SequenceNo",model.SequenceNo),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetActivityMasterData", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ActitvityMasterData", "SelectAllActivityData");
                return null;
            }
            finally
            {
            }
        }
        public DataSet AddorEdit(ActivityMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",3),
                                            new SqlParameter("@ActivityID",model.ActivityID),
                                            new SqlParameter("@ActivityName",model.ActivityName??string.Empty),
                                            new SqlParameter("@SubActivity",model.SubActivity??string.Empty),
                                            new SqlParameter("@Status",model.Status??string.Empty),
                                            new SqlParameter("@Nature",model.Nature),
                                            new SqlParameter("@ResourceReq",model.ResourceReq),
                                            new SqlParameter("@Responsibility",model.Responsibility),
                                            new SqlParameter("@ApprovingAuthority",model.ApprovingAuthority),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@SequenceNo",model.SequenceNo),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetActivityMasterData", parameters);
                ReturnResult = Convert.ToInt32(parameters[11].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ActitvityMasterData", "AddorEdit");
                ReturnResult = -1;
                return myDataSet;
            }
            finally

            {
            }
        }
        public DataSet GetActivityMasterDatabyId(int ActivityID)
        {
            ActivityMasterModel model = new ActivityMasterModel();
            DataSet myDataSet = null;
            SqlParameter[] parameters ={

                                            new SqlParameter("@ActivityID",ActivityID),
                                            new SqlParameter("@ActivityName",model.ActivityName??string.Empty),
                                            new SqlParameter("@SubActivity",model.SubActivity??string.Empty),
                                            new SqlParameter("@Status",model.Status??string.Empty),
                                            new SqlParameter("@Nature",model.Nature),
                                            new SqlParameter("@ResourceReq",model.ResourceReq),
                                            new SqlParameter("@Responsibility",model.Responsibility),
                                            new SqlParameter("@ApprovingAuthority",model.ApprovingAuthority),
                                            new SqlParameter("@SequenceNo",model.SequenceNo),
                                            new SqlParameter("@Mode",4),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetActivityMasterData", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ActitvityMasterData", "GetActivityMasterDatabyId");
                return myDataSet;
            }
            finally

            {
            }
        }
        public DataSet DeleteActivityMaster(int ActivityID, out int ReturnResult)
        {
            ActivityMasterModel model = new ActivityMasterModel();
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                            new SqlParameter("@ActivityID",ActivityID),
                                            new SqlParameter("@ActivityName",model.ActivityName??string.Empty),
                                            new SqlParameter("@SubActivity",model.SubActivity??string.Empty),
                                            new SqlParameter("@Status",model.Status??string.Empty),
                                            new SqlParameter("@Nature",model.Nature),
                                            new SqlParameter("@ResourceReq",model.ResourceReq),
                                            new SqlParameter("@Responsibility",model.Responsibility),
                                            new SqlParameter("@ApprovingAuthority",model.ApprovingAuthority),
                                            new SqlParameter("@SequenceNo",model.SequenceNo),
                                               new SqlParameter("@Mode",5),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetActivityMasterData", parameters);
                ReturnResult = Convert.ToInt32(parameters[9].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ActitvityMasterData", "DeleteActivityMaster");
                ReturnResult = -1;
                return myDataSet;
            }
            finally

            {
            }
        }
    }
}
