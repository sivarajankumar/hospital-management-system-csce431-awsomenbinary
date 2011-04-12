<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Portal.Master" Inherits="System.Web.Mvc.ViewPage<Hospital.Models.MedicalRecord>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Medical Records for <%: ViewData["patient"] %></h2>

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
                    <%: Model.previousMedicalHistory %>
                </p>
            </li>
            <li>
                Prescriptions: <br />
                <div id="prescriptions">
                    <ul>
                        <% foreach (var p in Model.prescriptions){ %>
                            <li><%: p %></li>
                        <% } %>
                    </ul>
                    


                </div>
            </li>
        </ul>
    </div>
    
    

    

</asp:Content>
