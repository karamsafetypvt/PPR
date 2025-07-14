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
    [RoutePrefix("ApprovingAuthorityMaster")]
    [Route("{action}")]
    public class ApprovingAuthorityMasterController : BaseController
    {
        IApprovingAuthorityMaster PPC = new ApprovingAuthorityMasterAccess();
        [HttpGet]
        public ActionResult Index()
        {
            ApprovingAuthorityMasterModel model = new ApprovingAuthorityMasterModel();
            ApprovingAuthorityMasterModel PPCm = new ApprovingAuthorityMasterModel();
            PPCm = PPC.GetAuthorityMasterData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            ApprovingAuthorityMasterModel PPCm = new ApprovingAuthorityMasterModel();
            PPCm._StatusList = UtilityAccess.StatusListCategory();
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Create(ApprovingAuthorityMasterModel model)
        {
            ApprovingAuthorityMasterModel PPCm = new ApprovingAuthorityMasterModel();

            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "ApprovingAuthorityMaster");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int CategoryID)
        {
            ApprovingAuthorityMasterModel PPCm = new ApprovingAuthorityMasterModel();
            ApprovingAuthorityMasterModel model = new ApprovingAuthorityMasterModel();
            model.Id = CategoryID;
            PPCm = PPC.GetAuthorityMasterDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(ApprovingAuthorityMasterModel model)
        {
            ApprovingAuthorityMasterModel PPCm = new ApprovingAuthorityMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "ApprovingAuthorityMaster");
            }
            else
            {
                return View();
            }
        }
    }
}
