<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="createuser.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Patient Registration</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" OnCreatedUser="CreateUserWizard1_CreatedUser">
            <WizardSteps>
                <asp:WizardStep ID="CreateUserWizardStep0" runat="server">
                    <table>
                        <tr>
                            <th>Personal Information</th>
                        </tr>
                        <tr>
                            <td>First Name:</td>
                            <td>
                                <asp:TextBox runat="server" ID="FirstName" MaxLength="50" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="FirstName"
                                     ErrorMessage="First Name is required." />
                            </td>
                        </tr> 
                        <tr>
                            <td>Middle Initial:</td>
                            <td>
                                <asp:TextBox runat="server" ID="MiddleInital" MaxLength="50" Columns="15" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="MiddleInital"
                                     ErrorMessage="MiddleInital City is required." />
                            </td>
                        </tr>  
                        <tr>
                            <td>Last Name:</td>
                            <td>
                                <asp:TextBox runat="server" ID="LastName" MaxLength="50" Columns="10" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="LastName"
                                     ErrorMessage="Last Name is required."  />
                            </td>
                        </tr>   
                        <tr>
                            <td>Age:</td>
                            <td>
                                <asp:TextBox runat="server" ID="Age" MaxLength="10" Columns="10" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="Age"
                                     ErrorMessage="Age is required." />
                            </td>
                        </tr>  
                        <tr>
                            <td>Sex:</td>
                            <td>
                                <asp:TextBox runat="server" ID="Sex" MaxLength="10" Columns="10" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="Sex"
                                     ErrorMessage="sex is required." />
                            </td>
                        </tr> 
                         <tr>
                            <td>PhoneNumber:</td>
                            <td>
                                <asp:TextBox runat="server" ID="PhoneNumber" MaxLength="50" Columns="10" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="PhoneNumber"
                                     ErrorMessage="PhoneNumber is required." />
                            </td>
                        </tr>             
                    </table>
                </asp:WizardStep>
                <asp:WizardStep ID="CreateUserWizardStep1" runat="server">
                    <table>
                        <tr>
                            <th>Mailing Information</th>
                        </tr>
                        <tr>
                            <td>Mailing Address:</td>
                            <td>
                                <asp:TextBox runat="server" ID="ShippingAddress" MaxLength="50" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="ShippingAddress"
                                     ErrorMessage="Shipping Address is required." />
                            </td>
                        </tr> 
                        <tr>
                            <td>Mailing City:</td>
                            <td>
                                <asp:TextBox runat="server" ID="ShippingCity" MaxLength="50" Columns="15" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="ShippingCity"
                                     ErrorMessage="Shipping City is required." />
                            </td>
                        </tr>  
                        <tr>
                            <td>Mailing State:</td>
                            <td>
                                <asp:TextBox runat="server" ID="ShippingState" MaxLength="25" Columns="10" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ShippingState"
                                     ErrorMessage="Shipping State is required." />
                            </td>
                        </tr>   
                        <tr>
                            <td>Mailing Zip:</td>
                            <td>
                                <asp:TextBox runat="server" ID="ShippingZip" MaxLength="10" Columns="10" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="ShippingZip"
                                ErrorMessage="Shipping Zip is required." />
                            </td>
                        </tr>                
                    </table>
                </asp:WizardStep>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <th>CreditCard Information</th>
                        </tr>
                        <tr>
                            <td>CreditCardName:</td>
                            <td>
                                <asp:TextBox runat="server" ID="CreditCardName" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="CreditCardName" 
                                    ErrorMessage="CreditCardName is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>CreditCardType:</td>
                            <td>
                                <asp:TextBox runat="server" ID="CreditCardType" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="CreditCardType" 
                                    ErrorMessage="CreditCardType is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>CreditCardNumber:</td>
                            <td>
                                <asp:TextBox runat="server" ID="CreditCardNumber" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="CreditCardNumber" 
                                    ErrorMessage="CreditCardNumber is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>CreditCardSecurityNumber:</td>
                            <td>
                                <asp:TextBox runat="server" ID="CreditCardSecurityNumber" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="CreditCardSecurityNumber" 
                                    ErrorMessage="CreditCardSecurityNumber is required." />
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="InsertExtraInfo" runat="server" ConnectionString="<%$ ConnectionStrings:ASPNETDBConnectionString1 %>"
                        InsertCommand="INSERT INTO [UserAddresses] ([UserId], [BillingAddress], [BillingCity], [BillingState], [BillingZip], [ShippingAddress], [ShippingCity], [ShippingState], [ShippingZip]) VALUES (@UserId, @BillingAddress, @BillingCity, @BillingState, @BillingZip, @ShippingAddress, @ShippingCity, @ShippingState, @ShippingZip)"
                        ProviderName="<%$ ConnectionStrings:ASPNETDBConnectionString1.ProviderName %>">
                        <InsertParameters>
                            <asp:ControlParameter Name="BillingAddress" Type="String" ControlID="BillingAddress" PropertyName="Text" />
                            <asp:ControlParameter Name="BillingCity" Type="String" ControlID="BillingCity" PropertyName="Text" />
                            <asp:ControlParameter Name="BillingState" Type="String" ControlID="BillingState" PropertyName="Text" />
                            <asp:ControlParameter Name="BillingZip" Type="String" ControlID="BillingZip" PropertyName="Text" />
                            <asp:ControlParameter Name="ShippingAddress" Type="String" ControlID="ShippingAddress" PropertyName="Text" />
                            <asp:ControlParameter Name="ShippingCity" Type="String" ControlID="ShippingCity" PropertyName="Text" />
                            <asp:ControlParameter Name="ShippingState" Type="String" ControlID="ShippingState" PropertyName="Text" />
                            <asp:ControlParameter Name="ShippingZip" Type="String" ControlID="ShippingZip" PropertyName="Text" />
                        </InsertParameters>
                       
                    </asp:SqlDataSource>
                    
                </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
            <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
            <HeaderStyle BackColor="#FFCC66" BorderColor="#FFFBD6" BorderStyle="Solid" BorderWidth="2px"
                Font-Bold="True" Font-Size="0.9em" ForeColor="#333333" HorizontalAlign="Center" />
            <CreateUserButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
            <ContinueButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
            <SideBarStyle BackColor="#990000" Font-Size="0.9em" VerticalAlign="Top" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <SideBarButtonStyle ForeColor="White" />
        </asp:CreateUserWizard>
    </div>
    </form>
</body>
</html>
