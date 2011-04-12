using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using System.Web.Security;


namespace Hospital.Controllers
{
    public class RecordsController : GenericController
    {
        MedicalRecordService svc = new MedicalRecordService();

        [Authorize]
        public ActionResult Index()
        {
          if (!User.IsInRole("Doctor"))
          {
            MedicalRecord model = svc.getMedicalRecordsForPatient(User.Identity.Name);
            return View("Medical", model);
          }
          
          return View(Roles.GetUsersInRole("patient"));
        }

        [Authorize]
        public ActionResult Medical(String patient)
        {
            if (patient == null || User.IsInRole("Patient"))
            {
                return RedirectToAction("Index");
            }
            ViewData["patient"] = patient;
            MedicalRecord model = svc.getMedicalRecordsForPatient(patient);
            return View(model);
        }

    }
}
