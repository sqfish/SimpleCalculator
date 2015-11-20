using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class EvaluateTest
    {
        [TestMethod]
        public void EnsureICanCreateAnInstance()
        {
            Evaluate anEvaluate = new Evaluate("1 + 1");
            Assert.IsNotNull(anEvaluate);
        }

        [TestMethod]
        public void EnsureValidInputThrowsNoError()
        {
            Evaluate anEvaluate = new Evaluate("1 + 8");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void EnsureInvalidInputThrowsAnError()
        {
            Evaluate anEvaluate = new Evaluate("1 + - 8");
        }

        [TestMethod]
        public void EnsureICanAdd()
        {
            Evaluate anEvaluate = new Evaluate("1 + -8");
            Assert.AreEqual("-7", anEvaluate.Result);
        }

        [TestMethod]
        public void EnsureICanSubtract()
        {
            Evaluate anEvaluate = new Evaluate("1 - -8");
            Assert.AreEqual("9", anEvaluate.Result);
        }

        [TestMethod]
        public void EnsureICanMultiply()
        {
            Evaluate anEvaluate = new Evaluate("1 * -8");
            Assert.AreEqual("-8", anEvaluate.Result);
        }

        [TestMethod]
        public void EnsureICanDivide()
        {
            Evaluate anEvaluate = new Evaluate("-16 / 8");
            Assert.AreEqual("-2", anEvaluate.Result);
        }
    }
}
