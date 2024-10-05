// See https://aka.ms/new-console-template for more information

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

        var iStr = new IceString();
        // string testString = "Polly1Polly2Polly3";
        string testString = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";

        var actVal = iStr.IndexOfAll(testString, "Polly");
        Console.WriteLine(actVal);
    }
  }
}

