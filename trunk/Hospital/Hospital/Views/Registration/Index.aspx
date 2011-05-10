<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Portal.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Hospital.Models.Registration>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                id
            </th>
            <th>
                username
            </th>
            <th>
                email
            </th>
            <th>
                password
            </th>
            <th>
                firstname
            </th>
            <th>
                middleinital
            </th>
            <th>
                lastname
            </th>
            <th>
                age
            </th>
            <th>
                sex
            </th>
            <th>
                mailingaddress
            </th>
            <th>
                phonenumber
            </th>
            <th>
                creditcardname
            </th>
            <th>
                creditcardtype
            </th>
            <th>
                creditcardnumber
            </th>
            <th>
                creditcardsecuritynumber
            </th>
            <th>
                insurancecompany
            </th>
            <th>
                insurancepolicynumber
            </th>
            <th>
                insurancepolicyholder
            </th>
            <th>
                martialstatus
            </th>
            <th>
                ssn
            </th>
            <th>
                dob
            </th>
            <th>
                operations
            </th>
            <th>
                allergies
            </th>
            <th>
                medication
            </th>
            <th>
                pastdoctor
            </th>
            <th>
                familyhistory
            </th>
            <th>
                emergencycontactname
            </th>
            <th>
                emergencycontactnumber
            </th>
            <th>
                recenttests
            </th>
            <th>
                latestbloodpressure
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%: item.id %>
            </td>
            <td>
                <%: item.username %>
            </td>
            <td>
                <%: item.email %>
            </td>
            <td>
                <%: item.password %>
            </td>
            <td>
                <%: item.firstname %>
            </td>
            <td>
                <%: item.middleinital %>
            </td>
            <td>
                <%: item.lastname %>
            </td>
            <td>
                <%: item.age %>
            </td>
            <td>
                <%: item.sex %>
            </td>
            <td>
                <%: item.mailingaddress %>
            </td>
            <td>
                <%: item.phonenumber %>
            </td>
            <td>
                <%: item.creditcardname %>
            </td>
            <td>
                <%: item.creditcardtype %>
            </td>
            <td>
                <%: item.creditcardnumber %>
            </td>
            <td>
                <%: item.creditcardsecuritynumber %>
            </td>
            <td>
                <%: item.insurancecompany %>
            </td>
            <td>
                <%: item.insurancepolicynumber %>
            </td>
            <td>
                <%: item.insurancepolicyholder %>
            </td>
            <td>
                <%: item.martialstatus %>
            </td>
            <td>
                <%: item.ssn %>
            </td>
            <td>
                <%: item.dob %>
            </td>
            <td>
                <%: item.operations %>
            </td>
            <td>
                <%: item.allergies %>
            </td>
            <td>
                <%: item.medication %>
            </td>
            <td>
                <%: item.pastdoctor %>
            </td>
            <td>
                <%: item.familyhistory %>
            </td>
            <td>
                <%: item.emergencycontactname %>
            </td>
            <td>
                <%: item.emergencycontactnumber %>
            </td>
            <td>
                <%: item.recenttests %>
            </td>
            <td>
                <%: item.latestbloodpressure %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

