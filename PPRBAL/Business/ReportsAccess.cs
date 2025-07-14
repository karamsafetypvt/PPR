using FPDAL.Data;
using PPRBAL.Interface;
using PPRDAL.Data;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PPRBAL.Business
{
    public class  ReportsAccess : IReports
    {
         ReportData pprdata = new  ReportData();
       

        public string GetPPRReport(ReportModel model)
        {
            int returnResult = 0;
            ReportModel response = new ReportModel();
            List<ReportModel> responseList = new List<ReportModel>();
            DataSet ds = pprdata.GetPPRReport(model, out returnResult);
            try
            {
                string json = "";
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            json += row[0];
                        }
                    }
                  
                }
                return json;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ReportAccess", "GetPPRReport");
                returnResult = -1;
                return null;
            }

        }
        public string GetDevelopmentSheetReport(ReportModel model)
        {
            int returnResult = 0;
            ReportModel response = new ReportModel();
            List<ReportModel> responseList = new List<ReportModel>();
            DataSet ds = pprdata.GetDevelopmentSheetReport(model, out returnResult);
            try
            {
                string json = "";
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            json += row[0];
                        }
                    }

                }
                return json;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ReportAccess", "GetDevelopmentSheetReport");
                returnResult = -1;
                return null;
            }

        }

    }
}
