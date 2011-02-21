using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SQLConnector;

namespace Hospital.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SQLConnector.SQLConnector c = new SQLConnector.SQLConnector("database-new.cse.tamu.edu", "djnemec-hosp", "djnemec", "csce431");
            c.connect();

            bool exists = c.userExists("dan");

            if(exists)
                ViewData["Message"] = "Welcome, dan. Your user exists.";
            else
                ViewData["Message"] = "Welcome, dan. Your user does not exist.";

            c.disconnect();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
