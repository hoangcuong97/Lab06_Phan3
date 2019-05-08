using QL_TrungTam_X.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QL_TrungTam_X.Areas.QuanLy.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /QuanLy/Base/
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Login", action = "Index", Area = "QuanLy" }));
            }
            base.OnActionExecuting(filterContext);
        }
	}
}