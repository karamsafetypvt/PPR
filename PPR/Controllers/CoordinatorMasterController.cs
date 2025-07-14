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
    [RoutePrefix("CoordinatorMaster")]
    [Route("{action}")]
    public class CoordinatorMasterController : BaseController
    {
        ICoordinatorMaster PPC = new CoordinatorMasterAccess();
        [HttpGet]
        public ActionResult Index()
        {
            CoordinatorMasterModel model = new CoordinatorMasterModel();
            CoordinatorMasterModel PPCm = new CoordinatorMasterModel();
            PPCm = PPC.GetCoordinatorMasterData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            CoordinatorMasterModel PPCm = new CoordinatorMasterModel();
            PPCm._StatusList = UtilityAccess.StatusListCategory();
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Create(CoordinatorMasterModel model)
        {
            CoordinatorMasterModel PPCm = new CoordinatorMasterModel();

            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "CoordinatorMaster");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int CategoryID)
        {
            CoordinatorMasterModel PPCm = new CoordinatorMasterModel();
            CoordinatorMasterModel model = new CoordinatorMasterModel();
            model.Id = CategoryID;
            PPCm = PPC.GetCoordinatorMasterDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(CoordinatorMasterModel model)
        {
            CoordinatorMasterModel PPCm = new CoordinatorMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "CoordinatorMaster");
            }
            else
            {
                return View();
            }
        }
    }
}
