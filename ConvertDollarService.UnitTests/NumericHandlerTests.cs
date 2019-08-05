using NUnit.Framework;
using ConvertDollarService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertDollarService.UnitTests
{
    [TestFixture()]
    public class NumericHandlerTests
    {
        [Test()]
        [TestCaseSource(typeof(NumericHundredTestData), "GetDollarsTestCases")]
        public void NumericHandlerTest(double testValue, string expectedValue)
        {
            var numericHandler = new NumericHandler();


            //expected
            var actualValue = numericHandler.GetDollarsText(testValue);
            Assert.AreEqual(expectedValue, actualValue);

        }












    }
}