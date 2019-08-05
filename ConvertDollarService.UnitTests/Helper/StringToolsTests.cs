using NUnit.Framework;

namespace ConvertDollarService.UnitTests
{
    [TestFixture()]
    public class StringToolsTests
    {
        [Test()]
        [TestCaseSource(typeof(StringToolsTestData), "LeftTestCases")]
        public string LeftTest(string source, int len)
        {
            var actualResult = StringTools.Left(source, len);
            return actualResult;
        }

        [Test()]
        [TestCaseSource(typeof(StringToolsTestData), "RightTestCases")]
        public string RightTest(string source, int len)
        {
            var actualResult = StringTools.Right(source, len);
            return actualResult;
        }
    }
}