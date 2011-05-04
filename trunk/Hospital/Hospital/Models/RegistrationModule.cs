using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MySql.Data.MySqlClient;
using Hospital.Providers;

namespace Hospital.Models
{
    #region models
    public class Registration
    {
        public int id{get;set;}
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string middleinital { get; set; }
        public string lastname { get; set; }
        public string age { get; set; }
        public string sex { get; set; }
        public string mailingaddress { get; set; }
        public string phonenumber { get; set; }
        public string creditcardname { get; set; }
        public string creditcardtype { get; set; }
        public string creditcardnumber { get; set; }
        public string creditcardsecuritynumber { get; set; }
        public string insurancecompany { get; set; }
        public string insurancepolicynumber { get; set; }
        public string insurancepolicyholder { get; set; }
        public string martialstatus { get; set; }
        public string ssn { get; set; }
        public string dob { get; set; }
        public string operations { get; set; }
        public string allergies { get; set; }
        public string medication { get; set; }
        public string pastdoctor { get; set; }
        public string familyhistory { get; set; }
        public string emergencycontactname { get; set; }
        public string emergencycontactnumber { get; set; }
        public string recenttests { get; set; }
        public string latestbloodpressure { get; set; }


    }
    #endregion

    #region services
    public class RegistrationProviderService
    {
        private readonly RegistrationProvider _provider; 
        
        public RegistrationProviderService() : this(null)
        {
        }

        public RegistrationProviderService(RegistrationProvider provider)
        {
            _provider = provider ?? new RegistrationProvider();
        }

        public void registerUser(string user, string email, string password, string firstname, string middleinital, string lastname, string age, string sex, string mailingaddress, string phonenumber, string creditcardname, string creditcardtype, string creditcardnumber, string creditcardsecuritynumber, string insurancecompany, string insurancepolicynumber, string insurancepolicyholder, string martialstatus, string ssn, string dob, string operations, string allergies, string medication, string pastdoctor, string familyhistory, string emergencycontactname, string emergencycontactnumber, string recenttests, string latestbloodpressure)
        {
            _provider.registerUser(user, email, password, firstname, middleinital, lastname, age, sex, mailingaddress, phonenumber, creditcardname, creditcardtype, creditcardnumber, creditcardsecuritynumber, insurancecompany, insurancepolicynumber, insurancepolicyholder, martialstatus, ssn, dob, operations, allergies, medication, pastdoctor, familyhistory, emergencycontactname, emergencycontactnumber, recenttests, latestbloodpressure);
        }

        public List<Registration> getRegistration()
        {
            return _provider.getRegistration();
        }

        public List<Registration> getRegistration(string user)
        {
            return _provider.getRegistrationForUser(user);
        }

        public void changeRegistration()
        {
        }

    }
    #endregion

}
