using PPR.Controllers;
using PPRBAL.Business;
using PPRBAL.Interface;
using PPRModel.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PPC.Controllers
{
    [RoutePrefix("ProductProjectCategory")]
    [Route("{action}")]
    public class ProductProjectCategoryController : BaseController
    {
        IProductProjectCategory PPC = new ProductProjectCategoryAccess();
        [HttpGet]
        public ActionResult Index()
        {
            ProductProjectCategoryModel model = new ProductProjectCategoryModel();
            ProductProjectCategoryModel PPCm = new ProductProjectCategoryModel();
            PPCm = PPC.GetProductProjectCategoryData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            ProductProjectCategoryModel  PPCm = new ProductProjectCategoryModel();
            PPCm._StatusList = UtilityAccess.StatusListCategory();
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Create(ProductProjectCategoryModel model)
        {
            ProductProjectCategoryModel PPCm = new ProductProjectCategoryModel();
           
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "ProductProjectCategory");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int CategoryID)
        {
            ProductProjectCategoryModel PPCm = new ProductProjectCategoryModel();
            ProductProjectCategoryModel model = new ProductProjectCategoryModel();
            model.Id= CategoryID;
            PPCm = PPC.GetProductProjectCategoryDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(ProductProjectCategoryModel model)
        {
            ProductProjectCategoryModel PPCm = new ProductProjectCategoryModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("Index", "ProductProjectCategory");
            }
            else
            {
                return View();
            }
        }
        //[HttpGet]
        //public ActionResult Delete(int ProjectID)
        //{
        //    ProductProjectCategoryModel PPCm = new ProductProjectCategoryModel();
        //    PPCm = PPC.DeleteProductProjectCategory(ProjectID);
        //    if (PPCm != null)
        //    {
        //        TempData["ReturnMessage"] = PPCm.ReturnMessage;
        //        TempData["ReturnCode"] = PPCm.ReturnCode;
        //        return RedirectToAction("Index", "ProductProjectCategory");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
