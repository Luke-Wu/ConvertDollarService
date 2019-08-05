using NUnit.Framework;
using System.Collections;


namespace ConvertDollarService.UnitTests
{
    public class StringToolsTestData
    {
        public static IEnumerable LeftTestCases
        {
            get
            {
                yield return new TestCaseData("123", 3).Returns("123");
                yield return new TestCaseData("145.21", 1).Returns("1");
                yield return new TestCaseData("234",0).Returns("");
                yield return new TestCaseData("2005",3).Returns("200");
                yield return new TestCaseData("179", -2).Returns("179");
                yield return new TestCaseData("842", 4).Returns("842");

            }

        }


        public static IEnumerable RightTestCases
        {
            get
            {
                yield return new TestCaseData("123", 3).Returns("123");
                yield return new TestCaseData("145.21", 1).Returns("1");
                yield return new TestCaseData("234", 0).Returns("");
                yield return new TestCaseData("2005", 3).Returns("005");
                yield return new TestCaseData("179", -2).Returns("179");
                yield return new TestCaseData("842", 4).Returns("842");

            }

        }

    }
}
