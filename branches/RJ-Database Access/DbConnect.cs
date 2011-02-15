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
  public class DbConnect : IDbConnect
  {
    private string server   = "database2.cse.tamu.edu";

    private string database = "jonesy57-Bank";

    private string username = "jonesy57";

    private string password = "sammy";

    private string connectionString = "";

    protected MySqlConnection connection;

    public DbConnect()
    {
      connection = new MySqlConnection();
    }

    public DbConnect(string server,
                     string database)
    {
      connection = new MySqlConnection();
      this.server   = server;
      this.database = database;
    }

    public DbConnect(string server,
                     string database,
                     string username,
                     string password)
    {
      connection = new MySqlConnection();
      this.server   = server;
      this.database = database;
      this.username = username;
      this.password = password;
    }

    public DbConnect(List<string> connectionStringData)
    {
      connection = new MySqlConnection();
      this.server   = connectionStringData[0];
      this.database = connectionStringData[1];
      this.username = connectionStringData[2];
      this.password = connectionStringData[3];
    }

    public bool Connect()
    {
      connectionString = "Server="    + this.server   +
                         ";Database=" + this.database +
                         ";Uid="      + this.username +
                         ";Pwd="      + this.password;

      connection.ConnectionString = this.connectionString;
      connection.Open();

      if (connection.State == ConnectionState.Closed)
      return false;

      return true;
    }

    public bool Connect(string username,
                        string password)
    {
      this.username = username;
      this.password = password;

      connectionString = "Server="    + this.server   +
                         ";Database=" + this.database +
                         ";Uid="      + this.username +
                         ";Pwd="      + this.password;

      connection.ConnectionString = this.connectionString;
      connection.Open();

      if (connection.State == ConnectionState.Closed)
      return false;

      return true;
    }

    public bool Disconnect()
    {
      connection.Close();
      return true;
    }

    public MySqlConnection GetConnection()
    {
      return this.connection;
    }

  }
}