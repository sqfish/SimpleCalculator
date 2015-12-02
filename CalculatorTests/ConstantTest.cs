using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System.Collections.Generic;

namespace CalculatorTests
{
    [TestClass]
    public class ConstantTest
    {
        private Constant aConstantGroup;
        [TestInitialize]
        public void Initialize()
        {
            aConstantGroup = new Constant();
        }

        [TestCleanup]
        public void CleanUp()
        {
            aConstantGroup = null;
        }

        [TestMethod]
        public void EnsureICanCreateAnInstance()
        {
            Assert.IsNotNull(aConstantGroup);
        }

        [TestMethod]
        public void EnsureICanUseALowerCaseLetterAsKey()
        {
            string input = "a = 5";
            aConstantGroup.StoreConstant(input);
            Assert.IsNotNull(aConstantGroup["a"]);
        }

        [TestMethod]
        public void EnsureKeyPointsToValue()
        {
            string input = "a = 5";
            aConstantGroup.StoreConstant(input);
            var expected = "5";
            var actual = aConstantGroup["a"];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnsureConstantKeysAreCaseInsensitive()
        {
            string input = "A = 51";
            aConstantGroup.StoreConstant(input);
            var expected = "51";
            var actual = aConstantGroup["a"];
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(aConstantGroup["A"], aConstantGroup["a"]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EnsureKeysCanOnlyBeDefinedOnce()
        {
            string input = "x = 12";
            aConstantGroup.StoreConstant(input);
            aConstantGroup["x"] = "5";
        }

    }

    [TestClass]
    public class ConstantAndEvaluateTest
    {
        private Evaluate anEvaluate;
        [TestInitialize]
        public void Initialize()
        {
            anEvaluate = new Evaluate();
        }

        [TestCleanup]
        public void CleanUp()
        {
            anEvaluate = null;
        }

        [TestMethod]
        public void EnsureEvaluateCanStoreANewInstanceOfConstantAndRetrieveAStoredValue()
        {
            string input = "x = 10";
            string expected = "10";
            anEvaluate.Input(input);
            string actual = anEvaluate.RetrieveConstant("x");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnsureICanUseDefinedConstantInMathCalculation()
        {
            string constant = "x = 10";
            string expression = "x + 5";
            anEvaluate.Input(constant);
            anEvaluate.Input(expression);
            string lastOutExpected = "15";
            string lastOutActual = anEvaluate.Result;
            Assert.AreEqual(lastOutExpected, lastOutActual);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void EnsureICannotUseUndefinedConstantInMathCalculation()
        {
            string expression = "a + 1";
            anEvaluate.Input(expression);
        }
    }
}
