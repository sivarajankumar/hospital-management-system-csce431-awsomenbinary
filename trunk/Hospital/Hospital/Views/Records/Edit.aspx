<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Portal.Master" Inherits="System.Web.Mvc.ViewPage<Hospital.Models.MedicalRecord>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm("Update", "Records", new { patient = ViewData["patient"] }))
       {%>
        <table>
            <tr>
                <td><b>Medical History:</b></td></tr><tr><td></td>
                <td><%= Html.TextArea("previousMedicalHistory", Model.previousMedicalHistory, new { style = "width:500px;height:200px" })%></td>
            </tr>

            <tr>
                <td><b>Current medical History:</b></td></tr><tr><td></td>
            <td><%= Html.TextArea("currentMedicalHistory", Model.currentMedicalHistory, new { style = "width:500px;height:200px" })%></td>
            </tr>
            <tr>
                <td><b>Prescriptions <br />(separate by a new line):</b></td></tr><tr><td></td>
            <td><%
        String prescriptions = "";
        foreach (String p in Model.prescriptions)
        {
            prescriptions += p + "\n";
        }
            %>
            <%=Html.TextArea("prescriptions", prescriptions, new { style = "width:500px;height:200px" })%></td>
            </tr>
        </table>

        <input type="submit" value="Save" />
    <% } %>
    


</asp:Content>
