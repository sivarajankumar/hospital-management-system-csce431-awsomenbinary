using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using Microsoft.CSharp;

namespace Hospital.Controllers
{
    public class RegistrationController : GenericController
    {

        RegistrationProviderService svc = new RegistrationProviderService();

        public ActionResult Index()
        {
            return View(svc.getRegistration());
        }

        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Create(string user, string email, string password, string firstname, string middleinital, string lastname, string age, string sex, string mailingaddress, string phonenumber, string creditcardname, string creditcardtype, string creditcardnumber, string creditcardsecuritynumber, string insurancecompany, string insurancepolicynumber, string insurancepolicyholder, string martialstatus, string ssn, string dob, string operations, string allergies, string medication, string pastdoctor, string familyhistory, string emergencycontactname, string emergencycontactnumber, string recenttests, string latestbloodpressure)
        {
            svc.registerUser(user, email, password, firstname, middleinital, lastname, age, sex, mailingaddress, phonenumber, creditcardname, creditcardtype, creditcardnumber, creditcardsecuritynumber, insurancecompany, insurancepolicynumber, insurancepolicyholder, martialstatus, ssn, dob, operations, allergies, medication, pastdoctor, familyhistory, emergencycontactname, emergencycontactnumber, recenttests, latestbloodpressure);
            return RedirectToAction("Index");
        }

    }
}
