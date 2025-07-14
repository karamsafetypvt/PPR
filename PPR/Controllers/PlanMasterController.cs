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
    [RoutePrefix("PlanMaster")]
    [Route("{action}")]
    public class PlanMasterController : BaseController
    {
        IPlanMaster PPC = new PlanMasterAccess();
        [HttpGet]
        public ActionResult Index()
        {
            PlanMasterModel model = new PlanMasterModel();
            PlanMasterModel PPCm = new PlanMasterModel();
            PPCm = PPC.GetPlanMasterData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            PlanMasterModel PPCm = new PlanMasterModel();
            PPCm._StatusList = UtilityAccess.StatusListCategory();
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Create(PlanMasterModel model)
        {
            PlanMasterModel PPCm = new PlanMasterModel();

            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "PlanMaster");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int CategoryID)
        {
            PlanMasterModel PPCm = new PlanMasterModel();
            PlanMasterModel model = new PlanMasterModel();
            model.Id = CategoryID;
            PPCm = PPC.GetPlanMasterDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(PlanMasterModel model)
        {
            PlanMasterModel PPCm = new PlanMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "PlanMaster");
            }
            else
            {
                return View();
            }
        }
    }
}
