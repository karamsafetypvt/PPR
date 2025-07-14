using PPR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PPR.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext context)
        {
            string url1 = MvcApplication.getControllerNameFromUrl();
            //dont interfere if the exception is already handled
            if (context.ExceptionHandled)
                return;
            context.Result = new ViewResult
            {    
            ViewName = "~/Views/Shared/Error.cshtml"
            };
            context.ExceptionHandled = true;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if (!Function.Authenticate())
                    filterContext.Result = new RedirectResult(Url.Action("logout", "account"));
                string url = MvcApplication.getControllerNameFromUrl();
                base.OnActionExecuting(filterContext);

                if (Session["PPR_EncryptedUserId"] == null) {
                    filterContext.Result = new RedirectResult(Url.Action("logout", "account"));
                } 
               
                // }
            }
            catch (Exception ex) { }
        }
    }
}