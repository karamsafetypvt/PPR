using FPDAL.Data;
using PPRBAL.Interface;
using PPRDAL.Data;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Business
{
    public class DashboardAccess:IDashboard
    {
        DashboardData data = new DashboardData();
        public DashBoardModel GetUsersLevel(DashBoardModel model)
        {
            DashBoardModel response = new DashBoardModel();
            List<DashBoardModel> responseList = new List<DashBoardModel>();
            DevelopmentSheetLevelModel developmentsheetresponse = new DevelopmentSheetLevelModel();
            List<DevelopmentSheetLevelModel> developmentsheetList = new List<DevelopmentSheetLevelModel>();
            DataSet ds = data.GetAllUserLevelData(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new DashBoardModel();
                            response.Level = Convert.ToString(row["LevelId"]);
                            //response.UserID = Convert.ToString(row["UserID"]);
                            response.UserName = Convert.ToString(row["UserName"]);
                            //response.LevelType = Convert.ToString(row["LevelType"]);
                            response.LevelOneCount = Convert.ToInt32(row["Level1"]);
                            response.LevelTwoCount = Convert.ToInt32(row["Level2"]);
                            response.LevelThreeCount = Convert.ToInt32(row["Level3"]);
                            responseList.Add(response);
                            response._DashBoardModelList = responseList;
                        }
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row1 in ds.Tables[1].Rows)
                        {
                            developmentsheetresponse = new DevelopmentSheetLevelModel();
                            developmentsheetresponse.Level = Convert.ToString(row1["LevelId"]);
                            //developmentsheetresponse.UserID = Convert.ToString(row1["UserID"]);
                            developmentsheetresponse.UserName = Convert.ToString(row1["UserName"]);
                            //developmentsheetresponse.LevelType = Convert.ToString(row1["LevelType"]);
                            developmentsheetresponse.LevelOneCount = Convert.ToInt32(row1["Level1"]);
                            developmentsheetresponse.LevelTwoCount = Convert.ToInt32(row1["Level2"]);
                            //developmentsheetresponse.LevelThreeCount = Convert.ToInt32(row1["Level3"]);
                            developmentsheetList.Add(developmentsheetresponse);
                            response._DevelopmentSheetLevelList = developmentsheetList;
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DashboardAccess", "GetUsersLevel");
                return null;
            }
            
        }

    }
}
