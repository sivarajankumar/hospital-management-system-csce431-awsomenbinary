<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Portal.Master" Inherits="System.Web.Mvc.ViewPage<Hospital.Models.BillingModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Billing
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table id="appttable">
        <tr><th>Patient</th><th>Doctor</th><th>Specialty</th><th>Date</th></tr>
        <% foreach (var a in Model)
           { %><tr>
            <% if (User.IsInRole("Patient") && User.Identity.Name == a.patient ||
                   User.IsInRole("Doctor") && User.Identity.Name == a.doctor)
               { %>
                <td><%if (User.IsInRole("Doctor"))
                      { %>
                        <p><%= Html.ActionLink("Show Billing", "ShowBilling") %></p>
                    <% }
                      else
                      { %>
                        <%: a.patient%></td>
                    <% } %>
                <td><%: a.doctor%></td>
                <td><%: a.appt_area%></td>
                <td><%: a.appt_time%></td>
                <td>
                    <%if (User.IsInRole("Doctor") || DateTime.Compare(a.appt_time, DateTime.Now.AddDays(1)) >= 0)
                      { %>
                       <p><%=Html.ActionLink("Edit Billing", "EditBilling")%> </p>
                    <% } %>
                </td>
            <% } %>
            </tr>
        <% } %>
    </table>

</asp:Content>