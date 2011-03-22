using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hospital.Models
{

    #region Models
    [PropertiesMustMatch("NewPassword", "ConfirmPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Current password")]
        public string OldPassword { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm new password")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }

    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public class RegisterModel
    {
        [Required]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        public string Email { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }


        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Middle Initial")]
        public string MiddleInital { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Age")]
        public string Age { get; set; }

        [Required]
        [DisplayName("Sex")]
        public string Sex { get; set; }

        [Required]
        [DisplayName("Mailing Address")]
        public string MailingAddress { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }


        [Required]
        [DisplayName("Credit Card Name")]
        public string CreditCardName { get; set; }
        [Required]
        [DisplayName("Credit Card Type")]
        public string CreditCardType { get; set; }
        [Required]
        [DisplayName("Credit Card Number")]
        public string CreditCardNumber { get; set; }
        [Required]
        [DisplayName("Credit Card Security Number")]
        public string CreditCardSecurityNumber { get; set; }

        [Required]
        [DisplayName("Insurance Company")]
        public string InsuranceCompany { get; set; }
        [Required]
        [DisplayName("Insurance Policy Number")]
        public string InsurancePolicyNumber { get; set; }
        [Required]
        [DisplayName("Insurance Policy Holder")]
        public string InsurancePolicyHolder { get; set; }

        [Required]
        [DisplayName("Martial Status")]
        public string MartialStatus { get; set; }

        [Required]
        [DisplayName("Social Security Number")]
        public string SSN { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        public string DOB { get; set; }

        [Required]
        [DisplayName("Recent Operations")]
        public string Operations { get; set; }
        [Required]
        [DisplayName("Allergies")]
        public string Allergies { get; set; }
        [Required]
        [DisplayName("Recent Medication")]
        public string Medication { get; set; }
        [Required]
        [DisplayName("Past Doctor")]
        public string PastDoctor { get; set; }
        [Required]
        [DisplayName("Family History")]
        public string FamilyHistory { get; set; }
        [Required]
        [DisplayName("Emergency Contact Name")]
        public string EmergencyContactName { get; set; }
        [Required]
        [DisplayName("Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; }
        [Required]
        [DisplayName("Recent Test/Exams")]
        public string RecentTests { get; set; }
        [Required]
        [DisplayName("Latest Blood Pressure")]
        public string LatestBloodPressure { get; set; }

    }


    #endregion

    #region Services
    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        bool ValidateUserInformation(string firstname, string middleinital, string lastname, string age, string sex, string mailingaddress, string phonenumber, string ccname, string cctype, string ccnumber, string ccsecuritynumber, string insurancecomp, string insurancepolicynumber, string insurancepolicyholder, string martialstatus, string ssn, string dob, string operations, string allergies, string medication, string pastdoctor, string familyhistory, string emergencyname, string emergencynumber, string recenttests, string bp);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }

    public class AccountMembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");


            return _provider.ValidateUser(userName, password);
        }

        public bool ValidateUserInformation(string firstname, string middleinital, string lastname, string age, string sex, string mailingaddress, string phonenumber, string ccname, string cctype, string ccnumber, string ccsecuritynumber, string insurancecomp, string insurancepolicynumber, string insurancepolicyholder, string martialstatus, string ssn, string dob, string operations, string allergies, string medication, string pastdoctor, string familyhistory, string emergencyname, string emergencynumber, string recenttests, string bp)
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

            return true;

        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("Value cannot be null or empty.", "email");

            MembershipCreateStatus status;
            _provider.CreateUser(userName, password, email, null, null, true, null, out status);
            Roles.AddUserToRole(userName, "patient");
            return status;
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

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
            if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("Value cannot be null or empty.", "newPassword");

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try
            {
                MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }
        }
    }

    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
    #endregion

    #region Validation
    public static class AccountValidation
    {
        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class PropertiesMustMatchAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' and '{1}' do not match.";
        private readonly object _typeId = new object();

        public PropertiesMustMatchAttribute(string originalProperty, string confirmProperty)
            : base(_defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty { get; private set; }
        public string OriginalProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalProperty, ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            object confirmValue = properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            return Object.Equals(originalValue, confirmValue);
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' must be at least {1} characters long.";
        private readonly int _minCharacters = Membership.Provider.MinRequiredPasswordLength;

        public ValidatePasswordLengthAttribute()
            : base(_defaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                name, _minCharacters);
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= _minCharacters);
        }
    }
    #endregion

}
