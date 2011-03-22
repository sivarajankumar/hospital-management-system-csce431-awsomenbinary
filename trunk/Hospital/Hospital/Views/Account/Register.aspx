<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Hospital.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create a New Account</h2>
    <p>
        Use the form below to create a new account. 
    </p>
    <p>
        Please enter all the desired information.
    </p>
    <p>
        If a data entry is not applicable to you please enter n/a into the text box.
    </p>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Email) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Email) %>
                    <%: Html.ValidationMessageFor(m => m.Email) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>

                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>     
                    <p>(Passwords are required to be a minimum of <%: ViewData["PasswordLength"] %> characters in length)</p>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.FirstName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.FirstName) %>
                    <%: Html.ValidationMessageFor(m => m.FirstName) %>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.MiddleInital) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.MiddleInital)%>
                    <%: Html.ValidationMessageFor(m => m.MiddleInital)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.LastName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.LastName) %>
                    <%: Html.ValidationMessageFor(m => m.LastName) %>
                </div>


                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Age) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Age) %>
                    <%: Html.ValidationMessageFor(m => m.Age) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Sex) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Sex)%>
                    <%: Html.ValidationMessageFor(m => m.Sex) %>
                    <p>(M/F/?)</p>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.MailingAddress)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.MailingAddress)%>
                    <%: Html.ValidationMessageFor(m => m.MailingAddress)%>
                    <p>(Address, City, State, Zip Code)</p>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.PhoneNumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.PhoneNumber)%>
                    <%: Html.ValidationMessageFor(m => m.PhoneNumber)%>
                    <p>(ex: 1234567890)</p>
                </div>



                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.CreditCardName)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.CreditCardName)%>
                    <%: Html.ValidationMessageFor(m => m.CreditCardName)%>
                    <p>(As it appears on the card)</p>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.CreditCardType)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.CreditCardType)%>
                    <%: Html.ValidationMessageFor(m => m.CreditCardType)%>
                    <p>(VISA, MASTERCARD, DISCOVER, AMERICAN EXPRESS)</p>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.CreditCardNumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.CreditCardNumber)%>
                    <%: Html.ValidationMessageFor(m => m.CreditCardNumber)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.CreditCardSecurityNumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.CreditCardSecurityNumber)%>
                    <%: Html.ValidationMessageFor(m => m.CreditCardSecurityNumber)%>
                    <p>(Located on back on card, 3 numbers)</p>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.InsuranceCompany)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.InsuranceCompany)%>
                    <%: Html.ValidationMessageFor(m => m.InsuranceCompany)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.InsurancePolicyNumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.InsurancePolicyNumber)%>
                    <%: Html.ValidationMessageFor(m => m.InsurancePolicyNumber)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.InsurancePolicyHolder)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.InsurancePolicyHolder)%>
                    <%: Html.ValidationMessageFor(m => m.InsurancePolicyHolder)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.MartialStatus)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.MartialStatus)%>
                    <%: Html.ValidationMessageFor(m => m.MartialStatus)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.SSN)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.SSN)%>
                    <%: Html.ValidationMessageFor(m => m.SSN)%>
                    <p>(ex: 123456789)</p>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.DOB)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.DOB)%>
                    <%: Html.ValidationMessageFor(m => m.DOB)%>
                    <p>(month/day/year ex:05/07/1990)</p>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.Operations)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.Operations)%>
                    <%: Html.ValidationMessageFor(m => m.Operations)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.Allergies)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.Allergies)%>
                    <%: Html.ValidationMessageFor(m => m.Allergies)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.Medication)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.Medication)%>
                    <%: Html.ValidationMessageFor(m => m.Medication)%>
                </div>


                <div class="editor-label">
                    <%: Html.LabelFor(m => m.PastDoctor)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.PastDoctor)%>
                    <%: Html.ValidationMessageFor(m => m.PastDoctor)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.FamilyHistory)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.FamilyHistory)%>
                    <%: Html.ValidationMessageFor(m => m.FamilyHistory)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.EmergencyContactName)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.EmergencyContactName)%>
                    <%: Html.ValidationMessageFor(m => m.EmergencyContactName)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.EmergencyContactNumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.EmergencyContactNumber)%>
                    <%: Html.ValidationMessageFor(m => m.EmergencyContactNumber)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.RecentTests)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.RecentTests)%>
                    <%: Html.ValidationMessageFor(m => m.RecentTests)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.LatestBloodPressure)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.LatestBloodPressure)%>
                    <%: Html.ValidationMessageFor(m => m.LatestBloodPressure)%>
                    <p>(systolic pressure/diastolic pressure ex: 140/90)</p>
                </div>
                
                <p>
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
