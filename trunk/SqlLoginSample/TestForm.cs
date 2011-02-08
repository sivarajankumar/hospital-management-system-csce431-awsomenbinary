using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient ;

namespace SqlLoginSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private SqlUtility.SqlLogin sqlLogin1;
		private System.Windows.Forms.Button btn_OK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlLogin1 = new SqlUtility.SqlLogin();
			this.btn_OK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// sqlLogin1
			// 
			this.sqlLogin1.Connection_Label = "Database Connection";
			this.sqlLogin1.Database_Name = "";
			this.sqlLogin1.Integrated_Security = true;
			this.sqlLogin1.Location = new System.Drawing.Point(8, 8);
			this.sqlLogin1.Name = "sqlLogin1";
			this.sqlLogin1.Pass_Word = "";
			this.sqlLogin1.Server_Name = "PERSIUS";
			this.sqlLogin1.Size = new System.Drawing.Size(440, 152);
			this.sqlLogin1.TabIndex = 0;
			this.sqlLogin1.User_Name = "sa";
			// 
			// btn_OK
			// 
			this.btn_OK.Location = new System.Drawing.Point(176, 168);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.TabIndex = 1;
			this.btn_OK.Text = "OK";
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 205);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.btn_OK,
																																	this.sqlLogin1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			String s ;
			s = this.sqlLogin1.Connection_String ;
			MessageBox.Show (s) ;
			SqlConnection cn = new SqlConnection(s) ;
			cn.Open() ;
			cn.Close() ;
		}
	}
}
