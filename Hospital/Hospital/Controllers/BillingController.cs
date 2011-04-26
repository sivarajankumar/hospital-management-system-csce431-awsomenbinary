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
            if (User.Identity.IsAuthenticated)
            {
                return redirectToPortal();
            }
            return View();
        }

        public ActionResult EditBilling()
        {
            if (User.IsInRole("Doctor") || User.IsInRole("Nurse") || User.IsInRole("Pharmacist"))
            {
                svc.EditBilling(id, true);
            }
            else


                return RedirectToAction("Index");
        }
        public ActionResult Edit(String doctor, String specialization, DateTime time)
        {
           
            return RedirectToAction("Index");
        }

        public ActionResult ShowBilling()
        {
            return View();
        }
    }
}
