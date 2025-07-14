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
    [RoutePrefix("Unit")]
    [Route("{action}")]
    public class UnitMasterController : BaseController
    {
        IUnitMaster PPC = new UnitMasterAccess();
        [HttpGet]
        public ActionResult Index()
        {
            UnitMasterModel model = new UnitMasterModel();
            UnitMasterModel PPCm = new UnitMasterModel();
            PPCm = PPC.GetUnitMasterData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            UnitMasterModel PPCm = new UnitMasterModel();
            PPCm._StatusList = UtilityAccess.StatusListCategory();
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Create(UnitMasterModel model)
        {
            UnitMasterModel PPCm = new UnitMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "UnitMaster");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int CategoryID)
        {
            UnitMasterModel PPCm = new UnitMasterModel();
            UnitMasterModel model = new UnitMasterModel();
            model.Id = CategoryID;
            PPCm = PPC.GetUnitMasterDataById(model);
            model.Id = PPCm.Id;
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(UnitMasterModel model)
        {
            UnitMasterModel PPCm = new UnitMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "UnitMaster");
            }
            else
            {
                return View();
            }
        }
    }
}
