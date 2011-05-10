using System;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Tests.Controllers
{
    public class RegistrationControllerTest : Controller
    {
        public ActionResult BasicDetails(string nextButton)
        {
            if (nextButton != null)
            {
                return RedirectToAction("AddressDetails");
            }
            return View();
        }

        public ActionResult Confirm()
        {
            return View();
        }



    }
}
