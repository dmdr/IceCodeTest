namespace TestIceCodeTest;
using IceCodeTest;

[TestClass]
public class UnitTestIceFunctions
{
    [TestMethod]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polly", 0)]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Kettle", 14)]
    public void TestMethodIceFirstIndexOf(string testString, string testSubString, int expectedResult)
    {
        var iTextMatch = new IceTextMatch();
        var actVal = iTextMatch.FirstIndexOf(testString, testSubString);
        Assert.AreEqual(expectedResult, actVal);
    }

    [TestMethod]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polly", 0, 0)]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Kettle", 0, 14)]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Kettle", 19, 39)]
    public void TestMethodIceFirstIndexOfWithStart(string testString, string testSubString, int startPos, int expectedResult)
    {
        var iTextMatch = new IceTextMatch();
        var actVal = iTextMatch.FirstIndexOf(testString, testSubString, startPos);
        Assert.AreEqual(expectedResult, actVal);
    }

    [TestMethod]
    [DataRow("Polly1Polly2Polly3", 6, "Polly2Polly3")]
    [DataRow("Dolly and Molly and Polly and Lolly", 20, "Polly and Lolly")]
    public void TestMethodIceFirstSubString(string testString, int startPos, string expectedResults)
    {
        var iTextMatch = new IceTextMatch();
        var actVal = iTextMatch.SubString(testString, startPos);
        Assert.AreEqual(expectedResults, actVal);
    }

    [TestMethod]
    [DataRow("Polly1Polly2Polly3", 6, 6, "Polly2")]
    [DataRow("Polly1Polly2Polly3", 6, 5, "Polly")]
    [DataRow("Dolly and Molly and Polly and Lolly", 10, 15, "Molly and Polly")]
    [DataRow("Polly1Polly2Polly3", 6, 7, "Polly2P")]
    public void TestMethodIceFirstSubStringWithEndPos(string testString, int startPos, int subStrLen, string expectedResults)
    {
        var iTextMatch = new IceTextMatch();
        var actVal = iTextMatch.SubString(testString, startPos, subStrLen);
        Assert.AreEqual(expectedResults, actVal);
    }

    [TestMethod]
    [DataRow("Pol", "Pol", "1")]
    [DataRow("Polly1Polly2Polly3", "", "<no matches>")]
    [DataRow("Polly1Polly2Polly3", "Polly", "1, 7, 13")]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "put", "7, 32, 57")]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "1")]
    // Code Test Examples
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polly", "1, 26, 51")]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "polly", "1, 26, 51")]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "ll", "3, 28, 53, 78, 82")]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Ll", "3, 28, 53, 78, 82")]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "X", "<no matches>")]
    [DataRow("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polx", "<no matches>")]
    public void TestMethodIceIndexOfAll(string testString, string testSubString, string expectedResults)
    {
        var iTextMatch = new IceTextMatch();
        var actVal = iTextMatch.IndexOfAll(testString, testSubString);

        Assert.AreEqual(expectedResults, actVal);
    }

}