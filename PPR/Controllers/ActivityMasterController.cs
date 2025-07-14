using PPR.Models;
using PPRBAL.Business;
using PPRBAL.Interface;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPR.Controllers
{
    public class ActivityMasterController : BaseController
    {
        // GET: ActivityMaster
        IActivityMaster activitymaster = new ActivityMasterAccess();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Activity()
        {
            
            ActivityMasterModel pprm = new ActivityMasterModel();
            pprm = activitymaster.GetAllActivityData();
            return View(pprm);
        }
        public ActionResult Create()
        {
            ActivityMasterModel model = new ActivityMasterModel();
            model = activitymaster.GetActivityCommonData();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ActivityMasterModel model)
        {
            ActivityMasterModel result = new ActivityMasterModel();
            if (Session["PPR_LoggedUserName"] != null) 
            { 
                model.CreatedBy = Session["PPR_LoggedUserName"].ToString(); 
            }
            else
            {
                model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            }
            result = activitymaster.AddOrEdit(model);
            if (result.ReturnCode == 11 || result.ReturnCode == 12)
            {
                TempData["ReturnMessage"] = result.ReturnMessage;
                TempData["ReturnCode"] = result.ReturnCode;
                return RedirectToAction("Activity", "ActivityMaster");
            }
            if (result.ReturnCode == -28 || result.ReturnCode == -8)
            {
                TempData["ReturnMessage"] = result.ReturnMessage;
                TempData["ReturnCode"] = result.ReturnCode;
                return RedirectToAction("Create","ActivityMaster");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int ActivityID)
        {
            ActivityMasterModel pprm = new ActivityMasterModel();
            pprm = activitymaster.GetActivityMasterDatabyId(ActivityID);
            return View(pprm);
        }
        [HttpPost]
        public ActionResult Edit(ActivityMasterModel model)
        {
            ActivityMasterModel pprm = new ActivityMasterModel();
            model.CreatedBy = Function.ReadCookie("FP_LoggedUserName");
            pprm = activitymaster.AddOrEdit(model);
            if (pprm.ReturnCode == 11 || pprm.ReturnCode == 12)
            {
                TempData["ReturnMessage"] = pprm.ReturnMessage;
                TempData["ReturnCode"] = pprm.ReturnCode;
                return RedirectToAction("Activity", "ActivityMaster");
            }
            if(pprm.ReturnCode==-28 || pprm.ReturnCode == -8)
            {
                TempData["ReturnMessage"] = pprm.ReturnMessage;
                TempData["ReturnCode"] = pprm.ReturnCode;
                return RedirectToAction("Edit", "ActivityMaster", new { ActivityID =model.ActivityID});
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int AID)
        {
            ActivityMasterModel pprm = new ActivityMasterModel();
            pprm = activitymaster.DeleteActivityMaster(AID);
            if (pprm != null)
            {
                TempData["ReturnMessage"] = pprm.ReturnMessage;
                TempData["ReturnCode"] = pprm.ReturnCode;
                return RedirectToAction("Activity", "ActivityMaster");
            }
            else
            {
                return View();
            }
        }
    }
}