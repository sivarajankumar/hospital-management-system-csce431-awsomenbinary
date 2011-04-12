<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Portal.Master" Inherits="System.Web.Mvc.ViewPage<String[]>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    Please choose a patient to view the records of: <br />
        <% foreach (var a in Model)
           { %>
             <%=Html.ActionLink(a, "Medical", new { patient = a }, null)%><br />
        <% } %>

</asp:Content>
