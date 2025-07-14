using PPRBAL.Business;
using PPRBAL.Interface;
using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPR.Controllers
{
    [RoutePrefix("ResponsibilityMaster")]
    [Route("{action}")]
    public class ResponsibilityMasterController : BaseController
    {
        IResponsibilityMaster PPC = new ResponsibilityMasterAccess();
        [HttpGet]
        public ActionResult Index()
        {
            ResponsibilityMasterModel model = new ResponsibilityMasterModel();
            ResponsibilityMasterModel PPCm = new ResponsibilityMasterModel();
            PPCm = PPC.GetResponsibilityMasterData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            ResponsibilityMasterModel PPCm = new ResponsibilityMasterModel();
            PPCm._StatusList = UtilityAccess.StatusListCategory();
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Create(ResponsibilityMasterModel model)
        {
            ResponsibilityMasterModel PPCm = new ResponsibilityMasterModel();

            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "ResponsibilityMaster");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int CategoryID)
        {
            ResponsibilityMasterModel PPCm = new ResponsibilityMasterModel();
            ResponsibilityMasterModel model = new ResponsibilityMasterModel();
            model.Id = CategoryID;
            PPCm = PPC.GetResponsibilityMasterDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(ResponsibilityMasterModel model)
        {
            ResponsibilityMasterModel PPCm = new ResponsibilityMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "ResponsibilityMaster");
            }
            else
            {
                return View();
            }
        }
    }
}
