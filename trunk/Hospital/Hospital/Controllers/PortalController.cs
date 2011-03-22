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
            /*34895735893573489573489573895738573489573489573489573895738957895753895738957389475389579345
             * ProfileBase profile = ProfileBase.Create(HttpContext.Profile.UserName, true);
             */


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

            throw new HttpException(403, "Not authorized");
        }

        [Authorize(Roles = "Patient")]
        public ActionResult Patient()
        {
            return View();
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Doctor()
        {
            return View();
        }

        [Authorize(Roles = "Nurse")]
        public ActionResult Nurse()
        {
            
            return View();
        }

        [Authorize(Roles = "Pharmacist")]
        public ActionResult Pharmacist()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Administrator()
        {
            return View();
        }

    }
}
