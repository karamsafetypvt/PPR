using FPDAL.Data;
using PPRBAL.Interface;
using PPRDAL.Data;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Business
{
    public class LevelMasterAccess : ILevelMaster
    {
        LevelMasterData leveldata = new LevelMasterData();
        public LevelMasteranDesignMasterModel GetAllUsers(string PPR_For)
        {
            int returnResult = 0;
            LevelMasteranDesignMasterModel response = new LevelMasteranDesignMasterModel();
            List<LevelMasteranDesignMasterModel> responseList = new List<LevelMasteranDesignMasterModel>();
            DataSet ds = leveldata.SelectAll(response, out returnResult, PPR_For);
            try
            {
                response._PPRUserLevel1List = UtilityAccess.RenderList(ds.Tables[1], 1);
                response._PPRUserLevel2List = UtilityAccess.RenderList(ds.Tables[1], 1);
                response._PPRUserLevel3List = UtilityAccess.RenderList(ds.Tables[1], 1);
                response._DevelopmentsheetUserLevel1List = UtilityAccess.RenderList(ds.Tables[1], 1);
                response._DevelopmentsheetUserLevel2List = UtilityAccess.RenderList(ds.Tables[1], 1);
                response._DevelopmentsheetUserLevel3List = UtilityAccess.RenderList(ds.Tables[1], 1);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "LevelMasterAccess", "GetAllUsers");
                returnResult = -1;
                return null;
            }
           
        }
        public LevelMasteranDesignMasterModel GetAllSelectedUsers()
        {
            int returnResult = 0;
            LevelMasteranDesignMasterModel response = new LevelMasteranDesignMasterModel();
            List<LevelMasteranDesignMasterModel> responseList = new List<LevelMasteranDesignMasterModel>();
            DataSet ds = leveldata.SelectAll(response, out returnResult,"");
            if (ds != null && ds.Tables.Count > 0)
            {
                try
                {
                    response.PPRLevel1Ids = Convert.ToString(ds.Tables[0].Rows[0]["Value"]);
                    response.PPRLevel2Ids = Convert.ToString(ds.Tables[0].Rows[1]["Value"]);
                    response.PPRLevel3Ids = Convert.ToString(ds.Tables[0].Rows[2]["Value"]);
                    
                }
                catch (Exception ex)
                {
                    ApplicationLogger.LogError(ex, "LevelMasterAccess", "GetAllSelectedUsers");
                    returnResult = -1;
                    return null;
                }
            }
            return response;
        }
        public LevelMasteranDesignMasterModel GetAllSelectedDevelopmentsheetLeveUsers()
        {
            int returnResult = 0;
            LevelMasteranDesignMasterModel response = new LevelMasteranDesignMasterModel();
            List<LevelMasteranDesignMasterModel> responseList = new List<LevelMasteranDesignMasterModel>();
            DataSet ds = leveldata.SelectAllDevelopmentSheetLevel(response, out returnResult);
            if (ds != null && ds.Tables.Count > 0)
            {
                try
                {
                    response.Developmentsheet1Ids = Convert.ToString(ds.Tables[0].Rows[0]["Value"]);
                    response.Developmentsheet2Ids = Convert.ToString(ds.Tables[0].Rows[1]["Value"]);
                    //response.Developmentsheet3Ids = Convert.ToString(ds.Tables[0].Rows[2]["Value"]);
                }
                catch (Exception ex)
                {
                    ApplicationLogger.LogError(ex, "LevelMasterAccess", "GetAllSelectedDevelopmentsheetLeveUsers");
                    returnResult = -1;
                    return null;
                }
            }
            return response;
        }
        public LevelMasteranDesignMasterModel AddEditLevels(LevelMasteranDesignMasterModel model)
        {
            LevelMasteranDesignMasterModel response = new LevelMasteranDesignMasterModel();
            Int32 returnResult = 0;
            //response.ReturnCode = 0;
            //response.ReturnMessage = Response.Message(returnResult);
            try
            {
                DataTable AddNewTableData = new DataTable();
                //AddNewTableData = AddNewTableData1(model);
                DataSet da = leveldata.AddOrEdit(model, AddNewTableData, out returnResult);

                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "LevelMasterAccess", "AddEditLevels");
                returnResult = -1;
                return null;
            }

        }
        public LevelMasteranDesignMasterModel AddEditDevelopmentsheetLevels(LevelMasteranDesignMasterModel model)
        {
            LevelMasteranDesignMasterModel response = new LevelMasteranDesignMasterModel();
            Int32 returnResult = 0;
            //response.ReturnCode = 0;
            //response.ReturnMessage = Response.Message(returnResult);
            try
            {
                DataTable AddNewTableData = new DataTable();
                //AddNewTableData = AddNewTableData1(model);
                DataSet da = leveldata.AddEditDevelopmentsheetLevels(model, AddNewTableData, out returnResult);

                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "LevelMasterAccess", "AddEditDevelopmentsheetLevels");
                returnResult = -1;
                return null;
            }

        }
    }
}

