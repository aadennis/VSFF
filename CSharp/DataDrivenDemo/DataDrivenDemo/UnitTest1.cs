using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using DemoUnderTest;
using System;

namespace DataDrivenDemo
{
    [TestClass]
    public class CalculatorTest 
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV","|DataDirectory|\\data.csv","data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv")]
        public void Adding2IntegersReturnsTheSum()
        {
            //var firstNumber = 22;
            //var secondNumber = 33;
            //var expectedResult = 5564;
            //var firstNumber = 22;
            //var secondString = TestContext.DataRow["Num2"].ToString();
            //var x = TestContext;

            var firstNumber = Int32.Parse(TestContext.DataRow["Num1"].ToString());
            var secondNumber = Int32.Parse(TestContext.DataRow["Num2"].ToString());
            var expectedResult = Int32.Parse(TestContext.DataRow["Sum"].ToString()); ;
            var actualResult = Calculator.Add(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
//[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
