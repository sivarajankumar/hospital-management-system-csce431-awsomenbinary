using System;
using System.Collections ;
using System.Text ;

namespace SqlUtility
{
	/// <summary>
	/// Summary description for SqlUtility.
	/// </summary>
	public class SqlUtilities
	{
		public SqlUtilities()
		{
		}

    /// <summary>
    /// This function Queries the Network and builds a list of Available SQL-Server
    /// servers and returns them
    /// </summary>
    /// <returns>ArrayList containing String names of the Available Servers</returns>
    public static ArrayList GetServerList()
    {
      ArrayList ServerList = new ArrayList() ;
      SQLDMO.Application oSQLServerDMOApp = new SQLDMO.Application();
      SQLDMO.NameList oNameList;
      oNameList=oSQLServerDMOApp.ListAvailableSQLServers();
      foreach ( object svrname in oNameList)
      {
        String sSvrName = svrname.ToString();
        if (sSvrName == "(local)")
        {
          // Stupid SQL-Server...Uses (local) instead of localhost.
          sSvrName = "localhost" ;
        }
        ServerList.Add ( sSvrName ) ;
      }
      return ServerList ;
    }

    /// <summary>
    /// This function returns the list of available databases in an ArrayList.
    /// An exception is thrown if there is a problem connecting to the server
    /// </summary>
    /// <param name="sServerName">The servername from which to lookup database names</param>
    /// <param name="bIntegratedSecurity">true to use integrated security</param>
    /// <param name="sUserName">The database user name, ignored when using integrated security</param>
    /// <param name="sPassword">The password for the user, ignored when using integrated security</param>
    public static ArrayList GetDatabaseList ( String sServerName, 
      bool bIntegratedSecurity, String sUserName, String sPassword)
    {
      ArrayList DatabaseList = new ArrayList() ;
      SQLDMO.SQLServer srv = new SQLDMO.SQLServerClass();                 
      try
      {
        srv.LoginSecure = bIntegratedSecurity ;
        srv.Connect(sServerName,sUserName,sPassword); 
      
        foreach(SQLDMO.Database db in srv.Databases) 
        { 
          if(db.Name!=null)
          {
            DatabaseList.Add (db.Name) ;
          }
        }
      }
      finally
      {
        if (srv.ConnectionID > 0)
        {
          srv.DisConnect();
        }
      }
      return DatabaseList ;
    }

    /// <summary>
    /// Builds a SQL-Server Connection String based on the passed parameters
    /// </summary>
    /// <param name="sServerName">The Server containing the SQL-Server instance</param>
    /// <param name="sDatabaseName">The name of the database</param>
    /// <param name="sUserName">The Connection Username.  Ignored if bIntegratedSecurity is true.</param>
    /// <param name="sPassword">The Connnection Password.  Ignored if bIntegratedSecurity is true</param>
    /// <param name="bIntegratedSecurity">When true, uses SQL-Server integrated security.</param>
    /// <returns>A constructed SQL-Server connection string.</returns>
    public static String BuildConnectString (
      String sServerName, String sDatabaseName,
      String sUserName, String sPassword, bool bIntegratedSecurity )
    {
      StringBuilder sConnect = new StringBuilder() ;
      sConnect.Append ("data source=") ;
      sConnect.Append (sServerName) ; 
      sConnect.Append (";initial catalog=") ;
      sConnect.Append (sDatabaseName) ;
      if (bIntegratedSecurity)
      {
        sConnect.Append (";Integrated Security=SSPI" ) ;
      }
      else
      {
        sConnect.Append (";user id=" ) ;
        sConnect.Append (sUserName) ;
        sConnect.Append (";password=") ;
        sConnect.Append (sPassword) ;
      }
      return sConnect.ToString() ;
    }


	}
}
