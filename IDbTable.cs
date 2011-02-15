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

namespace DbOperations
{
  interface IDbTable
  {
    bool SetStatement(string statement);

    SqlDataReader GetStatement(string query);

    List<string> GetTableNames(string query);

    List<string> GetColumnNames(string query);

    void TablesByColumns(ICollection<string> tables);

    bool GetQueryResults(string query);

    int PatternMatch(string sequence);
  }
}