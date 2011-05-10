<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Portal.Master" Inherits="System.Web.Mvc.ViewPage<Hospital.Models.MedicalRecord>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Medical Records for <%: ViewData["patient"] %> <%= Html.ActionLink("Edit", "Edit", new{ patient = ViewData["patient"]}) %></h2>

    <div id="records">
        <ul>
            <li>
                Current Medical History: <br />
                <p id="currentMedicalHistory">
                    <%: Model.currentMedicalHistory %>
                </p>
            </li>
            <li>
                Previous Medical History: <br />
                <p id="previousMedicalHistory">
                    <%: Model.prevMedHistory %>
                </p>
            </li>

        </ul>
    </div>
    
    

    

</asp:Content>
