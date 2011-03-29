using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using Telerik.Web.Mvc;
using Microsoft.CSharp;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        //
        // GET: /Appointment/

        public ActionResult Index()
        {
          if (!String.IsNullOrEmpty(Request["__EVENTTARGET"]))
          {
            String s = Request["__EVENTARGUMENT"];
            String t = Request["__EVENTTARGET"];
            object o = ViewData["ctl00"];
          }
          
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete()
        {
          return RedirectToAction("Index");
        }

    }
}
