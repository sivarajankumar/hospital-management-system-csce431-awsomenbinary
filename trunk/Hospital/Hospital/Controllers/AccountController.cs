using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Hospital.Models;

namespace Hospital.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }

        public bool CreateRestOfUser(string firstname, string middleinital, string lastname, string age, string sex, string mailingaddress, string phonenumber, string ccname, string cctype, string ccnumber, string ccsecuritynumber, string insurancecomp, string insurancepolicynumber, string insurancepolicyholder, string martialstatus, string ssn, string dob, string operations, string allergies, string medication, string pastdoctor, string familyhistory, string emergencyname, string emergencynumber, string recenttests, string bp)
        {
            if (String.IsNullOrEmpty(firstname)) throw new ArgumentException("Value cannot be null or empty.", "firstname");
            if (String.IsNullOrEmpty(middleinital)) throw new ArgumentException("Value cannot be null or empty.", "middleinital");
            if (String.IsNullOrEmpty(lastname)) throw new ArgumentException("Value cannot be null or empty.", "lastname");
            if (String.IsNullOrEmpty(age)) throw new ArgumentException("Value cannot be null or empty.", "age");
            if (String.IsNullOrEmpty(sex)) throw new ArgumentException("Value cannot be null or empty.", "sex");
            if (String.IsNullOrEmpty(mailingaddress)) throw new ArgumentException("Value cannot be null or empty.", "mailingaddress");
            if (String.IsNullOrEmpty(phonenumber)) throw new ArgumentException("Value cannot be null or empty.", "phonenumber");
            if (String.IsNullOrEmpty(ccname)) throw new ArgumentException("Value cannot be null or empty.", "ccname");
            if (String.IsNullOrEmpty(cctype)) throw new ArgumentException("Value cannot be null or empty.", "cctype");
            if (String.IsNullOrEmpty(ccnumber)) throw new ArgumentException("Value cannot be null or empty.", "ccnumber");
            if (String.IsNullOrEmpty(ccsecuritynumber)) throw new ArgumentException("Value cannot be null or empty.", "ccsecuritynumber");
            if (String.IsNullOrEmpty(insurancecomp)) throw new ArgumentException("Value cannot be null or empty.", "insurancecomp");
            if (String.IsNullOrEmpty(insurancepolicynumber)) throw new ArgumentException("Value cannot be null or empty.", "insurancepolicynumber");
            if (String.IsNullOrEmpty(insurancepolicyholder)) throw new ArgumentException("Value cannot be null or empty.", "insurancepolicyholder");
            if (String.IsNullOrEmpty(martialstatus)) throw new ArgumentException("Value cannot be null or empty.", "martialstatus");
            if (String.IsNullOrEmpty(ssn)) throw new ArgumentException("Value cannot be null or empty.", "ssn");
            if (String.IsNullOrEmpty(dob)) throw new ArgumentException("Value cannot be null or empty.", "dob");
            if (String.IsNullOrEmpty(operations)) throw new ArgumentException("Value cannot be null or empty.", "operations");
            if (String.IsNullOrEmpty(allergies)) throw new ArgumentException("Value cannot be null or empty.", "allergies");
            if (String.IsNullOrEmpty(medication)) throw new ArgumentException("Value cannot be null or empty.", "medication");
            if (String.IsNullOrEmpty(pastdoctor)) throw new ArgumentException("Value cannot be null or empty.", "pastdoctor");
            if (String.IsNullOrEmpty(familyhistory)) throw new ArgumentException("Value cannot be null or empty.", "familyhistory");
            if (String.IsNullOrEmpty(emergencyname)) throw new ArgumentException("Value cannot be null or empty.", "emergencyname");
            if (String.IsNullOrEmpty(recenttests)) throw new ArgumentException("Value cannot be null or empty.", "recenttests");
            if (String.IsNullOrEmpty(bp)) throw new ArgumentException("Value cannot be null or empty.", "bp");
            //CreateRestOfUser(firstname, middleinital, lastname, age, sex, mailingaddress, phonenumber, ccname, cctype, ccnumber, ccsecuritynumber, insurancecomp, insurancepolicynumber, insurancepolicyholder, martialstatus, ssn, dob, operations, allergies, medication, pastdoctor, familyhistory, emergencyname, emergencynumber, recenttests, bp);
            return true;
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Portal");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);
                bool createUserStatus = CreateRestOfUser(model.FirstName, model.MiddleInital, model.LastName, model.Age, model.Sex, model.MailingAddress, model.PhoneNumber, model.CreditCardName, model.CreditCardType, model.CreditCardNumber, model.CreditCardSecurityNumber, model.InsuranceCompany, model.InsurancePolicyNumber, model.InsurancePolicyHolder, model.MartialStatus, model.SSN, model.DOB, model.Operations, model.Allergies, model.Medication, model.PastDoctor, model.FamilyHistory, model.EmergencyContactName, model.EmergencyContactNumber, model.RecentTests, model.LatestBloodPressure);

               

                if (createStatus == MembershipCreateStatus.Success && createUserStatus)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }



      




        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

    }
}
