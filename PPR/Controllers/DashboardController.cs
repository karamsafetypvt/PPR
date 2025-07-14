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
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        IDashboard data = new DashboardAccess();
        public ActionResult Index()
        {
            DashBoardModel modal = new DashBoardModel();
            DashBoardModel result = new DashBoardModel();
            modal.UserID = Session["PNICode"].ToString();
            result = data.GetUsersLevel(modal);
            return View(result);
        }
    }
}