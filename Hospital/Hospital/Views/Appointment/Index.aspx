<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Portal/Portal.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>


<script runat="server">
  protected void GridView1_RowCommand(object sender,
                           GridViewCommandEventArgs e)
  {
    if (e.CommandName == "Delete")
    {
      // get the categoryID of the clicked row

      int categoryID = Convert.ToInt32(e.CommandArgument);
      // Delete the record 

      
      // Implement this on your own :) 

    }
  }
 </script>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Appointment
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

    <h2>Appointment</h2>
<p>
  <asp:GridView ID="AppointmentSchedule" runat="server" AutoGenerateColumns="False" 
    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
    CellPadding="4" DataSourceID="GetAppointments" ForeColor="Black" 
    GridLines="Horizontal"
    AllowPaging="True"
    OnRowCommand="GridView1_RowCommand">
    <Columns>
      <asp:BoundField DataField="patient" HeaderText="Patient" 
        SortExpression="patient" />
      <asp:BoundField DataField="doctor" HeaderText="Doctor" 
        SortExpression="doctor" />
      <asp:BoundField DataField="appt_area" HeaderText="Specialization" 
        SortExpression="appt_area" />
      <asp:BoundField DataField="appt_time" HeaderText="Time" 
        SortExpression="appt_time" />
      <asp:CommandField ShowDeleteButton="True" />
      <asp:ButtonField CommandName="Delete" Text="Button" />
      <asp:HyperLinkField DataNavigateUrlFormatString="~/Appointment/Delete/{0}" 
        Text="none" />
    </Columns>
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
  </asp:GridView>
  <asp:ObjectDataSource ID="GetAppointments" runat="server" 
    SelectMethod="getAppointments" 
    DeleteMethod="cancelAppointment"
    TypeName="Hospital.Models.AppointmentProviderService" 
    DataObjectTypeName="Hospital.Models.Appointment"></asp:ObjectDataSource>
</p>

</form>

</asp:Content>
