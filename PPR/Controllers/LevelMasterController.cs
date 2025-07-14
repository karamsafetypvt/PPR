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
    public class LevelMasterController : BaseController
    {
        // GET: LevelMaster
        ILevelMaster levelMaster=new LevelMasterAccess();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLevel()
        {
            LevelMasteranDesignMasterModel model = new LevelMasteranDesignMasterModel();
            string PPR_For=Session["Dept_ID"].ToString();
            model =levelMaster.GetAllUsers(PPR_For);
            return View(model);
        }
        [HttpPost]
        public ActionResult UserLevel(string PPRLevel1Ids, string PPRLevel2Ids, string PPRLevel3Ids)
        {
            LevelMasteranDesignMasterModel result = new LevelMasteranDesignMasterModel();
            result.PPRLevel1Ids = PPRLevel1Ids;
            result.PPRLevel2Ids = PPRLevel2Ids;
            result.PPRLevel3Ids = PPRLevel3Ids;
            result = levelMaster.AddEditLevels(result);
            //TempData["ReturnMessage"] = result.ReturnMessage;
            //TempData["ReturnCode"] = result.ReturnCode;
            //return RedirectToAction("UserLevel", "LevelMaster");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SelectedUserLevels()
        {
            LevelMasteranDesignMasterModel model = new LevelMasteranDesignMasterModel();
            model = levelMaster.GetAllSelectedUsers();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DevelopmentsheetLevel(string Developmentsheet1Ids, string Developmentsheet2Ids, string Developmentsheet3Ids)
        {
            LevelMasteranDesignMasterModel result = new LevelMasteranDesignMasterModel();
            result.Developmentsheet1Ids = Developmentsheet1Ids;
            result.Developmentsheet2Ids = Developmentsheet2Ids;
            result.Developmentsheet3Ids = Developmentsheet3Ids;
            result = levelMaster.AddEditDevelopmentsheetLevels(result);
            //TempData["ReturnMessage"] = result.ReturnMessage;
            //TempData["ReturnCode"] = result.ReturnCode;
            //return RedirectToAction("UserLevel", "LevelMaster");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult SelectedDevelopmentsheetLevel()
        {
            LevelMasteranDesignMasterModel model = new LevelMasteranDesignMasterModel();
            model = levelMaster.GetAllSelectedDevelopmentsheetLeveUsers();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}