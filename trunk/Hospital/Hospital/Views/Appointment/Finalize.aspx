<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Portal.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Finalize
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Finalize</h2>

    <form action="/Appointment/SubmitPayment" method="post">
        <input type="hidden" id="id" name="id" value="<%: ViewData["id"] %>" />
        <table>
            <tr>
                <td>Hours:</td>
                <td><input id="hours" type="text" name="hours" /></td>
            </tr>
        </table>
        <input type="submit" value="Save" />
    </form>

</asp:Content>
