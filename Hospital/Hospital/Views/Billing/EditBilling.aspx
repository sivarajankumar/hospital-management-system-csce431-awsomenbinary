<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Portal.Master" Inherits="System.Web.Mvc.ViewPage<Hospital.Models.BillingModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditBilling
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Patient Billing for <%: ViewData["patient"] %></h2>

    <p><%= Html.ActionLink("Edit Billing", "EditBilling") %></p>


</asp:Content>
