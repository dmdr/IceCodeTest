// See https://aka.ms/new-console-template for more information

//using System.Diagnostics.Contracts;

namespace IceCodeTest
{
  public class IceCodeTestProject
  {


    public static void Main(string[] args)
    {
      Console.WriteLine("ICE Code Test");

      string searchText = "";
      string testString = "";
      string testFileName = "";

      string actVal = "";

      if (args.Length > 0)
      {
        // dotnet run "-f search.txt" will use details in search.txt (first line is the subStr and remaining is the texr to search)
        var inputType = args[0];
        if (inputType.Length > 1)
        {
          var argsArr = IceTextMatch.Split(inputType);
          if (argsArr.Length > 1)
          {
            switch (argsArr[0])
            {
              case "-f":
                testFileName = argsArr[1];
                if (!ReadFromFile(testFileName, ref searchText, ref testString))
                {
                  searchText = "";
                  testString = "";
                }
                break;
            }
          }
        }
      }
      // "dotnet run" will use this details values
      if (testString.Length > 0)
      {
        Console.WriteLine($"Running test from file {testFileName}:\n");

        // var watch = System.Diagnostics.Stopwatch.StartNew();
        actVal = IceTextMatch.IndexOfAll(testString, searchText);
        // watch.Stop();
        // Console.WriteLine($"Time(ms): {watch.ElapsedMilliseconds}");
        Console.WriteLine($"Subtext: {searchText}\nOutput: {actVal}\n");
      }
      else
      {
        Console.WriteLine("Running default tests:\n");
        testString = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";
        string[] subStrTests = {
            "Polly",
            "polly",
            "ll",
            "Ll",
            "X",
            "Polx" };

        foreach (var thisSubStr in subStrTests)
        {
          actVal = IceTextMatch.IndexOfAll(testString, thisSubStr);
          Console.WriteLine($"Subtext: {thisSubStr}\nOutput: {actVal}\n");
        }
      }

    }

    private static bool ReadFromFile(string filePathName, ref string searchText, ref string testString)
    {
      Console.WriteLine($"FileName: {filePathName}");
      if (File.Exists(filePathName))
      {
        var lines = File.ReadAllLines(filePathName);
        if (lines.Length > 2)
        {
          searchText = lines[0];
          testString = string.Join("", lines.Skip(1).ToArray());
          Console.WriteLine($"Reading file {filePathName}, searchText: {searchText}");
          //Console.WriteLine($"teststring: {testString}");
          return true;
        }
      }
      else
      {
        Console.WriteLine($"File not found: {filePathName}");
      }
      return false;
    }

  }
}
