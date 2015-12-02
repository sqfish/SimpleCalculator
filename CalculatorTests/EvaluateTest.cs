using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class EvaluateTest
    {
        private Evaluate anEvaluate;
        [TestInitialize]
        public void Initialize()
        {
            anEvaluate = new Evaluate();
        }

        [TestCleanup]
        public void Cleanup()
        {
            anEvaluate = null;
        }

        [TestMethod]
        public void EnsureICanCreateAnInstance()
        {
            Assert.IsNotNull(anEvaluate);
        }

        [TestMethod]
        public void EnsureValidInputThrowsNoError()
        {
            anEvaluate.Input("1 + 8");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void EnsureInvalidInputThrowsAnError()
        {
            anEvaluate.Input("1 + - 8");
        }

        [TestMethod]
        public void EnsureICanAdd()
        {
            anEvaluate.Input("1 + -8");
            Assert.AreEqual("-7", anEvaluate.Result);
        }

        [TestMethod]
        public void EnsureICanSubtract()
        {
            anEvaluate.Input("1 - -8");
            Assert.AreEqual("9", anEvaluate.Result);
        }

        [TestMethod]
        public void EnsureICanMultiply()
        {
            anEvaluate.Input("1 * -8");
            Assert.AreEqual("-8", anEvaluate.Result);
        }

        [TestMethod]
        public void EnsureICanDivide()
        {
            anEvaluate.Input("-16 / 8");
            Assert.AreEqual("-2", anEvaluate.Result);
        }
    }
}
