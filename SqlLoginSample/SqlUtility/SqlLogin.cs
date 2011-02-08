using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace SqlUtility
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class SqlLogin : System.Windows.Forms.UserControl
	{
    private String sLastServer = "" ;
    private bool  bQueryDatabases = false ;

    private System.Windows.Forms.GroupBox grp_ConnectionName;
    private System.Windows.Forms.ComboBox cb_DatabaseName;
    private System.Windows.Forms.Label lbl_PassWord;
    private System.Windows.Forms.Label lbl_UserName;
    private System.Windows.Forms.Label lbl_DatabaseName;
    private System.Windows.Forms.Label lbl_ServerName;
    private System.Windows.Forms.ComboBox cb_ServerName;
    private System.Windows.Forms.TextBox txt_PassWord;
    private System.Windows.Forms.TextBox txt_UserName;
    private System.Windows.Forms.CheckBox chk_IntegratedSecurity;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SqlLogin()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.grp_ConnectionName = new System.Windows.Forms.GroupBox();
      this.chk_IntegratedSecurity = new System.Windows.Forms.CheckBox();
      this.cb_DatabaseName = new System.Windows.Forms.ComboBox();
      this.lbl_PassWord = new System.Windows.Forms.Label();
      this.lbl_UserName = new System.Windows.Forms.Label();
      this.lbl_DatabaseName = new System.Windows.Forms.Label();
      this.lbl_ServerName = new System.Windows.Forms.Label();
      this.cb_ServerName = new System.Windows.Forms.ComboBox();
      this.txt_PassWord = new System.Windows.Forms.TextBox();
      this.txt_UserName = new System.Windows.Forms.TextBox();
      this.grp_ConnectionName.SuspendLayout();
      this.SuspendLayout();
      // 
      // grp_ConnectionName
      // 
      this.grp_ConnectionName.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.grp_ConnectionName.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                     this.chk_IntegratedSecurity,
                                                                                     this.cb_DatabaseName,
                                                                                     this.lbl_PassWord,
                                                                                     this.lbl_UserName,
                                                                                     this.lbl_DatabaseName,
                                                                                     this.lbl_ServerName,
                                                                                     this.cb_ServerName,
                                                                                     this.txt_PassWord,
                                                                                     this.txt_UserName});
      this.grp_ConnectionName.Location = new System.Drawing.Point(8, 8);
      this.grp_ConnectionName.Name = "grp_ConnectionName";
      this.grp_ConnectionName.Size = new System.Drawing.Size(424, 136);
      this.grp_ConnectionName.TabIndex = 10;
      this.grp_ConnectionName.TabStop = false;
      this.grp_ConnectionName.Text = "Database Connection";
      // 
      // chk_IntegratedSecurity
      // 
      this.chk_IntegratedSecurity.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.chk_IntegratedSecurity.Checked = true;
      this.chk_IntegratedSecurity.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_IntegratedSecurity.Location = new System.Drawing.Point(256, 64);
      this.chk_IntegratedSecurity.Name = "chk_IntegratedSecurity";
      this.chk_IntegratedSecurity.Size = new System.Drawing.Size(152, 16);
      this.chk_IntegratedSecurity.TabIndex = 1;
      this.chk_IntegratedSecurity.Text = "Use Integrated Security";
      this.chk_IntegratedSecurity.CheckedChanged += new System.EventHandler(this.chk_OEMIntegratedSecurity_CheckedChanged);
      // 
      // cb_DatabaseName
      // 
      this.cb_DatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.cb_DatabaseName.Location = new System.Drawing.Point(128, 96);
      this.cb_DatabaseName.Name = "cb_DatabaseName";
      this.cb_DatabaseName.Size = new System.Drawing.Size(224, 21);
      this.cb_DatabaseName.TabIndex = 4;
      this.cb_DatabaseName.Enter += new System.EventHandler(this.cb_DatabaseName_Enter);
      // 
      // lbl_PassWord
      // 
      this.lbl_PassWord.Location = new System.Drawing.Point(24, 72);
      this.lbl_PassWord.Name = "lbl_PassWord";
      this.lbl_PassWord.TabIndex = 7;
      this.lbl_PassWord.Text = "Password:";
      // 
      // lbl_UserName
      // 
      this.lbl_UserName.Location = new System.Drawing.Point(24, 48);
      this.lbl_UserName.Name = "lbl_UserName";
      this.lbl_UserName.TabIndex = 6;
      this.lbl_UserName.Text = "User Name:";
      // 
      // lbl_DatabaseName
      // 
      this.lbl_DatabaseName.Location = new System.Drawing.Point(24, 96);
      this.lbl_DatabaseName.Name = "lbl_DatabaseName";
      this.lbl_DatabaseName.TabIndex = 8;
      this.lbl_DatabaseName.Text = "Database Name:";
      // 
      // lbl_ServerName
      // 
      this.lbl_ServerName.Location = new System.Drawing.Point(24, 24);
      this.lbl_ServerName.Name = "lbl_ServerName";
      this.lbl_ServerName.TabIndex = 5;
      this.lbl_ServerName.Text = "Server Name:";
      // 
      // cb_ServerName
      // 
      this.cb_ServerName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.cb_ServerName.Location = new System.Drawing.Point(128, 24);
      this.cb_ServerName.Name = "cb_ServerName";
      this.cb_ServerName.Size = new System.Drawing.Size(224, 21);
      this.cb_ServerName.TabIndex = 0;
      this.cb_ServerName.Enter += new System.EventHandler(this.cb_ServerName_Enter);
      // 
      // txt_PassWord
      // 
      this.txt_PassWord.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txt_PassWord.Enabled = false;
      this.txt_PassWord.Location = new System.Drawing.Point(128, 72);
      this.txt_PassWord.Name = "txt_PassWord";
      this.txt_PassWord.Size = new System.Drawing.Size(112, 20);
      this.txt_PassWord.TabIndex = 3;
      this.txt_PassWord.Text = "";
      // 
      // txt_UserName
      // 
      this.txt_UserName.AcceptsReturn = true;
      this.txt_UserName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txt_UserName.Enabled = false;
      this.txt_UserName.Location = new System.Drawing.Point(128, 48);
      this.txt_UserName.Name = "txt_UserName";
      this.txt_UserName.Size = new System.Drawing.Size(112, 20);
      this.txt_UserName.TabIndex = 2;
      this.txt_UserName.Text = "sa";
      // 
      // SqlLogin
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.grp_ConnectionName});
      this.Name = "SqlLogin";
      this.Size = new System.Drawing.Size(440, 152);
      this.Load += new System.EventHandler(this.SqlLogin_Load);
      this.grp_ConnectionName.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

    private void SqlLogin_Load(object sender, System.EventArgs e)
    {
      ArrayList svrList = SqlUtilities.GetServerList() ;
      foreach (String svrname in svrList )
      {
        this.cb_ServerName.Items.Add ( svrname ) ;
      }
      cb_ServerName.SelectedIndex = 0;    // Select the First Available Server
      bQueryDatabases = true ;
    }
    /// <summary>
    /// Records what the Servername was when the user first moves to the field.
    /// We need this so that we can re-lookup the available databases
    /// if the entry has been changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cb_ServerName_Enter(object sender, System.EventArgs e)
    {
      sLastServer = this.cb_ServerName.Text ;
    }

    /// <summary>
    /// If the user Checks/Unchecks the Integreated Security box, the username
    /// and password fields must be enabled/disabled correspondingly.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void chk_OEMIntegratedSecurity_CheckedChanged(object sender, System.EventArgs e)
    {
      this.txt_UserName.Enabled = ! this.chk_IntegratedSecurity.Checked;
      this.txt_PassWord.Enabled = ! this.chk_IntegratedSecurity.Checked;
      bQueryDatabases = true ;
    }

    /// <summary>
    /// When the user navigates to the Database name field, lookup the databases
    /// that are available on the requested server.  This routine contains an
    /// optimization in that the lookup is only performed if the user has changed
    /// the name of the server since the last time the lookup was performed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cb_DatabaseName_Enter(object sender, System.EventArgs e)
    {
      if (sLastServer != this.cb_ServerName.Text || bQueryDatabases )
      {
        cb_DatabaseName.Items.Clear() ;
        cb_DatabaseName.Text = "" ;     // Erase Current Selection

        try
        {
          ArrayList dbnames = SqlUtilities.GetDatabaseList (this.Server_Name,
            this.Integrated_Security, this.User_Name, this.Pass_Word) ;

          foreach (String dbname in dbnames)
          {
            cb_DatabaseName.Items.Add (dbname ) ;
          }
          bQueryDatabases = false ;     // Try to avoid add'l messages until a change is made
          sLastServer = this.cb_ServerName.Text ;
          cb_DatabaseName.SelectedIndex = 0 ;     // Default to the First Database
        }
        catch (Exception ex)
        {
          // Try to avoid add'l messages until a change is made.  NOTE: 
          // Putting this in a finally block doesn't work because the event is refired
          // before the finally block is executed.
          bQueryDatabases = false ;
          sLastServer = this.cb_ServerName.Text ;
          MessageBox.Show (ex.Message, "Error Retrieving Database Names") ;
        }
      }
    }

    /// <summary>
    /// Gets or Sets the Server name
    /// </summary>
    public String Server_Name
    {
      get
      {
        return this.cb_ServerName.Text;
      }
      set
      {
        this.cb_ServerName.Text = value ;
        bQueryDatabases = true ;
      }
    }

    /// <summary>
    /// Gets or Sets the Database name
    /// </summary>
    public String Database_Name
    {
      get
      {
        return this.cb_DatabaseName.Text;
      }
      set
      {
        this.cb_DatabaseName.Text = value ;
      }
    }

    /// <summary>
    /// Gets or Sets the Database User name
    /// </summary>
    public String User_Name
    {
      get
      {
        return this.txt_UserName.Text;
      }
      set
      {
        this.txt_UserName.Text = value ;
        bQueryDatabases = true ;
      }
    }

    /// <summary>
    /// Gets or Sets the Database User Password
    /// </summary>
    public String Pass_Word
    {
      get
      {
        return this.txt_PassWord.Text;
      }
      set
      {
        this.txt_PassWord.Text = value ;
        bQueryDatabases = true ;
      }
    }

    /// <summary>
    /// Gets or Sets the whether to use Integrated Security
    /// </summary>
    public bool Integrated_Security
    {
      get
      {
        return this.chk_IntegratedSecurity.Checked ;
      }
      set
      {
        this.chk_IntegratedSecurity.Checked = value ;
        bQueryDatabases = true ;
      }
    }

    /// <summary>
    /// Gets the Database Connection String
    /// </summary>
    public String Connection_String
    {
      get
      {
        return SqlUtilities.BuildConnectString (
          this.Server_Name, this.Database_Name, 
          this.User_Name, this.Pass_Word, this.Integrated_Security) ;
      }
    }

    /// <summary>
    /// Gets or Sets the Label on the Connection Group Box
    /// </summary>
    public String Connection_Label
    {
      get
      {
        return this.grp_ConnectionName.Text;
      }
      set
      {
        this.grp_ConnectionName.Text = value ;
      }
    }

	}
}
