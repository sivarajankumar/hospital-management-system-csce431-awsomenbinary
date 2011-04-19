using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hospital.Controllers
{
    public class BillingController : GenericController
    {
        //
        // GET: /Billing/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return redirectToPortal();
            }
            return View();
        }

        public ActionResult EditBilling()
        {
            return View();
        }

        public ActionResult ShowBilling()
        {
            return View();
        }
    }
}
