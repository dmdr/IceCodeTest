// See https://aka.ms/new-console-template for more information

//using System.Diagnostics.Contracts;

namespace IceCodeTest
{
  public class IceCodeTestProject
  {


    public static void Main(string[] args)
    {
        Console.WriteLine("ICE Code Test");

        // var iStr = new IceString();
        // string testStr = "Testing123";
        // Console.WriteLine($"Index of 'Test' in ${testStr} is: {iStr.FirstIndexOf(testStr, "Test")}");

        string searchText = "";
        string testString = "";
        string testFileName = "";

        var iStr = new IceString();
        string actVal = "";

        if(args.Length > 0)
        {
          // dotnet run "-f search.txt" will use details in search.txt (first line is the subStr and remained is the texr to search)
          var inputType = args[0];
          if(inputType.Length > 1 && inputType[0] == '-')
          {
            switch(inputType[1])
            {
              case 'f':
                testFileName = iStr.SubString(inputType, 2).Trim();
                if(!ReadFromFile(testFileName, ref searchText, ref testString))
                {
                  searchText = "";
                  testString = "";
                }
                break;
            }
          }
        }
        // "dotnet run" will use this details values
        if(testString.Length > 0)
        {
          Console.WriteLine($"Running test from file {testFileName}:\n");

          // var watch = System.Diagnostics.Stopwatch.StartNew();
          actVal = iStr.IndexOfAll(testString, searchText);
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

          foreach(var thisSubStr in subStrTests) 
          {
            actVal = iStr.IndexOfAll(testString, thisSubStr);
            Console.WriteLine($"Subtext: {thisSubStr}\nOutput: {actVal}\n");
          }
        }

    }

    private static bool ReadFromFile(string filePathName, ref string searchText, ref string testString)
    { 
      Console.WriteLine($"FileName: {filePathName}");
      if(File.Exists(filePathName))
      {
        var lines = File.ReadAllLines(filePathName);
        if(lines.Length > 2)
        {
          searchText = lines[0];
          testString = string.Join("",lines.Skip(1).ToArray());
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

/*
Output after running application (from the IceCodeTest sub-folder)
Running:
dotnet run

-- Output
ICE Code Test
Runing default tests:

Subtext: Polly
Output: 1, 26, 51

Subtext: polly
Output: 1, 26, 51

Subtext: ll
Output: 3, 28, 53, 78, 82

Subtext: Ll
Output: 3, 28, 53, 78, 82

Subtext: X
Output: <no matches>

Subtext: Polx
Output: <no matches>
-------------------


Run tking input from a text file (see search.txt)
Where the first line is the subtext to search for (Polly for example), and the rest of the file is input text

To run (using search.txt): 
[dotnet run "-f search.txt"]


Test Harness:
to Run uses using the MSTest test harness, 
(From the root folder where the IceCodeTestSolution.sln file is located) 
run:
[dotnet test]

Sample output:
Passed!  - Failed:     0, Passed:    19, Skipped:     0, Total:    19, Duration: 90 ms - TestIceCodeTest.dll (net7.0)

*/
