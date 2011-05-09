using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using System.Web.Security;
using Microsoft.CSharp;

namespace Hospital.Controllers
{
    public class BillingController : GenericController
    {
        BillingServices svc = new BillingServices();
        //
        // GET: /Billing/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return redirectToPortal();
            }
            else
                return View();
        }

        public ActionResult EditBilling(int id, DateTime date, double amt, string item)
        {
            if (User.IsInRole("Doctor") || User.IsInRole("Nurse") || User.IsInRole("Pharmacist"))
            {
               svc.editBillingStatement(id, date, amt, item);
            }
            else
            {
                svc.showBillingStatement(id);
            }

            return RedirectToAction("Index");
        }
      
        public ActionResult ShowBilling()
        {
            return View();
        }
    }
}
