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
using System.Data;
using MySql.Data.MySqlClient;

namespace DbOperations
{
  public class DbTable : IDbTable
  {

    private MySqlConnection connection;
    private MySqlDataReader dataReader;
    private MySqlCommand command;

    public DbTable(MySqlConnection connection)
    {
      this.connection = connection;
      this.command = this.connection.CreateCommand();
    }

    public bool SetStatement(string statement)
    {
      command.CommandText = statement;
      command.ExecuteNonQuery();
      return true;
    }

    public MySqlDataReader GetStatement(string query)
    {
      command.CommandText = query;
      dataReader = command.ExecuteReader(); // MySqlDataReader must be closed eventually
      return dataReader;
    }

    private List<string> GetTableNames() // nested version, used by internal functions
    {
      List<string> tableNames = new List<string>();

      DataTable table = dataReader.GetSchemaTable();

      foreach (DataRow row in table.Rows)
      {
        string tableName = (string)row["BaseTableName"];
        if (!tableNames.Contains(tableName))
          tableNames.Add(tableName);
      }

      return tableNames;
    }

    public List<string> GetTableNames(string query) // no regard for nesting
    {
      List<string> tableNames = new List<string>();

      using (MySqlDataReader data = this.GetStatement(query))
      {
        DataTable table = dataReader.GetSchemaTable();

        foreach (DataRow row in table.Rows)
        {
          string tableName = (string)row["BaseTableName"];
          if (!tableNames.Contains(tableName))
            tableNames.Add(tableName);
        }
      }

      return tableNames;
    }

    private List<string> GetColumnNames() // nested version, used by internal functions
    {
      List<string> columns = new List<string>();

      for (int i = 0; i < dataReader.FieldCount; i++)
        columns.Add(dataReader.GetName(i));

      return columns;
    }

    public List<string> GetColumnNames(string query) // no regard for nesting
    {
      List<string> columns = new List<string>();

      using (MySqlDataReader data = this.GetStatement(query))
      {
        for (int i = 0; i < data.FieldCount; i++)
          columns.Add(data.GetName(i));
      }

      return columns;
    }

    public void TablesByColumns(ICollection<string> tables)
    {
      Console.Write("Tables :");

      foreach (string tableName in tables)
      {
        Console.WriteLine(tableName + " -");

        string query = "SELECT * FROM " + tableName;

        List<string> columns = this.GetColumnNames(query);

        foreach (string columnName in columns)
        {
          Console.WriteLine("\t" + columnName);
        }
      }

      Console.WriteLine();
    }

    public bool GetQueryResults(string query)
    {
      using (MySqlDataReader data = this.GetStatement(query))
      {
        List<string> columnNames = this.GetColumnNames(); // nested version (uses same query/reader)

        foreach (string columnName in columnNames)
        Console.Write("{0,-16}", columnName);
        Console.WriteLine();
        Console.WriteLine();

        while (data.Read())
        {
          for (int i = 0; i < data.FieldCount; i++)
          Console.Write("{0,-16}", data.GetString(i));
          Console.WriteLine();
        }
      }

      return true;
    }

    public int PatternMatch(string sequence)
    {
      string[] patterns = { "INSERT", "UPDATE", "DELETE" };

      int position = 0;

      foreach (string pattern in patterns)
      {
        if (sequence.IndexOf(pattern) >= 0)
        {
          position = 1;
          break;
        }
      }

      return position;
    }

  }
}