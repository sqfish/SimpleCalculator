using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class ConstantTest
    {
        [TestMethod]
        public void EnsureICanCreateAnInstance()
        {
            Constant aConstantGroup = new Constant("b = 1");
            Assert.IsNotNull(aConstantGroup);
        }

        [TestMethod]
        public void EnsureICanUseALowerCaseLetterAsKey()
        {
            string input = "a = 5";
            Constant aConstantGroup = new Constant(input);
            Assert.IsNotNull(aConstantGroup["a"]);
        }

        [TestMethod]
        public void EnsureKeyPointsToValue()
        {
            string input = "a = 5";
            Constant aConstantGroup = new Constant(input);
            var expected = "5";
            var actual = aConstantGroup["a"];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnsureConstantKeysAreCaseInsensitive()
        {
            string input = "A = 51";
            Constant aConstantGroup = new Constant(input);
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
            Constant aConstantGroup = new Constant(input);
            aConstantGroup["x"] = "5";
        }
    }
}
