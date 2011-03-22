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
        Passwords are required to be a minimum of <%: ViewData["PasswordLength"] %> characters in length.
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
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Name) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Name) %>
                    <%: Html.ValidationMessageFor(m => m.Name) %>
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
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.MailingAddress)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.MailingAddress)%>
                    <%: Html.ValidationMessageFor(m => m.MailingAddress)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.PhoneNumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.PhoneNumber)%>
                    <%: Html.ValidationMessageFor(m => m.PhoneNumber)%>
                </div>



                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.CreditCardName)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.CreditCardName)%>
                    <%: Html.ValidationMessageFor(m => m.CreditCardName)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.CreditCardType)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.CreditCardType)%>
                    <%: Html.ValidationMessageFor(m => m.CreditCardType)%>
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
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.DOB)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.DOB)%>
                    <%: Html.ValidationMessageFor(m => m.DOB)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.Operations)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Operations)%>
                    <%: Html.ValidationMessageFor(m => m.Operations)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.Allergies)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Allergies)%>
                    <%: Html.ValidationMessageFor(m => m.Allergies)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.Medication)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Medication)%>
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
                    <%: Html.TextBoxFor(m => m.FamilyHistory)%>
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
                    <%: Html.TextBoxFor(m => m.RecentTests)%>
                    <%: Html.ValidationMessageFor(m => m.RecentTests)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.LatestBloodPressure)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.LatestBloodPressure)%>
                    <%: Html.ValidationMessageFor(m => m.LatestBloodPressure)%>
                </div>
                
                <p>
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
