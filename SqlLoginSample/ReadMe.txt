This sample code contains a reusable control that allows you to build a dialog
box that queries for SQL-Server connection parameters.

The SqlLoginSample project contains a single form (TestForm) that has two controls on
it - the SqlLogin Control and a command button.  The command button retrieves the
connection string from the SqlLogin Control and displays the connect string and then
connects to the database.

The SqlLogin Control:
--------------------------------------
Properties:

Server_Name
Database_Name
User_Name
Pass_Word
Integrated_Security
Connection_String (get only)
Connection_Label	Controls the Label on the Group Box

The reason I created this utility is there is no way in .NET to populate a list
of SQL-Server servers, nor is there a built-in mechanism for getting a list of
all the databases available on a given server.  Therefore I used SQLDMO to provide
these functions.  A project you create that uses the SqlLogin control must
reference the SQLDMO COM control (Add Reference, COM tab, Microsoft SQLDMO Object Library).

