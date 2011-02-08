/**
*  Copyright(C) 2010
*  All Rights Reserved. Luis De Moraes, Ryan Jones, Eric Olazaba, Moises Cruz
*
*  Permission to use, copy, modify, and distribute this
*  software and its documentation for EDUCATIONAL purposes
*  and without fee is hereby granted provided that this
*  copyright notice appears in all copies.
*
*  @date   : December 3rd, 2010.
*  @author : Luis de Moraes.
*/


using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

using DbOperations;
using InOut;

namespace MySqlScriptExecution
{
  public class MySqlScriptExecution00
  {
    protected static MySqlConnection connectToMySqlDb = null;

    protected static DbConnect dbC = null;

    protected static DbTable dbT = null;

    protected static TextIO tIO = new TextIO();

    protected static string outText = null;

    public static void Main(string[] args)
    {
      do
      {
        try
        {
          string dbFilename = tIO.GetString("dbFilename");

          List<string> connectionStringData = tIO.GetData(dbFilename);

          outText = "\\\\" + connectionStringData[0] +
                    "\\"   + connectionStringData[1] +
                    " database...";

          dbC = new DbConnect(connectionStringData);

          if (dbC.Connect())
          {
            Console.WriteLine();
            Console.WriteLine("Connected to " + outText);
            Console.WriteLine();

            connectToMySqlDb = dbC.GetConnection();

            dbT = new DbTable(connectToMySqlDb);

            string inputFilename = tIO.GetString("query");
            string query = tIO.GetSqlScript(inputFilename);

            Console.WriteLine();

            int matchesQueryOrUpdate = dbT.PatternMatch(query);

            switch (matchesQueryOrUpdate)
            {
              case 0: if (dbT.GetQueryResults(query))
                Console.WriteLine();
                break;

              case 1: if (dbT.SetStatement(query))
                Console.WriteLine("Table is set for : " + outText);
                break;
            }

            Console.WriteLine();

            if (dbC.Disconnect())
            Console.WriteLine("Disconnected from " + outText);
          }
          else
          {
            Console.WriteLine("Could not connect to " + outText);
          }
        }
        catch (IOException ioe)
        {
          Console.WriteLine();
          Console.WriteLine("Error accessing " + outText);
          Console.WriteLine(ioe.Message);
          Console.WriteLine();
        }
        catch (MySqlException sqle)
        {
          Console.WriteLine();
          Console.WriteLine("Error accessing " + outText);
          Console.WriteLine(sqle.Message);
          Console.WriteLine();
        }
      }
      while (tIO.GetChar("Yes|No") == 'Y');
    }
  }
}