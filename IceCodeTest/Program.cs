// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Contracts;

namespace IceCodeTest
{
  public class IceCodeTestProject
  {


    public static void Main(string[] args)
    {
        Console.WriteLine("IceCodeTest, Hello World!");

        // var iStr = new IceString();
        // string testStr = "Testing123";
        // Console.WriteLine($"Index of 'Test' in ${testStr} is: {iStr.FirstIndexOf(testStr, "Test")}");

        string searchText = "";
        string testString = "";

        var iStr = new IceString();

        if(args.Length > 0)
        {
          // dotnet run "-f search.txt" will use details in search.txt (first line is the subStr and remained is the texr to search)
          var inputType = args[0];
          if(inputType.Length > 1 && inputType[0] == '-')
          {
            switch(inputType[1])
            {
              case 'f':
                if(!ReadFromFile(iStr.SubString(inputType, 2).Trim(), ref searchText, ref testString))
                {
                  searchText = "";
                  testString = "";
                }
                break;
            }
          }
        }
        // "dotnet run" will use this details values
        if(testString.Length == 0)
        {
          searchText = "Polly";
          testString = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";
        }

        var watch = System.Diagnostics.Stopwatch.StartNew();
        var actVal = iStr.IndexOfAll(testString, searchText);
        watch.Stop();
        Console.WriteLine($"Time(ms): {watch.ElapsedMilliseconds}");
        Console.WriteLine($"results: {actVal}");
    }

    private static bool ReadFromFile(string filePathName, ref string searchText, ref string testString)
    { 
      Console.WriteLine($"FileName: {filePathName}");
      if(File.Exists(filePathName))
      {
        Console.WriteLine($"File found: {filePathName}");
        var lines = File.ReadAllLines(filePathName);
        if(lines.Length > 2)
        {
          searchText = lines[0];
          testString = string.Join("",lines.Skip(1).ToArray());
          Console.WriteLine($"File read searchText: {searchText}");
          //Console.WriteLine($"File read testString: {testString}");
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

