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

        [Authorize(Roles = "Doctor")]
        public ActionResult Edit(String patient)
        {
            ViewData["patient"] = patient;
            MedicalRecord model = svc.getMedicalRecordsForPatient(patient);
            return View(model);
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Update(String patient)
        {
            MedicalRecord model = svc.getMedicalRecordsForPatient(patient);

            //Only the patient should be able to update their Previous Medical History
            /*if (!String.IsNullOrEmpty(Request.Form["previousMedicalHistory"]))
            {
                model.previousMedicalHistory = Request.Form["previousMedicalHistory"];
            }*/

            if (!String.IsNullOrEmpty(Request.Form["currentMedicalHistory"]))
            {
                model.previousMedicalHistory = Request.Form["curentMedicalHistory"];
            }
            if (!String.IsNullOrEmpty(Request.Form["prescriptions"]))
            {
                String[] separated = Request.Form["prescriptions"].Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                model.prescriptions = new List<String>(separated);
            }
            svc.updateMedicalecordsForPatient(patient, model);
            return RedirectToAction("Medical", "Records", new { patient = patient });
        }

        /*[Authorize(Roles = "Patient")]
        public ActionResult UpdatePrev(String patient)
        {
            if(User.name == patient)
            {
                MedicalRecord model = svc.getMedicalRecordsForPatient(patient);
                if (!String.IsNullOrEmpty(Requests.Form["previousMedicalHistory"]))
                {
                    model.previousMedicalHistory = Request.Form["previousMedicalHistory"];
                }
                svc.updateMedicalecordsForPatient(patient, model);
                return RedirectToAction("Medical", "Records", new { patient = patient });
            }
         
           else
           {
                //Error Message: User does not have permission to view this page
           }
        }*/

        [Authorize(Roles = "Pharmacist")]
        public ActionResult fillRx(String patient)
        {
            MedicalRecord model = svc.getMedicalRecordsForPatient(patient);
            if (!String.IsNullOrEmpty(Request.Form["prescriptions"]))
            {
               //mark prescriptions as "filled"
            }
            svc.updateMedicalecordsForPatient(patient, model);
            return RedirectToAction("Medical", "Records", new { patient = patient });

        }

    }
}
