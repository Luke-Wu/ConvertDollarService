using NUnit.Framework;
using System.Collections;

namespace ConvertDollarService.UnitTests
{
    public class NumericHundredTestData
    {
        public static IEnumerable GetDollarsTestCases
        {
            get
            {
                yield return new TestCaseData(123, "ONE HUNDRED  AND TWENTY-THREE DOLLARS");
                yield return new TestCaseData(1, "ONE DOLLAR");
                yield return new TestCaseData(11005.23, "ELEVEN THOUSAND  AND FIVE DOLLARS AND TWENTY-THREE CENTS");
                yield return new TestCaseData(92.25, "NINETY-TWO DOLLARS AND TWENTY-FIVE CENTS");
                yield return new TestCaseData(9212568749351.25, null);
                yield return new TestCaseData(0.23, "TWENTY-THREE CENTS");
                yield return new TestCaseData(30, "THIRTY");
                yield return new TestCaseData(500, "FIVE HUNDRED");
                yield return new TestCaseData(1.1, "ONE DOLLAR AND TEN CENTS");
                yield return new TestCaseData(1.01, "ONE DOLLAR AND ONE CENT");
                yield return new TestCaseData(0.01, "ONE AND CENT");
                yield return new TestCaseData(5.01, "FIVE DOLLARS AND ONE CENT");



            }

        }






    }
}
