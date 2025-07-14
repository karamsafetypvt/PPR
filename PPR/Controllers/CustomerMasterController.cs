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
    [RoutePrefix("CustomerMaster")]
    [Route("{action}")]
    public class CustomerMasterController : BaseController
    {
        ICustomerMaster PPC = new CustomerMasterAccess();
        [HttpGet]
        public ActionResult Index()
        {
            CustomerMasterModel model = new CustomerMasterModel();
            CustomerMasterModel PPCm = new CustomerMasterModel();
            PPCm = PPC.GetCustomerMasterData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            CustomerMasterModel PPCm = new CustomerMasterModel();
            PPCm._StatusList = UtilityAccess.StatusListCategory();
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Create(CustomerMasterModel model)
        {
            CustomerMasterModel PPCm = new CustomerMasterModel();

            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "CustomerMaster");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int CategoryID)
        {
            CustomerMasterModel PPCm = new CustomerMasterModel();
            CustomerMasterModel model = new CustomerMasterModel();
            model.Id = CategoryID;
            PPCm = PPC.GetCustomerMasterDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(CustomerMasterModel model)
        {
            CustomerMasterModel PPCm = new CustomerMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "CustomerMaster");
            }
            else
            {
                return View();
            }
        }
    }
}
