using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        TextBox UserNameTextBox =
            (TextBox)CreateUserWizardStep2.ContentTemplateContainer.FindControl("UserName");

        SqlDataSource DataSource =
            (SqlDataSource)CreateUserWizardStep2.ContentTemplateContainer.FindControl("InsertExtraInfo");

        MembershipUser User = Membership.GetUser(UserNameTextBox.Text);

        object UserGUID = User.ProviderUserKey;

        DataSource.InsertParameters.Add("UserId", UserGUID.ToString());

        DataSource.Insert();
        
    }
}
