<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Hospital.Models.RegistrationModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Registration
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
                    <%: Html.LabelFor(m => m.username) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.username) %>
                    <%: Html.ValidationMessageFor(m => m.username) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.email) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.email) %>
                    <%: Html.ValidationMessageFor(m => m.email) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.password) %>
                </div>

                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.password) %>
                    <%: Html.ValidationMessageFor(m => m.password) %>     
                    <p>(Passwords are required to be a minimum of <%: ViewData["PasswordLength"] %> characters in length)</p>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.firstname) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.firstname)%>
                    <%: Html.ValidationMessageFor(m => m.firstname)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.middleinital)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.middleinital)%>
                    <%: Html.ValidationMessageFor(m => m.middleinital)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.lastname) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.lastname)%>
                    <%: Html.ValidationMessageFor(m => m.lastname)%>
                </div>


                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.age) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.age)%>
                    <%: Html.ValidationMessageFor(m => m.age)%>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.sex) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.sex)%>
                    <%: Html.ValidationMessageFor(m => m.sex) %>
                    <p>(M/F/?)</p>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.mailingaddress)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.mailingaddress)%>
                    <%: Html.ValidationMessageFor(m => m.mailingaddress)%>
                    <p>(Address, City, State, Zip Code)</p>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.phonenumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.phonenumber)%>
                    <%: Html.ValidationMessageFor(m => m.phonenumber)%>
                    <p>(ex: 1234567890)</p>
                </div>



                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.creditcardname)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.creditcardname)%>
                    <%: Html.ValidationMessageFor(m => m.creditcardname)%>
                    <p>(As it appears on the card)</p>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.creditcardtype)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.creditcardtype)%>
                    <%: Html.ValidationMessageFor(m => m.creditcardtype)%>
                    <p>(VISA, MASTERCARD, DISCOVER, AMERICAN EXPRESS)</p>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.creditcardnumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.creditcardnumber)%>
                    <%: Html.ValidationMessageFor(m => m.creditcardnumber)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.creditcardsecuritynumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.creditcardsecuritynumber)%>
                    <%: Html.ValidationMessageFor(m => m.creditcardsecuritynumber)%>
                    <p>(Located on back on card, 3 numbers)</p>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.insurancecompany)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.insurancecompany)%>
                    <%: Html.ValidationMessageFor(m => m.insurancecompany)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.insurancepolicynumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.insurancepolicynumber)%>
                    <%: Html.ValidationMessageFor(m => m.insurancepolicynumber)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.insurancepolicyholder)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.insurancepolicyholder)%>
                    <%: Html.ValidationMessageFor(m => m.insurancepolicyholder)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.martialstatus)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.martialstatus)%>
                    <%: Html.ValidationMessageFor(m => m.martialstatus)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.ssn)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.ssn)%>
                    <%: Html.ValidationMessageFor(m => m.ssn)%>
                    <p>(ex: 123456789)</p>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.dob)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.dob)%>
                    <%: Html.ValidationMessageFor(m => m.dob)%>
                    <p>(month/day/year ex:05/07/1990)</p>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.operations)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.operations)%>
                    <%: Html.ValidationMessageFor(m => m.operations)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.allergies)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.allergies)%>
                    <%: Html.ValidationMessageFor(m => m.allergies)%>
                </div>

                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.medication)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.medication)%>
                    <%: Html.ValidationMessageFor(m => m.medication)%>
                </div>


                <div class="editor-label">
                    <%: Html.LabelFor(m => m.pastdoctor)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.pastdoctor)%>
                    <%: Html.ValidationMessageFor(m => m.pastdoctor)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.familyhistory)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.familyhistory)%>
                    <%: Html.ValidationMessageFor(m => m.familyhistory)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.emergencycontactname)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.emergencycontactname)%>
                    <%: Html.ValidationMessageFor(m => m.emergencycontactname)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.emergencycontactnumber)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.emergencycontactnumber)%>
                    <%: Html.ValidationMessageFor(m => m.emergencycontactnumber)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.recenttests)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.recenttests)%>
                    <%: Html.ValidationMessageFor(m => m.recenttests)%>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(m => m.latestbloodpressure)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.latestbloodpressure)%>
                    <%: Html.ValidationMessageFor(m => m.latestbloodpressure)%>
                    <p>(systolic pressure/diastolic pressure ex: 140/90)</p>
                </div>
               
                
                <p>
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
