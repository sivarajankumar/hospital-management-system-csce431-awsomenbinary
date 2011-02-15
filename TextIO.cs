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

namespace InOut
{
  public class TextIO : ITextIO
  {
    public TextIO() { }

    public char GetChar(string message)
    {
      Console.Write("\n-> " + message + " : ");
      string c = Console.ReadLine().ToUpper();
      return c.Trim().ToCharArray()[0];
    }

    public string GetString(string message)
    {
      Console.Write("\n-> " + message + " : ");

      return Console.ReadLine();
    }

    public string GetPassword(string message) // no backspace function as of yet
    {
      Console.Write("\n-> " + message + " : ");
      string password = "";
      ConsoleKeyInfo nextKey;
      do {
        nextKey = Console.ReadKey(true);
        password = password + nextKey.KeyChar;
      } while(nextKey.Key != ConsoleKey.Enter);

      Console.WriteLine();

      return password;
    }

    public List<string> GetData(string fileName)
    {
      List<string> data = new List<string>();

      using (StreamReader sr = File.OpenText(fileName))
      {
        while (!sr.EndOfStream)
        data.Add(sr.ReadLine());
      }

      return data;
    }

    public string GetSqlScript(string fileName)
    {
      string script = "";

      using (StreamReader sr = File.OpenText(fileName))
      {
        while (!sr.EndOfStream)
        script += sr.ReadLine() + " ";
      }

      return script;
    }
  }
}
