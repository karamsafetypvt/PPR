using ClosedXML.Excel;
using FPDAL.Data;
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
using System.Web;
using System.Web.Mvc;

namespace PPR.Controllers
{
    public class DevelopmentSheetController : BaseController
    {
        // GET: ProductProjectReport
        IDevelopmentSheet ppr = new DevelomentSheetAccess();

        public ActionResult PPRList()
        {
            ProductProjectReportModel model = new ProductProjectReportModel();
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            pprm = ppr.GetDevelopmentSheetReportData(model, Session["PNICode"].ToString());
            return View(pprm);
        }
        [HttpPost]
        public ActionResult PPRList(ProductProjectReportModel model)
        {
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            pprm = ppr.GetDevelopmentSheetReportData(model, Session["PNICode"].ToString());
            return View(pprm);
        }
    

        [HttpGet]
        public ActionResult ChangeDevelopmentSheetStatus(int Status, int ProductID, string Type, string Remark)
        {
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            //pprm.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            pprm.CreatedBy = Session["PNICode"].ToString();
            pprm.Remark = Remark;
            if (Type == "Pre" && Status > 1)
            {
                Status = Status - 2;
            }
            pprm.Status = Status.ToString();
            pprm.ProductDescription = Type.ToString();
            pprm = ppr.ChangeDevelopmentSheetStatus(ProductID, pprm);
            if (pprm != null)
            {
                TempData["ReturnMessage"] = pprm.ReturnMessage;
                TempData["ReturnCode"] = pprm.ReturnCode;
                return RedirectToAction("PPRList", "DevelopmentSheet");
            }
            else
            {
                return View();
            }
        }
    }
}