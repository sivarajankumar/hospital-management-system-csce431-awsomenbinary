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
    public class RegistrationModel
    {
        public int id{get;set;}
        [Required]
        [DisplayName("User name")]
        public string username { get; set; }
        [Required]
        [DisplayName("Email")]
        public string email { get; set; }
        [Required]
        [DisplayName("Password")]
        public string password { get; set; }
        [Required]
        [DisplayName("First name")]
        public string firstname { get; set; }
        [Required]
        [DisplayName("Middle Initial")]
        public string middleinital { get; set; }
        [Required]
        [DisplayName("Last name")]
        public string lastname { get; set; }
        [Required]
        [DisplayName("Age")]
        public string age { get; set; }
        [Required]
        [DisplayName("Sex")]
        public string sex { get; set; }
        [Required]
        [DisplayName("Mailing Address")]
        public string mailingaddress { get; set; }
        [Required]
        [DisplayName("Phone number")]
        public string phonenumber { get; set; }
        [Required]
        [DisplayName("Credit Card Name")]
        public string creditcardname { get; set; }
        [Required]
        [DisplayName("Credit Card Type")]
        public string creditcardtype { get; set; }
        [Required]
        [DisplayName("Credit Card Number")]
        public string creditcardnumber { get; set; }
        [Required]
        [DisplayName("Credit Card Security Number")]
        public string creditcardsecuritynumber { get; set; }
        [Required]
        [DisplayName("Insurance Company")]
        public string insurancecompany { get; set; }
        [Required]
        [DisplayName("Insurance Policy Number")]
        public string insurancepolicynumber { get; set; }
        [Required]
        [DisplayName("Insurance Policy Holder")]
        public string insurancepolicyholder { get; set; }
        [Required]
        [DisplayName("Martial Status")]
        public string martialstatus { get; set; }
        [Required]
        [DisplayName("SSN")]
        public string ssn { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public string dob { get; set; }
        [Required]
        [DisplayName("Operations")]
        public string operations { get; set; }
        [Required]
        [DisplayName("Allergies")]
        public string allergies { get; set; }
        [Required]
        [DisplayName("Medication")]
        public string medication { get; set; }
        [Required]
        [DisplayName("Past Doctor")]
        public string pastdoctor { get; set; }
        [Required]
        [DisplayName("Family History")]
        public string familyhistory { get; set; }
        [Required]
        [DisplayName("Emergency Contact Name")]
        public string emergencycontactname { get; set; }
        [Required]
        [DisplayName("Emergency Contact Number")]
        public string emergencycontactnumber { get; set; }
        [Required]
        [DisplayName("Recent Tests")]
        public string recenttests { get; set; }
        [Required]
        [DisplayName("Latest Blood Pressure")]
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

        public List<RegistrationModel> getRegistration()
        {
            return _provider.getRegistration();
        }

        public List<RegistrationModel> getRegistration(string user)
        {
            return _provider.getRegistrationForUser(user);
        }

        public void changeRegistration()
        {
        }

    }
    #endregion

}
