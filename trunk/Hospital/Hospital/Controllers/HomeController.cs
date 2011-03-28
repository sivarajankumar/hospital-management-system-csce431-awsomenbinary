using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Hospital.Controllers
{
    [HandleError]
    public class HomeController : GenericController
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return redirectToPortal();
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
