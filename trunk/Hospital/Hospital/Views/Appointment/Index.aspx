<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Portal.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<Hospital.Models.Appointment>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Appointment
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Appointment</h2>

    <table id="appttable">
        <tr><th>Patient</th><th>Doctor</th><th>Specialty</th><th>Date</th></tr>
        <% foreach (var a in Model)
           { %><tr>
            <% if (User.IsInRole("Patient") && User.Identity.Name == a.patient ||
                   User.IsInRole("Doctor") && User.Identity.Name == a.doctor)
               { %>
                <td><%if (User.IsInRole("Doctor"))
                      { %>
                        <%=Html.ActionLink(a.patient, "Medical", "Records", new { patient = a.patient }, null)%>
                    <% }
                      else
                      { %>
                        <%: a.patient%></td>
                    <% } %>
                <td><%: a.doctor%></td>
                <td><%: a.appt_area%></td>
                <td><%: a.appt_time%></td>
                <% if (User.IsInRole("Doctor"))
                   { %>
                       <td>
                        <%=Html.ActionLink("Finalize", "Finalize", new { id = a.id }, null)%>
                       </td>
                <% } %>
                <td>
                    <%if (User.IsInRole("Doctor") || DateTime.Compare(a.appt_time, DateTime.Now.AddDays(1)) >= 0)
                      { %>
                        <%=Html.ActionLink("Cancel", "Delete", new { id = a.id }, null)%>
                    <% } %>
                </td>
            <% } %>
            </tr>
        <% } %>
    </table>

    <%if (User.IsInRole("Patient"))
      { %>
      <br />
      Add Appointment
      <form action="/Appointment/Create" method="post">
          <table>
              <tr>
                  <td>Doctor:</td>
                  <td><input id="doctor" type="text" name="doctor" /></td>
              </tr>
              <tr>
                  <td>Specialization:</td>
                  <td><input id="specialization" type="text" name="specialization" /></td>
              </tr>
              <tr>
                  <td>Time:</td>
                  <td><input id="time" type="text" name="time" /></td>
              </tr>
          </table>
          <input type="submit" value="Add Appointment" />
      </form>
    <% } %>

</asp:Content>
