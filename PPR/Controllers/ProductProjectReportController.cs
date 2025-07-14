
using ClosedXML.Excel;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2019.Drawing.Model3D;
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
    public class ProductProjectReportController : BaseController
    {
        // GET: ProductProjectReport
        IProductProjectReport ppr = new ProductProcessReportAccess();
        public ActionResult Index()
        {
            ProductProjectReportModel model = new ProductProjectReportModel();
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            model.PPR_For = Session["Dept_ID"].ToString();
            pprm = ppr.GetProductProjectReportData(model, Session["PNICode"].ToString());
            return View(pprm);
        }
        [HttpPost]
        public ActionResult Index(ProductProjectReportModel model)
        {
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            model.PPR_For = Session["Dept_ID"].ToString();
            pprm = ppr.GetProductProjectReportData(model, Session["PNICode"].ToString());
            return View(pprm);
        }
        public ActionResult Search_List(string Status, string No, string Date, string ApprovalStatus)
        {
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            pprm.SearchbyStatus = Status;
            pprm.SearchbyProjectNo = No;
            pprm.SearchbyDate = Date;
            pprm.Status = ApprovalStatus;
            pprm.PPR_For = Session["Dept_ID"].ToString();
            pprm = ppr.GetProductProjectReportData(pprm, Session["PNICode"].ToString());

            return PartialView("_Index", pprm);
        }
        public static string AddTimestampToFileName(string originalFileName)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string extension = Path.GetExtension(originalFileName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);

            return $"{fileNameWithoutExtension}_{timestamp}{extension}";
        }
        public ActionResult Create()
        {
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            pprm = ppr.GetProjectCommondata();
            return View(pprm);
        }
        [HttpPost]
        public ActionResult Create(ProductProjectReportModel model)
        {
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            HttpPostedFileBase httpPostedFileBase = null;
            try
            {
                httpPostedFileBase = Request.Files[0] as HttpPostedFileBase;
                var allowedExtensions = new[] {
            ".Jpg",".png",".jpg","jpeg"
        };
                string originalFileName = Path.GetFileName(httpPostedFileBase.FileName);
                string fileName = AddTimestampToFileName(originalFileName);
                //string fileName = Path.GetFileName(httpPostedFileBase.FileName);//getting only file name(ex-ganesh.jpg)  
                var ext = Path.GetExtension(httpPostedFileBase.FileName); //getting the extension(ex-.jpg)
                string filePath = "/Upload/ProductProjectReport/";
                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    model.ImageName = name + ext;
                    model.ImagePath = filePath + name + ext;
                    //model.ImagePath = Path.Combine(Server.MapPath("/Upload/ProductProjectReport/"), model.ImageName);
                    if (System.IO.File.Exists(Server.MapPath(filePath)))
                    {
                        System.IO.File.Delete(Server.MapPath(filePath));
                    }
                    if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                    httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);
                }
                model.CreatedBy = Session["PNICode"].ToString();
                model.PPR_For = Session["Dept_ID"].ToString();
                model.Status = "1";
                pprm = ppr.AddOrEdit(model);
                if (pprm != null)
                {
                    TempData["ReturnMessage"] = pprm.ReturnMessage;
                    TempData["ReturnCode"] = pprm.ReturnCode;
                    return RedirectToAction("Index", "ProductProjectReport");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectController", "Create");
                TempData["ReturnMessage"] = "An error occured while processing your request.";
                TempData["ReturnCode"] = -1;
                return View();
            }
        }

        public ActionResult Edit(int ProjectID)
        {
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            pprm = ppr.GetProductProjectReportDataById(ProjectID);
            return View(pprm);
        }
        [HttpPost]
        public ActionResult Edit(ProductProjectReportModel model)
        {
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            HttpPostedFileBase httpPostedFileBase = null;
            try
            {
                httpPostedFileBase = Request.Files[0] as HttpPostedFileBase;
                var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
        };
                string originalFileName = Path.GetFileName(httpPostedFileBase.FileName);
                string fileName = AddTimestampToFileName(originalFileName);
                //string fileName = Path.GetFileName(httpPostedFileBase.FileName);//getting only file name(ex-ganesh.jpg)  
                var ext = Path.GetExtension(httpPostedFileBase.FileName); //getting the extension(ex-.jpg)
                string filePath = "/Upload/ProductProjectReport/";
                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    model.ImageName = name + ext;
                    model.ImagePath = filePath + name + ext;
                    //model.ImagePath = Path.Combine(Server.MapPath("/Upload/ProductProjectReport/"), model.ImageName);
                    if (System.IO.File.Exists(Server.MapPath(model.ImagePath)))
                    {
                        System.IO.File.Delete(Server.MapPath(model.ImagePath));
                    }
                    if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                    httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);
                }
                model.CreatedBy = Session["PNICode"].ToString();
                model.PPR_For = Session["Dept_ID"].ToString();
                pprm = ppr.AddOrEdit(model);
                if (pprm != null)
                {
                    TempData["ReturnMessage"] = pprm.ReturnMessage;
                    TempData["ReturnCode"] = pprm.ReturnCode;
                    return RedirectToAction("Index", "ProductProjectReport");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "ProductProjectController", "Edit");
                TempData["ReturnMessage"] = "An error occured while processing your request.";
                TempData["ReturnCode"] = -1;
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int ProjectID)
        {
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            pprm = ppr.DeleteProductProjectReport(ProjectID);
            if (pprm != null)
            {
                TempData["ReturnMessage"] = pprm.ReturnMessage;
                TempData["ReturnCode"] = pprm.ReturnCode;
                return RedirectToAction("Index", "ProductProjectReport");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult ChangeProductStatus(int Status, int ProductID, string Type, string Remark)
        {
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            //pprm.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            pprm.CreatedBy = Session["PNICode"].ToString();
            pprm.PPR_For = Session["Dept_ID"].ToString();
            pprm.Remark = Remark;
            string Deptid = Session["Dept_ID"].ToString();
            if (Type == "Pre" && Status == 4 && Deptid == "40")// in TPD only 2 status
            {
                Status = Status - 1;
            }
            if (Type == "Pre" && Status > 1)
            {
                Status = Status - 2;
            }

            pprm.Status = Status.ToString();
            pprm.ProductDescription = Type.ToString();
            pprm = ppr.ChangeProductStatus(ProductID, pprm);
            if (pprm != null)
            {
                TempData["ReturnMessage"] = pprm.ReturnMessage;
                TempData["ReturnCode"] = pprm.ReturnCode;
                return RedirectToAction("Index", "ProductProjectReport");
            }
            else
            {
                return View();
            }
        }
        public ActionResult PPRList()
        {
            ProductProjectReportModel model = new ProductProjectReportModel();
            ProductProjectReportModel pprm = new ProductProjectReportModel();
            pprm = ppr.GetProductProjectReportData(model, Session["PPR_LoggedUserName"].ToString());
            return View(pprm);
        }
        //public ActionResult AddDevelopmentSheetImprovisation(int ProjectId,int ActivityID)
        //{
        //    DevelopmentSheetModel pprm = new DevelopmentSheetModel();
        //    pprm = ppr.GetDevelopmentSheetImprovisation(ProjectId, ActivityID);
        //    TempData["test"] = "1";
        //    return View(pprm);
        //}
        [HttpPost]
        public ActionResult AddDevelopmentSheetImprovisation(DevelopmentSheetModel model)
        {
            DevelopmentSheetModel pprm = new DevelopmentSheetModel();
            model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            pprm = ppr.AddADevelopmentSheetImprovisation(model);
            if (pprm != null)
            {
                TempData["ReturnMessage"] = pprm.ReturnMessage;
                TempData["ReturnCode"] = pprm.ReturnCode;
                //return RedirectToAction("AddDevelopmentSheetImprovisation", "ProductProjectReport", new { ProjectId = model.ProjectID });
                return RedirectToAction("DevelopmentPlan", "DesignDevelopmetPlan", new { ProjectID = model.ProjectID });
            }
            else
            {
                return View();
            }
        }

    }
}