
using ClosedXML.Excel;
using FPDAL.Data;
using Newtonsoft.Json;
using PPR.Models;
using PPRBAL.Business;
using PPRBAL.Interface;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace PPR.Controllers
{
    public class ReportsController : BaseController
    {
        // GET: GetPPRReport
        IReports ppr = new  ReportsAccess();

        public ActionResult PPRReport()
        {
            return PartialView("_DevelopmentSheetReport");
        }
        [HttpGet]
        public string GetPPRReport(int ProjectID)
        {
            ReportModel pprm = new ReportModel();
            pprm.ProjectID = ProjectID;
            string result = ppr.GetPPRReport(pprm);
            return result;
        }
        [HttpGet]
        public string GetDevelopmentSheetReport()
        {
            ReportModel pprm = new ReportModel();
            //pprm.ProjectID = ProjectID;
            string result = ppr.GetDevelopmentSheetReport(pprm);
            return result;
        }
    }
}