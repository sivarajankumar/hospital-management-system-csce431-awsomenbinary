using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using System.Web.Security;


namespace Hospital.Profiles
{
    
    public class PatientProfile : ProfileBase
    {
        public static PatientProfile CurrentUser
        {
            get { return (PatientProfile)(ProfileBase.Create(Membership.GetUser().UserName)); }
        }

        public static PatientProfile GetPatientProfile(string username)
        {
            return Create(username) as PatientProfile;
        }

        public static PatientProfile GetPatientProfile()
        {
            return Create(Membership.GetUser().UserName) as PatientProfile;
        }


        public string FirstName { get { return base["FirstName"] as string; } set { base["FirstName"] = value; Save(); } }

        public string MiddleInital { get { return base["MiddleInitial"] as string; } set { base["MiddleInitial"] = value; Save(); } }

        public string LastName { get { return base["LastName"] as string; } set { base["LastName"] = value; Save(); } }

        public string Age { get { return base["Age"] as string; } set { base["Age"] = value; Save(); } }

        public string Sex { get { return base["Sex"] as string; } set { base["Sex"] = value; Save(); } }

        public string MailingAddress { get { return base["MailingAddress"] as string; } set { base["MailingAddress"] = value; Save(); } }

        public string PhoneNumber { get { return base["PhoneNumber"] as string; } set { base["PhoneNumber"] = value; Save();  } }

        public string CreditCardName { get { return base["CreditCardName"] as string; } set { base["CreditCardName"] = value; Save(); } }

        public string CreditCardType { get { return base["CreditCardType"] as string; } set { base["CreditCardType"] = value; Save(); } }

        public string CreditCardNumber { get { return base["CreditCardNumber"] as string; } set { base["CreditCardNumber"] = value; Save(); } }

        public string CreditCardSecurityNumber { get { return base["CreditCardSecurityNumber"] as string; } set { base["CreditCardSecurityNumber"] = value; Save(); } }

        public string InsuranceCompany { get { return base["InsuranceCompany"] as string; } set { base["InsurancePolicy"] = value; Save(); } }

        public string InsurancePolicyNumber { get { return base["InsurancePolicyNumber"] as string; } set { base["InsurancePolicyNumber"] = value; Save(); } }

        public string InsurancePolicyHolder { get { return base["InsurancePolicyHolder"] as string; } set { base["InsurancePolicyHolder"] = value; Save(); } }

        public string MartialStatus { get { return base["MartialStatus"] as string; } set { base["MartialStatus"] = value; Save(); } }

        public string SSN { get { return base["SSN"] as string; } set { base["SSN"] = value; Save(); } }

        public string DOB { get { return base["DOB"] as string; } set { base["DOB"] = value; Save(); } }

        public string Operations { get { return base["Operations"] as string; } set { base["Operations"] = value; Save(); } }

        public string Allergies { get { return base["Allergies"] as string; } set { base["Allergies"] = value; Save(); } }

        public string Medication { get { return base["Medication"] as string; } set { base["Medication"] = value; Save(); } }

        public string PastDoctor { get { return base["PastDoctor"] as string; } set { base["PastDoctor"] = value; Save(); } }

        public string FamilyHistory { get { return base["FamilyHistory"] as string; } set { base["FamilyHistory"] = value; Save(); } }

        public string EmergencyContactName { get { return base["EmergencyContactName"] as string; } set { base["EmergencyContactName"] = value; Save(); } }

        public string EmergencyContactNumber { get { return base["EmergencyContactNumber"] as string; } set { base["EmergencyContactNumber"] = value; Save(); } }

        public string RecentTests { get { return base["RecentTests"] as string; } set { base["RecentTests"] = value; Save(); } }

        public string LatestBloodPressure { get { return base["LatestBloodPressure"] as string; } set { base["LatestBloodPressure"] = value; Save(); } }


        public PatientProfile UserProfile(string firstname, string middleinital, string lastname, string age, string sex, string mailingaddress, string phonenumber, string ccname, string cctype, string ccnumber, string ccsecuritynumber, string insurancecomp, string insurancepolicynumber, string insurancepolicyholder, string martialstatus, string ssn, string dob, string operations, string allergies, string medication, string pastdoctor, string familyhistory, string emergencyname, string emergencynumber, string recenttests, string bp)
        {
            PatientProfile profile = new PatientProfile();
            profile.FirstName = firstname;
            profile.MiddleInital = middleinital;
            profile.LastName = lastname;
            profile.Age = age;
            profile.Sex = sex;
            profile.MailingAddress = mailingaddress;
            profile.PhoneNumber = phonenumber;
            profile.CreditCardName = ccname;
            profile.CreditCardType = cctype;
            profile.CreditCardNumber = ccnumber;
            profile.CreditCardSecurityNumber = ccsecuritynumber;
            profile.InsuranceCompany = insurancecomp;
            profile.InsurancePolicyNumber = insurancepolicynumber;
            profile.InsurancePolicyHolder = insurancepolicyholder;
            profile.MartialStatus = martialstatus;
            profile.SSN = ssn;
            profile.DOB = dob;
            profile.Operations = operations;
            profile.Allergies = allergies;
            profile.Medication = medication;
            profile.PastDoctor = pastdoctor;
            profile.FamilyHistory = familyhistory;
            profile.EmergencyContactName = emergencyname;
            profile.EmergencyContactNumber = emergencynumber;
            profile.RecentTests = recenttests;
            profile.LatestBloodPressure = bp;
            profile.Save();
            return profile;
        }

    }

 }
