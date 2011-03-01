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

            if (c.userExists("dan") && c.verifyUser("dan", "pass"))
            {
                ViewData["Message"]+="User exists!<br/>";
            }

            if (!c.userExists("test1"))
            {
                c.addUser("test1", "ppp");
            }
            if (!c.userExists("test1"))
            {
                Console.WriteLine("Error adding user");
            }
            c.disconnect();
            /*SQLConnector.SQLConnector c = new SQLConnector.SQLConnector("database-new.cse.tamu.edu", "djnemec-hosp", "djnemec", "csce431");
            c.connect();

            bool exists = c.userExists("dan");

            if(exists)
                ViewData["Message"] = "Welcome, dan. Your user exists.";
            else
                ViewData["Message"] = "Welcome, dan. Your user does not exist.";

            c.disconnect();*/

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
