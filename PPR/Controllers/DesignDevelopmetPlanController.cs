using DocumentFormat.OpenXml.EMMA;
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
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace PPR.Controllers
{
    public class DesignDevelopmetPlanController : BaseController
    {
        // GET: DesignDevelopmetPlan
        IDevelopmentPlan activity = new DevelopmentPlanAccess();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DevelopmentPlan(string ProjectID)
        {
            DevelopmentPlanModel model = new DevelopmentPlanModel();
            model = activity.GetAllActivity(ProjectID);
            model.ProjectID = Convert.ToInt16(ProjectID);
            return View(model);
        }
        [HttpPost]
        public ActionResult DevelopmentPlan(DevelopmentPlanModel data)
        {
            DevelopmentPlanModel model = new DevelopmentPlanModel();
            if (Session["PPR_LoggedUserName"] != null) { model.CreatedBy = Session["PPR_LoggedUserName"].ToString(); }
            else
            {
                model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            }
            HttpPostedFileBase httpPostedFileBase = null;
            int i = 0;
            //save Attachments
            httpPostedFileBase = Request.Files[i] as HttpPostedFileBase;
            if (httpPostedFileBase != null && httpPostedFileBase.ContentLength > 0)
            {
                //string fileName = Path.GetFileName(httpPostedFileBase.FileName);
                string originalFileName = Path.GetFileName(httpPostedFileBase.FileName);
                string fileName = AddTimestampToFileName(originalFileName);
                string ext = Path.GetExtension(httpPostedFileBase.FileName);
                String filePath = "/Upload/DFMEA/";

                data.DesignValidation_DOCUMENTSPATH = filePath + fileName;
                data.DesignValidation_DocumentName = fileName;
                if (System.IO.File.Exists(Server.MapPath(data.DesignValidation_DOCUMENTSPATH)))
                {
                    System.IO.File.Delete(Server.MapPath(data.DesignValidation_DOCUMENTSPATH));
                }
                if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);

            }
            DevelopmentPlanModel result = new DevelopmentPlanModel();
            model = activity.AddOrEdit(data);
            TempData["ReturnMessage"] = model.ReturnMessage;
            TempData["ReturnCode"] = model.ReturnCode;
            return RedirectToAction("DevelopmentPlan", "DesignDevelopmetPlan", new { ProjectID = model.ProjectID });
        }
        public DevelopmentPlanModel GetAllDesignDevelopmentPlan(DevelopmentPlanModel model)
        {
            DevelopmentPlanModel result = new DevelopmentPlanModel();
            result = activity.GetAllDesignDevelopmentPlan(model);
            return result;
        }
        [HttpGet]
        public ActionResult DesignDataSheet(string PageName, string ProjectID, string PlanID,string CompletionDate)
        {
            if (PageName == "_DesignInputDataSheet")
            {
                DesignDataSheetModel model = new DesignDataSheetModel(); 
                model = activity.GetData(ProjectID, PlanID);
                if (CompletionDate != "")
                {
                    DateTime completionDate = DateTime.ParseExact(CompletionDate.ToString(), "yyyy-MM-dd", null);
                    string formattedDate = completionDate.ToString("dd-MM-yyyy");
                    model.REF_Date = formattedDate.ToString();
                }
                return PartialView(PageName, model);
            }
            else if (PageName == "_DesignReview")
            {
                DesignReviewModel designreviewmodel = new DesignReviewModel();
                designreviewmodel = activity.GetDesignReviewData(ProjectID, PlanID);
                if (CompletionDate != "")
                {
                    DateTime completionDate = DateTime.ParseExact(CompletionDate.ToString(), "yyyy-MM-dd", null);
                    string formattedDate = completionDate.ToString("dd-MM-yyyy");
                    designreviewmodel.REF_Date = formattedDate.ToString();
                }
                return PartialView(PageName, designreviewmodel);
            }
            else if (PageName == "_DesignVerification")
            {
                DesignVerificationModel designVerificationmodel = new DesignVerificationModel();
                designVerificationmodel = activity.GetDesignVerificationData(ProjectID, PlanID);
                if (CompletionDate != "")
                {
                    DateTime completionDate = DateTime.ParseExact(CompletionDate.ToString(), "yyyy-MM-dd", null);
                    string formattedDate = completionDate.ToString("dd-MM-yyyy");
                    designVerificationmodel.REF_Date = formattedDate.ToString();
                }
                return PartialView(PageName, designVerificationmodel);
            }
            else if (PageName == "_QualityPlan")
            {
                QualityPlanModel qualityPlanModel = new QualityPlanModel();
                qualityPlanModel = activity.GetQualityPlanData(ProjectID, PlanID);
                if (CompletionDate != "")
                {
                    DateTime completionDate = DateTime.ParseExact(CompletionDate.ToString(), "yyyy-MM-dd", null);
                    string formattedDate = completionDate.ToString("dd-MM-yyyy");
                    qualityPlanModel.REF_Date = formattedDate.ToString();
                }
                return PartialView(PageName, qualityPlanModel);
            }
            else if (PageName == "_DesignValidation")
            {
                DesignValidationModel designValidationModel = new DesignValidationModel();
                designValidationModel = activity.GetDesignValidationData(ProjectID, PlanID);
                if (CompletionDate != "")
                {
                    DateTime completionDate = DateTime.ParseExact(CompletionDate.ToString(), "yyyy-MM-dd", null);
                    string formattedDate = completionDate.ToString("dd-MM-yyyy");
                    designValidationModel.REF_Date = formattedDate.ToString();
                }
                return PartialView(PageName, designValidationModel);
            }
            //else if (PageName == "_CheckListforIndustrilization")
            //{
            //    IndustrialisationModel industrialisationModel = new IndustrialisationModel();
            //    industrialisationModel = activity.GetIndustrialisationData(ProjectID, PlanID);
            //    if (CompletionDate != "")
            //    {
            //        DateTime completionDate = DateTime.ParseExact(CompletionDate.ToString(), "yyyy-MM-dd", null);
            //        string formattedDate = completionDate.ToString("dd-MM-yyyy");
            //        industrialisationModel.REF_Date = formattedDate.ToString();
            //    }
            //    return PartialView(PageName, industrialisationModel);
            //}
            else if (PageName == "_CheckListforIndustrilization")
            {
                IndustrialisationModel_New industrialisationModel = new IndustrialisationModel_New();
                industrialisationModel = activity.GetIndustrialisationData_New(ProjectID, PlanID);
                //if (CompletionDate != "")
                //{
                //    //DateTime completionDate = DateTime.ParseExact(CompletionDate.ToString(), "yyyy-MM-dd", null);
                //    //string formattedDate = completionDate.ToString("dd-MM-yyyy");
                //    //industrialisationModel.REF_Date = formattedDate.ToString();
                //}
                return PartialView(PageName, industrialisationModel);
            }
            else
            {
                return View();
            }
        }

        public ActionResult SaveDesignInputDataSheet(DesignDataSheetModel model)
        {
            DesignDataSheetModel ddsm = new DesignDataSheetModel();
            model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            ddsm = activity.AddOrEdit_DesignInputDataSheet(model);
            if (ddsm != null)
            {
                TempData["ReturnMessage"] = ddsm.ReturnMessage;
                TempData["ReturnCode"] = ddsm.ReturnCode;
                return RedirectToAction("DevelopmentPlan", "DesignDevelopmetPlan", new { ProjectID = model.ProjectID });
            }
            else
            {
                return View();
            }
        }
        public ActionResult SaveDesignReview(DesignReviewModel model)
        {
            DesignReviewModel ddsm = new DesignReviewModel();
            HttpPostedFileBase httpPostedFileBase = null;
            int i = 0;
            //save Attachments
            httpPostedFileBase = Request.Files[i] as HttpPostedFileBase;
            if (httpPostedFileBase != null && httpPostedFileBase.ContentLength > 0)
            {
                //string fileName = Path.GetFileName(httpPostedFileBase.FileName);
                string originalFileName = Path.GetFileName(httpPostedFileBase.FileName);
                string fileName = AddTimestampToFileName(originalFileName);
                string ext = Path.GetExtension(httpPostedFileBase.FileName);
                String filePath = "/Upload/DesignReview/";
                if (model.DesignReview_DOCUMENTS != null)
                {
                    model.DesignReview_DOCUMENTSPATH = filePath + fileName;
                    model.DesignReview_DocumentName = fileName;
                    if (System.IO.File.Exists(Server.MapPath(model.DesignReview_DOCUMENTSPATH)))
                    {
                        System.IO.File.Delete(Server.MapPath(model.DesignReview_DOCUMENTSPATH));
                    }
                    if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                    httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);

                }
            }

            model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            ddsm = activity.AddOrEdit_DesignReviewDataSheet(model);
            if (ddsm != null)
            {
                TempData["ReturnMessage"] = ddsm.ReturnMessage;
                TempData["ReturnCode"] = ddsm.ReturnCode;
                return RedirectToAction("DevelopmentPlan", "DesignDevelopmetPlan", new { ProjectID = model.ProjectID });
            }
            else
            {
                return View();
            }
        }

        public static string SanitizeFilename(string filename)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
            string fileExtension = Path.GetExtension(filename);

            // Define a regular expression to match any character that is not a letter, digit, or underscore
            string pattern = @"[^\w\d_]+";

            // Replace matched characters with an empty string
            string sanitizedFileNameWithoutExtension = Regex.Replace(fileNameWithoutExtension, pattern, "");

            // Combine sanitized file name and extension
            string sanitizedFilename = sanitizedFileNameWithoutExtension + fileExtension;

            return sanitizedFilename; 
        }
        public static string AddTimestampToFileName(string originalFileName)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string extension = Path.GetExtension(originalFileName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);

            return $"{fileNameWithoutExtension}_{timestamp}{extension}";
        }

        [HttpPost]
        public ActionResult SaveQualityPlan(QualityPlanModel model, FormCollection data)
        {
            QualityPlanModel ddsm = new QualityPlanModel();
            HttpPostedFileBase httpPostedFileBase = null;
            int count = default(int);
            int i = 0;

            try
            {
                foreach (var item in Request.Files)
                {
                    // Save profile pic
                    httpPostedFileBase = Request.Files[i] as HttpPostedFileBase;
                    if (httpPostedFileBase != null && httpPostedFileBase.ContentLength > 0)
                    {
                        string originalFileName = Path.GetFileName(httpPostedFileBase.FileName);
                        string fileName = AddTimestampToFileName(originalFileName);

                        string filePath = "/Upload/QualityPlanDocs/";

                        if (model.WORKINSTRUCTIONS_DOCUMENTS != null)
                        {
                            model.WORKINSTRUCTIONS_DOCUMENTSPATH = filePath + fileName;
                            model.WORKINSTRUCTIONS_DocumentName = fileName;
                            if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                                System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                            httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);
                            model.WORKINSTRUCTIONS_DOCUMENTS = null;
                        }
                        else if (model.INSPECTIONCRITERION_DOCUMENTS != null)
                        {
                            model.INSPECTIONCRITERION_DOCUMENTSPATH = filePath + fileName;
                            model.INSPECTIONCRITERION_DocumentName = fileName;
                            if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                                System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                            httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);
                            model.INSPECTIONCRITERION_DOCUMENTS = null;
                        }
                        else if (model.TESTINGPLAN_DOCUMENTS != null)
                        {
                            model.TESTINGPLAN_DOCUMENTSPATH = filePath + fileName;
                            model.TESTINGPLAN_DocumentName = fileName;
                            if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                                System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                            httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);
                            model.TESTINGPLAN_DOCUMENTS = null;
                        }
                        else if (model.TechnicalDataSheet_DOCUMENTS != null)
                        {
                            model.TechnicalDataSheet_DOCUMENTSPATH = filePath + fileName;
                            model.TechnicalDataSheet_DocumentName = fileName;
                            if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                                System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                            httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);
                            model.TechnicalDataSheet_DOCUMENTS = null;
                        }
                        else if (model.TechnicalDrawings_DOCUMENTS[0] != null)
                        {
                            fileName = "";
                            model.TechnicalDrawings_DOCUMENTSPATH = "";
                            model.TechnicalDrawings_DocumentName = "";
                            foreach (var item1 in model.TechnicalDrawings_DOCUMENTS)
                            {
                                fileName = AddTimestampToFileName(item1.FileName) + ",";
                                string fileName1 = AddTimestampToFileName(item1.FileName);

                                model.TechnicalDrawings_DOCUMENTSPATH += filePath + fileName.Trim();
                                model.TechnicalDrawings_DocumentName += fileName;
                                if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                                    System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                                httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName1);
                            }
                            model.TechnicalDrawings_DOCUMENTS[0] = null;
                        }
                        else if (model.TechnicalFile_DOCUMENTS != null)
                        {
                            model.TechnicalFile_DOCUMENTSPATH = filePath + fileName;
                            model.TechnicalFile_DocumentName = fileName;
                            if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                                System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                            httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);
                            model.TechnicalFile_DOCUMENTS = null;
                        }
                        else if (model.UserInstruction_DOCUMENTS != null)
                        {
                            model.UserInstruction_DOCUMENTSPATH = filePath + fileName;
                            model.UserInstruction_DocumentName = fileName;
                            if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                                System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                            httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);
                            model.UserInstruction_DOCUMENTS = null;
                        }
                    }
                    i++;
                }

                model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
                ddsm = activity.AddOrEdit_QualityPlanDataSheet(model);
                if (ddsm != null)
                {
                    TempData["ReturnMessage"] = ddsm.ReturnMessage;
                    TempData["ReturnCode"] = ddsm.ReturnCode;
                    return RedirectToAction("DevelopmentPlan", "DesignDevelopmetPlan", new { ProjectID = model.ProjectID });
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddOrEdit_QualityPlanDataSheet");
                TempData["ReturnMessage"] = "An error occurred while saving the quality plan.";
                TempData["ReturnCode"] = "Error";
                return View("Error"); // Or return View() if you don't have a specific error view
            }
        }
         

        public ActionResult SaveDesignVerification(DesignVerificationModel model)
        {
            DesignVerificationModel ddsm = new DesignVerificationModel();
            HttpPostedFileBase httpPostedFileBase = null;
            int i = 0;
            //save Attachments
            httpPostedFileBase = Request.Files[i] as HttpPostedFileBase;
            if (httpPostedFileBase != null && httpPostedFileBase.ContentLength > 0)
            {
                //string fileName = Path.GetFileName(httpPostedFileBase.FileName);
                string originalFileName = Path.GetFileName(httpPostedFileBase.FileName);
                string fileName = AddTimestampToFileName(originalFileName);
                string ext = Path.GetExtension(httpPostedFileBase.FileName);
                String filePath = "/Upload/DesignVerification/";
                if (model.DesignVerification_DOCUMENTS != null)
                {
                    model.DesignVerification_DOCUMENTSPATH = filePath + fileName;
                    model.DesignVerification_DocumentName = fileName;
                    if (System.IO.File.Exists(Server.MapPath(model.DesignVerification_DOCUMENTSPATH)))
                    {
                        System.IO.File.Delete(Server.MapPath(model.DesignVerification_DOCUMENTSPATH));
                    }
                    if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                    httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);

                }
            }
            model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            ddsm = activity.AddOrEdit_DesignVerification(model);
            if (ddsm != null)
            {
                TempData["ReturnMessage"] = ddsm.ReturnMessage;
                TempData["ReturnCode"] = ddsm.ReturnCode;
                return RedirectToAction("DevelopmentPlan", "DesignDevelopmetPlan", new { ProjectID = model.ProjectID });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult SaveDesignValidationPlan(DesignValidationModel model)
        {
            DesignValidationModel ddsm = new DesignValidationModel();
            HttpPostedFileBase httpPostedFileBase = null;
            int i = 0;
            //save Attachments
            httpPostedFileBase = Request.Files[i] as HttpPostedFileBase;
            if (httpPostedFileBase != null && httpPostedFileBase.ContentLength > 0)
            {
                //string fileName = Path.GetFileName(httpPostedFileBase.FileName);
                string originalFileName = Path.GetFileName(httpPostedFileBase.FileName);
                string fileName = AddTimestampToFileName(originalFileName);
                string ext = Path.GetExtension(httpPostedFileBase.FileName);
                String filePath = "/Upload/DesignValidation/";
                if (model.DesignValidation_DOCUMENTS != null)
                {
                    model.DesignValidation_DOCUMENTSPATH = filePath + fileName;
                    model.DesignValidation_DocumentName = fileName;
                    if (System.IO.File.Exists(Server.MapPath(model.DesignValidation_DOCUMENTSPATH)))
                    {
                        System.IO.File.Delete(Server.MapPath(model.DesignValidation_DOCUMENTSPATH));
                    }
                    if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                    httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);

                }
            }
            model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            ddsm = activity.AddOrEdit_DesignValidationDataSheet(model);
            if (ddsm != null)
            {
                TempData["ReturnMessage"] = ddsm.ReturnMessage;
                TempData["ReturnCode"] = ddsm.ReturnCode;
                return RedirectToAction("DevelopmentPlan", "DesignDevelopmetPlan", new { ProjectID = model.ProjectID });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult SaveInduatrilisationDataSheet(IndustrialisationModel model)
        {
            IndustrialisationModel ddsm = new IndustrialisationModel();
            HttpPostedFileBase httpPostedFileBase = null;
            int i = 0;
            //save Attachments
            httpPostedFileBase = Request.Files[i] as HttpPostedFileBase;
            if (httpPostedFileBase != null && httpPostedFileBase.ContentLength > 0)
            {
                //string fileName = Path.GetFileName(httpPostedFileBase.FileName);
                string originalFileName = Path.GetFileName(httpPostedFileBase.FileName);
                string fileName = AddTimestampToFileName(originalFileName);
                string ext = Path.GetExtension(httpPostedFileBase.FileName);
                String filePath = "/Upload/CheckListForIndustralization/";
                if (model.QUALITYPLAN_DOCUMENTS != null)
                {
                    model.QUALITYPLAN_DOCUMENTSPATH = filePath + fileName;
                    model.JIGFIXTURESTOOLSNew = fileName;
                    if (System.IO.File.Exists(Server.MapPath(model.QUALITYPLAN_DOCUMENTSPATH)))
                    {
                        System.IO.File.Delete(Server.MapPath(model.QUALITYPLAN_DOCUMENTSPATH));
                    }
                    if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                    httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);

                }
            }
            model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            ddsm = activity.AddOrEdit_InduatrilisationDataSheet(model);
            if (ddsm != null)
            {
                TempData["ReturnMessage"] = ddsm.ReturnMessage;
                TempData["ReturnCode"] = ddsm.ReturnCode;
                return RedirectToAction("DevelopmentPlan", "DesignDevelopmetPlan", new { ProjectID = model.ProjectID });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult SaveInduatrilisationDataSheet_New(IndustrialisationModel_New model)
        {
            IndustrialisationModel_New ddsm = new IndustrialisationModel_New();
            HttpPostedFileBase httpPostedFileBase = null;
            int i = 0;
            //save Attachments
            httpPostedFileBase = Request.Files[i] as HttpPostedFileBase;
            if (httpPostedFileBase != null && httpPostedFileBase.ContentLength > 0)
            {
                //string fileName = Path.GetFileName(httpPostedFileBase.FileName);
                string originalFileName = Path.GetFileName(httpPostedFileBase.FileName);
                string fileName = AddTimestampToFileName(originalFileName);
                string ext = Path.GetExtension(httpPostedFileBase.FileName);
                String filePath = "/Upload/CheckListForIndustralization/";
                if (model.QUALITYPLAN_DOCUMENTS != null)
                {
                    model.QUALITYPLAN_DOCUMENTSPATH = filePath + fileName;
                    model.ItemPicture = fileName;
                    if (System.IO.File.Exists(Server.MapPath(model.QUALITYPLAN_DOCUMENTSPATH)))
                    {
                        System.IO.File.Delete(Server.MapPath(model.QUALITYPLAN_DOCUMENTSPATH));
                    }
                    if (!System.IO.Directory.Exists(Server.MapPath(filePath)))
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/" + filePath));
                    httpPostedFileBase.SaveAs(Server.MapPath("~/" + filePath) + "/" + fileName);

                }
            }
            model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            ddsm = activity.AddOrEdit_InduatrilisationDataSheet_New(model);
            if (ddsm != null)
            {
                TempData["ReturnMessage"] = ddsm.ReturnMessage;
                TempData["ReturnCode"] = ddsm.ReturnCode;
                return RedirectToAction("DevelopmentPlan", "DesignDevelopmetPlan", new { ProjectID = model.ProjectID });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowDevelopmentsheet(int ActivityID, int ProjectID)
        {

            IProductProjectReport ppr = new ProductProcessReportAccess();
            DevelopmentSheetModel pprm = new DevelopmentSheetModel();
            pprm = ppr.GetDevelopmentSheetImprovisation(ProjectID, ActivityID);
            TempData["test"] = "1";
            return PartialView(@"~/Views/ProductProjectReport/AddDevelopmentSheetImprovisation.cshtml", pprm);
        }
    }
}