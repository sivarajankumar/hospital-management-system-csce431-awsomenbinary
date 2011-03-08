using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hospital.Controllers
{
    public class PortalController : Controller
    {
        //
        // GET: /Portal/

        public ActionResult Index()
        {
            string[] roles = Roles.GetRolesForUser();
            if (roles.Length > 0)
            {
                if (roles.Contains("Patient"))
                {
                    return RedirectToAction("Patient", "Portal");
                }
                else if (roles.Contains("Doctor"))
                {
                    return RedirectToAction("Doctor", "Portal");
                }
                else if (roles.Contains("Nurse"))
                {
                    return RedirectToAction("Nurse", "Portal");
                }
                else if (roles.Contains("Pharmacist"))
                {
                    return RedirectToAction("Pharmacist", "Portal");
                }
                else if (roles.Contains("Administrator"))
                {
                    return RedirectToAction("Administrator", "Portal");
                }
            }
            return View();
        }

        public ActionResult Patient()
        {
            return View();
        }

        public ActionResult Doctor()
        {
            return View();
        }

        public ActionResult Nurse()
        {
            return View();
        }

        public ActionResult Pharmacist()
        {
            return View();
        }

        public ActionResult Administrator()
        {
            return View();
        }

    }
}
